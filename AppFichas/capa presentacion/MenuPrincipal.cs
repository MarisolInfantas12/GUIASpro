using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;//Libreria para mover form
using AppFichas.capa_presentacion;


namespace AppFichas
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            PanelMenu.Width = 70;
            LogoUnsaac.Image = Image.FromFile(@"D:\Escudo.gif");
            LogoUnsaac.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        //=======METODO PARA ARRASTRAR EL FORMULARIO=================
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        // variables de posision
        int lx, ly;
        int sw, sh;

        private void PicCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
            // creacion de variables locales
            int lx;
            int lY;
        }

        private void PicMaximizar_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            PicRestaurar.Visible = true;
            PicMaximizar.Visible = false;
        }
        // pestañas de agregar consultar estado y reportes
        private void AbrirFormHijo(object formhijo)
        {
            if (this.Contenedor.Controls.Count > 0)
                this.Contenedor.Controls.RemoveAt(0);
            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.Contenedor.Controls.Add(fh);
            this.Contenedor.Tag = fh;
            fh.Show();

        }

        private void ManteniminetoGuia_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new capa_presentacion.Guia());
        }

        private void Despliegue_Click(object sender, EventArgs e)
        {
            unsaac.Visible = true;
            if (PanelMenu.Width == 250)
            {
                PanelMenu.Width = 70;
                unsaac.Visible = false;
            }
            else
                PanelMenu.Width = 250;
        }

        private void PanelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        

        private void ListaAlumno_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new capa_presentacion.Alumno());
        }

        private void VentaGuia_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new capa_presentacion.VentasGuias());
        }

        private void AgregarUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new capa_presentacion.NuevoUsuario());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new capa_presentacion.Ayuda());
        }

        private void PicMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PicRestaurar_Click(object sender, EventArgs e)
        {
            // this.WindowState = FormWindowState.Normal;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            PicRestaurar.Visible = false;
            PicMaximizar.Visible = true;
        }
    }
}
