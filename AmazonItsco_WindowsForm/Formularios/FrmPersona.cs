using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AmazonItsco_Logica_ClassLibrary;
using AmazonItsco_Logica_ClassLibrary.Logica;
using AmazonItsco_Data_ClassLibrary;

namespace AmazonItsco_WindowsForm.Formularios
{
    public partial class FrmPersona : Form
    {
        public FrmPersona()
        {
            InitializeComponent();
            loadPerson();
        }


        private void savePersona()
        {
            try
            {
                Persona persona = new Persona();

                persona.per_tipodni = cmbTipoDNI.Text == "Cedula" ? "C" : "P";
                persona.per_dni = txtDNI.Text.TrimEnd().TrimStart();
                persona.per_apellidos = txtApellido.Text.ToUpper();
                persona.per_nombres = txtNombre.Text.ToUpper();
                persona.per_genero = cmbGenero.Text == "Masculino" ? Convert.ToChar("M") : Convert.ToChar("F");
                persona.per_fechanacimiento = dtpFechaNacimiento.Value;

                bool res = LogicaPersona.savePersona(persona);

                if (res)
                {
                    MessageBox.Show("Registro guardado correctamente");
                }
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al guardar persona " + ex.Message);
            }

        }



        private void loadPerson() //para cargar los datos de los campos
        {
            try
            {
                Persona persona = new Persona();
                persona = LogicaPersona.getAllPersonXId(3);


                if (persona != null)
                {
                    string tipoDni = persona.per_tipodni == "C" ? "Cedula" : "Pasaporte";
                    cmbTipoDNI.SelectedIndex = cmbTipoDNI.FindString(tipoDni);

                    lblCodigo.Text = persona.per_id.ToString();
                    txtDNI.Text = persona.per_dni;
                    txtApellido.Text = persona.per_apellidos;
                    txtNombre.Text = persona.per_nombres;

                    //string genero = persona.per_genero.Equals("M") ? "Masculino" : "Femenino";
                    string genero = persona.per_genero == Convert.ToChar("M") ? "Masculino" : "Femenino";
                    cmbGenero.SelectedIndex = cmbGenero.FindString(genero);
                }

            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al guardar persona " + ex.Message);
            }
        }





        private void updatePersona()
        {

            try
            {
                int codigoPersona = Convert.ToInt32(lblCodigo.Text);

                if (!string.IsNullOrEmpty(lblCodigo.Text))
                {
                    Persona persona = new Persona();
                    persona = LogicaPersona.getAllPersonXId(codigoPersona);

                    persona.per_tipodni = cmbTipoDNI.Text == "Cedula" ? "C" : "P";
                    persona.per_dni = txtDNI.Text.TrimEnd().TrimStart();
                    persona.per_apellidos = txtApellido.Text.ToUpper();
                    persona.per_nombres = txtNombre.Text.ToUpper();
                    persona.per_genero = cmbGenero.Text == "Masculino" ? Convert.ToChar("M") : Convert.ToChar("F");
                    persona.per_fechanacimiento = dtpFechaNacimiento.Value;

                    bool res = LogicaPersona.updatePersona(persona);

                    if (res)
                    {
                        MessageBox.Show("Registro modificado correctamente");
                    } 
                }
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al modificar persona " + ex.Message);
            }

        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            savePersona();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            updatePersona();
        }
    }
}
