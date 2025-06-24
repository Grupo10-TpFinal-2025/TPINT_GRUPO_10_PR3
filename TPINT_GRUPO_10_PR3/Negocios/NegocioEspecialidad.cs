using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;
using System.Data;
using System.Data.SqlClient;

namespace Negocios
{
    public class NegocioEspecialidad
    {
        DaoEspecialidad DaoE;

        public NegocioEspecialidad()
        {
            DaoE = new DaoEspecialidad();
        }

        public SqlDataReader ObtenerListaEspecialidad()
        {
            return DaoE.ObtenerListaEspecialidad();
        }
    }
}
