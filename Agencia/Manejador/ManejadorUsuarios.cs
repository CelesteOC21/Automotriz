using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace Manejador
{
    public class ManejadorUsuarios
    {
        private AccesoDatosUsuario _accesoDatosUsaurio;

        public ManejadorUsuarios()
        {
            _accesoDatosUsaurio = new AccesoDatosUsuario();
        }

        public bool VerificarUsuarios(string usuario, string clave)
        {
            bool resultado = false;
            int cuenta = _accesoDatosUsaurio.Comprobacion(usuario, clave);
            if(cuenta > 0)
            {
                resultado = true;
            }
            return resultado;
        }

        public List<EntidadesUsuarios> ObtenerUsuario(string valor)
        {
            return _accesoDatosUsaurio.ObtenerDatos(valor);
        }

        public void EliminarUsuario(int IdUsuario)
        {
            _accesoDatosUsaurio.EliminarUsuario(IdUsuario);
        }

        public void GuardarUsuario(EntidadesUsuarios datosUsuario)
        {
            _accesoDatosUsaurio.GuardarUsuarios(datosUsuario);
        }

        public void ActualizarUsuario(EntidadesUsuarios datosUsuario)
        {
            _accesoDatosUsaurio.ActualizarUsuarios(datosUsuario);
        }

        public Tuple<bool, string> ValidarDatosUsuario(EntidadesUsuarios nuevosDatos)
        {
            
            string mensaje = "";
            bool esValido = true;

            if (nuevosDatos.Nombre == "")
            {
                mensaje = "El campo Nombre es requerido";
                esValido = false;
            }
            if (nuevosDatos.Apellido_paterno == "")
            {
                mensaje = "El campo Apellido Paterno es requerido";
                esValido = false;
            }
            if (nuevosDatos.Apellido_materno == "")
            {
                mensaje = "El campo Apellido Materno es requerido";
                esValido = false;
            }
            if (nuevosDatos.Fecha == "")
            {
                mensaje = "El campo Fecha es requerido";
                esValido = false;
            }
            if (nuevosDatos.Rfc == "")
            {
                mensaje = "El campo RFC es requerido";
                esValido = false;
            }

            var resultado = new Tuple<bool, string>(esValido, mensaje);
            return resultado;
        }

    }
}
