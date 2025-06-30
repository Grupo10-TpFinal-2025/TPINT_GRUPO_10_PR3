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

        //Diferenciador de casos de filtros avanzados
        public DataTable getTablaFiltrada(DateTime? fecha, string dni, string ddl)
        {
            //Variable
            int numero = 0;

            //Identifico el caso
            if (fecha != null && !string.IsNullOrEmpty(dni) && ddl != "0")
            {

                //1 = ambos filtros y dni por medico - 2 ambos filtros y dni por paciente
                if (ddl == "1")
                {
                    numero = 1;
                }
                else
                {
                    numero = 2;
                }

            }
            else if (dni != string.Empty)
            {
                //3 = busqueda solo por dni medico - 4 = busqueda solo por dni paciente
                if (ddl == "1")
                {
                    numero = 3;
                }
                else
                {
                    numero = 4;
                }

            }
            else
            {
                //5 = Busqueda solo por fecha
                numero = 5;

            }

            //Devuelvo
            return daoTurno.getTablaFiltrada(numero, dni, fecha);
        }

        public DataTable getTurnosXMedico(int legajoMedico)
        {
             return daoTurno.getTurnosXMedico(legajoMedico);
        }
    }
}
