using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmazonItsco_WindowsForm.Formularios
{
    public partial class FrmMaster : Form
    {
        public FrmMaster()
        {
            InitializeComponent();
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPersona frmPersona = new FrmPersona();
            frmPersona.Show();


        }
    }
}
