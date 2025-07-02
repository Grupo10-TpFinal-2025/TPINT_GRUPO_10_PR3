using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Entidades;


namespace Datos
{
    public class DaoTurno
    {
        private const string ConsultaBase = "SELECT CodTurno_TU AS [ID Consulta], Nombre_ME + ' ' + Apellido_ME AS Medico, " +
            "Nombre_PA + ' ' + Apellido_PA AS [Paciente], Fecha_TU AS Turno, Pendiente_TU AS Pendiente," +
            "Asistencia_TU AS Asistencia, Descripcion_TU AS Descripcion, Estado_TU AS Estado FROM Turno " +
            "INNER JOIN Medico ON LegajoMedico_TU = Legajo_ME " +
            "INNER JOIN Paciente ON LegajoPaciente_TU = Legajo_PA WHERE Estado_TU = 1";

        private readonly AccesoDatos datos;

        public DaoTurno()
        {
            datos = new AccesoDatos();
        }

        public void ValidarOCrearProcedimientoAgendarTurno()
        {
            SqlConnection conexion = datos.ObtenerConexion();
            using (conexion)
            {
                // Verificar si existe el procedimiento
                string consultaExiste = @"
                    SELECT COUNT(*) 
                    FROM sys.objects 
                    WHERE type = 'P' AND name = 'SP_AgendarTurno'";

                SqlCommand cmdExiste = new SqlCommand(consultaExiste, conexion);
                int cantidad = (int)cmdExiste.ExecuteScalar();

                if (cantidad == 0)
                {
                    // Crear el procedimiento si no existe
                    string crearProc = @"
                        CREATE PROCEDURE SP_AgendarTurno
                            @LegajoMedico INT,
                            @LegajoPaciente INT,
                            @Fecha DATETIME
                        AS
                        BEGIN
                            INSERT INTO Turno 
                            (LegajoMedico_TU, LegajoPaciente_TU, Fecha_TU, Pendiente_TU, 
                            Asistencia_TU, Descripcion_TU, Estado_UM) 
                            VALUES 
                            (@LegajoMedico, @LegajoPaciente, @Fecha, 1, NULL, NULL, 1)                                                        
                        END";

                    SqlCommand cmdCrear = new SqlCommand(crearProc, conexion);
                    cmdCrear.ExecuteNonQuery();
                }
            }
        }

