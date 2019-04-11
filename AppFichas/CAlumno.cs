using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AppEventosSociales.Clases
{
    class CAlumno
    {
        // Conecta con la base de datos
        SqlConnection oConexion = new SqlConnection("Server=DESKTOP-P6EPV25; Integrated Security=SSPI; DataBase=BDFichas;");

        // Campos
        private string aCodAlumno;
        private string aNombres;


        // Propiedades de la clase

        // Constructor
        public CAlumno()
        {
            aCodAlumno = "";
            aNombres = "";


        }
        public CAlumno(string pCodAlumno, string pNombres)
        {
            aCodAlumno = pCodAlumno;
            aNombres = pNombres;


        }

        public string CodAlumno
        {
            get
            {
                return aCodAlumno;
            }
            set
            {
                aCodAlumno = value;
            }
        }

        public string Nombres
        {
            get
            {
                return aNombres;
            }
            set
            {
                aNombres = value;
            }
        }
    }
}
        
             

          