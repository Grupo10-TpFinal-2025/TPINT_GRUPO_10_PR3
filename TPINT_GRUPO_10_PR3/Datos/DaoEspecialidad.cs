using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoEspecialidad
    {
        AccesoDatos datos;
       
        public DaoEspecialidad()
        {
            datos = new AccesoDatos();
        }

        public DataTable ObtenerTablaEspecialidad()
        {
            return datos.ObtenerTabla("Especialidad", "SELECT * FROM Especialidad");
        }
    }
}
