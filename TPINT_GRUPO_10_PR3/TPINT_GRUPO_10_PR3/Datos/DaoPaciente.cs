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
        private const string consultaBaseSQL = "SELECT P.Legajo_PA AS 'Legajo Paciente', P.DNI_PA AS 'DNI Paciente', P.Nombre_PA AS 'Nombre', P.Apellido_PA AS 'Apellido', P.Sexo_PA AS 'Sexo', P.Nacionalidad_PA AS 'Nacionalidad', P.FechaNacimiento_PA AS 'Fecha Nacimiento', P.Direccion_PA AS 'Direccion', P.Localidad_PA AS 'Localidad', Pr.Descripcion_Pr AS 'Provincia', P.Correo_PA AS 'Correo Electronico', P.Telefono_PA AS 'Telefono' FROM Paciente AS P INNER JOIN Provincia AS Pr ON P.CodProvincia_PA = Pr.CodProvincia_Pr";

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
                    @Telefono_PA NVARCHAR(15),
                    @Estado_PA BIT

                AS
                BEGIN
                    INSERT INTO Paciente (DNI_PA, Nombre_PA, Apellido_PA, Sexo_PA, Nacionalidad_PA, FechaNacimiento_PA, Direccion_PA, Localidad_PA, CodProvincia_PA, Correo_PA, Telefono_PA, Estado_PA)
                    VALUES (@DNI_PA, @Nombre_PA, @Apellido_PA, @Sexo_PA, @Nacionalidad_PA, @FechaNacimiento_PA, @Direccion_PA, @Localidad_PA, @CodProvincia_PA, @Correo_PA, @Telefono_PA, @Estado_PA);
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
            command.Parameters.AddWithValue("@Estado_PA", true);
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

        public int BajaLogicaPacientePorDNI(string dni)
        {
            using (SqlConnection conexion = datos.ObtenerConexion())
            {
                string consulta = "UPDATE Paciente SET Estado_PA = 0 WHERE DNI_PA = @DNI_PA AND Estado_PA = 1";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@DNI_PA", dni);

                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas;
            }
        }

        public DataTable ObtenerPacientes()
        {
            string consulta = consultaBaseSQL + " WHERE P.Estado_PA = 1 ORDER BY P.Apellido_PA, P.Nombre_PA";
            return datos.ObtenerTabla("Pacientes", consulta);
        }

        public void ArmarParametro_FiltroPaciente(ref SqlCommand command, Paciente paciente)
        {
            if(!string.IsNullOrEmpty(paciente.Dni) && paciente.Dni.Length > 0)
            {
                command.Parameters.AddWithValue("@DNI_PA", paciente.Dni);
            }
            else
            {
                command.Parameters.AddWithValue("@CodProvincia_PA", paciente.CodProvincia);
            }
        }

        public DataTable ObtenerPacientes_Filtrados(Paciente paciente, bool FiltrosAvanzados, bool[,] filtros)
        {
            string consulta =
                "SELECT Legajo_PA AS 'Legajo', Apellido_PA AS 'Apellido', Nombre_PA  AS 'Nombre', Sexo_PA AS 'Sexo', Nacionalidad_PA AS 'Nacionalidad', " +
                "FORMAT(FechaNacimiento_PA, 'dd/MM/yyyy') AS 'Fecha Nacimiento', Direccion_PA AS 'Dirección', Localidad_PA AS 'Localidad', " +
                "Descripcion_PR AS 'Provincia', Correo_PA AS 'Correo', Telefono_PA AS 'Teléfono'," + "DNI_PA AS 'DNI' " +
                "FROM (Paciente INNER JOIN Provincia " + "ON CodProvincia_PA = CodProvincia_PR)" +
                "WHERE Estado_PA = 1";

            if (!FiltrosAvanzados)
            {
                if (!string.IsNullOrEmpty(paciente.Dni) && paciente.Dni.Trim().Length > 0)
                {
                    consulta += " AND DNI_PA = @DNI_PA";
                }
                else if (paciente.CodProvincia > 0)
                {
                    consulta += " AND CodProvincia_PA = @CodProvincia_PA";
                }

                sqlCommand = new SqlCommand(consulta);
                ArmarParametro_FiltroPaciente(ref sqlCommand, paciente);

                return datos.ObtenerTablaFiltrada("Paciente", sqlCommand);
            }
            else
            {
                sqlCommand = GenerarConsultasAvanzada_Pacientes(paciente, filtros, consulta);
                return datos.ObtenerTablaFiltrada("Paciente", sqlCommand);
            }
        }

        private SqlCommand GenerarConsultasAvanzada_Pacientes(Paciente paciente, bool[,] filtros, string consulta)
        {
            sqlCommand = new SqlCommand();

            if (paciente.Dni.Trim().Length > 0)
            {
                if (filtros[0, 0]) // Igual a
                {
                    consulta += " AND DNI_PA = @DNI_PA";
                }
                else if (filtros[0, 1]) // Mayor a
                {
                    consulta += " AND DNI_PA > @DNI_PA";
                }
                else if (filtros[0, 2]) // Menor a
                {
                    consulta += " AND DNI_PA < @DNI_PA";
                }

                sqlCommand.Parameters.Add("@DNI_PA", SqlDbType.Char, 8).Value = paciente.Dni;
            }

            if (paciente.Nombre.Trim().Length > 0)
            {
                if (filtros[1, 0]) // Contiene
                {
                    consulta += " AND Nombre_PA LIKE @Nombre_PA";
                    sqlCommand.Parameters.Add("@Nombre_PA", SqlDbType.NVarChar, 50).Value = "%" + paciente.Nombre + "%";
                }
                else if (filtros[1, 1]) // Empieza con
                {
                    consulta += " AND Nombre_PA LIKE @Nombre_PA";
                    sqlCommand.Parameters.Add("@Nombre_PA", SqlDbType.NVarChar, 50).Value = paciente.Nombre + "%";
                }
                else if (filtros[1, 2]) // Termina con
                {
                    consulta += " AND Nombre_PA LIKE @Nombre_PA";
                    sqlCommand.Parameters.Add("@Nombre_PA", SqlDbType.NVarChar, 50).Value = "%" + paciente.Nombre;
                }
            }

            if (paciente.Telefono.Trim().Length > 0)
            {
                if (filtros[2, 0]) // Contiene
                {
                    consulta += " AND Telefono_PA LIKE @Telefono_PA";
                    sqlCommand.Parameters.Add("@Telefono_PA", SqlDbType.Char, 15).Value = "%" + paciente.Telefono + "%";
                }
                else if (filtros[2, 1]) // Empieza con
                {
                    consulta += " AND Telefono_PA LIKE @Telefono_PA";
                    sqlCommand.Parameters.Add("@Telefono_PA", SqlDbType.Char, 15).Value = paciente.Telefono + "%";
                }
                else if (filtros[2, 2]) // Termina con
                {
                    consulta += " AND Telefono_PA LIKE @Telefono_PA";
                    sqlCommand.Parameters.Add("@Telefono_PA", SqlDbType.Char, 15).Value = "%" + paciente.Telefono;
                }
            }

            sqlCommand.CommandText = consulta;

            return sqlCommand;
        }
    }
}
