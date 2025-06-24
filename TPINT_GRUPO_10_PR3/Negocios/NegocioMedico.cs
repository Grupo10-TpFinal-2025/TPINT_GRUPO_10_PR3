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
    public class NegocioMedico
    {
        ///---------------------------------------------------- Propiedades -------------------------------------------------------------------------------
        private DaoMedico daoM;

        ///--------------------------------------------------- Constructores ------------------------------------------------------------------------------
        public NegocioMedico()
        {
            daoM = new DaoMedico();
        }

        ///-------------------------------------------------- Getters y Setters ---------------------------------------------------------------------------------

        ///------------------------------------------------------ Metodos ---------------------------------------------------------------------------------
        public SqlDataReader readerProvincias()
        {
            return daoM.readerProvincias();
        }

        public SqlDataReader readerEspecialidad()
        {
            return daoM.readerEspecialidad();
        }

        public SqlDataReader ObtenerListaMedicoPorEspecialidad(string cod)
        {
            return daoM.ObtenerListaMedicoPorEspecialidad(cod);
        }

        public bool AgregarMedico(Medico medico)
        {
            return daoM.AgregarMedico(medico);
        }

    }
}
