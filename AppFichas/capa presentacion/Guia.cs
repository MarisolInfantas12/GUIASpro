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
    public partial class Guia : Form
    {
        

            CFicha f = new CFicha();
            private string Fi = null;
            private bool editar = false;
            public Guia()
            {
                InitializeComponent();
            }

            public void Limpiar()
            {
                txtCodigo.Text = "";
                txtCurso.Text = "";
                txtGuia.Text = "";

            }
            private void MostrarGuia()
            {
                dgvFicha.DataSource = f.Mostrar();
            }

        
            private void Guia_Load(object sender, EventArgs e)
            {
                cConexion c = new cConexion();
                MostrarGuia();
            }
     
        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            CFicha oU = new CFicha();
            oU.insertarDatos(txtCodigo.Text, txtCurso.Text, txtGuia.Text);
            Limpiar();
            MostrarGuia();
        }

        

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvFicha.SelectedRows.Count > 0)
            {
                editar = true;
                txtCodigo.Text = dgvFicha.CurrentRow.Cells["CodFicha"].Value.ToString();
                txtCurso.Text = dgvFicha.CurrentRow.Cells["Curso"].Value.ToString();
                txtGuia.Text = dgvFicha.CurrentRow.Cells["NombreGuia"].Value.ToString();

            }
            else
            {
                MessageBox.Show("selecionar fila");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvFicha.SelectedRows.Count > 0)
            {
                Fi = dgvFicha.CurrentRow.Cells["CodFicha"].Value.ToString();
                f.EliminarDatos(Fi);

            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvFicha_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }






