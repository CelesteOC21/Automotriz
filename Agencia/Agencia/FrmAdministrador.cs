using System;
using System.Globalization;
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

                LlenarUsuario("");
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
            datosUsuario.Clave = txtClave.Text;
            datosUsuario.Fecha = fechaNacimiento;
            datosUsuario.Rfc = txtRFC.Text;

            var validar = _manejadorUsuarios.ValidarDatosUsuario(datosUsuario);
            if (validar.Item1)
                try
                {
                    _manejadorUsuarios.ActualizarUsuario(datosUsuario);
                    LlenarUsuario("");
                    MessageBox.Show("Actualizado");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            guardando = true;

            
        }

        private void dtgUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombre.Focus();
            txtNombre.Text = dtgUsuarios.CurrentRow.Cells["Nombre"].Value.ToString();
            txtApellidoM.Text = dtgUsuarios.CurrentRow.Cells["Apellido_materno"].Value.ToString();
            txtApellidoP.Text = dtgUsuarios.CurrentRow.Cells["Apellido_paterno"].Value.ToString();
            //dtp.Text = dtgUsuarios.CurrentRow.Cells["Fecha"].Value.ToString();

            string fechaStr = dtgUsuarios.CurrentRow.Cells["Fecha"].Value.ToString();
            if (DateTime.TryParseExact(fechaStr, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaNacimiento))
            {
                dtp.Value = fechaNacimiento;
            }

            txtClave.Text = dtgUsuarios.CurrentRow.Cells["Clave"].Value.ToString();
            txtRFC.Text = dtgUsuarios.CurrentRow.Cells["Rfc"].Value.ToString();

            guardando = false;
        }

        private void FrmAdministrador_Load(object sender, EventArgs e)
        {
            LlenarUsuario("");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LimpiarCuadro()
        {
            txtNombre.Text = "";
            txtApellidoM.Text = "";
            txtApellidoP.Text = "";
            txtClave.Text = "";
            txtRFC.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCuadro();
        }

        private void EliminarUsuario()
        {
            if(MessageBox.Show("Desea eliminar el usuario seleccionado?", "Eliminar usuario", MessageBoxButtons.YesNo) 
                == DialogResult.Yes)
            {
                var idUsuario = int.Parse(dtgUsuarios.CurrentRow.Cells["id"].Value.ToString());
                _manejadorUsuarios.EliminarUsuario(idUsuario);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarUsuario();
            LlenarUsuario("");
        }
    }
}
