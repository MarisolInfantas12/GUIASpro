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
using AppFichas.Capalogica;


namespace AppFichas.capa_presentacion
{
    public partial class Alumno : Form
    {
        CAlumno a = new CAlumno();
        public Alumno()
        {
            InitializeComponent();
        }
        private void MostrarAlumnos()
        {
            DgvAlumnos.DataSource = a.MostrarAlumno();
        }

        private void Alumno_Load(object sender, EventArgs e)
        {
            cConexion c = new cConexion();
            MostrarAlumnos();
        }
    }
}
