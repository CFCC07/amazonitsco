using AmazonItsco_Data_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonItsco_Logica_ClassLibrary
{
    public class LogicaProducto
    {
        private static dcAmazonItscoDataContext dc = new dcAmazonItscoDataContext();

        public static List<Producto> getAllProducts()
        {
            try
            {
                var resPro = dc.Producto.Where(data => data.pro_status.Equals("A"));
                return resPro.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener lista de productos" + ex.Message);
            }
        }


        public static List<Producto> getSearchAllProducts(string codeProduct)
        {
            try
            {
                var resPro = dc.Producto.Where(data => data.pro_status.Equals("A")
                                                && data.pro_codigo.StartsWith(codeProduct)
                                                || data.pro_nombre.StartsWith(codeProduct)
                                                || data.Categoria.cat_descripcion.StartsWith(codeProduct)
                                                || data.pro_precioventa.ToString().StartsWith(codeProduct)
                                                );
                return resPro.ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener todos los productos desde form buscar" + ex.Message);
            }
        }

        public static Producto getProductByCode(string codeProduct)
        {
            try
            {
                var resPro = dc.Producto.Where(data => data.pro_status.Equals("A")
                                               && data.pro_codigo.Equals(codeProduct)).
                                               FirstOrDefault();
                return resPro;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener lista de productos" + ex.Message);
            }
        }



        public static Producto getProductById(int idProduct)
        {
            try
            {
                var resPro = dc.Producto.Where(data => data.pro_status.Equals("A")
                                               && data.pro_id.Equals(idProduct)).
                                               FirstOrDefault();
                return resPro;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener lista de productos" + ex.Message);
            }
        }


        public static bool saveProduct(Producto producto)
        {
            try
            {
                bool resPro = false;

                producto.pro_status = 'A';
                producto.pro_add = DateTime.Now;

                dc.Producto.InsertOnSubmit(producto);
                dc.SubmitChanges();

                resPro = true;
                return resPro;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al guardar producto" + ex.Message);
            }

        }


        public static bool updateProduct(Producto producto)
        {
            try
            {
                dc = new dcAmazonItscoDataContext();
                
                bool resPro = false;

                producto.pro_edit = DateTime.Now;
                var resUpdate = dc.Pcd_UpdateProduct(producto.pro_id, producto.pro_codigo,
                                                producto.pro_nombre, producto.pro_descripcion,
                                                producto.pro_peso, producto.pro_preciocompra,
                                                producto.pro_precioventa, producto.pro_edit,
                                                producto.cat_id);

                var resProduct = resUpdate.FirstOrDefault<Pcd_UpdateProductResult>(); //para capturar el 1 que puso en e SP en SQL
                int resultado = resProduct.Resultado;
                if (resultado >0)
                {
                    resPro = true;
                }

                dc.SubmitChanges();

                resPro = true;
                return resPro;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al modificar producto" + ex.Message);
            }

        }


    }
}
