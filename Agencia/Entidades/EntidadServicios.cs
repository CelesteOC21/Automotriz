using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EntidadServicios
    {
        private int _id;
        private string _servicio;
        private string _fk_id_usuario;
        private string _fk_id_permiso;

        public int Id { get => _id; set => _id = value; }
        public string Servicio { get => _servicio; set => _servicio = value; }
        public string Fk_id_usuario { get => _fk_id_usuario; set => _fk_id_usuario = value; }
        public string Fk_id_permiso { get => _fk_id_permiso; set => _fk_id_permiso = value; }
    }
}
