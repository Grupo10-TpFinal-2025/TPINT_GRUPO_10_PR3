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
        private readonly DaoDisponibilidad daoD;

        public NegocioDisponibilidad()
        {
            daoD = new DaoDisponibilidad();
        }

        public DataTable ObtenerTablaDisponibilidad()
        {
            return daoD.ObtenerTablaDisponibilidad();
        }

        public DataTable ObtenerTablaDisponibilidad(int codEspecialidad, int diaSeleccionado, int legajoMedico)
        {
            return daoD.ObtenerTablaDisponibilidad(codEspecialidad, diaSeleccionado, legajoMedico);
        }


        public DataTable ObtenerTablaDisponibilidadFiltroAvanzado()
        {
            return daoD.ObtenerTablaDisponibilidadFiltroAvanzado();
        {

        }
        }

        public List<Disponibilidad> ObtenerListaDisponibilidadMedico(int legajoMedico)
        {
            List<Disponibilidad> listaDisponibilidadMedico;

            return listaDisponibilidadMedico = daoD.ObtenerListaDisponibilidadMedico(legajoMedico);
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