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
    class CAlumno
    {
        public cConexion oConexion { get; set; }

        public CAlumno()
        {
            oConexion = new cConexion();
        }
        public DataTable MostrarAlumno()
        {
            return oConexion.EjecutarConsultaSql("Select * from TAlumno");
        }


    }
}
          