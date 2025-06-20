using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DaoLogin
    {
        private AccesoDatos datos;

        public DaoLogin()
        {
            datos = new AccesoDatos();
        }

        public DataTable ObtenerUsuario(string usuario, string contrasena)
        {
            string consulta = "SELECT * FROM UsuarioAdministrador WHERE Nombre_UA = @usuario AND Contraseña_UA = @contrasena AND Estado_UA = 1";

            SqlCommand comando = new SqlCommand(consulta);
            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@contrasena", contrasena);

            return datos.ObtenerTablaFiltrada("UsuarioAdministrador", comando);
        }
    }
}
