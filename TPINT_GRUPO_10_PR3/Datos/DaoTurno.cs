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

        public void AgendarTurno()
        {

        }

        public DataTable getTabla()
        {
            DataTable table = datos.ObtenerTabla("Turnos", "SELECT CodTurno_TU AS [ID Consulta], Nombre_ME + ' ' + Apellido_ME AS Medico, " +
                "Nombre_PA + ' ' + Apellido_PA AS [Paciente], Fecha_TU AS Turno, Pendiente_TU AS Pendiente," +
                "Asistencia_TU AS Asistencia, Descripcion_TU AS Descripcion, Estado_TU AS Estado FROM Turno " +
                "INNER JOIN Medico ON LegajoMedico_TU = Legajo_ME " +
                "INNER JOIN Paciente ON LegajoPaciente_TU = Legajo_PA"
            );
            return table;
        }

    }
}
