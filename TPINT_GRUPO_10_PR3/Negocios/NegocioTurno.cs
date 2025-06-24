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
    public class NegocioTurno
    {
        private DaoTurno daoT;

        public NegocioTurno()
        {
            daoT = new DaoTurno();
        }
        
        public SqlDataReader ObtenerListaTurnos(int legajoMedico, string nombreDia)
        {
            return daoT.ObtenerListaTurnos(legajoMedico, nombreDia);
        }
    }
}

    

