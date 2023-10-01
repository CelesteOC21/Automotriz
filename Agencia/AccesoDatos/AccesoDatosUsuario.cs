using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class AccesoDatosUsuario
    {
        Conexion conexion;
        public AccesoDatosUsuario()
        {
            conexion = new Conexion("localhost", "root", "12345678", "Agencia", 3306);
        }
        public List<EntidadesUsuarios> ObtenerDatos(string valor)
        {
            var ListaDatosUsuarios = new List<EntidadesUsuarios>();
            var dataTable = new DataTable();

            var consulta = string.Format("select * from usuarios where nombre like '%{0}%'", valor);
            dataTable = conexion.ObtenerDatos(consulta);

            foreach (DataRow renglon in dataTable.Rows)
            {
                var EntidadUsuarios = new EntidadesUsuarios
                {
                    Id = Convert.ToInt32(renglon["id"]),
                    Nombre = renglon["nombre"].ToString(),
                    Clave = renglon["clave"].ToString(),
                    Apellido_paterno = renglon["apellido_paterno"].ToString(),
                    Apellido_materno = renglon["apellido_materno"].ToString(),
                    Fecha = renglon["fecha_de_nacimeinto"].ToString(),
                    Rfc = renglon["rfc"].ToString()
                };
                ListaDatosUsuarios.Add(EntidadUsuarios);
            }
            return ListaDatosUsuarios;
        }

        public void GuardarUsuarios(EntidadesUsuarios nuevosDatos)
        {
            string consulta = string.Format("insert into usuarios values(null, '{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                nuevosDatos.Nombre, nuevosDatos.Clave, nuevosDatos.Apellido_paterno, nuevosDatos.Apellido_materno, nuevosDatos.Fecha, 
                nuevosDatos.Rfc);
            conexion.EjecutarConsulta(consulta);
        }

        public void ActualizarUsuarios(EntidadesUsuarios nuevosDatos)
        {
            string consulta = string.Format("update usuarios set nombre = '{0}', Clave = '{1}', Apellido_paterno = '{1}', Apellido_materno = '{2}', " +
                "Fecha = '{3}', Rfc = '{4}'", nuevosDatos.Nombre, nuevosDatos.Clave, nuevosDatos.Apellido_paterno, nuevosDatos.Apellido_materno, nuevosDatos.Fecha,
                nuevosDatos.Rfc);
            conexion.EjecutarConsulta(consulta);
        }

        public void EliminarUsuario(int IdUsuario)
        {
            string consulta = string.Format("delete from usuarios where id = {0}", IdUsuario);
            conexion.EjecutarConsulta(consulta);
        }
    }
}
