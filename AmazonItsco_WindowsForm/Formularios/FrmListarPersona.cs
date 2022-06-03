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
    public partial class FrmListarPersona : Form
    {
        public FrmListarPersona()
        {
            InitializeComponent();

        }
        private void loadPerson()
        {

            var listaPersonas = LogicaPersona.getAllPerson();
            if (listaPersonas.Count > 0 && listaPersonas != null)
            {
                dgvPersonas.DataSource = listaPersonas;
            }

        }

        private void FrmListarPersona_Load(object sender, EventArgs e)
        {
            loadPerson();
        }
    }
}
