using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EntidadesPermisos
    {
        private int _id;
        private string _lectura;
        private string _escritura;
        private string _eliminacion;
        private string _actualizacion;

        public int Id { get => _id; set => _id = value; }
        public string Lectura { get => _lectura; set => _lectura = value; }
        public string Escritura { get => _escritura; set => _escritura = value; }
        public string Eliminacion { get => _eliminacion; set => _eliminacion = value; }
        public string Actualizacion { get => _actualizacion; set => _actualizacion = value; }
    }
}
