using System.Collections.Generic;
using SistemaGestionEntities;
using SistemaGestionData;

namespace SistemaGestionBusiness
{
    public static class UsuarioBusiness
    {
        public static Usuario TraerUsuario(int id)
        {
            return UsuarioData.ObtenerUsuario(id);
        }
        public static Usuario ObtenerUsuario(int id)
        {
            return UsuarioData.ObtenerUsuario(id);
        }
        public static List<Usuario> ListarUsuarios()
        {
            return UsuarioData.ListarUsuarios();
        }
        public static bool CrearUsuario(Usuario nuevoUsuario)
        {
            try
            {
                UsuarioData.CrearUsuario(nuevoUsuario);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool ModificarUsuario(int id, Usuario usuarioModificado)
        {
            try
            {
                usuarioModificado.Id = id;
                UsuarioData.ModificarUsuario(usuarioModificado);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool EliminarUsuario(int id)
        {
            try
            {
                UsuarioData.EliminarUsuario(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static Usuario ValidarCredenciales(string username, string password)
        {
            return UsuarioData.ObtenerUsuarioPorCredenciales(username, password);
        }
    }
}
