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

namespace AppFichas.Capalogica
{
    class CFicha
    {
        public cConexion oConexion { get; set; }
    
        public CFicha()
        {
            oConexion = new cConexion();
        }
        public DataTable Mostrar()
        {
            return oConexion.EjecutarConsultaSql("Select * from TFicha");
        }
        public void insertarDatos(string CodFicha, string Curso, string Nombreguia)
        {
          
            oConexion.InsertarDatosFicha("sp_Ficha_Agregar", CodFicha, Curso, Nombreguia);
           
            
        }

        public void ModificarDatos(string CodFicha, string Curso, string NombreGuia)
        {

            oConexion.InsertarDatosFicha("sp_Ficha_Modificar", CodFicha, Curso, NombreGuia);

        }

        public void EliminarDatos(string CodFicha)
        {
            //comando.Connection = conexion.Abrirconecxion();
            //comando.CommandText = "sp_Ficha_Eliminar";
            //comando.CommandType = CommandType.StoredProcedure;
            //comando.Parameters.AddWithValue("CodFicha", CodFicha);

            //comando.ExecuteNonQuery();
            //comando.Parameters.Clear();
            oConexion.EliminarDatos("sp_Ficha_Eliminar", CodFicha);
            
          

        }
       
       
    }

}

