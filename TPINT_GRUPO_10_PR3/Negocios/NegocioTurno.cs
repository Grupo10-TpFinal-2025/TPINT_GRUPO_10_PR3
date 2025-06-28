using System;
using System.Collections.Generic;
using System.Data;
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
        
        public List<Turno> ObtenerListaTurnos(int legajoMedico)
        {
            List<Turno> listaTurnosMedico;

            return daoT.ObtenerListaTurnos(legajoMedico);
        }
    }
}