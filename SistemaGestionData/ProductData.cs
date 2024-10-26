using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using SistemaGestionEntities;

namespace SistemaGestionData
{
    public static class ProductoData
    {
        private const string connectionString = "cadena_de_conexion";

        public static Producto ObtenerProducto(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Productos WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Producto
                        {
                            Id = (int)reader["Id"],
                            Descripcion = reader["Descripcion"].ToString(),
                            Costo = (decimal)reader["Costo"],
                            PrecioVenta = (decimal)reader["PrecioVenta"],
                            Stock = (int)reader["Stock"],
                            IdUsuario = (int)reader["IdUsuario"]
                        };
                    }
                }
            }
            return null; 
        }

        public static List<Producto> ListarProductos()
        {
            var productos = new List<Producto>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Productos", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        productos.Add(new Producto
                        {
                            Id = (int)reader["Id"],
                            Descripcion = reader["Descripcion"].ToString(),
                            Costo = (decimal)reader["Costo"],
                            PrecioVenta = (decimal)reader["PrecioVenta"],
                            Stock = (int)reader["Stock"],
                            IdUsuario = (int)reader["IdUsuario"]
                        });
                    }
                }
            }
            return productos; 
        }

        public static void CrearProducto(Producto producto)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("INSERT INTO Productos (Descripcion, Costo, PrecioVenta, Stock, IdUsuario) VALUES (@Descripcion, @Costo, @PrecioVenta, @Stock, @IdUsuario)", connection);
                command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                command.Parameters.AddWithValue("@Costo", producto.Costo);
                command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                command.Parameters.AddWithValue("@Stock", producto.Stock);
                command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void ModificarProducto(Producto producto)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("UPDATE Productos SET Descripcion = @Descripcion, Costo = @Costo, PrecioVenta = @PrecioVenta, Stock = @Stock, IdUsuario = @IdUsuario WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                command.Parameters.AddWithValue("@Costo", producto.Costo);
                command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                command.Parameters.AddWithValue("@Stock", producto.Stock);
                command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);
                command.Parameters.AddWithValue("@Id", producto.Id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void EliminarProducto(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("DELETE FROM Productos WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
