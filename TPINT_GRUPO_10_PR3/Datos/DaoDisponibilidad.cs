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
        private string consultaBase = @"SELECT E.Descripcion_ES AS 'Especialidad', 
                                        M.Apellido_ME + ' ' + 
                                        M.Nombre_ME AS 'Medico', 
                                        DIA.Descripcion_DI AS 'Dia', 
                                        CONVERT(VARCHAR(5), HorarioInicio_DIS, 108) + ' - ' + CONVERT(VARCHAR(5), 
                                        HorarioFin_DIS, 108) AS 'Horario' 
                                        FROM Disponibilidad DIS 
                                        INNER JOIN Dia DIA ON DIA.NumDia_DI = DIS.NumDia_DIS 
                                        INNER JOIN Medico M ON M.Legajo_ME = DIS.LegajoMedico_DIS 
                                        INNER JOIN Especialidad E ON E.CodEspecialidad_ES = M.CodigoEspecialidad_ME 
                                        ORDER BY [Especialidad] ASC";

        public DaoDisponibilidad()
        {
            datos = new AccesoDatos();
        }

        public DataTable ObtenerTablaDisponibilidades()
        {
            return datos.ObtenerTabla("Disponibilidad", consultaBase);
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
