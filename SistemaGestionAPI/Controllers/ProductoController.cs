using Microsoft.AspNetCore.Mvc;
using SistemaGestionData;
using SistemaGestionEntities;

[ApiController]
[Route("api/[controller]")]
public class ProductoController : ControllerBase
{
    [HttpPost("CrearProducto")]
    public IActionResult CrearProducto([FromBody] Producto producto)
    {
        if (string.IsNullOrEmpty(producto.Descripcion) || producto.Costo <= 0 || producto.PrecioVenta <= 0)
        {
            return BadRequest("Datos del producto incompletos o incorrectos.");
        }

        ProductoData.CrearProducto(producto);
        return Ok("Producto creado correctamente.");
    }

    [HttpPut("ModificarProducto/{id}")]
    public IActionResult ModificarProducto(int id, [FromBody] Producto producto)
    {
        if (producto == null || id != producto.Id)
        {
            return BadRequest("Datos del producto incorrectos.");
        }

        var productoExistente = ProductoData.ObtenerProducto(id);
        if (productoExistente == null)
        {
            return NotFound("Producto no encontrado.");
        }

        ProductoData.ModificarProducto(producto);
        return Ok("Producto modificado correctamente.");
    }

    [HttpDelete("EliminarProducto/{id}")]
    public IActionResult EliminarProducto(int id)
    {
        var productoExistente = ProductoData.ObtenerProducto(id);
        if (productoExistente == null)
        {
            return NotFound("Producto no encontrado.");
        }

        ProductoVendidoData.EliminarProductoVendido(id);

        ProductoData.EliminarProducto(id);
        return Ok("Producto eliminado correctamente.");
    }

    [HttpGet("ListarProductos")]
    public IActionResult ListarProductos()
    {
        var productos = ProductoData.ListarProductos();
        return Ok(productos);
    }

    [HttpGet("ObtenerProducto/{id}")]
    [HttpGet("ObtenerProductos")]
    public IActionResult ObtenerProductos()
    {
        var productos = ProductoData.ListarProductos();
        return Ok(productos);
    }
}
