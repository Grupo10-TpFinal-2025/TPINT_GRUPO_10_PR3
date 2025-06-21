using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoEspecialidad
    {
        private AccesoDatos datos;

        public DaoEspecialidad()
        {
            datos = new AccesoDatos();
        }

        public SqlDataReader readerEspecialidad()
        {
            return datos.ObtenerLista("SELECT * FROM Especialidad");            
        }
    }
}
