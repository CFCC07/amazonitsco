using AmazonItsco_Data_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AmazonItsco_Logica_ClassLibrary.Logica
{
    public class LogicaCategoria
    {
        private static dcAmazonItscoDataContext dc = new dcAmazonItscoDataContext();

        public static List<Categoria> getAllCategoria()
        {
            try
            {
                var resCategorias = dc.Categoria.Where(data => data.cat_status.Equals("A"));
                return resCategorias.ToList();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener lista de categorias" + ex.Message);
            }
        }


        public static Categoria getAllCategoriaXID(int idCategoria)
        {
            try
            {
                var resCategoria = dc.Categoria.FirstOrDefault(data => data.cat_status.Equals("A")
                                                         && data.cat_id.Equals(idCategoria));
                return resCategoria;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener lista de categorias" + ex.Message);
            }
        }

    }
}
