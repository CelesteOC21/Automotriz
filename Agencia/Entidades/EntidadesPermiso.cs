using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EntidadesPermiso
    {
        private int _id;
        private int _fk_id_usuario;
        private string _permiso;

        public int Id { get => _id; set => _id = value; }
        public int Fk_id_usuario { get => _fk_id_usuario; set => _fk_id_usuario = value; }
        public string Permiso { get => _permiso; set => _permiso = value; }
    }
}
