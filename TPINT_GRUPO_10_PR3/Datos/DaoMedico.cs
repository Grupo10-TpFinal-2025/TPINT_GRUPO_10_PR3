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
    public class DaoMedico
    {
        ///---------------------------------------------------- Propiedades -------------------------------------------------------------------------------
        private AccesoDatos datos;

        ///--------------------------------------------------- Constructores ------------------------------------------------------------------------------
        public DaoMedico()
        {
            datos = new AccesoDatos();
        }

        ///-------------------------------------------------- Getters y Setters ---------------------------------------------------------------------------------

        ///------------------------------------------------------ Metodos ---------------------------------------------------------------------------------
        //devuelve el reader para provincia
        public SqlDataReader readerProvincias()
        {
            return datos.ObtenerLista("SELECT * FROM Provincia");
        }

        //devuelve el reader para especialidad
        public SqlDataReader readerEspecialidad()
        {
            return datos.ObtenerLista("SELECT * FROM Especialidad");
        }

        public SqlDataReader ObtenerTablaMedicoPorEspecialidad(string cod)
        {
            SqlDataReader reader;
            SqlConnection conexion;

            try
            {
                ValidarOCrearProcedimientoMedicoPorEspecialidad();

                conexion = datos.ObtenerConexion();
                SqlCommand comando = new SqlCommand("SP_ObtenerListaMedicosPorEspecialidad", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@CodigoEspecialidad_ME", cod);

                reader = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return reader;
        }

        //Carga los parametros en el SQL command
        private void CargarParametros(ref SqlCommand cmd, Medico medico)
        {
            //Creo el sqlParameter
            SqlParameter sqlParameter = new SqlParameter();

            //Añado los parametros
            sqlParameter = cmd.Parameters.Add("@Nombre_ME", SqlDbType.NVarChar, 50);
            sqlParameter.Value = medico.Nombre;
            sqlParameter = cmd.Parameters.Add("@Apellido_ME", SqlDbType.NVarChar, 50);
            sqlParameter.Value = medico.Apellido;
            sqlParameter = cmd.Parameters.Add("@Sexo_ME", SqlDbType.Char);
            sqlParameter.Value = medico.Sexo;
            sqlParameter = cmd.Parameters.Add("@Nacionalidad_ME", SqlDbType.NVarChar, 50);
            sqlParameter.Value = medico.Nacionalidad;
            sqlParameter = cmd.Parameters.Add("@FechaNacimiento_ME", SqlDbType.Date);
            sqlParameter.Value = medico.FechaNacimiento;
            sqlParameter = cmd.Parameters.Add("@Direccion_ME", SqlDbType.NVarChar, 100);
            sqlParameter.Value = medico.Direccion;
            sqlParameter = cmd.Parameters.Add("@Localidad_ME", SqlDbType.NVarChar, 50);
            sqlParameter.Value = medico.Localidad;
            sqlParameter = cmd.Parameters.Add("@CodProvincia_ME", SqlDbType.Int);
            sqlParameter.Value = medico.CodigoProvincia;
            sqlParameter = cmd.Parameters.Add("@Correo_ME", SqlDbType.NVarChar, 100);
            sqlParameter.Value = medico.Correo;
            sqlParameter = cmd.Parameters.Add("@Telefono_ME", SqlDbType.Char, 10);
            sqlParameter.Value = medico.Telefono;
            sqlParameter = cmd.Parameters.Add("@CodigoEspecialidad_ME", SqlDbType.Int);
            sqlParameter.Value = medico.CodigoEspecialidad;
            sqlParameter = cmd.Parameters.Add("@DNI_ME", SqlDbType.Char, 8);
            sqlParameter.Value = medico.DNI;
            sqlParameter = cmd.Parameters.Add("@Estado_ME", SqlDbType.Bit);
            sqlParameter.Value = medico.Estado;
        }

        //Agregar Medico
        public bool AgregarMedico(Medico medico)
        {
            //Variable consulta
            const string consulta = "INSERT INTO Medico ([Nombre_ME], [Apellido_ME], [Sexo_ME], [Nacionalidad_ME], [FechaNacimiento_ME], [Direccion_ME], [Localidad_ME], [CodProvincia_ME], [Correo_ME], [Telefono_ME], [CodigoEspecialidad_ME], [DNI_ME], [Estado_ME])" +
                                    " VALUES (@Nombre_ME, @Apellido_ME, @Sexo_ME, @Nacionalidad_ME, @FechaNacimiento_ME, @Direccion_ME, @Localidad_ME, @CodProvincia_ME, @Correo_ME, @Telefono_ME, @CodigoEspecialidad_ME, @DNI_ME, @Estado_ME)";

            //Creo el SqlCommand
            SqlCommand sqlComand = new SqlCommand(consulta);

            //Cargo los parametros
            CargarParametros(ref sqlComand, medico);

            return datos.AltaPorParametros(sqlComand);
        }

        public void ValidarOCrearProcedimientoMedicoPorEspecialidad()
        {
            SqlConnection conexion = datos.ObtenerConexion();
            using (conexion)
            {
                // Verificar si existe el procedimiento
                string consultaExiste = @"
                    SELECT COUNT(*) 
                    FROM sys.objects 
                    WHERE type = 'P' AND name = 'SP_ObtenerListaMedicosPorEspecialidad'";

                SqlCommand cmdExiste = new SqlCommand(consultaExiste, conexion);
                int cantidad = (int)cmdExiste.ExecuteScalar();

                if (cantidad == 0)
                {
                    // Crear el procedimiento si no existe
                    string crearProc = @"
                        CREATE PROCEDURE SP_ObtenerListaMedicosPorEspecialidad(
                        @CodigoEspecialidad_ME INT
                        )
                        AS
                        BEGIN
                        SELECT Legajo_ME,
                               Apellido_ME + ' ' + Nombre_ME AS 'Medico', 
                               CodigoEspecialidad_ME
                        FROM Medico
                        WHERE CodigoEspecialidad_ME = @CodigoEspecialidad_ME
                        END";

                    SqlCommand cmdCrear = new SqlCommand(crearProc, conexion);
                    cmdCrear.ExecuteNonQuery();
                }
            }

        }
    }
}
