using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EntidadesUsuarios
    {
        private int _id;
        private string _nombre;
        private string _clave;
        private string _apellido_paterno;
        private string _apellido_materno;
        private string _fecha;
        private string _rfc;

        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Clave { get => _clave; set => _clave = value; }
        public string Apellido_paterno { get => _apellido_paterno; set => _apellido_paterno = value; }
        public string Apellido_materno { get => _apellido_materno; set => _apellido_materno = value; }
        public string Fecha { get => _fecha; set => _fecha = value; }
        public string Rfc { get => _rfc; set => _rfc = value; }
    }
}
