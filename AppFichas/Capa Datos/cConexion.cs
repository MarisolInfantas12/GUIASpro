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

namespace AppFichas.Capa_Datos
{
        class cConexion
        {
            public SqlConnection Conexion { get; set; }
            public SqlDataAdapter Adaptador { get; set; }
            public SqlDataAdapter Adaptador1 { get; set; }
            public SqlCommand Comando { get; set; }
            public DataTable Tabla { get; set; }
            public DataSet Tabla1 { get; set; }
             



        public string CadenaConexion;

            public cConexion()
            {
                CadenaConexion = @"Server=DESKTOP-P6EPV25\SQLEXPRESS;Database=BDFichas;Integrated Security=true";
                Conexion = new SqlConnection(CadenaConexion);
            }
        public SqlConnection Abrirconecxion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }
        public SqlConnection Cerrarconecxion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
       
        public DataTable EjecutarConsultaSql(string CadenaConsulta)
            {
                if (Conexion.State != ConnectionState.Open) Conexion.Open();
                Adaptador = new SqlDataAdapter(CadenaConsulta, Conexion);
                Tabla = new DataTable();
                Adaptador.Fill(Tabla);
                return (Tabla);
            }
     

        public void InsertarDatosFicha(string Nombre_sp,string CodFicha, string Curso, string NombreGuia)
            {
                try
                {
                    // Conecta con el procedimeinto Almacenado
                    SqlCommand oCon = new SqlCommand(Nombre_sp, Conexion);
                    oCon.CommandType = CommandType.StoredProcedure;

                    SqlParameter pCodFicha = new SqlParameter("@CodFicha", SqlDbType.VarChar,6);
                    pCodFicha.Value = CodFicha;
                    oCon.Parameters.Add(pCodFicha);

                    SqlParameter pCurso = new SqlParameter("@Curso", SqlDbType.VarChar, 20);
                    pCurso.Value = Curso;
                    oCon.Parameters.Add(pCurso);

                    SqlParameter pNombreGuia = new SqlParameter("@NombreGuia", SqlDbType.VarChar, 50);
                    pNombreGuia.Value = NombreGuia;
                    oCon.Parameters.Add(pNombreGuia);

                    SqlDataAdapter oDataAdapter = new SqlDataAdapter(oCon);
                    DataSet oData = new DataSet();
                    oDataAdapter.Fill(oData);
                    MessageBox.Show("Datos Guardados..!");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error al guardar datos..?\n" + e.ToString());
                }
                finally
                {
                    Conexion.Close();
                }

            }


            public void ModificarDatosFicha(string Nombre_sp,string CodFicha, string Curso, string NombreGuia)
            {
                try
                {
                    // Conecta con el procedimeinto Almacenado
                    SqlCommand oCon = new SqlCommand(Nombre_sp, Conexion);
                    oCon.CommandType = CommandType.StoredProcedure;

                    SqlParameter pCodFicha = new SqlParameter("@CodFicha", SqlDbType.VarChar,6);
                    pCodFicha.Value = CodFicha;
                    oCon.Parameters.Add(pCodFicha);

                    SqlParameter pCurso = new SqlParameter("@Curso", SqlDbType.VarChar, 20);
                    pCurso.Value = Curso;
                    oCon.Parameters.Add(pCurso);

                    SqlParameter pNombreGuia = new SqlParameter("@NombreGuia", SqlDbType.VarChar, 50);
                    pNombreGuia.Value = NombreGuia;
                    oCon.Parameters.Add(pNombreGuia);

                    SqlDataAdapter oDataAdapter = new SqlDataAdapter(oCon);
                    DataSet oData = new DataSet();
                    oDataAdapter.Fill(oData);
                    MessageBox.Show("Datos Modificados correctamente..!");
                    //oCon.ExecuteNonQuery();
                    //return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error al modificar datos..?\n" + e.ToString());
                }
                finally
                {
                    Conexion.Close();
                }

            }


            public void EliminarDatos(string nombre_sp,string CodFicha)
            {
                try
                {
                    // Conecta con el procedimeinto Almacenado
                    SqlCommand oCon = new SqlCommand(nombre_sp, Conexion);
                    oCon.CommandType = CommandType.StoredProcedure;

                    SqlParameter pCodFicha = new SqlParameter("@CodFicha", SqlDbType.VarChar,6);
                    pCodFicha.Value = CodFicha;
                    oCon.Parameters.Add(pCodFicha);

                   
                    SqlDataAdapter oDataAdapter = new SqlDataAdapter(oCon);

                    DataSet oData = new DataSet();
                    oDataAdapter.Fill(oData);
                    MessageBox.Show("Datos Eliminados correctamente..!");
                    //oCon.ExecuteNonQuery();
                    //return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error al Eliminados datos..!\n" + e.ToString());
                }
                finally
                {
                    Conexion.Close();
                }

            }
        public DataSet RecuperarDatosUsuario(string NombreProc, string CodAdmin, string password)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(NombreProc, Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pCodAadmin = new SqlParameter("@Nombre", SqlDbType.VarChar, 10);
                pCodAadmin.Value = CodAdmin;
                cmd.Parameters.Add(pCodAadmin);

                SqlParameter pContrasena = new SqlParameter("@Contrasena", SqlDbType.VarChar, 10);
                pContrasena.Value = password;
                cmd.Parameters.Add(pContrasena);

                SqlDataAdapter oDataAdapter = new SqlDataAdapter(cmd);
                DataSet oData = new DataSet();
                oDataAdapter.Fill(oData);
                return oData;
            }
            catch (Exception)
            {
                return null;
            }
        }




    }



}
        

   