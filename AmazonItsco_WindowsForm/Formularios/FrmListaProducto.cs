using AmazonItsco_Data_ClassLibrary;
using AmazonItsco_Logica_ClassLibrary;
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

    public partial class FrmListaProducto : Form
    {
        public delegate void loadNameProduct(Producto producto);    //debe ser igual que el otro form () //esta generando un apuntador al metodo del otro form
        public event loadNameProduct EventloadNameProduct;          //aparte un evento...
        private Producto dataProducto;


        public FrmListaProducto()
        {
            InitializeComponent();
        }

        private void FrmListaProducto_Load(object sender, EventArgs e)
        {
            var listaProduct = LogicaProducto.getAllProducts();

            loadProducts(listaProduct);
        }

        private void loadProducts(List<Producto> listaProduct)
        {
            try
            {
                if (listaProduct != null && listaProduct.Count > 0)
                {
                    dgvProducto.DataSource = listaProduct.Select(data => new
                    {
                        Codigo = data.pro_codigo,
                        Nombre = data.pro_nombre,
                        Categoria = data.Categoria.cat_descripcion,
                        Precio_Venta = data.pro_precioventa
                    }).ToList();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al cargar la lista de productos" + ex.Message);
            }

        }

        private void dgvProducto_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var codigoProducto = dgvProducto.Rows[e.RowIndex].Cells["Codigo"].Value;
            if (!string.IsNullOrEmpty(codigoProducto.ToString()))
            {
                Producto producto = new Producto();
                producto = LogicaProducto.getProductByCode(codigoProducto.ToString());
                if (producto!=null)
                {
                    dataProducto = new Producto();
                    dataProducto = producto;
                }

            }

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            buscar(txtBuscar.Text);
        }


        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            buscar(txtBuscar.Text);
        }


        private void buscar(string datoBuscar)
        {
            if (!string.IsNullOrEmpty(datoBuscar))
            {
                List<Producto> listaproductos = new List<Producto>();
                listaproductos = LogicaProducto.getSearchAllProducts(datoBuscar);
                loadProducts(listaproductos);
            }

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dataProducto != null)
            {
                EventloadNameProduct(dataProducto);
                this.Close();
            }
        }

    }
}