        public List<Turno> ObtenerListaTurnos(int legajoMedico)
        {
            List<Turno> listaTurnosMedico = new List<Turno>();

            SqlConnection conexion = null;
            SqlCommand comando;
            SqlDataReader lector;

            try
            {
                string consulta = "SELECT Fecha_TU, Estado_TU FROM Turno WHERE LegajoMedico_TU = @LegajoMedico AND Fecha_TU > GETDATE() AND Fecha_TU <= DATEADD(Day, 30, GETDATE())";
                conexion = datos.ObtenerConexion();
                comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("LegajoMedico", legajoMedico);
                lector = comando.ExecuteReader();

                using (lector)
                {
                    while (lector.Read())
                    {
                        if ((bool)lector["Estado_TU"])
                        {
                            Turno turno = new Turno();
                            turno.Fecha = (DateTime)lector["Fecha_TU"];
                            turno.Estado = (bool)lector["Estado_TU"];

                            listaTurnosMedico.Add(turno);
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

            return listaTurnosMedico;
        }

        public void AgendarTurno()
        {

        }

        public void ValidarOCrearProcedimientoMostrarTurno()
        {
            SqlConnection conexion = datos.ObtenerConexion();
            using (conexion)
            {
                // Verificar si existe el procedimiento
                string consultaExiste = @"
                    SELECT COUNT(*) 
                    FROM sys.objects 
                    WHERE type = 'P' AND name = 'SP_MostrarTurnosDisponibles'";

                SqlCommand cmdExiste = new SqlCommand(consultaExiste, conexion);
                int cantidad = (int)cmdExiste.ExecuteScalar();

                if (cantidad == 0)
                {
                    // Crear el procedimiento si no existe
                    string crearProc = @"
                        CREATE PROCEDURE SP_MostrarTurnosDisponibles(
                            @LegajoMedico INT,
                            @NombreDia VARCHAR (10)                           
                        )
                        AS
                        BEGIN
                            DECLARE @NumDia INT
                            
                            SELECT @NumDia = NumDia_DI
                            FROM Dia
                            WHERE LOWER(Descripcion_DI) = @NombreDia

                            SELECT	NumDia_DIS AS 'NumeroDia',
		                            DI.Descripcion_DI AS 'NombreDia'
                            FROM Disponibilidad DIS
                            INNER JOIN Dia DI ON DI.NumDia_DI = DIS.NumDia_DIS
                            WHERE	DIS.LegajoMedico_DIS = @LegajoMedico AND
		                            DIS.NumDia_DIS >= @NumDia                                                        
                        END";

                    SqlCommand cmdCrear = new SqlCommand(crearProc, conexion);
                    cmdCrear.ExecuteNonQuery();
                }
            }
        }

        //Consigue la tabla
        public DataTable getTabla()
        {
            DataTable table = datos.ObtenerTabla("Turnos", ConsultaBase);
            return table;
        }

        //Consigue la tabla por codigo de turno
        public DataTable getTablaPorCodigoTurno(int numero)
        {
            string consulta = ConsultaBase + " AND CodTurno_TU = @CodTurno_TU";

            //Creo el sqlCommand y lo cargo
            SqlCommand sqlComand = new SqlCommand(consulta);
            sqlComand.Parameters.AddWithValue("@CodTurno_TU", numero);

            //Devuelvo
            return datos.ObtenerTablaFiltrada("Turnos", sqlComand);
        }

        //Consige la consulta de la tabla filtrada
        private SqlCommand ObtenerConsultaFiltrada(int caso, string dni, DateTime? fecha)
        {
            //Variable
            string consulta = "";

            //Pregunto que caso es
            if (caso == 1)
            {
                //Establesco la consulta
                consulta = ConsultaBase + " AND DNI_ME = @DNI_ME AND Fecha_TU = @Fecha_TU";

                //Creo el sqlCommand y lo cargo
                SqlCommand sqlComand = new SqlCommand(consulta);
                sqlComand.Parameters.AddWithValue("@DNI_ME", Convert.ToInt32(dni));
                sqlComand.Parameters.AddWithValue("@Fecha_TU", fecha);

                //Devuelvo el sqlCommand
                return sqlComand;

            }
            else if (caso == 2)
            {
                //Establesco la consulta
                consulta = ConsultaBase + " AND DNI_PA = @DNI_PA AND Fecha_TU = @Fecha_TU";

                //Creo el sqlCommand y lo cargo
                SqlCommand sqlComand = new SqlCommand(consulta);
                sqlComand.Parameters.AddWithValue("@DNI_PA", Convert.ToInt32(dni));
                sqlComand.Parameters.AddWithValue("@Fecha_TU", fecha);

                //Devuelvo el sqlCommand
                return sqlComand;

            }
            else if (caso == 3)
            {
                //Establesco la consulta
                consulta = ConsultaBase + " AND DNI_ME = @DNI_ME";

                //Creo el sqlCommand y lo cargo
                SqlCommand sqlComand = new SqlCommand(consulta);
                sqlComand.Parameters.AddWithValue("@DNI_ME", Convert.ToInt32(dni));

                //Devuelvo el sqlCommand
                return sqlComand;

            }
            else if (caso == 4)
            {

                //Establesco la consulta
                consulta = ConsultaBase + " AND DNI_PA = @DNI_PA";

                //Creo el sqlCommand y lo cargo
                SqlCommand sqlComand = new SqlCommand(consulta);
                sqlComand.Parameters.AddWithValue("@DNI_PA", Convert.ToInt32(dni));

                //Devuelvo el sqlCommand
                return sqlComand;

            }
            else if (caso == 5)
            {
                //Establesco la consulta
                consulta = ConsultaBase + " AND Fecha_TU = @Fecha_TU";

                //Creo el sqlCommand y lo cargo
                SqlCommand sqlComand = new SqlCommand(consulta);
                sqlComand.Parameters.AddWithValue("@Fecha_TU", fecha);

                //Devuelvo el sqlCommand
                return sqlComand;
            }
            else
            {
                return null;
            }
        }

        //Consigue la tabla filtrada
        public DataTable getTablaFiltrada(int caso, string dni, DateTime? fecha)
        {
            SqlCommand sql = ObtenerConsultaFiltrada(caso, dni, fecha);

            return datos.ObtenerTablaFiltrada("Turnos", sql);
        }

        public DataTable getTurnosXMedico(int legajoMedico)
        {
            string consultaTurnosM = ConsultaBase + " AND LegajoMedico_TU = @LegajoMedico_TU ORDER BY Fecha_TU";

            SqlCommand sqlComand = new SqlCommand(consultaTurnosM);
            sqlComand.Parameters.AddWithValue("@LegajoMedico_TU", legajoMedico);
            return datos.ObtenerTablaFiltrada("Turnos", sqlComand);
        }

        public void ValidarOCrearProcedimiento_ModificacionTurno()
        {
            SqlConnection conexion = datos.ObtenerConexion();
            using (conexion)
            {
                try
                {
                    // Verificar si existe el procedimiento
                    string consultaExiste = @"
                        SELECT COUNT(*) 
                        FROM sys.objects 
                        WHERE type = 'P' AND name = 'SP_ModificacionTurno_Grupo10'";
                    SqlCommand cmdExiste = new SqlCommand(consultaExiste, conexion);
                    int cantidad = (int)cmdExiste.ExecuteScalar();
                    if (cantidad == 0)
                    {
                        // Crear el procedimiento si no existe
                        string crearProcedimiento = @"
                            CREATE PROCEDURE SP_ModificacionTurno_Grupo10 
                                @Fecha_TU DateTime,           
                                @CodTurno_TU INT,
                                @Asistencia_TU BIT,
                                @Descripcion_TU NVARCHAR(300),
                                @Estado_TU BIT
                            AS
                            BEGIN
                                UPDATE Turno 
                                SET 
                                    Fecha_TU = @Fecha_TU,    
                                    Asistencia_TU = @Asistencia_TU, 
                                    Descripcion_TU = @Descripcion_TU, 
                                    Estado_TU = @Estado_TU 
                                WHERE CodTurno_TU = @CodTurno_TU;                                                        
                            END";
                        SqlCommand cmdCrear = new SqlCommand(crearProcedimiento, conexion);
                        cmdCrear.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al crear el procedimiento almacenado: " + ex.Message);
                }
            }
        }

        public SqlCommand CargarParametros_ModificacionTurno(Turno turno)
        {
            SqlCommand sqlComand = new SqlCommand("SP_ModificacionTurno_Grupo10");
            sqlComand.CommandType = CommandType.StoredProcedure;
            sqlComand.Parameters.AddWithValue("@Fecha_TU", turno.Fecha);
            sqlComand.Parameters.AddWithValue("@CodTurno_TU", turno.CodTurno);
            object asistenciaParametro;
            if (turno.Asistencia == "NULL")
            {
                asistenciaParametro = (object)DBNull.Value;
            }
            else
            {
                asistenciaParametro = Convert.ToInt32(turno.Asistencia);
            }
            sqlComand.Parameters.AddWithValue("@Asistencia_TU", asistenciaParametro);
            sqlComand.Parameters.AddWithValue("@Descripcion_TU", turno.Descripcion);
            sqlComand.Parameters.AddWithValue("@Estado_TU", 1);
            return sqlComand;
        }

        public int ModificarTurno(Turno turno)
        {
            ValidarOCrearProcedimiento_ModificacionTurno();
            SqlCommand sqlComand = CargarParametros_ModificacionTurno(turno);
            return datos.EjecutarProcedimientoAlmacenado("SP_ModificacionTurno_Grupo10 ", sqlComand);
        }

        public int BajaLogicaTurno(int codTurno)
        {
            string consulta = "UPDATE Turno SET Estado_TU = 0 WHERE CodTurno_TU = @CodTurno_TU AND Estado_TU = 1";

            using (SqlConnection conexion = datos.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@CodTurno_TU", codTurno);
                    return comando.ExecuteNonQuery(); // Devuelve 1 si se actualizó
                }
            }
        }

        public DataTable ObtenerConcurrenciaTurnosXDia()
        {
            string consulta = @"
                SET DATEFIRST 1;
                SET LANGUAGE Spanish;

                WITH DiasSemana AS (
                    SELECT 1 AS NumeroDia_DS, 'Lunes' AS NombreDia_DS UNION ALL
                    SELECT 2, 'Martes' UNION ALL
                    SELECT 3, 'Miércoles' UNION ALL
                    SELECT 4, 'Jueves' UNION ALL
                    SELECT 5, 'Viernes' UNION ALL
                    SELECT 6, 'Sábado' UNION ALL
                    SELECT 7, 'Domingo'
                )

                SELECT 
                    NombreDia_DS AS [Día de la Semana],
                    ISNULL(COUNT(Fecha_TU), 0) AS [Turnos Asignados],
                    ISNULL(SUM(CASE WHEN Asistencia_TU = 1 THEN 1 ELSE 0 END), 0) AS [Turnos Asistidos],
                    CASE 
                        WHEN COUNT(Fecha_TU) = 0 THEN '0.00 %'
                        ELSE CONCAT(FORMAT(100.0 * SUM(CASE WHEN Asistencia_TU = 1 THEN 1 ELSE 0 END) / COUNT(Fecha_TU), 'N2'), ' %')
                    END AS [Porcentaje de Asistencia]
                FROM DiasSemana LEFT JOIN Turno
                ON DATEPART(weekday, Fecha_TU) = NumeroDia_DS AND Estado_TU = 1 AND Pendiente_TU = 0
                GROUP BY NumeroDia_DS, NombreDia_DS
                ORDER BY NumeroDia_DS";

            return datos.ObtenerTabla("ConcurrenciaTurnosPorDia", consulta);
        }
    }
}
