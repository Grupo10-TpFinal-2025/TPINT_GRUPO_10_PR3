using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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


    }
}

