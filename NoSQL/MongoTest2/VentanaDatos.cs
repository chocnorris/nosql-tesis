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

namespace MongoTest2
{
    public partial class VentanaDatos : Form
    {
        MongoDatabase db;
        public VentanaDatos(MongoDatabase mdb)
        {
            db = mdb;
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
                db.GetCollection("authors").Insert(new { name = textBoxNombreAutor.Text });
                textBoxNombreAutor.Text = "";
                cargarAutores();
            }
        }

        private void cargarAutores()
        {
            comboBoxAutorThread.Items.Clear();
            comboBoxAutorThread.DisplayMember = "Text";
            comboBoxAutorThread.ValueMember = "Value";
            comboBoxAutorCom.Items.Clear();
            comboBoxAutorCom.DisplayMember = "Text";
            comboBoxAutorCom.ValueMember = "Value";
            MongoCursor<BsonDocument> autores = db.GetCollection("authors").FindAll();
            bool tieneAutores = autores.Count() > 0;
            foreach (var auth in autores)
            {
                comboBoxAutorCom.Items.Add(new ComboItem { Text = auth["name"], Value = auth["_id"] });
                comboBoxAutorThread.Items.Add(new ComboItem { Text = auth["name"], Value = auth["_id"] });
            }
            if (tieneAutores)
            {
                comboBoxAutorThread.SelectedIndex = 0;
                comboBoxAutorCom.SelectedIndex = 0;
            }
        }

        private void cargarThreads()
        {
            treeViewCom.Nodes.Clear();
            MongoCursor<BsonDocument> threads = db.GetCollection("threads").FindAll();
            bool tieneThreads = threads.Count() > 0;
            foreach (var th in threads)
            {
                TreeNode nodo = new TreeNode(th["title"] + "");
                //TreeNode nodo = new TreeNode(th["title"] + "", subComments(th["_id"] + "").ToArray());
                nodo.Tag = th["_id"].ToString();
                treeViewCom.Nodes.Add(nodo);
            }
        }
        //Metodo recursivo para levantar toda la estructura!! Not recommended
        private List<TreeNode> subComments(string parent)
        {
            List<TreeNode> hijos = new List<TreeNode>();
            MongoCursor<BsonDocument> comments = db.GetCollection("comments").Find(Query.EQ("parent_id", new BsonObjectId(new ObjectId(parent)))).SetLimit(10);
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

        private void buttonAgregarThread_Click(object sender, EventArgs e)
        {
            if (textBoxNombreThread.Text != "")
            {
                db.GetCollection("threads").Insert(
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
        }

        private void buttonAgregarCom_Click(object sender, EventArgs e)
        {
            if (textBoxCom.Text != "")
            {
                db.GetCollection("comments").Insert(
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
                foreach (BsonDocument com in db.GetCollection("comments").Find(Query.EQ("parent_id", new BsonObjectId(new ObjectId(treeViewCom.SelectedNode.Tag.ToString())))))
                {
                    TreeNode nodo = new TreeNode("Comentario: " + i);
                    i++;
                    nodo.Tag = com["_id"].ToString();
                    treeViewCom.SelectedNode.Nodes.Add(nodo);
                }
                treeViewCom.EndUpdate();
            }
            //Modificacion no recursiva
            BsonDocument comentario = db.GetCollection("comments").FindOne(Query.EQ("_id", new BsonObjectId(new ObjectId(treeViewCom.SelectedNode.Tag.ToString()))));
            if (comentario != null)
            {
                textBoxContCom.Text =
                    comentario["text"] + "";
            }
            else
            {
                BsonDocument thread = db.GetCollection("threads").FindOne(Query.EQ("_id", new BsonObjectId(new ObjectId(treeViewCom.SelectedNode.Tag.ToString()))));
                textBoxContCom.Text =
                    "[Thread] " + Environment.NewLine +
                    "Fecha: " + thread["date"].ToLocalTime().ToShortDateString() + Environment.NewLine +
                    "Título: " + thread["title"] + Environment.NewLine +
                    "Autor: " + thread["author"]["name"];
            }
        }

    }

    public class ComboItem
    {
        public BsonValue Text { get; set; }
        public BsonValue Value { get; set; }
        public override string ToString()
        {
            return Text+"";
        }
    }
}
