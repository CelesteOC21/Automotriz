using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace AccesoDatos
{
    public class AccesoDatosHerramientas
    {
        Conexion conexion;
        public AccesoDatosHerramientas()
        {
            conexion = new Conexion("localhost", "root", "12345678", "Agencia", 3306);
        }
        public List<EntidadesHerramientas> ObtenerDatos(string valor)
        {
            var ListaDatosHerramientas = new List<EntidadesHerramientas>();
            var dataTable = new DataTable();

            var consulta = string.Format("select * from herramientas where nombre like '%{0}%'", valor);
            dataTable = conexion.ObtenerDatos(consulta);

            foreach (DataRow renglon in dataTable.Rows)
            {
                var EntidadHerramientas = new EntidadesHerramientas
                {
                    Id = Convert.ToInt32(renglon["id"]),
                    Nombre = renglon["nombre"].ToString(),
                    Medida = renglon["medida"].ToString(),
                    Marca = renglon["marca"].ToString(),
                    Descripcion = renglon["descripcion"].ToString()
                };
                ListaDatosHerramientas.Add(EntidadHerramientas);
            }
            return ListaDatosHerramientas;
        }

        public void GuardarHerramienta(EntidadesHerramientas nuevosDatos)
        {
            string consulta = string.Format("insert into herramientas values(null, '{0}', '{1}', '{2}', '{3}')",
                nuevosDatos.Nombre, nuevosDatos.Medida, nuevosDatos.Marca, nuevosDatos.Descripcion);
            conexion.EjecutarConsulta(consulta);
        }

        public void ActualizarHerramienta(EntidadesHerramientas nuevosDatos)
        {
            string consulta = string.Format("update herramientas set nombre = '{0}', medida = '{1}', marca = '{2}', " +
                "descripcion = '{3}'", nuevosDatos.Nombre, nuevosDatos.Medida, nuevosDatos.Marca, nuevosDatos.Descripcion);
            conexion.EjecutarConsulta(consulta);
        }

        public void EliminarHerramienta(int IdHerramienta)
        {
            string consulta = string.Format("delete from herramientas where id = {0}", IdHerramienta);
            conexion.EjecutarConsulta(consulta);
        }
    }
}
