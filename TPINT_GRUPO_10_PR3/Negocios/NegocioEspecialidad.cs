using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data;

namespace Negocios
{
    public class NegocioEspecialidad
    {
        DaoEspecialidad daoE;

        public NegocioEspecialidad()
        {
            daoE = new DaoEspecialidad();
        }

        public DataTable ObtenerEspecialidades()
        {
            return daoE.ObtenerTablaEspecialidad();
        }
            
    }
}
