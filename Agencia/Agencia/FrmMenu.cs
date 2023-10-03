using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agencia
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnTaller_Click(object sender, EventArgs e)
        {
            FrmTaller frmTaller = new FrmTaller();
            frmTaller.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FrmRefacciones frmRefacciones = new FrmRefacciones();
            frmRefacciones.ShowDialog();
        }
    }
}
