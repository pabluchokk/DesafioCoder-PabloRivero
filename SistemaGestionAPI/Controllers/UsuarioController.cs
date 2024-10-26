using Microsoft.AspNetCore.Mvc;
using SistemaGestionData;
using SistemaGestionBusiness;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    [HttpPost("CrearUsuario")]
    public IActionResult CrearUsuario(SistemaGestionEntities.Usuario nuevoUsuario)
    {
        if (string.IsNullOrWhiteSpace(nuevoUsuario.Nombre) ||
            string.IsNullOrWhiteSpace(nuevoUsuario.Apellido) ||
            string.IsNullOrWhiteSpace(nuevoUsuario.NombreUsuario) ||
            string.IsNullOrWhiteSpace(nuevoUsuario.Contraseña) ||
            string.IsNullOrWhiteSpace(nuevoUsuario.Mail))
        {
            return BadRequest("Todos los campos son obligatorios.");
        }

        var resultado = UsuarioBusiness.CrearUsuario(nuevoUsuario);

        if (!UsuarioBusiness.CrearUsuario(nuevoUsuario))
        {
            return StatusCode(500, "Error al crear el usuario en la base de datos.");
        }

        return Ok("Usuario creado exitosamente.");
    }
    [HttpPut("ModificarUsuario/{id}")]
    public IActionResult ModificarUsuario(int id, SistemaGestionEntities.Usuario usuarioModificado)
    {
        if (id <= 0 || usuarioModificado == null ||
            string.IsNullOrWhiteSpace(usuarioModificado.Nombre) ||
            string.IsNullOrWhiteSpace(usuarioModificado.Apellido) ||
            string.IsNullOrWhiteSpace(usuarioModificado.NombreUsuario) ||
            string.IsNullOrWhiteSpace(usuarioModificado.Contraseña) ||
            string.IsNullOrWhiteSpace(usuarioModificado.Mail))
        {
            return BadRequest("Los datos del usuario son inválidos.");
        }

        var resultado = UsuarioBusiness.ModificarUsuario(id, usuarioModificado);

        if (!resultado)
        {
            return StatusCode(500, "Error al modificar el usuario en la base de datos.");
        }

        return Ok("Usuario modificado exitosamente.");
    }
    [HttpDelete("EliminarUsuario/{id}")]
    public IActionResult EliminarUsuario(int id)
    {
        if (id <= 0)
        {
            return BadRequest("ID de usuario inválido.");
        }

        var resultado = UsuarioBusiness.EliminarUsuario(id);

        if (!resultado)
        {
            return StatusCode(500, "Error al eliminar el usuario en la base de datos.");
        }
        return Ok("Usuario eliminado exitoxamente.");
    }
    [HttpGet("ListarUsuarios")]
    public IActionResult ListarUsuarios()
    {
        var usuarios = UsuarioData.ListarUsuarios();
        return Ok(usuarios);
    }
    [HttpGet("TraerUsuario/{id}")]
    public IActionResult TraerUsuario(int id)
    {
        if (id <= 0)
        {
            return BadRequest("ID de usuario inválido.");
        }
        var usuario = UsuarioBusiness.TraerUsuario(id);

        if (usuario == null)
        {
            return NotFound("Usuario no encontrado");
        }

        return Ok(usuario);
    }
    [HttpGet("TraerNombre")]
    public IActionResult TraerNombre(int id)
    {
        var usuario = UsuarioBusiness.TraerUsuario(id);

        if (usuario == null)
        {
            return NotFound("Usuario no encontrado.");
        }

        return Ok(usuario.Nombre);
    }
    [HttpPost("IniciarSesion")]
    public IActionResult IniciarSesion(SistemaGestionEntities.LoginRequest loginRequest)
    {
        var usuario = UsuarioBusiness.ValidarCredenciales(loginRequest.Username, loginRequest.Password);

        if (usuario == null)
        {
            return Unauthorized("Nombre de usuario o contraseña incorrectos.");
        }

        return Ok(new
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            Apellido = usuario.Apellido,
            Mail = usuario.Mail
        });
    }
}