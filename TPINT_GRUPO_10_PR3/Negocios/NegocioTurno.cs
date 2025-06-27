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
    public class NegocioTurno
    {
        DaoTurno daoTurno = new DaoTurno();

        //Devuelvo la tabla
        public DataTable getTabla()
        {
            //Creo el objeto de acceso a datos y le pido que devuelva el dato
            return daoTurno.getTabla();
        }

        //Devuelvo la tabla filtrada
        public DataTable getTablaPorCodigoTurno(int numero)
        {
           return daoTurno.getTablaPorCodigoTurno(numero);
        }
    }
}
