﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace AccesoDatos
{
    public class AccesoDatosProducto
    {
        Conexion conexion;
        public AccesoDatosProducto()
        {
            conexion = new Conexion("localhost", "root", "12345678", "Agencia", 3306);
        }
        public List<EntidadesProducto> ObtenerDatos(string valor)
        {
            var ListaDatosProducto = new List<EntidadesProducto>();
            var dataTable = new DataTable();

            var consulta = string.Format("select * from producto where nombre like '%{0}%'", valor);
            dataTable = conexion.ObtenerDatos(consulta);

            foreach (DataRow renglon in dataTable.Rows)
            {
                var EntidadProducto = new EntidadesProducto
                {
                    Id = Convert.ToInt32(renglon["id"]),
                    Nombre = renglon["nombre"].ToString(),
                    Descripcion = renglon["descripcion"].ToString(),
                    Marca = renglon["marca"].ToString()
                };
                ListaDatosProducto.Add(EntidadProducto);
            }
            return ListaDatosProducto;
        }

        public void GuardarProducto(EntidadesProducto nuevosDatos)
        {
            string consulta = string.Format("insert into producto values(null, '{0}', '{1}', '{2}')",
                nuevosDatos.Nombre, nuevosDatos.Descripcion, nuevosDatos.Marca);
            conexion.EjecutarConsulta(consulta);
        }

        public void ActualizarProducto(EntidadesProducto nuevosDatos)
        {
            string consulta = string.Format("update producto set nombre = '{0}', descripcion = '{1}', marca = '{2}'", 
                nuevosDatos.Nombre, nuevosDatos.Descripcion, nuevosDatos.Marca);
            conexion.EjecutarConsulta(consulta);
        }

        public void EliminarProdcuto(int IdProducto)
        {
            string consulta = string.Format("delete from producto where id = {0}", IdProducto);
            conexion.EjecutarConsulta(consulta);
        }
    }

}
