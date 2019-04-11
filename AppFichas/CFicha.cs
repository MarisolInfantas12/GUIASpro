using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AppEventosSociales.Clases
{
    class CFicha
    {
        // Conecta con la base de datos
        SqlConnection oConexion = new SqlConnection("Server=DESKTOP-P6EPV25; Integrated Security=true; DataBase=BDFichas;");

        // Campos
        private string aCodFicha;
        private string aCurso;
        private string aNombreGuia;
       

        // Propiedades de la clase

        // Constructor
        public CFicha()
        {
            aCodFicha = "";
            aCurso = "";
            aNombreGuia = "";                
        }
        public CFicha(string pCodFicha, string pCurso, string pNombreGuia)
        {
            aCodFicha = pCodFicha;
            aCurso = pCurso;
            aNombreGuia = pNombreGuia;
            
            

        }

        public string CodFicha
        {
            get
            {
                return aCodFicha;
            }
            set
            {
                aCodFicha = value;
            }
        }

        public string Curso
        {
            get
            {
                return aCurso;
            }
            set
            {
                aCurso = value;
            }
        }
        public string NombreGuia
        {
            get
            {
                return aNombreGuia;
            }
            set
            {
                aNombreGuia = value;
            }
        }

       
        // Metodos de la clase que agrega datos al alumno
        public bool Agregar()
        {

            // Conecta con el procedimeinto Almacenado
            SqlCommand oCon = new SqlCommand("sp_Ficha_Agregar", oConexion);
            oCon.CommandType = CommandType.StoredProcedure;

            // Crea los parametros para el procedimiento almacenado
            SqlParameter pCodFicha = new SqlParameter("@CodFicha", SqlDbType.VarChar, 6);
            pCodFicha.Value = aCodFicha;
            oCon.Parameters.Add(pCodFicha);
            SqlParameter pCurso = new SqlParameter("@Curso", SqlDbType.NVarChar, 50);
            pCurso.Value = aCurso;
            oCon.Parameters.Add(pCurso);
            SqlParameter pNombreGuia = new SqlParameter("@NombreGuia", SqlDbType.NVarChar, 50);
            pNombreGuia.Value = aNombreGuia;
            oCon.Parameters.Add(pNombreGuia);
            // Abre la conexion con la base de datos
            oConexion.Open();
            try
            {
                oCon.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                // Cierra la conexion con la base de datos
                oConexion.Close();
            }
        }

        
        // Metodo que elimina los datos de una Ficha
        public bool Eliminar()
        {
            // Conecta con el procedimeinto ALMACENADO
            SqlCommand oCon = new SqlCommand("sp_Ficha_Eliminar", oConexion);
            oCon.CommandType = CommandType.StoredProcedure;

            // Crea los parametros para el procedimiento almacenado
            SqlParameter pCodFicha = new SqlParameter("@CodFicha", SqlDbType.VarChar, 6);
            pCodFicha.Value = aCodFicha;
            oCon.Parameters.Add(pCodFicha);

            // Abre la conexion con la base de datos
            oConexion.Open();
            // Verifica si hay algun error
            try
            {
                oCon.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                // Cierra la conexion con la base de datos
                oConexion.Close();
            }
        }

        public string GenerarCodigo(string Codigo, string Prefijo, int Tamaño)
        {
            try
            {
                // SQL Commad para recuperar es cliente
                SqlCommand oComm = new SqlCommand("sp_GenerarCodigoFicha", oConexion);
                // Define el procedimiento almacenado
                oComm.CommandType = CommandType.StoredProcedure;
                // Crea los parametros
                SqlParameter pCodigo = new SqlParameter("@Codigo", SqlDbType.NVarChar, 6);
                pCodigo.Value = Codigo;
                pCodigo.Direction = ParameterDirection.Output;
                oComm.Parameters.Add(pCodigo);
                SqlParameter pPrefijo = new SqlParameter("@Prefijo", SqlDbType.NVarChar, 5);
                pPrefijo.Value = Prefijo;
                pPrefijo.Direction = ParameterDirection.Input;
                oComm.Parameters.Add(pPrefijo);
                SqlParameter pTamaño = new SqlParameter("@Tamaño", SqlDbType.TinyInt, 0);
                pTamaño.Value = Tamaño;
                pTamaño.Direction = ParameterDirection.Input;
                oComm.Parameters.Add(pTamaño);
                // Abre la conneccion con la base de datos
                oConexion.Open();
                // Verifica si hay algun error
                oComm.ExecuteScalar();
                return Convert.ToString(oComm.Parameters["@Codigo"].Value);
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                // Cierra la conexion con la base de datos
                oConexion.Close();
            }
        }
        // Metodos para obtener reportes de los clientes
        public DataSet Reporte()
        {
            try
            {
                SqlCommand oComm = new SqlCommand("sp_Ficha_Listar", oConexion);
                oComm.CommandType = CommandType.StoredProcedure;
                // Data Adapter donde carga los datos de los alumnos
                SqlDataAdapter oAdapter = new SqlDataAdapter(oComm);
                // Data set que contiene los datos de los alumnos
                DataSet oData = new DataSet();
                // Llena el data set
                oAdapter.Fill(oData, "TFicha");
                // Retorna el data set
                return oData;
            }
            catch
            {

                return null;
            }
        }

        // Metodo que actualiza los datos de los servicios
        public bool Actualizar()
        {
            // Conecta con el procedimeinto ALMACENADO
            SqlCommand oCon = new SqlCommand("sp_Ficha_Modificar", oConexion);
            oCon.CommandType = CommandType.StoredProcedure;

            // Crea los parametros para el procedimiento almacenado
            SqlParameter pCodFicha = new SqlParameter("@CodFicha", SqlDbType.VarChar, 6);
            pCodFicha.Value = aCodFicha;
            oCon.Parameters.Add(pCodFicha);
            SqlParameter pCurso = new SqlParameter("@Curso", SqlDbType.NVarChar, 50);
            pCurso.Value = aCurso;
            oCon.Parameters.Add(pCurso);
            SqlParameter pNombreGuia = new SqlParameter("@NombreGuia", SqlDbType.NVarChar, 11);
            pNombreGuia.Value = aNombreGuia;
            oCon.Parameters.Add(pNombreGuia);
             // Abre la conexion con la base de datos
            oConexion.Open();
            try
            {
                // Ejecuta el procedimiento almacenado
                oCon.ExecuteNonQuery();
                return true;
            }
            catch
            {
                // Mensaje de error                
                return false;
            }
            finally
            {
                // Cierra la conexion con la base de datos
                oConexion.Close();
            }
        }

        

    }
}
