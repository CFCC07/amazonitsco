using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazonItsco_Data_ClassLibrary;


namespace AmazonItsco_Logica_ClassLibrary.Logica
{
    public class LogicaUsuario
    {
        
        private static dcAmazonItscoDataContext dc = new dcAmazonItscoDataContext();


        public static Usuario getUserbyUsernameAndPassword(string correo, string clave)
        {
            try
            {
                var resUser = dc.Usuario.Where(data => data.usu_correo.Equals(correo)
                                        && data.usu_clave.Equals(clave)
                                        && data.usu_status.Equals("A")).
                                        FirstOrDefault(); //si no hay datos te devuelve un null                                           )
                return resUser;

            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener usuario");
            }

        }



        public static Usuario getUserbyUsername(string correo)
        {
            try
            {
                var resUser = dc.Usuario.Where(data => data.usu_correo.Equals(correo)
                                        && data.usu_status.Equals("A")).
                                        FirstOrDefault(); //si no hay datos te devuelve un null


                return resUser;

            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener usuario");
            }

        }






        //profesor
        public static bool updateUsuario(Usuario usuario)
        {
            try
            {
                bool resUsu = false;

                usuario.usu_edit = DateTime.Now;

                dc.SubmitChanges();

                resUsu = true;
                return resUsu;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al actualizar usuario " + ex.Message);
            }
        }


        public static bool updateIntentoUsuario(int intento)
        {
            Usuario usuario = new Usuario();

            try
            {
                bool resUsu = false;

                usuario.per_intentos = (byte?)intento;

                dc.SubmitChanges();

                resUsu = true;
                return resUsu;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al actualizar usuario " + ex.Message);
            }
        }

    }
}
