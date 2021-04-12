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
    public partial class Form1 : Form
    {
        private List<Categoria> _categorias;
        private List<Receta> _recetas;
        private Boolean muestraGuia = true;
        public Form1()
        {
            InitializeComponent();
            inicializaCategorias();
            _recetas = new List<Receta>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void inicializaCategorias()
        {
            _categorias = new List<Categoria>();
            List<Ingrediente> ingredientes = new List<Ingrediente>();
            //Agua
            Categoria nuevaCategoria = new Categoria("Agua");
            Ingrediente ingrediente_aux = new Ingrediente("Agua");
            ingredientes.Add(ingrediente_aux);
            nuevaCategoria.agregaIngredientes(ingredientes);
            _categorias.Add(nuevaCategoria);
            //Lácteos
            ingredientes = new List<Ingrediente>();
            nuevaCategoria = new Categoria("Lácteos");
            ingrediente_aux = new Ingrediente("Leche");
            ingredientes.Add(ingrediente_aux);
            ingrediente_aux = new Ingrediente("Mantequilla");
            ingredientes.Add(ingrediente_aux);
            nuevaCategoria.agregaIngredientes(ingredientes);
            _categorias.Add(nuevaCategoria);
            //Carnes
            ingredientes = new List<Ingrediente>();
            nuevaCategoria = new Categoria("Carne");
            ingrediente_aux = new Ingrediente("Pollo");
            ingredientes.Add(ingrediente_aux);
            ingrediente_aux = new Ingrediente("Cerdo");
            ingredientes.Add(ingrediente_aux);
            ingrediente_aux = new Ingrediente("Vaca");
            ingredientes.Add(ingrediente_aux);
            nuevaCategoria.agregaIngredientes(ingredientes);
            _categorias.Add(nuevaCategoria);
            //Verduras
            ingredientes = new List<Ingrediente>();
            nuevaCategoria = new Categoria("Verduras");
            ingrediente_aux = new Ingrediente("Zanahoria");
            ingredientes.Add(ingrediente_aux);
            ingrediente_aux = new Ingrediente("Cebolla");
            ingredientes.Add(ingrediente_aux);
            ingrediente_aux = new Ingrediente("Lechuga");
            ingredientes.Add(ingrediente_aux);
            nuevaCategoria.agregaIngredientes(ingredientes);
            _categorias.Add(nuevaCategoria);
            //Frutas
            ingredientes = new List<Ingrediente>();
            nuevaCategoria = new Categoria("Frutas");
            ingrediente_aux = new Ingrediente("Manzana");
            ingredientes.Add(ingrediente_aux);
            ingrediente_aux = new Ingrediente("Limon");
            ingredientes.Add(ingrediente_aux);
            ingrediente_aux = new Ingrediente("Platano");
            ingredientes.Add(ingrediente_aux);
            nuevaCategoria.agregaIngredientes(ingredientes);
            _categorias.Add(nuevaCategoria);
            //Cereales
            ingredientes = new List<Ingrediente>();
            nuevaCategoria = new Categoria("Cereales");
            ingrediente_aux = new Ingrediente("Arroz");
            ingredientes.Add(ingrediente_aux);
            ingrediente_aux = new Ingrediente("Harina");
            ingredientes.Add(ingrediente_aux);
            ingrediente_aux = new Ingrediente("Avena");
            ingredientes.Add(ingrediente_aux);
            nuevaCategoria.agregaIngredientes(ingredientes);
            _categorias.Add(nuevaCategoria);
        }

        private void creaReceta(string nombre, List<Ingrediente> ingredientes)
        {
            if(nombre == "")
            {
                nombre = "Receta sin nombre";
            }
            Receta nuevaReceta = new Receta(nombre);
            nuevaReceta.agregaIngredientes(ingredientes);
            _recetas.Add(nuevaReceta);
        }
        private void buttonCrearReceta_Click(object sender, EventArgs e)
        {
            string res = Interaction.InputBox("Ingrese nombre de la receta a crear", "Crear receta", "");
            if (res == "")
            {
                res = "Receta sin nombre";
            }
            if (muestraGuia)
            {
                Form_guia DialogGuia = new Form_guia();
                DialogGuia.ShowDialog(this);
                DialogGuia.Dispose();
                muestraGuia = false;
            }
            Form_HacerReceta DialogReceta = new Form_HacerReceta(_categorias, res);
            if (DialogReceta.ShowDialog(this) == DialogResult.OK)
            {
                if (DialogReceta.Ingredientes.Count > 0)
                {
                    creaReceta(DialogReceta.NombreReceta, DialogReceta.Ingredientes);
                    MessageBox.Show("Receta creada con éxito");
                }
                else
                {
                    MessageBox.Show("La receta no fue creada, no existen ingredientes");
                }
               
            }
            DialogReceta.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_recetas.Count > 0)
            {
                Form_VerRecetas DialogVerReceta = new Form_VerRecetas(_recetas);
                if (DialogVerReceta.ShowDialog(this) == DialogResult.OK)
                {
                }
                DialogVerReceta.Dispose();
            }
            else
            {
                MessageBox.Show("No existen recetas");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
