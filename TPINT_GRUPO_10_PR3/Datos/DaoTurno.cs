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
                            Asistencia_TU, Descripcion_TU, Estado_UM) 
                            VALUES 
                            (@LegajoMedico, @LegajoPaciente, @Fecha, 1, NULL, NULL, 1)                                                        
                        END";

                    SqlCommand cmdCrear = new SqlCommand(crearProc, conexion);
                    cmdCrear.ExecuteNonQuery();
                }
            }
        }

        public SqlDataReader ObtenerListaTurnos(int legajoMedico, string nombreDia)
        {
            SqlDataReader reader;
            SqlConnection conexion;

            try
            {
                ValidarOCrearProcedimientoMostrarTurno();

                conexion = datos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("SP_MostrarTurnosDisponibles", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@LegajoMedico", legajoMedico);
                comando.Parameters.AddWithValue("@NombreDia", nombreDia);

                reader = comando.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {
                throw;
            }

            return reader;
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
