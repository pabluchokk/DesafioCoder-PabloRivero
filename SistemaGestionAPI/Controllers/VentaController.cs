using Microsoft.AspNetCore.Mvc;
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
            return BadRequest("Datos de la venta incorrectos");
        }

        var nuevaVenta = new Venta
        {
            IdUsuario = idUsuario,
            Comentarios = "Venta realizada"
        };
        VentaData.CrearVenta(nuevaVenta);

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
        return Ok("Venta creada correctamente");
    }

    [HttpPut("ModificarVenta/{id}")]
    public IActionResult ModificarVenta(int id, [FromBody] Venta venta)
    {
        venta.Id = id;
        VentaData.ModificarVenta(venta);
        return Ok("Venta modificada correctamente.");
    }

    [HttpDelete("EliminarVenta/{id}")]
    public IActionResult EliminarVenta(int id)
    {
        VentaData.EliminarVenta(id);
        return Ok("Venta eliminada correctamente.");
    }

    [HttpGet("ListarVentas")]
    public IActionResult ListarVentas()
    {
        var ventas = VentaData.ListarVentas();
        return Ok(ventas);
    }

    [HttpGet("ObtenerVenta/{id}")]
    public IActionResult ObtenerVenta(int id)
    {
        var venta = VentaData.ObtenerVenta(id);
        if (venta == null) return NotFound("Venta no encontrada.");
        return Ok(venta);
    }
}
