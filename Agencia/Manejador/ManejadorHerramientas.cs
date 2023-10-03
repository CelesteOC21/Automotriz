using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;


namespace Manejador
{
    public class ManejadorHerramientas
    {
        private AccesoDatosHerramientas _accesoDatosHerramientas;

        public ManejadorHerramientas()
        {
            _accesoDatosHerramientas = new AccesoDatosHerramientas();
        }


        public List<EntidadesHerramientas> ObtenerHerramientas(string valor)
        {
            return _accesoDatosHerramientas.ObtenerDatos(valor);
        }

        public void EliminarHerramienta(int IdUsuario)
        {
            _accesoDatosHerramientas.EliminarHerramienta(IdUsuario);
        }

        public void GuardarHerramientas(EntidadesHerramientas datosHerramientas)
        {
            _accesoDatosHerramientas.GuardarHerramienta(datosHerramientas);
        }

        public void ActualizarHerramientas(EntidadesHerramientas datosHerramientas)
        {
            _accesoDatosHerramientas.ActualizarHerramienta(datosHerramientas);
        }

        public Tuple<bool, string> ValidarCamposHerramientas(EntidadesHerramientas nuevosDatos)
        {

            string mensaje = "";
            bool esValido = true;

            if (nuevosDatos.Nombre == "")
            {
                mensaje = "El campo Nombre es requerido";
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
