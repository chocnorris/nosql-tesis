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
using MongoTest2.Entidades;

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

        private void buttonAgregarAutor_Click(object sender, EventArgs e)
        {
            if (textBoxNombreAutor.Text != "")
            {
                try
                {                    
                    db.addAutor(new Autor() { Nombre = textBoxNombreAutor.Text });
                    textBoxNombreAutor.Text = "";
                    cargarAutores();
                }
                catch (System.IO.IOException DbException)
                {
                    MessageBox.Show(MSG_ERROR_DB,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }
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
                    comboBoxAutorCom.Items.Add(new ComboItem { Text = autor.Nombre, Value = (BsonValue)autor.AutorId.Value });
                    comboBoxAutorThread.Items.Add(new ComboItem { Text = autor.Nombre, Value = (BsonValue)autor.AutorId.Value });
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
                TreeNode nodo = new TreeNode(th.Titulo + "");
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

        private void buttonAgregarThread_Click(object sender, EventArgs e)
        {
            if (textBoxNombreThread.Text != "")
            {
                try
                {
                    dbmongo.GetCollection("threads").Insert(
                        new
                        {
                            title = textBoxNombreThread.Text,
                            author = new
                            {
                                name = ((ComboItem)comboBoxAutorThread.SelectedItem).Text,
                                id = ((ComboItem)comboBoxAutorThread.SelectedItem).Value
                            },
                            date = DateTime.Now
                        }
                    );
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
                dbmongo.GetCollection("comments").Insert(
                    new
                    {
                        text = textBoxCom.Text,
                        thread_id = new BsonObjectId(new ObjectId(threadRaiz(treeViewCom.SelectedNode).Tag.ToString())),
                        author = new
                        {
                            name = ((ComboItem)comboBoxAutorCom.SelectedItem).Text,
                            id = ((ComboItem)comboBoxAutorCom.SelectedItem).Value
                        },
                        date = DateTime.Now,
                        parent_id = new BsonObjectId(new ObjectId(treeViewCom.SelectedNode.Tag.ToString()))
                    }
                );
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
                foreach (BsonDocument com in dbmongo.GetCollection("comments").Find(Query.EQ("parent_id", new BsonObjectId(new ObjectId(treeViewCom.SelectedNode.Tag.ToString())))))
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
                    "Fecha: " + comentario["date"].ToLocalTime().ToShortDateString() + Environment.NewLine +
                    "Autor: " + comentario["author"]["name"] + Environment.NewLine +Environment.NewLine +
                    comentario["text"] ;
            }
            else
            {
                BsonDocument thread = dbmongo.GetCollection("threads").FindOne(Query.EQ("_id", new BsonObjectId(new ObjectId(treeViewCom.SelectedNode.Tag.ToString()))));
                textBoxContCom.Text =
                    "[Thread] " + Environment.NewLine +
                    "Fecha: " + thread["date"].ToLocalTime().ToShortDateString() + Environment.NewLine +
                    "Título: " + thread["title"] + Environment.NewLine +
                    "Autor: " + thread["author"]["name"];
            }
        }

    }
}
