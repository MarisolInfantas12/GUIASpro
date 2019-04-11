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

namespace AppFichas.capa_logica
{
    class CLogin
    {
        public string pAdmin { get; set; }
        public string pPassword { get; set; }

        public cConexion oConexion { get; set; }

        public CLogin()
        {
            oConexion = new cConexion();
        }

        public DataSet RecuperarDatosAdminLogin(string Admin, string password)
        {
            return oConexion.RecuperarDatosUsuario("sp_consultar_Usuario", Admin, password);
        }
    }
}
    
