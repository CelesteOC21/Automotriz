using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using AccesoDatos;
using Manejador;

namespace Agencia
{
    public partial class FrmTaller : Form
    {
        private ManejadorHerramientas _ManejadorHerramientas;
        private int ID = 0;
        bool guardando = true;
        public FrmTaller()
        {
            InitializeComponent();
            _ManejadorHerramientas = new ManejadorHerramientas();
        }

        private void LlenarDtgHerramientas(string valor)
        {
            dtgHerramientas.DataSource = _ManejadorHerramientas.ObtenerHerramientas(valor);
        }



        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Focus();
            LimpiarCuadro();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (guardando)
            {
                EntidadesHerramientas entidadesHerramientas = new EntidadesHerramientas();
                entidadesHerramientas.Id = 0;
                entidadesHerramientas.Nombre = txtNombre.Text;
                entidadesHerramientas.Marca = txtMarca.Text;
                entidadesHerramientas.Descripcion = txtDescripcion.Text;

                _ManejadorHerramientas.GuardarHerramientas(entidadesHerramientas);
                LlenarDtgHerramientas("");
            }
            else
            {
                ActualizarHerramientas();
            }
        }

        private void ActualizarHerramientas()
        {
            EntidadesHerramientas entidadesHerramientas = new EntidadesHerramientas();

            ID = int.Parse(dtgHerramientas.CurrentRow.Cells["id"].Value.ToString());
            entidadesHerramientas.Nombre = txtNombre.Text;
            entidadesHerramientas.Marca= txtMarca.Text;
            entidadesHerramientas.Descripcion = txtDescripcion.Text;

            var validar = _ManejadorHerramientas.ValidarCamposHerramientas(entidadesHerramientas);

            if (validar.Item1)
            {
                try
                {
                    _ManejadorHerramientas.ActualizarHerramientas(entidadesHerramientas);
                    LlenarDtgHerramientas("");
                    MessageBox.Show("Actualizado!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                guardando = true; 
            }

        }

        private void dtgHerramientas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombre.Focus();
            txtNombre.Text = dtgHerramientas.CurrentRow.Cells["Nombre"].Value.ToString();
            txtMarca.Text = dtgHerramientas.CurrentRow.Cells["Marca"].Value.ToString();
            txtDescripcion.Text = dtgHerramientas.CurrentRow.Cells["Descripcion"].Value.ToString();

            guardando = false;
        }

        private void FrmTaller_Load(object sender, EventArgs e)
        {
            LlenarDtgHerramientas("");
        }

        private void LimpiarCuadro()
        {
            txtNombre.Text = "";
            txtMarca.Text = "";
            txtDescripcion.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCuadro();
        }

        private void EliminarHerramientas()
        {
            if (MessageBox.Show("Desea eliminar la herramienta seleccionado?", "Eliminar herramienta", MessageBoxButtons.YesNo)
                == DialogResult.Yes)
            {
                var idHerramienta = int.Parse(dtgHerramientas.CurrentRow.Cells["id"].Value.ToString());
                _ManejadorHerramientas.EliminarHerramienta(idHerramienta);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarHerramientas();
            LlenarDtgHerramientas("");
        }
    }
}
