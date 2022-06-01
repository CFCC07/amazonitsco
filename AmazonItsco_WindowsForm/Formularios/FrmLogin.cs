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
                    
                    MessageBox.Show("Bienvenido al Sistema. \n" + usuario.Perfil.prf_descripcion + "\n" + usuario.Persona.per_apellidos, "Sistema Amazon Itsco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmMaster frmMaster = new FrmMaster();
                    frmMaster.Show();
                    this.Hide();
                }
                else
                {
                    usuario = LogicaUsuario.getUserbyUsername(correo);
                    int intentos = Convert.ToInt32(usuario.per_intentos);
                    intentos = intentos + 1;


                    if (intentos <=3)
                    {
                        
                        usuario.per_intentos = (byte?)intentos;
                        bool resUsu = LogicaUsuario.updateIntentoUsuario(intentos);
                        MessageBox.Show("Correo o clave incorrectos. Ud ha realizado: \n" + intentos + " intentos fallidos", "Sistema Amazon Itsco", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        usuario.per_intentos = (byte?)intentos;
                        usuario.usu_status = 'I';
                        bool resUsu = LogicaUsuario.updateIntentoUsuario(intentos);
                        MessageBox.Show("Correo o clave incorrectos. Ud ha realizado: \n" + intentos + " intentos fallidos. Por favor contacte al administrador", "Sistema Amazon Itsco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Hide();
                    }
                }
            }
            else 
            {
                MessageBox.Show("Correo y clave son campos oblogatorios", "Sistema Amazon Itsco",MessageBoxButtons.OK,MessageBoxIcon.Error);           
                
            
            }
        }


           

        private void btnCancelar_Click(object sender, EventArgs e) //en realidad es el boton btnAceptar pero no me deja cambiar el nombre da error
        {
            login();
        }


        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
