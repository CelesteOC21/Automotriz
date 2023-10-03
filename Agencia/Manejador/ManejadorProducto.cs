using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace Manejador
{
    public class ManejadorProducto
    {
        private AccesoDatosProducto _AccesoDatosProducto;

        public ManejadorProducto()
        {
            _AccesoDatosProducto = new AccesoDatosProducto();
        }

        public List<EntidadesProducto> ObtenerProducto(string valor)
        {
            return _AccesoDatosProducto.ObtenerDatos(valor);
        }

        public void EliminarProducto(int IdProducto)
        {
            _AccesoDatosProducto.EliminarProducto(IdProducto);
        }

        public void GuardarProducto(EntidadesProducto entidadesProducto)
        {
            _AccesoDatosProducto.GuardarProducto(entidadesProducto);
        }

        public void ActualizarProducto(EntidadesProducto entidadesProducto)
        {
            _AccesoDatosProducto.ActualizarProducto(entidadesProducto);
        }

        public Tuple<bool, string> ValidarDatosProductos(EntidadesProducto nuevosDatos)
        {

            string mensaje = "";
            bool esValido = true;

            if (nuevosDatos.Nombre == "")
            {
                mensaje = "El campo Nombre es requerido";
                esValido = false;
            }
            if (nuevosDatos.Medida == "")
            {
                mensaje = "El campo Medida es requerido";
                esValido = false;
            }
            if (nuevosDatos.Marca == "")
            {
                mensaje = "El campo Marca es requerido";
                esValido = false;
            }
            if (nuevosDatos.Descripcion == "")
            {
                mensaje = "El campo Descripcion es requerido";
                esValido = false;
            }

            var resultado = new Tuple<bool, string>(esValido, mensaje);
            return resultado;
        }
    }
}
