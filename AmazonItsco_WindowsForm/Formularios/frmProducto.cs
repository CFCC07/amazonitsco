using AmazonItsco_Data_ClassLibrary;
using AmazonItsco_Logica_ClassLibrary;
using AmazonItsco_Logica_ClassLibrary.Logica;
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
    public partial class frmProducto : Form
    {

        public frmProducto()
        {
            InitializeComponent();
            loadCategoria();
            loadProduct(3);

        }

        private void loadCategoria()
        {
            List<Categoria> listaCategoria = new List<Categoria>();
            listaCategoria = LogicaCategoria.getAllCategoria();

            if (listaCategoria.Count > 0 && listaCategoria != null)
            {

                var listaOrdenada = listaCategoria.OrderBy(data => data.cat_descripcion).ToList();  //...descripcion)..ThenBy(data=>data.cat_detalle);     //para ordenar por un segundo criterio

                listaOrdenada.Insert(0, new Categoria {
                    cat_id = 0,
                    cat_descripcion = "SELECCIONE CATEGORIA"

                });

                cmbCategoria.DataSource = listaOrdenada;
                cmbCategoria.DisplayMember = "cat_descripcion";
                cmbCategoria.ValueMember = "cat_id";

            }

        }


        private void loadProduct(int codigoProduct)
        {
            if (codigoProduct >0)
            {
                Producto producto = new Producto();
                producto = LogicaProducto.getProductById(codigoProduct);
                if (producto != null)
                {
                    lblcodigo.Text = producto.pro_id.ToString();
                    txtCodigo.Text = producto.pro_codigo;
                    txtNombre.Text = producto.pro_nombre;
                    txtDescripcion.Text = producto.pro_descripcion;
                    txtPeso.Text = producto.pro_peso.ToString();
                    txtPrecioCompra.Text = producto.pro_preciocompra.ToString();
                    txtPrecioVenta.Text = producto.pro_precioventa.ToString();
                    cmbCategoria.SelectedIndex = cmbCategoria.FindString(producto.Categoria.cat_descripcion);   // revisar, entender
   
                }
            }
        }

        private void limpiarCampos() {

            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPeso.Clear();
            txtPrecioCompra.Clear();
            txtPrecioVenta.Clear();
            cmbCategoria.SelectedIndex = 0;
            lblcodigo.Text = "";

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }


        private void frmProducto_Load(object sender, EventArgs e)
        {

        }

        private bool validarCampos()
        {
            bool result = false;
            string messageError = "";

            if (cmbCategoria.SelectedIndex==0)
            {
                messageError += "*Seleccione una categoria.\n";   //el mensaje de error se va acumulando
            }


            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                messageError += "Codigo Campo Obligatorio.\n";   //el mensaje de error se va acumulando
            }

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                messageError += "Nombre Campo Obligatorio.\n";
            }

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                messageError += "Descripcion Campo Obligatorio.\n";
            }

            if (string.IsNullOrEmpty(txtPeso.Text))
            {
                messageError += "Peso Campo Obligatorio.\n";
            }

            if (string.IsNullOrEmpty(txtPrecioCompra.Text))
            {
                messageError += "Precio Compra Campo Obligatorio.\n";
            }

            if (string.IsNullOrEmpty(txtPrecioVenta.Text))
            {
                messageError += "PrecioVenta Campo Obligatorio.\n";
            }

            if (!string.IsNullOrEmpty(messageError))
            {
                result = true;
                MessageBox.Show(messageError, "Sistema Amazon Itsco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }


        private void Guardar()
        {
            if (!string.IsNullOrEmpty(lblcodigo.Text))
            {
                updateProducto();
            }
            else
            {
                guardarProducto();
            }
        }


        private void guardarProducto()
        {
            try
            {       
                Producto producto = new Producto();
                producto.cat_id = Convert.ToInt16(cmbCategoria.SelectedValue);   //ToInt16parasmallint; ToInt32para bigint;
                producto.pro_codigo = txtCodigo.Text.ToUpper();
                producto.pro_nombre = txtNombre.Text.ToUpper();
                producto.pro_descripcion = txtDescripcion.Text.ToUpper();
                producto.pro_peso = Convert.ToDecimal(txtPeso.Text);
                producto.pro_preciocompra = Convert.ToDecimal(txtPrecioCompra.Text);
                producto.pro_precioventa = Convert.ToDecimal(txtPrecioVenta.Text);

                var resSaveProducto = LogicaProducto.saveProduct(producto);

                if (resSaveProducto)
                {
                    MessageBox.Show("Registro producto guardado correctamente");
                    limpiarCampos();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar producto" + ex.Message);
            }


        }


        private void updateProducto()
        {
            try
            {
                Producto producto = new Producto();

                producto.pro_id = int.Parse(lblcodigo.Text);
                producto.cat_id = Convert.ToInt16(cmbCategoria.SelectedValue);   //ToInt16parasmallint; ToInt32para bigint;
                producto.pro_codigo = txtCodigo.Text.ToUpper();
                producto.pro_nombre = txtNombre.Text.ToUpper();
                producto.pro_descripcion = txtDescripcion.Text.ToUpper();
                producto.pro_peso = Convert.ToDecimal(txtPeso.Text);
                producto.pro_preciocompra = Convert.ToDecimal(txtPrecioCompra.Text);
                producto.pro_precioventa = Convert.ToDecimal(txtPrecioVenta.Text);

                var resSaveProducto = LogicaProducto.updateProduct(producto);

                if (resSaveProducto)
                {
                    MessageBox.Show("Registro producto modificado correctamente");
                    limpiarCampos();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar producto" + ex.Message);
            }


        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                return;
            }
            Guardar();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }



        private void saltoTextbox(TextBox text)
        {
            text.Focus();
        }

        #region SaltoTextbox
        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saltoTextbox(txtNombre);
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saltoTextbox(txtDescripcion);
            }
        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saltoTextbox(txtPeso);
            }
        }

        private void txtPeso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saltoTextbox(txtPrecioCompra);
            }
        }

        private void txtPrecioCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saltoTextbox(txtPrecioVenta);
            }
        }

        private void txtPrecioVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saltoTextbox(txtCodigo);
            }
        }
        #endregion

    }
}
