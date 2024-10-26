using System.Collections.Generic;
using SistemaGestionEntities;
using SistemaGestionData;

namespace SistemaGestionBusiness
{
    public static class ProductoBusiness
    {
        public static Producto ObtenerProducto(int id)
        {
            return ProductoData.ObtenerProducto(id);
        }

        public static List<Producto> ListarProductos()
        {
            return ProductoData.ListarProductos();
        }

        public static bool CrearProducto(Producto producto)
        {
            if (producto == null || string.IsNullOrEmpty(producto.Descripcion) || producto.Costo <= 0 || producto.PrecioVenta <= 0)
            {
                return false;
            }
            ProductoData.CrearProducto(producto);
            return true;
        }

        public static bool ModificarProducto(Producto producto)
        {
            if (producto == null || producto.Id <= 0 || string.IsNullOrEmpty(producto.Descripcion) || producto.Costo <= 0 || producto.PrecioVenta <= 0)
            {
                return false;
            }

            var productoExistente = ProductoData.ObtenerProducto(producto.Id);
            if (productoExistente == null)
            {
                return false;
            }

            ProductoData.ModificarProducto(producto);
            return true;
        }

        public static bool EliminarProducto(int id)
        {
            var productoExistente = ProductoData.ObtenerProducto(id);
            if (productoExistente == null)
            {
                return false;
            }

            ProductoData.EliminarProducto(id);
            return true;
        }
    }
}
