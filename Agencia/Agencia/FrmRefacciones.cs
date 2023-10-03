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
using Manejador;
namespace Agencia
{
    public partial class FrmRefacciones : Form
    {
        private ManejadorProducto _ManejadorProducto;
        private int ID = 0;
        bool guardando = true;
        public FrmRefacciones()
        {
            InitializeComponent();
            _ManejadorProducto = new ManejadorProducto();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Focus();
            LimpiarCuadro();
        }

        private void LlenarProducto(string valor)
        {
            dtgProductos.DataSource = _ManejadorProducto.ObtenerProducto(valor);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (guardando)
            {
                EntidadesProducto entidadProducto = new EntidadesProducto();

                entidadProducto.Id = 0;
                entidadProducto.Nombre = txtNombre.Text;
                entidadProducto.Medida = txtMedida.Text;
                entidadProducto.Marca = txtMarca.Text;
                entidadProducto.Descripcion = txtDescripcion.Text;

                _ManejadorProducto.GuardarProducto(entidadProducto);
                LlenarProducto("");
            }
            else
            {
                ActualizarProducto();
            }
        }

        private void ActualizarProducto()
        {
            EntidadesProducto entidadesProducto = new EntidadesProducto();
            ID = int.Parse(dtgProductos.CurrentRow.Cells["id"].Value.ToString());
            entidadesProducto.Id = ID;
            entidadesProducto.Nombre = txtNombre.Text;
            entidadesProducto.Medida = txtMedida.Text;
            entidadesProducto.Marca = txtMarca.Text;
            entidadesProducto.Descripcion = txtDescripcion.Text;

            var validar = _ManejadorProducto.ValidarDatosProductos(entidadesProducto);
            if (validar.Item1)
                try
                {
                    _ManejadorProducto.ActualizarProducto(entidadesProducto);
                    LlenarProducto("");
                    MessageBox.Show("Actualizado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                guardando = true;
        }

        private void dtgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombre.Focus();
            txtNombre.Text = dtgProductos.CurrentRow.Cells["Nombre"].Value.ToString();
            txtMedida.Text = dtgProductos.CurrentRow.Cells["Medida"].Value.ToString();
            txtMarca.Text = dtgProductos.CurrentRow.Cells["Marca"].Value.ToString();
            txtDescripcion.Text = dtgProductos.CurrentRow.Cells["Descripcion"].Value.ToString();

            guardando = false;
        }

        private void FrmRefacciones_Load(object sender, EventArgs e)
        {
            LlenarProducto("");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LimpiarCuadro()
        {
            txtNombre.Text = "";
            txtMarca.Text = "";
            txtMedida.Text = "";
            txtDescripcion.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCuadro();
        }

        private void EliminarProducto()
        {
            if (MessageBox.Show("Desea eliminar el producto seleccionado?", "Eliminar producto", MessageBoxButtons.YesNo)
                == DialogResult.Yes)
            {
                var idProducto = int.Parse(dtgProductos.CurrentRow.Cells["id"].Value.ToString());
                _ManejadorProducto.EliminarProducto(idProducto);
                LlenarProducto("");
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarProducto();
            LimpiarCuadro();
        }
    }
}
