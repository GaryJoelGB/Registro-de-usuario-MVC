using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using PaginaRegistro.Models;
using System.Data.SqlClient;
using System.Data;

namespace PaginaRegistro.Logica
{
    public class LO_Usuario
    {
        public Usuarios EncontrarUsuario(string correo, string clave)
        {
            Usuarios objeto = new Usuarios();

            using (SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-VRMOVCG; Initial Catalog=Registro; Integrated Security=true"))
            {
                string query = "select Nombre,Correo,Clave,IdRol from USUARIO where Correo = @pcorreo and clave = @pclave";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@pcorreo", correo);
                cmd.Parameters.AddWithValue("@pclave", clave);
                cmd.CommandType = CommandType.Text;

                conexion.Open();

                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        objeto = new Usuarios()
                        {
                            Nombre = dr["Nombre"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Clave = dr["Clave"].ToString(),
                            IdRol = (Rol) dr["IdRol"],

                        };
                    }
                }




            }

            return objeto;
        }


    }
}