using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeMaker
{
    public class Ingrediente
    {
        private string _nombre;
        private int _cantidad;

        public Ingrediente( string nombre,  int cantidad=0)
        {
            _nombre = nombre;
            _cantidad = cantidad;
        }
        public string Nombre
        {
            get => _nombre;
            set => _nombre = value;
        }
        public int Cantidad
        {
            get => _cantidad;
            set => _cantidad = value;
        }
    }
}
