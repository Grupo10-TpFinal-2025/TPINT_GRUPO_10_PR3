using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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
        private string ConsultaBase = "SELECT M.Legajo_ME AS 'Legajo', M.Nombre_ME As 'Nombre', M.Apellido_ME As 'Apellido', M.DNI_ME As 'DNI', CASE M.Sexo_ME WHEN 'F' Then 'Femenino' ELSE 'Masculino' END AS 'Sexo', M.FechaNacimiento_ME AS 'Nacimiento' ,M.Nacionalidad_ME AS 'Nacionalidad' ,(SELECT P.Descripcion_PR FROM Provincia  AS P WHERE P.CodProvincia_PR = M.CodProvincia_ME) AS 'Provincia', M.CodProvincia_ME AS 'CodProvincia', M.Localidad_ME AS 'Localidad', M.Direccion_ME AS 'Direccion', M.Telefono_ME AS 'Telefono', M.Correo_ME AS 'Correo',(SELECT E.Descripcion_ES FROM Especialidad AS E WHERE E.CodEspecialidad_ES = M.CodigoEspecialidad_ME) AS 'Especialidad', M.CodigoEspecialidad_ME AS 'CodEspecialidad' FROM Medico AS M WHERE M.Estado_ME = 1";
        private SqlCommand sqlCommand;

        ///--------------------------------------------------- Constructores ------------------------------------------------------------------------------
        public DaoMedico()
        {
            datos = new AccesoDatos();
        }

        ///------------------------------------------------------ Metodos ---------------------------------------------------------------------------------


        //Alta Medico----------------------------------------------------------------------------------

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

        public DataTable getTablaMedicos()
        {
            const string consulta =
                "SELECT Legajo_ME AS Legajo, Apellido_ME AS Apellido, Nombre_ME AS Nombre, Sexo_ME AS Sexo, Nacionalidad_ME AS Nacionalidad, " +
                "FORMAT(FechaNacimiento_ME, 'dd/MM/yyyy') AS [Fecha de Nacimiento], Direccion_ME AS Dirección, Localidad_ME AS Localidad, " +
                "Descripcion_PR AS Provincia, Correo_ME AS Correo, Telefono_ME AS Teléfono, Descripcion_ES AS Especialidad, " +
                "DNI_ME AS DNI " +
                "FROM (Medico INNER JOIN Provincia " +
                "ON CodProvincia_ME = CodProvincia_PR) INNER JOIN Especialidad " +
                "ON CodigoEspecialidad_ME = CodEspecialidad_ES " +
                "WHERE Estado_ME = 1 ";
            
            DataTable dataTable = datos.ObtenerTabla("Medico", consulta);
            
            return dataTable;
        }

        public DataTable getTablaMedicosFiltrada(Medico medico, bool aplicarFiltroAvanzado, bool[,] filtros)
        {
            string consulta =
                "SELECT Legajo_ME AS Legajo, Apellido_ME AS Apellido, Nombre_ME AS Nombre, Sexo_ME AS Sexo, Nacionalidad_ME AS Nacionalidad, " +
                "FORMAT(FechaNacimiento_ME, 'dd/MM/yyyy') AS [Fecha de Nacimiento], Direccion_ME AS Dirección, Localidad_ME AS Localidad, " +
                "Descripcion_PR AS Provincia, Correo_ME AS Correo, Telefono_ME AS Teléfono, Descripcion_ES AS Especialidad, " +
                "DNI_ME AS DNI " +
                "FROM (Medico INNER JOIN Provincia " +
                "ON CodProvincia_ME = CodProvincia_PR) INNER JOIN Especialidad " +
                "ON CodigoEspecialidad_ME = CodEspecialidad_ES " +
                "WHERE Estado_ME = 1";

            if (!aplicarFiltroAvanzado)
            {
                consulta += " AND Legajo_ME = @Legajo_ME";

                sqlCommand = new SqlCommand(consulta);
                ArmarParametro_LegajoMedico(ref sqlCommand, medico);

                return datos.ObtenerTablaFiltrada("Medico", sqlCommand);
            }
            else
            {
                sqlCommand = GenerarConsultaAvanzada(medico, filtros, consulta);
                return datos.ObtenerTablaFiltrada("Medico", sqlCommand);
            }
        }

        private SqlCommand GenerarConsultaAvanzada(Medico medico, bool[,] filtros, string consulta)
        {
            sqlCommand = new SqlCommand();

            if (medico.DNI.Trim().Length > 0)
            {
                if (filtros[0, 0]) // Igual a
                {
                    consulta += " AND DNI_ME = @DNI_ME";
                    sqlCommand.Parameters.Add("@DNI_ME", SqlDbType.Char, 8).Value = medico.DNI;
                }
                else if (filtros[0, 1]) // Mayor a
                {
                    consulta += " AND DNI_ME > @DNI_ME";
                    sqlCommand.Parameters.Add("@DNI_ME", SqlDbType.Char, 8).Value = medico.DNI;
                }
                else if (filtros[0, 2]) // Menor a
                {
                    consulta += " AND DNI_ME < @DNI_ME";
                    sqlCommand.Parameters.Add("@DNI_ME", SqlDbType.Char, 8).Value = medico.DNI;
                }
            }

            if (medico.Apellido.Trim().Length > 0)
            {
                if (filtros[1, 0]) // Contiene
                {
                    consulta += " AND Apellido_ME LIKE @Apellido_ME";
                    sqlCommand.Parameters.Add("@Apellido_ME", SqlDbType.NVarChar, 50).Value = "%" + medico.Apellido + "%";
                }
                else if (filtros[1, 1]) // Empieza con
                {
                    consulta += " AND Apellido_ME LIKE @Apellido_ME";
                    sqlCommand.Parameters.Add("@Apellido_ME", SqlDbType.NVarChar, 50).Value = medico.Apellido + "%";
                }
                else if (filtros[1, 2]) // Termina con
                {
                    consulta += " AND Apellido_ME LIKE @Apellido_ME";
                    sqlCommand.Parameters.Add("@Apellido_ME", SqlDbType.NVarChar, 50).Value = "%" + medico.Apellido;
                }
            }

            if (medico.Correo.Trim().Length > 0)
            {
                if (filtros[2, 0]) // Contiene
                {
                    consulta += " AND Correo_ME LIKE @Correo_ME";
                    sqlCommand.Parameters.Add("@Correo_ME", SqlDbType.NVarChar, 100).Value = "%" + medico.Correo + "%";
                }
                else if (filtros[2, 1]) // Empieza con
                {
                    consulta += " AND Correo_ME LIKE @Correo_ME";
                    sqlCommand.Parameters.Add("@Correo_ME", SqlDbType.NVarChar, 100).Value = medico.Correo + "%";
                }
                else if (filtros[2, 2]) // Termina con
                {
                    consulta += " AND Correo_ME LIKE @Correo_ME";
                    sqlCommand.Parameters.Add("@Correo_ME", SqlDbType.NVarChar, 100).Value = "%" + medico.Correo;
                }
            }

            sqlCommand.CommandText = consulta;

            return sqlCommand;
        }

        //Carga los parametros en el SQL command
        private void CargarParametros(ref SqlCommand cmd, Medico medico)
        {
            if (medico.Legajo != 0)
            {
                cmd.Parameters.Add("@Legajo_ME", SqlDbType.Int).Value = medico.Legajo;
            }
            else
            {
                cmd.Parameters.Add("@Estado_ME", SqlDbType.Bit).Value = medico.Estado;
            }
            cmd.Parameters.Add("@Nombre_ME", SqlDbType.NVarChar, 50).Value = medico.Nombre;
            cmd.Parameters.Add("@Apellido_ME", SqlDbType.NVarChar, 50).Value = medico.Apellido;
            cmd.Parameters.Add("@Sexo_ME", SqlDbType.Char).Value = medico.Sexo;
            cmd.Parameters.Add("@Nacionalidad_ME", SqlDbType.NVarChar, 50).Value = medico.Nacionalidad;
            cmd.Parameters.Add("@FechaNacimiento_ME", SqlDbType.Date).Value = medico.FechaNacimiento;
            cmd.Parameters.Add("@Direccion_ME", SqlDbType.NVarChar, 100).Value = medico.Direccion;
            cmd.Parameters.Add("@Localidad_ME", SqlDbType.NVarChar, 50).Value = medico.Localidad;
            cmd.Parameters.Add("@CodProvincia_ME", SqlDbType.Int).Value = medico.CodigoProvincia;
            cmd.Parameters.Add("@Correo_ME", SqlDbType.NVarChar, 100).Value = medico.Correo;
            cmd.Parameters.Add("@Telefono_ME", SqlDbType.VarChar, 16).Value = medico.Telefono;
            cmd.Parameters.Add("@CodigoEspecialidad_ME", SqlDbType.Int).Value = medico.CodigoEspecialidad;
            cmd.Parameters.Add("@DNI_ME", SqlDbType.Char, 8).Value = medico.DNI;
        }

        public void ArmarParametro_LegajoMedico(ref SqlCommand command, Medico medico)
        {
            command.Parameters.Add("@Legajo_ME", SqlDbType.Int).Value = medico.Legajo;
        }

        //Agregar Medico
        public bool AgregarMedico(Medico medico)
        {
            //Variable consulta
            const string consulta = "INSERT INTO Medico ([Nombre_ME], [Apellido_ME], [Sexo_ME], [Nacionalidad_ME], [FechaNacimiento_ME], [Direccion_ME], [Localidad_ME], [CodProvincia_ME], [Correo_ME], [Telefono_ME], [CodigoEspecialidad_ME], [DNI_ME], [Estado_ME])" +
                                    " VALUES (@Nombre_ME, @Apellido_ME, @Sexo_ME, @Nacionalidad_ME, @FechaNacimiento_ME, @Direccion_ME, @Localidad_ME, @CodProvincia_ME, @Correo_ME, @Telefono_ME, @CodigoEspecialidad_ME, @DNI_ME, @Estado_ME)";

            //Creo el SqlCommand
            sqlCommand = new SqlCommand(consulta);

            //Cargo los parametros
            CargarParametros(ref sqlCommand, medico);
            return datos.AltaPorParametros(sqlCommand);
        }

        //Modificacion Medico ------------------------------------------------------------------------
        public DataTable ObtenerTablaCompleta_Medico()
        {
            //Obtengo la tabla
            return datos.ObtenerTabla("Medico", ConsultaBase);
        }

        public void ValidarOCrearProcedimientoModificacionMedico()
        {
            using (SqlConnection conexion = datos.ObtenerConexion())
            {
                string consultaExiste = "SELECT COUNT(*) FROM sys.objects WHERE type = 'P' AND name = 'ModificarMedico_Grupo10'";
                SqlCommand cmdExiste = new SqlCommand(consultaExiste, conexion);
                if ((int)cmdExiste.ExecuteScalar() == 0)
                {
                    string crearProc = @"
                    CREATE PROCEDURE ModificarMedico_Grupo10
                        @Legajo_ME INT, @DNI_ME CHAR(8), @Nombre_ME VARCHAR(50), @Apellido_ME VARCHAR(50),
                        @Sexo_ME CHAR(1), @Nacionalidad_ME VARCHAR(50), @FechaNacimiento_ME DATE,
                        @Direccion_ME VARCHAR(100), @Localidad_ME VARCHAR(50), @CodProvincia_ME INT,
                        @CodigoEspecialidad_ME INT, @Correo_ME VARCHAR(100), @Telefono_ME CHAR(12)
                    AS
                    BEGIN
                        UPDATE Medico SET 
                            DNI_ME = @DNI_ME, Nombre_ME = @Nombre_ME, Apellido_ME = @Apellido_ME, Sexo_ME = @Sexo_ME, 
                            Nacionalidad_ME = @Nacionalidad_ME, FechaNacimiento_ME = @FechaNacimiento_ME, 
                            Direccion_ME = @Direccion_ME, Localidad_ME = @Localidad_ME, 
                            CodProvincia_ME = @CodProvincia_ME, 
                            CodigoEspecialidad_ME = @CodigoEspecialidad_ME, 
                            Correo_ME = @Correo_ME, Telefono_ME = @Telefono_ME
                        WHERE Legajo_ME = @Legajo_ME;
                    END";
                    SqlCommand cmdCrear = new SqlCommand(crearProc, conexion);
                    cmdCrear.ExecuteNonQuery();
                }
            }
        }

        public int ModificacionMedico(Medico medico)
        {
            sqlCommand = new SqlCommand();
            CargarParametros(ref sqlCommand, medico);
            ValidarOCrearProcedimientoModificacionMedico();
            return datos.EjecutarProcedimientoAlmacenado("ModificarMedico_Grupo10", sqlCommand);
        }




    }
}
