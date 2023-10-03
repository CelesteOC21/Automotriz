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
    public partial class FrmLogin : Form
    {
        //FrmMenu Menu = new FrmMenu();
        private ManejadorUsuarios _manejadorUsuarios;
        public FrmLogin()
        {
            InitializeComponent();
            _manejadorUsuarios = new ManejadorUsuarios();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            bool sesion = _manejadorUsuarios.VerificarUsuarios(txtNombre.Text, txtClave.Text);
            if(sesion == true )
            {
                FrmMenu menu = new FrmMenu();
                this.Hide();
                menu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario o clave incorrectos, verifique sus datos!");
            }

        }
    }
}
