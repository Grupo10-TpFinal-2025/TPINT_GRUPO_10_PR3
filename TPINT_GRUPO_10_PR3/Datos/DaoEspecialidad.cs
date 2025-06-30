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
        string consultaBase = "SELECT * FROM Especialidad";
        string consultaPorEspecialidad;
       
        public DaoEspecialidad()
        {
            datos = new AccesoDatos();
        }

        public DataTable ObtenerTablaEspecialidad()
        {
            return datos.ObtenerTabla("Especialidad", consultaBase);
        }

        public DataTable ObtenerTablaEspecialidadPorCod(int codEspecialidad)
        {        
            consultaPorEspecialidad = consultaBase + " WHERE CodEspecialidad_ES = " + codEspecialidad;
            return datos.ObtenerTabla("Especialidad", consultaPorEspecialidad);
        }
    }
}
