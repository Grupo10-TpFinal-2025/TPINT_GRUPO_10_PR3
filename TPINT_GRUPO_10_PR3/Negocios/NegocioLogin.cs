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
            DaoLogin dao = new DaoLogin();
            DataTable tabla = dao.ObtenerUsuario(usuario, contrasena);

            return tabla.Rows.Count > 0;
        }
    }
}