using System.Collections.Generic;
using System.Linq;
using SistemaGestionEntities;

namespace SistemaGestionData
{
    public static class ProductoVendidoData
    {
        private static List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

        public static ProductoVendido ObtenerProductoVendido(int id)
        {
            return productosVendidos.FirstOrDefault(pv => pv.Id == id);
        }

        public static List<ProductoVendido> ListarProductosVendidos()
        {
            return productosVendidos;
        }

        public static void CrearProductoVendido(ProductoVendido productoVendido)
        {
            productoVendido.Id = productosVendidos.Count > 0 ? productosVendidos.Max(pv => pv.Id) + 1 : 1; 
            productosVendidos.Add(productoVendido);
        }

        public static void ModificarProductoVendido(ProductoVendido productoVendido)
        {
            var existente = ObtenerProductoVendido(productoVendido.Id);
            if (existente != null)
            {
                existente.ProductoId = productoVendido.ProductoId;
                existente.Cantidad = productoVendido.Cantidad;
                existente.Precio = productoVendido.Precio;
            }
        }

        public static void EliminarProductoVendido(int id)
        {
            var productoVendido = ObtenerProductoVendido(id);
            if (productoVendido != null)
            {
                productosVendidos.Remove(productoVendido);
            }
        }
    }
}
