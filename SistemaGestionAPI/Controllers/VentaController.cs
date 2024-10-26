using Microsoft.AspNetCore.Mvc;
using SistemaGestionBusiness;
using SistemaGestionData;
using SistemaGestionEntities;

[ApiController]
[Route("api/[controller]")]
public class VentaController : ControllerBase
{
    [HttpPost("CrearVenta")]
    public IActionResult CrearVenta([FromBody] List<ProductoVendido> productoVendidos, [FromQuery] int idUsuario)
    {
        if (productoVendidos == null || productoVendidos.Count == 0 || idUsuario <= 0)
        {
            return BadRequest("Datos de la venta incorrectos.");
        }

        var nuevaVenta = new Venta
        {
            IdUsuario = idUsuario,
            Comentarios = "Venta realizada"
        };
        VentaBusiness.CrearVenta(nuevaVenta);

        foreach (var productoVendido in productoVendidos)
        {
            var producto = ProductoData.ObtenerProducto(productoVendido.ProductoId);

            if (producto == null || producto.Stock < productoVendido.Cantidad)
            {
                return BadRequest($"Stock insuficiente para el producto con ID {productoVendido.ProductoId}");
            }

            productoVendido.IdVenta = nuevaVenta.Id;
            ProductoVendidoData.CrearProductoVendido(productoVendido);

            producto.Stock -= productoVendido.Cantidad;
            ProductoData.ModificarProducto(producto);
        }
        return Ok("Venta creada correctamente.");
    }

    [HttpPut("ModificarVenta/{id}")]
    public IActionResult ModificarVenta(int id, [FromBody] Venta venta)
    {
        if (venta == null || id != venta.Id)
        {
            return BadRequest("Datos de la venta incorrectos.");
        }

        var ventaExistente = VentaData.ObtenerVenta(id);
        if (ventaExistente == null)
        {
            return NotFound("Venta no encontrada.");
        }

        VentaBusiness.ModificarVenta(venta);
        return Ok("Venta modificada correctamente.");
    }

    [HttpDelete("EliminarVenta/{id}")]
    public IActionResult EliminarVenta(int id)
    {
        var ventaExistente = VentaData.ObtenerVenta(id);
        if (ventaExistente == null)
        {
            return NotFound("Venta no encontrada.");
        }

        VentaBusiness.EliminarVenta(id);
        return Ok("Venta eliminada correctamente.");
    }

    [HttpGet("ListarVentas")]
    public IActionResult ListarVentas()
    {
        var ventas = VentaBusiness.ListarVentas();
        return Ok(ventas);
    }

    [HttpGet("ObtenerVenta/{id}")]
    public IActionResult ObtenerVenta(int id)
    {
        var venta = VentaBusiness.ObtenerVenta(id);
        if (venta == null) return NotFound("Venta no encontrada.");
        return Ok(venta);
    }
}
