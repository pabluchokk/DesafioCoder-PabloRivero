using System.Collections.Generic;
using System.Linq;
using SistemaGestionEntities;
using System.Data.SqlClient;

namespace SistemaGestionData
{
    public static class UsuarioData
    {
        private static string connectionString = "CADENA_DE_CONEXION";
        public static List<Usuario> ListarUsuarios()
        {
            var usuarios = new List<Usuario>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Usuarios", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    usuarios.Add(new Usuario
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        NombreUsuario = reader["NombreUsuario"].ToString(),
                        Contraseña = reader["Contraseña"].ToString(),
                        Mail = reader["Mail"].ToString()
                    });
                }
            }
            return usuarios;
        }
        public static Usuario ObtenerUsuario(int id)
        {
            Usuario usuario = null;

            using (SqlConnection connection = new SqlConnection("tu_cadena_de_conexion"))
            {
                string query = "SELECT * FROM Usuarios WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    usuario = new Usuario
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        NombreUsuario = reader["NombreUsuario"].ToString(),
                        Contraseña = reader["Contraseña"].ToString(),
                        Mail = reader["Mail"].ToString()
                    };
                }

                reader.Close();
            }

            return usuario;
        }
        public static void CrearUsuario(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Usuarios (Nombre, Apellido, NombreUsuario, Contraseña, Mail) " +
                               "VALUES (@Nombre, @Apellido, @NombreUsuario, @Contraseña, @Mail)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                command.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                command.Parameters.AddWithValue("@Mail", usuario.Mail);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public static void ModificarUsuario(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Usuarios SET Nombre = @Nombre, Apellido = @Apellido, NombreUsuario = @NombreUsuario, Contraseña = @Contraseña, Mail = @Mail WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                command.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                command.Parameters.AddWithValue("@Mail", usuario.Mail);
                command.Parameters.AddWithValue("@Id", usuario.Id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public static void EliminarUsuario(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Usuarios WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public static Usuario ObtenerUsuarioPorCredenciales(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Usuarios WHERE NombreUsuario = @Username AND Contraseña = @Password", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Usuario
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        NombreUsuario = reader["NombreUsuario"].ToString(),
                        Contraseña = reader["Contraseña"].ToString(),
                        Mail = reader["Mail"].ToString()
                    };
                }

                return null;
            }
        }
    }
}

