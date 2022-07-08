using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AmazonItsco_Data_ClassLibrary;

namespace AmazonItsco_WindowsForm.Formularios
{
    public partial class FrmInventario : Form
    {
        private Producto dataProducto;


        public FrmInventario()
        {
            InitializeComponent();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            FrmListaProducto frmListaProducto = new FrmListaProducto();
            frmListaProducto.EventloadNameProduct += new FrmListaProducto.loadNameProduct(loadNameProduct);
            frmListaProducto.ShowDialog();
        }

        public void loadNameProduct(Producto producto)
        {
            dataProducto = new Producto();
            dataProducto = producto;
            lblProducto.Text = dataProducto.pro_nombre;

        }
    }
}
