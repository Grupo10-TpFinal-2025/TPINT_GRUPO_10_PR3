using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

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

        public DataTable Obtener_Disponibilidad(Disponibilidad disponibilidad)
        {
            DataTable tablaDisponibilidad = new DataTable();
            using (SqlConnection conexion = datos.ObtenerConexion())
            {
                string consulta = "SELECT NumDia_DIS AS 'Numero Día Semana', LegajoMedico_DIS AS 'Legajo Medico', HorarioInicio_DIS AS 'Horario de Inicio', HorarioFin_DIS AS 'Horario de Finalizacion', Descripcion_DI AS 'Día Semana' FROM Disponibilidad INNER JOIN Dia ON NumDia_DI = NumDia_DIS WHERE LegajoMedico_DIS = @Legajo AND Estado_DIS = 1";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Legajo", disponibilidad.LegajoMedico);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        tablaDisponibilidad.Load(reader);
                    }
                }
            }
            return tablaDisponibilidad;
        }

        public int BajaLogicaDisponibilidad(Disponibilidad disponibilidad)
        {
            try
            {
                using (SqlConnection conexion = datos.ObtenerConexion())
                {
                    string consulta = "SET DATEFIRST 1 UPDATE Turno SET Estado_TU = 0 WHERE LegajoMedico_TU = @LegajoMedico_TU AND DATEPART(weekday, Fecha_TU) = @NumDia_DIS AND YEAR(Fecha_TU) = @Anio_DIS AND Estado_TU = 1";
                    SqlCommand comandoTurnos = new SqlCommand(consulta, conexion);
                    comandoTurnos.Parameters.AddWithValue("@LegajoMedico_TU", disponibilidad.LegajoMedico);
                    comandoTurnos.Parameters.AddWithValue("@NumDia_DIS", disponibilidad.NumDia);
                    comandoTurnos.Parameters.AddWithValue("@Anio_DIS", DateTime.Now.Year);
                    comandoTurnos.ExecuteNonQuery();

                    consulta = "UPDATE Disponibilidad SET Estado_DIS = 0 WHERE LegajoMedico_DIS = @LegajoMedico_DIS AND Estado_DIS = 1";
                    SqlCommand comandoDisponibilidad = new SqlCommand(consulta, conexion);
                    comandoDisponibilidad.Parameters.AddWithValue("@LegajoMedico_DIS", disponibilidad.LegajoMedico);
                   int filasAfectadas = comandoDisponibilidad.ExecuteNonQuery();

                    return filasAfectadas;
                }
            }
            catch
            {
                return -1;
            }
        }

        public DataTable ObtenerDias()
        {
            DataTable tablaDias = new DataTable();
            using (SqlConnection conexion = datos.ObtenerConexion())
            {
                string consulta = "SELECT NumDia_DI, Descripcion_DI FROM Dia";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        tablaDias.Load(reader);
                    }
                }
            }
            return tablaDias;
        }

        public int AgregarDisponibilidad(Disponibilidad disponibilidad)
        {
            try
            {
                using (SqlConnection conexion = datos.ObtenerConexion())
                {
                    string consulta = "INSERT INTO Disponibilidad (NumDia_DIS, LegajoMedico_DIS, HorarioInicio_DIS, HorarioFin_DIS, Estado_DIS) VALUES (@NumDia, @LegajoMedico, @HorarioInicio, @HorarioFin, @Estado)";
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@NumDia", disponibilidad.NumDia);
                    comando.Parameters.AddWithValue("@LegajoMedico", disponibilidad.LegajoMedico);
                    comando.Parameters.AddWithValue("@HorarioInicio", disponibilidad.HorarioInicio);
                    comando.Parameters.AddWithValue("@HorarioFin", disponibilidad.HorarioFin);
                    comando.Parameters.AddWithValue("@Estado", disponibilidad.Estado);

                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas; // Devuelve 1 si insertó correctamente
                }
            }
            catch
            {
                return -1; // Devuelve -1 si hubo error
            }
        }

        public bool ExisteDisponibilidad(int legajoMedico, int numDia, TimeSpan inicio, TimeSpan fin)
        {
            using (SqlConnection conexion = datos.ObtenerConexion())
            {
                string consulta = @"SELECT COUNT(*) FROM Disponibilidad 
                            WHERE LegajoMedico_DIS = @LegajoMedico 
                            AND NumDia_DIS = @NumDia 
                            AND Estado_DIS = 1 
                            AND (
                                (@Inicio >= HorarioInicio_DIS AND @Inicio < HorarioFin_DIS) OR
                                (@Fin > HorarioInicio_DIS AND @Fin <= HorarioFin_DIS) OR
                                (@Inicio <= HorarioInicio_DIS AND @Fin >= HorarioFin_DIS)
                            )";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@LegajoMedico", legajoMedico);
                    comando.Parameters.AddWithValue("@NumDia", numDia);
                    comando.Parameters.AddWithValue("@Inicio", inicio);
                    comando.Parameters.AddWithValue("@Fin", fin);

                    int count = (int)comando.ExecuteScalar();
                    return count > 0;
                }
            }
        }

    }
}
