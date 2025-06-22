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
        private readonly AccesoDatos datos;
        private SqlCommand sqlCommand;

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
            cmd.Parameters.Add("@Nombre_ME", SqlDbType.NVarChar, 50).Value = medico.Nombre;
            cmd.Parameters.Add("@Apellido_ME", SqlDbType.NVarChar, 50).Value = medico.Apellido;
            cmd.Parameters.Add("@Sexo_ME", SqlDbType.Char).Value = medico.Sexo;
            cmd.Parameters.Add("@Nacionalidad_ME", SqlDbType.NVarChar, 50).Value = medico.Nacionalidad;
            cmd.Parameters.Add("@FechaNacimiento_ME", SqlDbType.Date).Value = medico.FechaNacimiento;
            cmd.Parameters.Add("@Direccion_ME", SqlDbType.NVarChar, 100).Value = medico.Direccion;
            cmd.Parameters.Add("@Localidad_ME", SqlDbType.NVarChar, 50).Value = medico.Localidad;
            cmd.Parameters.Add("@CodProvincia_ME", SqlDbType.Int).Value = medico.CodigoProvincia;
            cmd.Parameters.Add("@Correo_ME", SqlDbType.NVarChar, 100).Value = medico.Correo;
            cmd.Parameters.Add("@Telefono_ME", SqlDbType.Char, 10).Value = medico.Telefono;
            cmd.Parameters.Add("@CodigoEspecialidad_ME", SqlDbType.Int).Value = medico.CodigoEspecialidad;
            cmd.Parameters.Add("@DNI_ME", SqlDbType.Char, 8).Value = medico.DNI;
            cmd.Parameters.Add("@Estado_ME", SqlDbType.Bit).Value = medico.Estado;
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
    }
}
