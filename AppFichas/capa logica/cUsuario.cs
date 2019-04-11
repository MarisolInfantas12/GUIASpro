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
    class cUsuario
    {
        public cConexion oConexion { get; set; }
        public cUsuario()
        {
            oConexion = new cConexion();
        }
       
       
    }
}

