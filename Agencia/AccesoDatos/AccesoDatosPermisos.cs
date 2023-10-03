using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class AccesoDatosPermisos
    {
        Conexion conexion;
        public AccesoDatosPermisos()
        {
            conexion = new Conexion("localhost", "root", "12345678", "Agencia", 3306);
        }
        public List<EntidadesPermiso> ObtenerDatos(string valor)
        {
            var ListaDatosPermiso = new List<EntidadesPermiso>();
            var dataTable = new DataTable();

            var consulta = string.Format("select * from permisosUsuarios where fk_id_usuario like '%{0}%'", valor);
            dataTable = conexion.ObtenerDatos(consulta);

            foreach (DataRow renglon in dataTable.Rows)
            {
                var EntidadPermiso = new EntidadesPermiso
                {
                    Id = Convert.ToInt32(renglon["ID"]),
                    Fk_id_usuario = Convert.ToInt32(renglon["fk_id_usuario"].ToString()),
                    Permiso = renglon["permiso"].ToString()
                };
                ListaDatosPermiso.Add(EntidadPermiso);
            }
            return ListaDatosPermiso;
        }

        public List<EntidadesPermiso> ListarPermisos(int valor)
        {
            var ListaPermiso = new List<EntidadesPermiso>();
            var dataTable = new DataTable();

            var consulta = string.Format("select * from permisosusuarios WHERE fk_id_usuario like '%{0}%'", valor);
            dataTable = conexion.ObtenerDatos(consulta);

            foreach (DataRow renglon in dataTable.Rows)
            {
                var EntidadPermiso = new EntidadesPermiso
                {
                    Id = Convert.ToInt32(renglon["ID"]),
                    Fk_id_usuario = Convert.ToInt32(renglon["fk_id_usuario"].ToString()),
                    Permiso = renglon["permiso"].ToString()
                };
                ListaPermiso.Add(EntidadPermiso);
            }
            return ListaPermiso;
        }
        public void GuardarPermiso(EntidadesPermiso nuevosDatos)
        {
            string consulta = string.Format("insert into PermisosUsuarios values(null, {0}, '{1}'",
                nuevosDatos.Fk_id_usuario, nuevosDatos.Permiso);
            conexion.EjecutarConsulta(consulta);
        }

        public void ActualizarPermiso(EntidadesPermiso nuevosDatos)
        {
            string consulta = string.Format("update PermisosUsuarios set fk_id_usuario = {0}, permiso = '{1}' where id = {2}", 
                nuevosDatos.Fk_id_usuario, nuevosDatos.Permiso, nuevosDatos.Id);
            conexion.EjecutarConsulta(consulta);
        }

        public void EliminarPermiso(int IdPermiso)
        {
            string consulta = string.Format("delete from PermisosUsuarios where id = {0}", IdPermiso);
            conexion.EjecutarConsulta(consulta);
        }
    }
}
