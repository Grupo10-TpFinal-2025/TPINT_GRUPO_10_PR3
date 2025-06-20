using System;
using System.Data;
using System.Data.SqlClient;
using Datos;

namespace Negocios
{
    public class NegocioLogin
    {
        public bool ValidarUsuario(string usuario, string contrasena)
        {
            AccesoDatos acceso = new AccesoDatos();

            string consulta = "SELECT * FROM UsuarioAdministrador WHERE Nombre_UA = @usuario AND Contraseña_UA = @contrasena AND Estado_UA = 1";

            SqlCommand comando = new SqlCommand(consulta);
            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@contrasena", contrasena);

            DataTable tabla = acceso.ObtenerTablaFiltrada("UsuarioAdministrador", comando);

            return tabla.Rows.Count > 0;
        }
    }
}