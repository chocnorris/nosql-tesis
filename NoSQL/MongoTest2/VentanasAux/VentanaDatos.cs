using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NoSQL.Servicios;
using NoSQL.Modelo;

namespace NoSQL
{
    public partial class VentanaDatos : Form
    {
        IOperaciones db;
        const string MSG_ERROR_DB  = "Error accediendo a la base de datos, operación no realizada. Verifique la configuración.";
        string[] tags = new string [0];
        Image foto = Image.FromFile(@"Data\nophoto.jpg");

        public VentanaDatos(IOperaciones db)
        {
            this.db = db;
            InitializeComponent();
            if (db.Identidad() == "Cassandra")
                numericUpDownPag.Enabled = false;
        }

        private void VentanaDatos_Load(object sender, EventArgs e)
        {            
            numericUpDownPag.Value = 1;
            if(db.GetThreadsCount() > 100)
                numericUpDownCant.Value = 100;
            else
                numericUpDownCant.Value = db.GetThreadsCount();
            cargarAutores();
            cargarThreads();
        }

        private void cargarAutores()
        {
            comboBoxAutorThread.Items.Clear();
            comboBoxAutorCom.Items.Clear();

            var Autores = db.GetAuthors();            
            foreach (var autor in Autores)
            {    // sacado if de "identidad", no hace la diferencia                            
                 comboBoxAutorCom.Items.Add(new ComboItem { Text = autor.Name, Value = autor.Id });
                 comboBoxAutorThread.Items.Add(new ComboItem { Text = autor.Name, Value = autor.Id });                
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
            var Threads = db.GetThreads(((int)numericUpDownPag.Value - 1) * (int)numericUpDownCant.Value, (int)numericUpDownCant.Value);            
            foreach (var th in Threads)
            {
                TreeNode nodo = new TreeNode(th.Title + "");
                //TreeNode nodo = new TreeNode(th["title"] + "", subComments(th["_id"] + "").ToArray());
                nodo.Tag = th.Id.ToString();
                nodo.ContextMenuStrip = contextMenuStripNode;
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
                    db.AddAuthor(new Author() { Name = textBoxNombreAutor.Text, Photo = (Bitmap)foto });
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
                    db.AddThread(new Thread()
                    {
                        Title = textBoxNombreThread.Text,
                        Author = new Author()
                        {
                            Name = ((ComboItem)comboBoxAutorThread.SelectedItem).Text.ToString(),
                            Id = ((ComboItem)comboBoxAutorThread.SelectedItem).Value
                        },
                        Date = DateTime.Now,
                        Tags = tags
                    });
                    if(numericUpDownCant.Value < 100)
                        numericUpDownCant.Value++;
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
            if (textBoxCom.Text != "" && treeViewCom.SelectedNode != null)
            {
                db.AddComment(new Comment()
                {
                    Text = textBoxCom.Text,
                    Thread_id = threadRaiz(treeViewCom.SelectedNode).Tag.ToString(),
                    Author = new Author()
                    {
                        Name = ((ComboItem)comboBoxAutorCom.SelectedItem).Text.ToString(),
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
                foreach (Comment com in db.GetChildComments(treeViewCom.SelectedNode.Tag.ToString()) )
                {
                    TreeNode nodo = new TreeNode("Comentario: " + i);
                    i++;
                    nodo.Tag = com.Id.ToString();
                    treeViewCom.SelectedNode.Nodes.Add(nodo);
                    nodo.ContextMenuStrip = contextMenuStripNode;
                }
                treeViewCom.EndUpdate();
            }
            //Modificacion no recursiva          
            //dbmongo.GetCollection("comments").FindOne(Query.EQ("_id", new BsonObjectId(new ObjectId(treeViewCom.SelectedNode.Tag.ToString()))));
            if (treeViewCom.SelectedNode.Level > 0)

            {
                Comment comentario = db.GetComment(treeViewCom.SelectedNode.Tag.ToString());
                textBoxContCom.Text =
                    "[Comentario] " + Environment.NewLine +
                    "Fecha: " + comentario.Date.ToLocalTime().ToShortDateString() + Environment.NewLine +
                    "Autor: " + comentario.Author.Name + Environment.NewLine +
                    "Respuestas: " + comentario.CommentCount + Environment.NewLine + Environment.NewLine +
                    comentario.Text;
            }
            else
            {
                Thread thread = db.GetThread(treeViewCom.SelectedNode.Tag.ToString());
                //BsonDocument thread = dbmongo.GetCollection("threads").FindOne(Query.EQ("_id", new BsonObjectId(new ObjectId(treeViewCom.SelectedNode.Tag.ToString()))));
                string tags = "";
                if(thread.Tags != null)
                    tags = "Tags: ["+ String.Join(", ",thread.Tags)+"]";
                textBoxContCom.Text =
                    "[Thread] " + Environment.NewLine +
                    "Fecha: " + thread.Date.ToLocalTime().ToShortDateString() + Environment.NewLine +
                    "Título: " + thread.Title + Environment.NewLine +
                    "Autor: " + thread.Author.Name + Environment.NewLine +
                    "Comentarios: " + thread.CommentCount + Environment.NewLine  +
                    tags;
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (treeViewCom.SelectedNode.Level > 0)
            {
                Comment comentario = db.GetComment(treeViewCom.SelectedNode.Tag.ToString());
                result = db.RemoveComment(comentario);
            }
            else
            {
                Thread thread = db.GetThread(treeViewCom.SelectedNode.Tag.ToString());
                result = db.RemoveThread(thread);
            }
            if (result) 
                treeViewCom.Nodes.Remove(treeViewCom.SelectedNode);
        }

        private void numericUpDownDesde_ValueChanged(object sender, EventArgs e)
        {
            cargarThreads();
        }

        private void numericUpDownHasta_ValueChanged(object sender, EventArgs e)
        {
            cargarThreads();
        }

        private void buttonTags_Click(object sender, EventArgs e)
        {
            Form vt = new VentanaTags(this, tags);
            vt.ShowDialog();
        }

        public void SetTags(string[] tags)
        {
            this.tags = tags;
        }

        private void buttonFoto_Click(object sender, EventArgs e)
        {
            openFileDialogFoto.ShowDialog();
        }

        private void openFileDialogFoto_FileOk(object sender, CancelEventArgs e)
        {
            foto = Image.FromFile(openFileDialogFoto.FileName);
        }

        private void textBoxNombreAutor_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNombreAutor.Text.Length == 0)
                buttonAgregarAutor.Enabled = false;
            else
                buttonAgregarAutor.Enabled = true;
        }

        private void textBoxNombreThread_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNombreThread.Text.Length == 0)
                buttonAgregarThread.Enabled = false;
            else
                buttonAgregarThread.Enabled = true;
        }

        private void comboBoxAutorThread_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
