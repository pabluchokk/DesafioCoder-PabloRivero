using System.Collections.Generic;
using System.Linq;
using SistemaGestionEntities;

namespace SistemaGestionData
{
    public static class ProductoData
    {
        private static List<Producto> productos = new List<Producto>();

        public static Producto ObtenerProducto(int id)
        {
            return productos.FirstOrDefault(p => p.Id == id);
        }

        public static List<Producto> ListarProductos()
        {
            return productos;
        }

        public static void CrearProducto(Producto producto)
        {
            producto.Id = productos.Count > 0 ? productos.Max(p => p.Id) + 1 : 1; 
            productos.Add(producto);
        }

        public static void ModificarProducto(Producto producto)
        {
            var existente = ObtenerProducto(producto.Id);
            if (existente != null)
            {
                existente.Descripcion = producto.Descripcion;
                existente.Costo = producto.Costo;
                existente.PrecioVenta = producto.PrecioVenta;
                existente.Stock = producto.Stock;
                existente.IdUsuario = producto.IdUsuario;
            }
        }

        public static void EliminarProducto(int id)
        {
            var producto = ObtenerProducto(id);
            if (producto != null)
            {
                productos.Remove(producto);
            }
        }
    }
}
