using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Manejador;

namespace Agencia
{
    public partial class FrmAdministrador : Form
    {
        private ManejadorUsuarios _manejadorUsuarios;
        private int ID = 0;
        bool guardando = true;
        public FrmAdministrador()
        {
            InitializeComponent();
            _manejadorUsuarios = new ManejadorUsuarios();

        }

        private void LlenarUsuario(string valor)
        {
            dtgUsuarios.DataSource = _manejadorUsuarios.ObtenerUsuario(valor);
        }

       

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (guardando)
            {
                EntidadesUsuarios entidadUsuario = new EntidadesUsuarios();
                DateTime fechaSeleccionada = dtp.Value;

                string fechaNacimiento = fechaSeleccionada.ToString("yyyy-MM-dd");

                entidadUsuario.Id = 0;
                entidadUsuario.Nombre = txtNombre.Text;
                entidadUsuario.Clave = txtClave.Text;
                entidadUsuario.Apellido_materno = txtApellidoM.Text;
                entidadUsuario.Fecha = fechaNacimiento;
                entidadUsuario.Apellido_paterno = txtApellidoP.Text;
                entidadUsuario.Rfc = txtRFC.Text;

                _manejadorUsuarios.GuardarUsuario(entidadUsuario);
            }
            else
            {
                ActualizarUsuario();
            }
            
        }

        private void ActualizarUsuario()
        {
            DateTime fechaSeleccionada = dtp.Value;
            string fechaNacimiento = fechaSeleccionada.ToString("yyyy-MM-dd");

            EntidadesUsuarios datosUsuario = new EntidadesUsuarios();
            ID = int.Parse(dtgUsuarios.CurrentRow.Cells["id"].Value.ToString());
            datosUsuario.Id = ID;
            datosUsuario.Nombre = txtNombre.Text;
            datosUsuario.Apellido_paterno = txtApellidoP.Text;
            datosUsuario.Apellido_materno = txtApellidoM.Text;
            datosUsuario.Fecha = fechaNacimiento;
            datosUsuario.Rfc = txtRFC.Text;

            var validar = _manejadorUsuarios.ValidarDatosUsuario(datosUsuario);
            if (validar.Item1)
            {
                _manejadorUsuarios.ActualizarUsuario(datosUsuario);
                MessageBox.Show("Actualizado");
            }
            guardando = true;

            
        }

        private void dtgUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DateTime fechaSeleccionada = dtp.Value;

            string fechaNacimiento = fechaSeleccionada.ToString("yyyy-MM-dd");

            txtNombre.Focus();
            txtNombre.Text = dtgUsuarios.CurrentRow.Cells["nombre"].Value.ToString();
            txtApellidoM.Text = dtgUsuarios.CurrentRow.Cells["apellido_materno"].Value.ToString();
            txtApellidoP.Text = dtgUsuarios.CurrentRow.Cells["apellido_paterno"].Value.ToString();
            fechaNacimiento = dtgUsuarios.CurrentRow.Cells["fecha_de_nacimiento"].Value.ToString();
            txtRFC.Text = dtgUsuarios.CurrentRow.Cells["rfc"].Value.ToString();
        }

        private void FrmAdministrador_Load(object sender, EventArgs e)
        {
            LlenarUsuario("");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
