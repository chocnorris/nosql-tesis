using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;
using MongoTest2.Servicios;
using MongoTest2.Modelo;

namespace MongoTest2
{
    public partial class VentanaDatos : Form
    {
        MongoDatabase dbmongo;
        IOperaciones db;

        const string MSG_ERROR_DB  = "Error accediendo a la base de datos, operación no realizada. Verifique la configuración.";

        public VentanaDatos(MongoDatabase mdb, IOperaciones db)
        {
            dbmongo = mdb;
            this.db = db;
            InitializeComponent();
        }

        private void VentanaDatos_Load(object sender, EventArgs e)
        {
            cargarAutores();
            cargarThreads();
        }

        private void cargarAutores()
        {
            comboBoxAutorThread.Items.Clear();
            comboBoxAutorCom.Items.Clear();

            var Autores = db.GetAutores();            
            foreach (var autor in Autores)
            {
                if (db.Identidad() == "MongoDB")
                {
                    comboBoxAutorCom.Items.Add(new ComboItem { Text = autor.Name, Value = (ObjectId)autor.Id });
                    comboBoxAutorThread.Items.Add(new ComboItem { Text = autor.Name, Value = (ObjectId)autor.Id });
                }
            }
            if (Autores.Count > 0)
            {
                comboBoxAutorThread.SelectedIndex = 0;
                comboBoxAutorCom.SelectedIndex = 0;
            }
        }

        private void cargarThreads()
        {
            treeViewCom.Nodes.Clear();           
            var Threads = db.GetThreads();            
            foreach (var th in Threads)
            {
                TreeNode nodo = new TreeNode(th.Title + "");
                //TreeNode nodo = new TreeNode(th["title"] + "", subComments(th["_id"] + "").ToArray());
                nodo.Tag = th.Id.ToString();
                treeViewCom.Nodes.Add(nodo);
            }
        }

        //Metodo recursivo para levantar toda la estructura!! Not recommended
        /*
        private List<TreeNode> subComments(string parent)
        {
            List<TreeNode> hijos = new List<TreeNode>();
            MongoCursor<BsonDocument> comments = dbmongo.GetCollection("comments").Find(Query.EQ("parent_id", new BsonObjectId(new ObjectId(parent)))).SetLimit(10);
            //textBoxCom.Text += parent+" "+comments.ToJson() + Environment.NewLine;
            int i = 1;
            foreach (var com in comments)
            {
                TreeNode nodo = new TreeNode("Comentario: "+i, subComments(com["_id"]+"").ToArray());
                i++;
                nodo.Tag = com["_id"].ToString();
                hijos.Add(nodo);
            }
            return hijos;
        }
         */
        private void buttonAgregarAutor_Click(object sender, EventArgs e)
        {
            if (textBoxNombreAutor.Text != "")
            {
                try
                {
                    db.addAutor(new Author() { Name = textBoxNombreAutor.Text });
                    textBoxNombreAutor.Text = "";
                    cargarAutores();
                }
                catch (System.IO.IOException DbException)
                {
                    MessageBox.Show(MSG_ERROR_DB, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonAgregarThread_Click(object sender, EventArgs e)
        {
            if (textBoxNombreThread.Text != "")
            {
                try
                {
                    db.addThread(new Thread()
                    {
                        Title = textBoxNombreThread.Text,
                        Author = new Author()
                        {
                            Name = ((ComboItem)comboBoxAutorThread.SelectedItem).Text.AsString,
                            Id = ((ComboItem)comboBoxAutorThread.SelectedItem).Value
                        },
                        Date = DateTime.Now
                    });
                    textBoxNombreThread.Text = "";
                    cargarThreads();
                }                                
                catch (System.IO.IOException DbException)
                {
                    MessageBox.Show(MSG_ERROR_DB, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonAgregarCom_Click(object sender, EventArgs e)
        {
            if (textBoxCom.Text != "")
            {
                db.addComentario(new Comment()
                {
                    Text = textBoxCom.Text,
                    Thread_id = threadRaiz(treeViewCom.SelectedNode).Tag.ToString(),
                    Author = new Author()
                    {
                        Name = ((ComboItem)comboBoxAutorCom.SelectedItem).Text.AsString,
                        Id = ((ComboItem)comboBoxAutorCom.SelectedItem).Value
                    },
                    Date = DateTime.Now,
                    Parent_id = treeViewCom.SelectedNode.Tag.ToString()

                });
                textBoxCom.Text = "";
                cargarThreads();
            }
        }

        private TreeNode threadRaiz(TreeNode node)
        {
            if (node.Parent != null)
                return threadRaiz(node.Parent);
            return node;
        }

        private void treeViewCom_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Modificacion no recursiva
            if (treeViewCom.SelectedNode.Nodes.Count == 0)
            {
                treeViewCom.BeginUpdate();
                int i = 1;
                foreach (BsonDocument com in dbmongo.GetCollection("comments").Find(Query.EQ("Parent_id", new BsonObjectId(new ObjectId(treeViewCom.SelectedNode.Tag.ToString())))))
                {
                    TreeNode nodo = new TreeNode("Comentario: " + i);
                    i++;
                    nodo.Tag = com["_id"].ToString();
                    treeViewCom.SelectedNode.Nodes.Add(nodo);
                }
                treeViewCom.EndUpdate();
            }
            //Modificacion no recursiva
            BsonDocument comentario = dbmongo.GetCollection("comments").FindOne(Query.EQ("_id", new BsonObjectId(new ObjectId(treeViewCom.SelectedNode.Tag.ToString()))));
            if (comentario != null)
            {
                textBoxContCom.Text =
                    "[Comentario] " + Environment.NewLine +
                    "Fecha: " + comentario["Date"].ToLocalTime().ToShortDateString() + Environment.NewLine +
                    "Autor: " + comentario["Author"]["Name"] + Environment.NewLine +Environment.NewLine +
                    comentario["Text"] ;
            }
            else
            {
                BsonDocument thread = dbmongo.GetCollection("threads").FindOne(Query.EQ("_id", new BsonObjectId(new ObjectId(treeViewCom.SelectedNode.Tag.ToString()))));
                textBoxContCom.Text =
                    "[Thread] " + Environment.NewLine +
                    "Fecha: " + thread["Date"].ToLocalTime().ToShortDateString() + Environment.NewLine +
                    "Título: " + thread["Title"] + Environment.NewLine +
                    "Autor: " + thread["Author"]["Name"];
            }
        }

    }
}
