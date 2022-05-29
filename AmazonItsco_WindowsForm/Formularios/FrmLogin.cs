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
using AmazonItsco_Logica_ClassLibrary.Logica;//pense que con la anterior libreria seria suficiente pero tuve que llamar a esta (ver el namespace de la clase logica usuarios)


namespace AmazonItsco_WindowsForm.Formularios
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void login() 
        {
            string correo = txtCorreo.Text.TrimEnd();
            String clave = txtClave.Text;

            if (!string.IsNullOrEmpty(correo) && !string.IsNullOrEmpty(clave))
            {
                Usuario usuario = new Usuario();
                usuario = LogicaUsuario.getUserbyUsernameAndPassword(correo, clave);
                if (usuario != null)
                {
                    MessageBox.Show("Bienvenido al Sistema", "Sistema Amazon Itsco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmMaster frmMaster = new FrmMaster();
                    frmMaster.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Correo o clave incorrectos", "Sistema Amazon Itsco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                MessageBox.Show("Correo y clave son campos oblogatorios", "Sistema Amazon Itsco",MessageBoxButtons.OK,MessageBoxIcon.Error);           
            }
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            login();
        }
    }
}
