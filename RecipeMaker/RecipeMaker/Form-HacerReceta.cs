using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace RecipeMaker
{
    public partial class Form_HacerReceta : Form
    {
        List<Categoria> categorias;
        List<Ingrediente> ingredientes = new List<Ingrediente>();
        private string nombreReceta;
        public Form_HacerReceta(List<Categoria> categorias, string nombre)
        {
            InitializeComponent();
            this.categorias = categorias;
            nombreReceta = nombre;
            label2.Text = nombreReceta;
            creaTreeView();
            inicializaListView();
        }
        public string NombreReceta
        {
            get => nombreReceta;
        }
        public List<Ingrediente> Ingredientes
        {
            get => ingredientes;
        }
        private void creaTreeView()
        {
            foreach(Categoria categoria in categorias)
            {
                TreeNode node = new TreeNode();
                node.Text = categoria.Nombre;
                node.Tag = categoria.Nombre;
                
                foreach(Ingrediente ingrediente in categoria.Ingredientes)
                {
                    TreeNode nodeingrediente = new TreeNode();
                    nodeingrediente.Text = ingrediente.Nombre;
                    nodeingrediente.Tag = ingrediente.Nombre;
                    node.Nodes.Add(nodeingrediente);
                }
                treeView1.Nodes.Add(node);
            }
            treeView1.ExpandAll();
        }

        private void inicializaListView()
        {
            listView1.Columns.Add("Ingredientes", -2, HorizontalAlignment.Center);
            listView1.View = View.Details;
            listView1.GridLines = true;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                int cantidad;
                string res = Interaction.InputBox("Insertar cantidad de ingredientes requeridos", "Agregar Ingrediente", "0");
                bool isNumeric = int.TryParse(res, out cantidad);
                
                if (isNumeric && cantidad>0)
                {
                    Ingrediente ingrediente = new Ingrediente(e.Node.Text,cantidad);
                    ingredientes.Add(ingrediente);
                    ListViewItem item = new ListViewItem("item1",0);
                    item.Text = e.Node.Text + "  -  " + cantidad;
                    item.Tag = e.Node.Text;
                    
                    listView1.Items.Add(item);
                }
                else
                {
                    MessageBox.Show("El numero ingresado no es válido");
                }
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ingredientes.Count > 0)
            {
                ingredientes.RemoveAt(ingredientes.Count-1);
                listView1.Items.RemoveAt(listView1.Items.Count-1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nombreReceta = Interaction.InputBox("Ingrese nombre de la receta a crear", "Crear receta", "");
            label2.Text = nombreReceta;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
