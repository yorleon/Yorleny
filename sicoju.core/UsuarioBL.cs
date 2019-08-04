using sicoju.entities.Entities;
using sicoju.Repositorio;
using System;
using System.Collections.Generic;

namespace sicoju.core
{
    public class UsuarioBL
    {
        public static Usuario GetUsuario(Usuario pUsuario, Boolean pCompleto = false)
        {
            try
            {
                if (pCompleto)
                    return UsuariosRepositorio.GetUsuario(pUsuario, pCompleto);

                return UsuariosRepositorio.GetUsuario(pUsuario);

            }
            catch (Exception ex) { throw ex; }

        }
        public static Usuario CambiarClave(Usuario pUsuario)
        {
            try
            {
                var vUsuarioExistente = UsuariosRepositorio.GetUsuario(pUsuario);
                if (vUsuarioExistente != null || vUsuarioExistente.UsuarioID != 0)
                {
                    vUsuarioExistente.Clave = pUsuario.Clave;
                    vUsuarioExistente.Restablecer = pUsuario.Restablecer;
                }

                return UsuariosRepositorio.Update(vUsuarioExistente);
            }
            catch (Exception ex) { throw ex; }
        }
        public static string ValidarUsuario(Usuario pUsuario)
        {
            try
            {

                var vUsuarioExistente = UsuariosRepositorio.GetUsuario(pUsuario);

                if (vUsuarioExistente == null || vUsuarioExistente.UsuarioID == 0)
                    return "N";

                if (!vUsuarioExistente.Activo)
                    return "I";

                if (vUsuarioExistente.Clave == pUsuario.Clave)
                    return "S";
                else
                    return "C";

            }
            catch (Exception ex) { throw ex; }
        }
        public static List<Usuario> GetUsuarios()
        {
            try
            {
                return UsuariosRepositorio.Get();
            }
            catch (Exception ex) { throw ex; }

        }
        public static List<Usuario> GetUsuariosFiltro(Usuario pUsuario, Boolean pTodos = false)
        {
            try
            {
                return UsuariosRepositorio.GetUsuarios(pUsuario,pTodos);
            }
            catch (Exception ex) { throw ex; }
        }
        public static void DeleteUsuario(int pUsuarioID)
        {
            try
            {
                var vUsuario = UsuariosRepositorio.Get(pUsuarioID);
                UsuariosRepositorio.Delete(vUsuario);
            }
            catch (Exception ex) { throw ex; }
        }
        public static Usuario SaveUsuario(Usuario pUsuario)
        {
            try
            {
                return pUsuario.UsuarioID > 0 ? UsuariosRepositorio.Update(pUsuario) : UsuariosRepositorio.Insert(pUsuario, true);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
