﻿using System.Collections.Generic;
using SistemaGestionEntities;
using SistemaGestionData;

namespace SistemaGestionBusiness
{
    public static class UsuarioBusiness
    {
        public static Usuario ObtenerUsuario(int id)
        {
            return UsuarioData.ObtenerUsuario(id);
        }

        public static List<Usuario> ListarUsuarios()
        {
            return UsuarioData.ListarUsuarios();
        }

        public static void CrearUsuario(Usuario usuario)
        {
            UsuarioData.CrearUsuario(usuario);
        }

        public static void ModificarUsuario(Usuario usuario)
        {
            UsuarioData.ModificarUsuario(usuario);
        }

        public static void EliminarUsuario(int id)
        {
            UsuarioData.EliminarUsuario(id);
        }
    }
}
