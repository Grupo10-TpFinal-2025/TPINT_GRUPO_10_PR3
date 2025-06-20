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
   public class NegocioPaciente
    {
        DaoPaciente daoP;

        public NegocioPaciente()
        {
            daoP = new DaoPaciente();
        }

        // -------------------- Alta Paciente ------------------------------------
        public bool AltaPaciente(Paciente paciente)
        {
            if (daoP.AltaPaciente(paciente) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable getRegistrosProvincias()
        {
            return daoP.getProvincias();
        }
        // ------------------------------------------------------------------------





        //-------------------- Validaciones y Verificaciones Pacientes ----------------------

        // Para evitar repetidos, revisar los metodos existentes antes de crear uno nuevo.
        public bool VerificarExistenciaPacienteXDNI(Paciente paciente)
        {
            return daoP.VerificarExistenciaPacienteXDNI(paciente);
        }
        // ------------------------------------------------------------------------


    }
}


