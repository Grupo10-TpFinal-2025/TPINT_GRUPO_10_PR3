using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocios
{
   public class NegocioDisponibilidad
    {
        DaoDisponibilidad daoD;

       public NegocioDisponibilidad()
        {
            daoD = new DaoDisponibilidad();
        }
        
        public List<Disponibilidad> ObtenerListaDisponibilidadMedico(int legajoMedico)
        {
            List<Disponibilidad> listaDisponibilidadMedico;
            
            return listaDisponibilidadMedico = daoD.ObtenerListaDisponibilidadMedico(legajoMedico);            
        }
    }
}

