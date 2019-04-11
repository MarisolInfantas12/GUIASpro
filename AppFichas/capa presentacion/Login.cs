using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using AppFichas.Capa_Datos;
using System.Runtime.InteropServices;//Libreria para mover form
using AppFichas.capa_logica;

namespace AppFichas.capa_presentacion
{
    public partial class Login : Form
    {
        int INTENTOS = 3;
        int Fallidos = 0;
        public Login()
        {
            InitializeComponent();
        }
        //=======METODO PARA ARRASTRAR EL FORMULARIO=================
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            VerificarContrasena();
            //PaginaPrincipal main = new PaginaPrincipal();
            //main.ShowDialog();
            TxtUsuario.Text = "";
            TxtContraseña.Text = "";
        }
        private void VerificarContrasena()
        {
            CLogin login = new CLogin();
            DataSet oDS = new DataSet();

            oDS = login.RecuperarDatosAdminLogin(TxtUsuario.Text, TxtContraseña.Text);

            if (oDS != null)
            {
                if (oDS.Tables[0].Rows.Count == 0)
                {
                    INTENTOS--;
                    Fallidos++;
                    MessageBox.Show("El Usuario o Contraseña es incorrecta\n Nro de Intentos restantes [" + INTENTOS.ToString() + "]");
                    if (INTENTOS == 0)
                    {
                        MessageBox.Show("realizo [" + Fallidos.ToString() + "] intentos fallidos.. Se cerrara la pantalla de LOGIN..");
                        this.Close();
                    }
                }
                else
                {
                    string Nomb = oDS.Tables[0].Rows[0]["Nombre"].ToString();
                    string pass = oDS.Tables[0].Rows[0]["Contrasena"].ToString();
                    MenuPrincipal main = new MenuPrincipal();
                    //Program.frm.Hide();
                    main.ShowDialog();
                }
            }
            else
                MessageBox.Show("Error..");
        }


    }
}
