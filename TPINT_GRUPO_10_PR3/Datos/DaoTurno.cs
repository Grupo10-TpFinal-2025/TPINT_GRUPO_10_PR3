using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoTurno
    {
        private AccesoDatos datos;
        
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
                            Asistencia_TU, Descripcion_TU, Estado_TU) 
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
    }
}
