using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazonItsco_Data_ClassLibrary;
using System.Data.Linq;

namespace AmazonItsco_Logica_ClassLibrary.Logica
{
    public class LogicaPersona
    {
        private static dcAmazonItscoDataContext dc= new dcAmazonItscoDataContext();

        public static List<Persona> getAllPerson()
        {
            try
            {
                var resPer = dc.Persona.Where(data => data.per_status.Equals("A"));
                return resPer.ToList();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener lista de personas" + ex.Message);
            }
        }



        public static Persona getAllPersonXId(int codigo)
        {
            try
            {
                var resPer = dc.Persona.Where(data => data.per_status.Equals("A")
                                                &&data.per_id.Equals(codigo)).FirstOrDefault();
                return resPer;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener personas x id" + ex.Message);
            }
        }



        public static List<Persona> getAllPersonXDni(string cedula)
        {
            try
            {
                var resPer = dc.Persona.Where(data => data.per_status.Equals("A")
                                                && data.per_dni.StartsWith(cedula));
                return resPer.ToList();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener lista de personas x DNI" + ex.Message);
            }
        }



        public static List<Persona> getAllPersonXApellido(string apellido)
        {
            try
            {
                var resPer = dc.Persona.Where(data => data.per_status.Equals("A")
                                                && data.per_apellidos.StartsWith(apellido));
                return resPer.ToList();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener Lista de personas x Apellido" + ex.Message);
            }
        }

        public static bool savePersona(Persona persona)
        {
            try
            {
                bool resPer = false;

                persona.per_status = 'A';
                persona.per_add = DateTime.Now;

                dc.Persona.InsertOnSubmit(persona);
                dc.SubmitChanges();

                resPer = true;
                return resPer;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al guardar persona" + ex.Message);
            }

        }


        public static bool updatePersona(Persona persona)
        {
            try
            {
                bool resPer = false;

                persona.per_edit = DateTime.Now;

                dc.SubmitChanges();

                resPer = true;
                return resPer;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al actualizar persona " + ex.Message);
            }
        }



        public static bool deletePersona(Persona persona)
        {
            try
            {
                bool resPer = false;

                persona.per_delete = DateTime.Now;
                persona.per_status = 'I';

                
                dc.SubmitChanges();

                resPer = true;
                return resPer;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al eliminar persona" + ex.Message);
            }

        }






    }
}
