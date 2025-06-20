using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocios
{
    class NegocioDisponibilidad
    {
        DaoDisponibilidad daoD;

        NegocioDisponibilidad()
        {
            daoD = new DaoDisponibilidad();
        }
        
    }
}
