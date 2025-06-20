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
    public class NegocioMedico
    {
        ///---------------------------------------------------- Propiedades -------------------------------------------------------------------------------
        private DaoMedico daoMedico;

        ///--------------------------------------------------- Constructores ------------------------------------------------------------------------------
        public NegocioMedico()
        {
            daoMedico = new DaoMedico();
        }

        ///-------------------------------------------------- Getters y Setters ---------------------------------------------------------------------------------

        ///------------------------------------------------------ Metodos ---------------------------------------------------------------------------------
        public SqlDataReader readerProvincias()
        {
            return daoMedico.readerProvincias();
        }

        public SqlDataReader readerEspecialidad()
        {
            return daoMedico.readerEspecialidad();
        }

    }
}
