using System.Collections.Generic;
using System.Linq;
using SistemaGestionEntities;

namespace SistemaGestionData
{
    public static class VentaData
    {
        private static List<Venta> ventas = new List<Venta>();

        public static Venta ObtenerVenta(int id)
        {
            return ventas.FirstOrDefault(v => v.Id == id);
        }

        public static List<Venta> ListarVentas()
        {
            return ventas;
        }

        public static void CrearVenta(Venta venta)
        {
            venta.Id = ventas.Count > 0 ? ventas.Max(v => v.Id) + 1 : 1; 
            ventas.Add(venta);
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
            var venta = ObtenerVenta(id);
            if (venta != null)
            {
                ventas.Remove(venta);
            }
        }
    }
}
