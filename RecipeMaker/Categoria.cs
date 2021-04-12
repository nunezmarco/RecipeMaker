using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeMaker
{
    public class Categoria
    {
        private List<Ingrediente> _ingredientes = new List<Ingrediente>();
        private string _nombre;

        public Categoria(string nombre)
        {
            _nombre = nombre;
        }
        public string Nombre
        {
            get => _nombre;
            set => _nombre = value;
        }
        public List<Ingrediente> Ingredientes
        {
            get => _ingredientes;

        }

        public void agregaIngredientes( List<Ingrediente> ingredientes)
        {
            foreach(Ingrediente ingrediente in ingredientes)
            {
                _ingredientes.Add(ingrediente);
            }
        }
    }
}
