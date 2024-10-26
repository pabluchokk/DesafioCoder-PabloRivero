using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using SistemaGestionEntities;

namespace SistemaGestionData
{
    public static class VentaData
    {
        private static string connectionString = "cadena_de_conexion";
        public static List<Venta> ListarVentas()
        {
            var ventas = new List<Venta>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Ventas", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ventas.Add(new Venta
                    {
                        Id = (int)reader["Id"],
                        Comentarios = reader["Comentarios"].ToString(),
                        IdUsuario = (int)reader["IdUsuario"]
                    });
                }
            }
            return ventas;
        }
        public static void CrearVenta(Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Ventas (Comentarios, IdUsuario) VALUES (@Comentarios, @IdUsuario)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Comentarios", venta.Comentarios);
                command.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public static Venta ObtenerVenta(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Ventas WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Venta
                    {
                        Id = (int)reader["Id"],
                        Comentarios = reader["Comentarios"].ToString(),
                        IdUsuario = (int)reader["IdUsuario"]
                    };
                }
            }
            return null;
        }
        public static void ModificarVenta(Venta venta)
        {
            var existente = ObtenerVenta(venta.Id);
            if (existente != null)
            {
                existente.Comentarios = venta.Comentarios;
                existente.IdUsuario = venta.IdUsuario;
            }
        }
        public static void EliminarVenta(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Ventas WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

            }
        }
    }
}