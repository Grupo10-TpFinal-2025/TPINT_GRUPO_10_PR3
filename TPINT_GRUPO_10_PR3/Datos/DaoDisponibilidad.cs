using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Net.NetworkInformation;

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
                                INNER JOIN Especialidad E ON E.CodEspecialidad_ES = M.CodigoEspecialidad_ME";

        private string ordenamiento = " ORDER BY [Especialidad] ASC";

        public DaoDisponibilidad()
        {
            datos = new AccesoDatos();
        }

        public DataTable ObtenerTablaDisponibilidad()
        {
            return datos.ObtenerTabla("Disponibilidad", consultaBase + ordenamiento);
        }

        //PRUEBA
        public DataTable ObtenerTablaDisponibilidad(int codEspecialidad = 0, int diaSeleccionado = 0)
        {
            DataTable tablaDisponibilidad = new DataTable();

            using (SqlConnection conexion = datos.ObtenerConexion())
            {
                string consulta = consultaBase;
                List<string> condiciones = new List<string>();

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                
                if (codEspecialidad > 0)
                {
                    condiciones.Add("CodEspecialidad_ES = @CodEspecialidad");
                    comando.Parameters.AddWithValue("@CodEspecialidad", codEspecialidad);

                }

                if(diaSeleccionado > 0)
                {
                    condiciones.Add("NumDia_Dis = @NumDia");
                    comando.Parameters.AddWithValue("@NumDia", diaSeleccionado);
                }
                
                if(condiciones.Count > 0)
                {   
                    //string.Join() concatena elementos de una lista, y entre medio, agrega en este caso "AND"
                    consulta += " WHERE " + string.Join(" AND ", condiciones);
                }

                consulta += ordenamiento;

                comando.CommandText = consulta;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                   tablaDisponibilidad.Load(reader);
                    }
                
            }

            return tablaDisponibilidad;
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
            // Usar variables distintas para las consultas mejora la legibilidad.
            string consultaTurnos = @" SET DATEFIRST 1 UPDATE Turno SET Estado_TU = 0 WHERE LegajoMedico_TU = @LegajoMedico AND DATEPART(weekday, Fecha_TU) = @NumDia AND Fecha_TU >= GETDATE() AND Estado_TU = 1;";

            string consultaDisponibilidad = @" UPDATE Disponibilidad SET Estado_DIS = 0 WHERE LegajoMedico_DIS = @LegajoMedico  AND NumDia_DIS = @NumDia AND Estado_DIS = 1;";

            using (SqlConnection conexion = datos.ObtenerConexion())
            {
                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        // Comando para actualizar los turnos
                        using (SqlCommand comandoTurnos = new SqlCommand(consultaTurnos, conexion, transaccion))
                        {
                            comandoTurnos.Parameters.AddWithValue("@LegajoMedico", disponibilidad.LegajoMedico);
                            comandoTurnos.Parameters.AddWithValue("@NumDia", disponibilidad.NumDia);
                            comandoTurnos.ExecuteNonQuery();
                        }

                        // Comando para actualizar la disponibilidad
                        int filasAfectadas;
                        using (SqlCommand comandoDisponibilidad = new SqlCommand(consultaDisponibilidad, conexion, transaccion))
                        {
                            comandoDisponibilidad.Parameters.AddWithValue("@LegajoMedico", disponibilidad.LegajoMedico);
                            comandoDisponibilidad.Parameters.AddWithValue("@NumDia", disponibilidad.NumDia);
                            filasAfectadas = comandoDisponibilidad.ExecuteNonQuery();
                        }

                        // Si todo fue exitoso, confirma la transacción.
                        transaccion.Commit();
                        return filasAfectadas;
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        Console.WriteLine("Error al realizar la baja lógica de disponibilidad: " + ex.Message);

                        return -1;
                    }
                } 
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
                    // Verificar si existe dado de baja
                    string consultaVerificar = @"SELECT COUNT(*) FROM Disponibilidad 
                                         WHERE LegajoMedico_DIS = @LegajoMedico 
                                         AND NumDia_DIS = @NumDia 
                                         AND Estado_DIS = 0";

                    using (SqlCommand comandoVerificar = new SqlCommand(consultaVerificar, conexion))
                    {
                        comandoVerificar.Parameters.AddWithValue("@LegajoMedico", disponibilidad.LegajoMedico);
                        comandoVerificar.Parameters.AddWithValue("@NumDia", disponibilidad.NumDia);

                        int existe = (int)comandoVerificar.ExecuteScalar();

                        if (existe > 0)
                        {
                            // Reactivar el registro dado de baja
                            string consultaReactivar = @"UPDATE Disponibilidad 
                                                 SET Estado_DIS = 1,
                                                     HorarioInicio_DIS = @HorarioInicio,
                                                     HorarioFin_DIS = @HorarioFin
                                                 WHERE LegajoMedico_DIS = @LegajoMedico 
                                                 AND NumDia_DIS = @NumDia 
                                                 AND Estado_DIS = 0";

                            using (SqlCommand comandoReactivar = new SqlCommand(consultaReactivar, conexion))
                            {
                                comandoReactivar.Parameters.AddWithValue("@LegajoMedico", disponibilidad.LegajoMedico);
                                comandoReactivar.Parameters.AddWithValue("@NumDia", disponibilidad.NumDia);
                                comandoReactivar.Parameters.AddWithValue("@HorarioInicio", disponibilidad.HorarioInicio);
                                comandoReactivar.Parameters.AddWithValue("@HorarioFin", disponibilidad.HorarioFin);

                                return comandoReactivar.ExecuteNonQuery(); // Devuelve 1 si se reactivó
                            }
                        }
                        else
                        {
                            // Insertar nuevo registro
                            string consultaInsertar = @"INSERT INTO Disponibilidad 
                                                (NumDia_DIS, LegajoMedico_DIS, HorarioInicio_DIS, HorarioFin_DIS, Estado_DIS) 
                                                VALUES (@NumDia, @LegajoMedico, @HorarioInicio, @HorarioFin, @Estado)";

                            using (SqlCommand comandoInsertar = new SqlCommand(consultaInsertar, conexion))
                            {
                                comandoInsertar.Parameters.AddWithValue("@NumDia", disponibilidad.NumDia);
                                comandoInsertar.Parameters.AddWithValue("@LegajoMedico", disponibilidad.LegajoMedico);
                                comandoInsertar.Parameters.AddWithValue("@HorarioInicio", disponibilidad.HorarioInicio);
                                comandoInsertar.Parameters.AddWithValue("@HorarioFin", disponibilidad.HorarioFin);
                                comandoInsertar.Parameters.AddWithValue("@Estado", disponibilidad.Estado);

                                return comandoInsertar.ExecuteNonQuery(); // Devuelve 1 si se insertó
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en AgregarDisponibilidad: " + ex.Message);
            }
        }

        public bool ExisteDisponibilidad(int legajoMedico, int numDia)
        {
            using (SqlConnection conexion = datos.ObtenerConexion())
            {
                string consulta = @"SELECT COUNT(*) FROM Disponibilidad 
                            WHERE LegajoMedico_DIS = @LegajoMedico 
                            AND NumDia_DIS = @NumDia 
                            AND Estado_DIS = 1";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@LegajoMedico", legajoMedico);
                    comando.Parameters.AddWithValue("@NumDia", numDia);

                    int count = (int)comando.ExecuteScalar();
                    return count > 0;
                }
            }
        }


    }
}
