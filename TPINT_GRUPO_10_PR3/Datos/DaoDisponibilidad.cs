using Entidades;
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

        public List<Disponibilidad> ObtenerListaDisponibilidadMedico(int legajoMedico)
        {
            List<Disponibilidad> listaDisponibilidadMedico = new List<Disponibilidad>();

            SqlConnection conexion = null;
            SqlCommand comando;
            SqlDataReader lector;

            try
            {
                string consulta = "SELECT NumDia_DIS, LegajoMedico_DIS, HorarioInicio_DIS, HorarioFin_DIS, Estado_DIS, Descripcion_DI FROM Disponibilidad INNER JOIN Dia ON NumDia_DI = NumDia_DIS WHERE @LegajoMedico = LegajoMedico_DIS ORDER BY NumDia_DIS ASC";
                conexion = datos.ObtenerConexion();
                comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@LegajoMedico", legajoMedico);
                lector = comando.ExecuteReader();

                using (lector)
                {
                    while (lector.Read())
                    {
                        if ((bool)lector["Estado_DIS"])
                        {
                            Disponibilidad disponibilidad = new Disponibilidad();
                            disponibilidad.NumDia = (int)lector["NumDia_DIS"];
                            disponibilidad.NombreDia = (string)lector["Descripcion_DI"];
                            disponibilidad.LegajoMedico = (int)lector["LegajoMedico_DIS"];
                            disponibilidad.HorarioInicio = (TimeSpan)lector["HorarioInicio_DIS"];
                            disponibilidad.HorarioFin = (TimeSpan)lector["HorarioFin_DIS"];

                            listaDisponibilidadMedico.Add(disponibilidad);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return listaDisponibilidadMedico;
        }
    }
}
