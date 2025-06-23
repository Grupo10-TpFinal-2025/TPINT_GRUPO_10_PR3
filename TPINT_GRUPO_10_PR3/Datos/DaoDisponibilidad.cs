using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoDisponibilidad
    {
        private AccesoDatos datos;

        public DaoDisponibilidad()
        {
            datos = new AccesoDatos();
        }

        public SqlDataReader MostrarDisponibilidad(int legajoMedico, string nombreDia)
        {
            SqlDataReader reader;
            SqlConnection conexion;

            try
            {
                conexion = datos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("SP_VerificarDisponibilidad", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@LegajoMedico", legajoMedico);
                comando.Parameters.AddWithValue("@NombreDia", nombreDia);

                reader = comando.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return reader;
        }
    }
}
