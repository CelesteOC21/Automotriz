using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EntidadesHerramientas
    {
        private int _id;
        private string _nombre;
        private string _marca;
        private string _descripcion;

        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Marca { get => _marca; set => _marca = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
    }
}
