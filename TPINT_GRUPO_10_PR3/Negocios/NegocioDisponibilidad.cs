using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;


namespace Negocios
{
   public class NegocioDisponibilidad
    {
        DaoDisponibilidad daoD;

       public NegocioDisponibilidad()
        {
            daoD = new DaoDisponibilidad();
        }

        public DataTable ObtenerTablaDisponibilidad()
        {
            return daoD.ObtenerTablaDisponibilidad();
        }


        public DataTable ObtenerTablaDisponibilidad(int codEspecialidad, int diaSeleccionado)
        {

            return daoD.ObtenerTablaDisponibilidad(codEspecialidad, diaSeleccionado);
        }
 

       

        public DataTable ObtenerDisponibilidad(Disponibilidad disponibilidad)
        {
            return daoD.Obtener_Disponibilidad(disponibilidad);
        }

        public int BajaLogicaDisponibilidad(Disponibilidad disponibilidad)
        {
            return daoD.BajaLogicaDisponibilidad(disponibilidad);
        }

        public DataTable ObtenerDias()
        {
            return daoD.ObtenerDias();
        }

        public int AltaDisponibilidad(Disponibilidad disponibilidad)
        {
            return daoD.AgregarDisponibilidad(disponibilidad);
        }

        public bool VerificarDisponibilidad(int legajoMedico, int numDia)
        {
            return daoD.ExisteDisponibilidad(legajoMedico, numDia);
        }
    }
}

