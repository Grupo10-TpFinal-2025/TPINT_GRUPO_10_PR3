using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class DaoPaciente
    {
        private AccesoDatos datos;
        private SqlCommand sqlCommand;
        private const string consultaBaseSQL = "SELECT P.Legajo_PA AS 'Legajo Paciente', P.DNI_PA AS 'DNI Paciente', P.Nombre_PA AS 'Nombre', P.Apellido_PA AS 'Apellido', P.Sexo_PA AS 'Sexo', P.Nacionalidad_PA AS 'Nacionalidad', P.FechaNacimiento_PA AS 'Fecha Nacimiento', P.Direccion_PA AS 'Direccion', P.Localidad_PA AS 'Localidad', Pr.Descripcion_Pr AS 'Provincia', P.Correo_PA, P.Telefono_PA AS 'Telefono', P.Estado_PA FROM Paciente AS P INNER JOIN Provincia AS Pr ON P.CodProvincia_PA = Pr.CodProvincia_Pr";

        public DaoPaciente()
        {
            datos = new AccesoDatos();
        }

        //------------------------------------------------------ Alta Paciente ------------------------------------------------------
       
        public void ValidarOCrearProcedimientoAltaPaciente()
        {
            using (SqlConnection conexion = datos.ObtenerConexion())
            {
                string consultaExiste = @"
            SELECT COUNT(*) 
            FROM sys.objects 
            WHERE type = 'P' AND name = 'AltaPaciente_Grupo10'";
                SqlCommand cmdExiste = new SqlCommand(consultaExiste, conexion);
                int cantidad = (int)cmdExiste.ExecuteScalar();
                if (cantidad == 0)
                {
                    string crearProc = @"
                CREATE PROCEDURE AltaPaciente_Grupo10
                    @DNI_PA CHAR(8),
                    @Nombre_PA NVARCHAR(50),
                    @Apellido_PA NVARCHAR(50),
                    @Sexo_PA CHAR(1),
                    @Nacionalidad_PA NVARCHAR(50),
                    @FechaNacimiento_PA DATE,
                    @Direccion_PA NVARCHAR(100),
                    @Localidad_PA NVARCHAR(50),
                    @CodProvincia_PA INT,
                    @Correo_PA NVARCHAR(100),
                    @Telefono_PA NVARCHAR(15)
                AS
                BEGIN
                    SET NOCOUNT ON;
                    INSERT INTO Paciente (DNI_PA, Nombre_PA, Apellido_PA, Sexo_PA, Nacionalidad_PA, FechaNacimiento_PA, Direccion_PA, Localidad_PA, CodProvincia_PA, Correo_PA, Telefono_PA)
                    VALUES (@DNI_PA, @Nombre_PA, @Apellido_PA, @Sexo_PA, @Nacionalidad_PA, @FechaNacimiento_PA, @Direccion_PA, @Localidad_PA, @CodProvincia_PA, @Correo_PA, @Telefono_PA);
                END";
                    SqlCommand cmdCrear = new SqlCommand(crearProc, conexion);
                    cmdCrear.ExecuteNonQuery();
                }
            }
        }

        public void ArmarParametro_Alta_Paciente(ref SqlCommand command, Paciente paciente)
        {
            command.Parameters.AddWithValue("@DNI_PA", paciente.Dni);
            command.Parameters.AddWithValue("@Nombre_PA", paciente.Nombre);
            command.Parameters.AddWithValue("@Apellido_PA", paciente.Apellido);
            command.Parameters.AddWithValue("@Sexo_PA", paciente.Sexo);
            command.Parameters.AddWithValue("@Nacionalidad_PA", paciente.Nacionalidad);
            command.Parameters.AddWithValue("@FechaNacimiento_PA", paciente.FechaNacimiento);
            command.Parameters.AddWithValue("@Direccion_PA", paciente.Direccion);
            command.Parameters.AddWithValue("@Localidad_PA", paciente.Localidad);
            command.Parameters.AddWithValue("@CodProvincia_PA", paciente.CodProvincia);
            command.Parameters.AddWithValue("@Correo_PA", paciente.CorreoElectronico);
            command.Parameters.AddWithValue("@Telefono_PA", paciente.Telefono);
        }

        public int AltaPaciente(Paciente paciente)
        {
            sqlCommand = new SqlCommand();
            ArmarParametro_Alta_Paciente(ref sqlCommand, paciente);
            ValidarOCrearProcedimientoAltaPaciente();
            int resultado = datos.EjecutarProcedimientoAlmacenado("AltaPaciente_Grupo10", sqlCommand);
            return resultado;
        }

        public void ArmarParametro_DNIPaciente(ref SqlCommand command, Paciente paciente)
        {
            SqlParameter parametro = new SqlParameter();
            parametro = command.Parameters.Add("@DNI_PA", SqlDbType.Int);
            parametro.Value = paciente.Dni;
        }

        public bool VerificarExistenciaPacienteXDNI(Paciente paciente)
        {
            string consultaVerificacion = "SELECT * FROM Paciente WHERE DNI_PA = @DNI_PA";
            bool existe = false;
            using (SqlConnection conexion = datos.ObtenerConexion())
            {
                sqlCommand = new SqlCommand(consultaVerificacion, conexion);
                ArmarParametro_DNIPaciente(ref sqlCommand, paciente);
                SqlDataReader lector = sqlCommand.ExecuteReader();

                if (lector.Read())
                {
                    existe = true;
                }
            }

            return existe;
        }

        public DataTable getProvincias()
        {
            return  datos.ObtenerTabla("Provincias", "SELECT CodProvincia_PR, Descripcion_PR FROM Provincia ORDER BY Descripcion_PR");
          
        }

        // -----------------------------------------------------------------------------------------------------------------------------


    }

}
