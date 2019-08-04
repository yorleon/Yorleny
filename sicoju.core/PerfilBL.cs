using sicoju.entities.Entities;
using sicoju.General;
using sicoju.Repositorio;
using System;
using System.Collections.Generic;

namespace sicoju.core
{
    public class PerfilBL
    {
        public static List<Perfil> GetPerfiles()
        {
            return PerfilRepositorio.Get();
        }
        public static List<Perfil> GetPerfilesFiltro(Perfil pPerfil)
        {
            try
            {
                return PerfilRepositorio.GetPerfiles(pPerfil);
            }
            catch (Exception ex) { throw ex; }
        }
        public static void DeletePerfil(int pPerfilID)
        {
            try
            {
                var vPerfil = PerfilRepositorio.Get(pPerfilID);
                var vFormularios = FormularioPerfilRepositorio.GetFormularios(vPerfil.PerfilID);

                foreach (var vFormulario in vFormularios)
                    FormularioPerfilRepositorio.Delete(vFormulario);

                PerfilRepositorio.Delete(vPerfil);
            }
            catch (Exception ex) { throw ex; }
        }
        public static Perfil SavePerfil(Perfil pPerfil)
        {
            try
            {
                return pPerfil.PerfilID > 0 ? PerfilRepositorio.Update(pPerfil) : PerfilRepositorio.Insert(pPerfil, true);
            }
            catch (Exception ex) { throw ex; }
        }
        public static List<PerfilReporte> GetPerfilesUsuario(int pUsuarioID)
        {
            var vPerfiles = new List<PerfilReporte>();
            try
            {
                var vListaUsuariosPerfil = UsuariosPerfilRepositorio.GetPerfiles(pUsuarioID);
                foreach (var vPerfil in vListaUsuariosPerfil)
                {
                    vPerfiles.Add(new PerfilReporte()
                    {
                        ID = vPerfil.UsuarioPerfilID,
                        Perfil = vPerfil.Perfil.Descripcion
                    });
                }

                return vPerfiles;
            }
            catch (Exception ex) { throw ex; }
        }
        public static void SaveUsuarioPerfil(UsuarioPerfil pUsuarioPerfil)
        {
            try
            {
                UsuariosPerfilRepositorio.Insert(pUsuarioPerfil);
            }
            catch (Exception ex) { throw ex; }
        }
        public static void DeleteUsuarioPerfil(int pUsuarioPerfilID)
        {
            try
            {
                var vUsuario = UsuariosPerfilRepositorio.Get(pUsuarioPerfilID);
                UsuariosPerfilRepositorio.Delete(vUsuario);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
