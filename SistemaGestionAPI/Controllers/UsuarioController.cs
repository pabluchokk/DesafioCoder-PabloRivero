using Microsoft.AspNetCore.Mvc;
using SistemaGestionData;
using SistemaGestionEntities;

[ApiController]
[Route("api/[controller]")] 
public class UsuarioController : ControllerBase
{
    [HttpPost("CrearUsuario")]
    public IActionResult CrearUsuario([FromBody] Usuario usuario)
    {
        UsuarioData.CrearUsuario(usuario);
        return Ok("Usuario creado correctamente");
    }

    [HttpPut("ModificarUsuario/{id}")]
    public IActionResult ModificarUsuario(int id, [FromBody] Usuario usuario)
    {
        if (usuario == null || id != usuario.Id)
        {
            return BadRequest("Los datos proporcionados son incorrectos");
        }

        var usuarioExistente = UsuarioData.ObtenerUsuario(id);
        if (usuarioExistente == null)
        {
            return NotFound("El usuario no fue encontrado.");
        }

        UsuarioData.ModificarUsuario(usuario);
        return Ok("Usuario modificado correctamente");
    }

    [HttpDelete("EliminarUsuario/{id}")]
    public IActionResult EliminarUsuario(int id)
    {
        UsuarioData.EliminarUsuario(id);
        return Ok("Usuario eliminado correctamente.");
    }

    [HttpGet("ListarUsuarios")]
    public IActionResult ListarUsuarios()
    {
        var usuarios = UsuarioData.ListarUsuarios();
        return Ok(usuarios);
    }

    [HttpGet("ObtenerUsuario/{id}")]
    public IActionResult ObtenerUsuario(int id)
    {
        var usuario = UsuarioData.ObtenerUsuario(id);
        if (usuario == null) return NotFound("Usuario no encontrado.");
        return Ok(usuario);
    }
}