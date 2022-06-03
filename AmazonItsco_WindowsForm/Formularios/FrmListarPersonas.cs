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
using AmazonItsco_Logica_ClassLibrary;
using AmazonItsco_Logica_ClassLibrary.Logica;

namespace AmazonItsco_WindowsForm.Formularios
{
    public partial class FrmListarPersonas : Form
    {
        public FrmListarPersonas()
        {
            InitializeComponent();
        }

        private void loadPerson(List<Persona> listaPersonas)
        {
            //var listaPersonas = LogicaPersona.getAllPerson(); ya no la utiliza porque la funcion viene con el parametro listaPersonas
            if (listaPersonas.Count >0 && listaPersonas != null)
            {
                dgvPersonas.DataSource = listaPersonas.Select(data => new
                {
                    CODIGO = data.per_id,
                    APELLIDOS = data.per_apellidos,
                    NOMBRES = data.per_nombres,
                    IDENTIFICACION = data.per_dni,
                    TIPO = data.per_tipodni,
                    GENERO = data.per_genero,
                }).ToList();

            }

        }

        private void FrmListarPersonas_Load(object sender, EventArgs e)
        {
            var listaPersonas = LogicaPersona.getAllPerson();
            loadPerson(listaPersonas);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarPersona(cmbTipoBuscar.Text);
        }


        private void buscarPersona(string op)
        {
            List<Persona> listaPersona = new List<Persona>();      
            string dataABuscar = txtBuscar.Text.TrimEnd();


            if (!string.IsNullOrEmpty(dataABuscar))
            {
                switch (op)
                {
                    case "Cedula":
                        listaPersona = LogicaPersona.getAllPersonXDni(dataABuscar);
                        loadPerson(listaPersona);

                        break;

                    case "Apellido":
                        listaPersona = LogicaPersona.getAllPersonXApellido(dataABuscar);
                        loadPerson(listaPersona);

                        break;

                    case "Nombre":
                        listaPersona = LogicaPersona.getAllPersonXNombre(dataABuscar);
                        loadPerson(listaPersona);

                        break;

                    case "Genero":
                        listaPersona = LogicaPersona.getAllPersonXGenero(dataABuscar);
                        loadPerson(listaPersona);

                        break;


                    case "Todos":
                        listaPersona = LogicaPersona.getAllPerson();
                        txtBuscar.Text = "";
                        loadPerson(listaPersona);

                        break;
                        

                }


            }



        }

    }
}
