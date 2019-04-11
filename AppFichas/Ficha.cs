using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using AppEventosSociales.Clases;

namespace AppFichas
{
    public partial class Ficha : Form
    {
        // Declaracion de la clase
        
        CFicha oFicha = new CFicha();
        public Ficha()
        {
            InitializeComponent();
        }
       
        private void Copiar()
        {
            // Muestra los datos del grid en los Controles Text Box
            if (dgvFicha.RowCount > 1)
            {
                //copiar contenido de la grilla a los cuadros de texto
                txtCodigo.Text = Convert.ToString(dgvFicha.CurrentRow.Cells[0].Value);
                txtCurso.Text = Convert.ToString(dgvFicha.CurrentRow.Cells[1].Value);
                txtGuia.Text = Convert.ToString(dgvFicha.CurrentRow.Cells[2].Value);
            }
        }

        private void LimpiarControles()
        {
            // Limpia los controles
            txtCurso.Clear();
            txtGuia.Clear();
            txtCodigo.Clear();

        }
        private void Refrescar()
        {
            // Cambia el estado del mantenimiento
            btnAgregar.Text = "&Modificar";
            dgvFicha.DataSource = oFicha.Reporte().Tables[0];

            dgvFicha.Enabled = true;
            txtCodigo.Enabled = false;
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Actualiza el Opcion
            btnAgregar.Text = "&Agregar";

            // Deshabilita el dgd
            dgvFicha.Enabled = false;
            // Limpia Controles
            LimpiarControles();
            txtCodigo.Text = oFicha.GenerarCodigo("", "F", 6);
            txtGuia.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Asignar propiedades
            if (txtCodigo.Text != "")
            {
                oFicha.CodFicha = txtCodigo.Text.ToUpper().Trim();
                oFicha.Curso = txtCurso.Text.ToUpper().Trim();
                oFicha.NombreGuia = txtGuia.Text.ToUpper().Trim();
               

                if (btnAgregar.Text == "&Agregar")
                {
                    if (oFicha.Agregar())
                        MessageBox.Show("Los datos se guardaron satisfactoriamente", "Ventana de Mensaje");

                    else
                        MessageBox.Show("Error al guardar los datos", "Ventana de Mensaje");
                }
                else
                {
                    // Modifica el cliente    
                    if (oFicha.Actualizar())
                        MessageBox.Show("Los datos se modificaron satisfactoriamente", "Ventana de Mensaje");

                    else
                        MessageBox.Show("Error al modificar los datos", "Ventana de Mensaje");
                }
                Refrescar();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            DialogResult iRespuesta;

            // Asignar propiedades
            if (txtCodigo.Text.Trim() != "")
            {
                oFicha.CodFicha = txtCodigo.Text.ToUpper().Trim();
                iRespuesta = MessageBox.Show("¿Desea Eliminar?", "Eliminar", MessageBoxButtons.YesNo);
                // Verifica la opcion
                if (iRespuesta == DialogResult.Yes)
                {
                    // Elimina los datos del servicio
                    if (oFicha.Eliminar())
                        MessageBox.Show("Los datos se eliminaron satisfactoriamente", "Ventana de Mensaje");

                    else
                        MessageBox.Show("Error al eliminar los datos", "Ventana de Mensaje");

                }
                // Refresca y limpia los controles
                Refrescar();
                LimpiarControles();
            }
        }
    }
    }
    
            

