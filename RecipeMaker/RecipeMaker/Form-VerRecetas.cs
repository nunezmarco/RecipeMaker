using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeMaker
{
    public partial class Form_VerRecetas : Form
    {
        List<Receta> _recetas;
        public Form_VerRecetas(List<Receta> recetas)
        {
            InitializeComponent();
            _recetas = recetas;
            inicializaTreeView();
        }

        private void Form_VerRecetas_Load(object sender, EventArgs e)
        {

        }

        private void inicializaTreeView()
        {
            foreach(Receta receta in _recetas)
            {
                TreeNode node = new TreeNode();
                node.Text = receta.Nombre;
                node.Tag = receta.Nombre;
                foreach (Ingrediente ingrediente in receta.Ingredientes)
                {
                    TreeNode nodeingrediente = new TreeNode();
                    nodeingrediente.Text = ingrediente.Nombre + " - " + ingrediente.Cantidad;
                    nodeingrediente.Tag = ingrediente.Nombre;
                    node.Nodes.Add(nodeingrediente);
                }
                treeView1.Nodes.Add(node);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
