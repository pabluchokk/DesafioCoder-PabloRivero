using System.Collections.Generic;
using System.Linq;
using SistemaGestionEntities;

namespace SistemaGestionData
{
    public static class UsuarioData
    {
        private static List<Usuario> usuarios = new List<Usuario>();

        public static Usuario ObtenerUsuario(int id)
        {
            return usuarios.FirstOrDefault(u => u.Id == id);
        }

        public static List<Usuario> ListarUsuarios()
        {
            return usuarios;
        }

        public static void CrearUsuario(Usuario usuario)
        {
            usuario.Id = usuarios.Count > 0 ? usuarios.Max(u => u.Id) + 1 : 1; // Generar un nuevo ID
            usuarios.Add(usuario);
        }

        public static void ModificarUsuario(Usuario usuario)
        {
            var existente = ObtenerUsuario(usuario.Id);
            if (existente != null)
            {
                existente.Nombre = usuario.Nombre;
                existente.Apellido = usuario.Apellido;
                existente.NombreUsuario = usuario.NombreUsuario;
                existente.Contraseña = usuario.Contraseña;
                existente.Mail = usuario.Mail;
            }
        }

        public static void EliminarUsuario(int id)
        {
            var usuario = ObtenerUsuario(id);
            if (usuario != null)
            {
                usuarios.Remove(usuario);
            }
        }
    }
}
