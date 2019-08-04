using sicoju.core;
using sicoju.entities.Entities;
using sicoju.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace sicoju.services
{

    public class ServicioJudicial : IServicioJudicial
    {

        #region Casos
        public List<Caso> GetCasosFiltro(Caso pCaso)
        {
            try
            {
                return CasoBL.GetCasosFiltro(pCaso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Caso GetCaso(int pCasoID)
        {
            try
            {
                return CasoBL.GetCaso(pCasoID);

            }
            catch (Exception ex) { throw ex; }
        }
        public List<Involucrado> GetInvolucrados()
        {
            try
            {
                return CasoBL.GetInvolucrados();
            }
            catch (Exception ex) { throw ex; }
        }
        public void DeleteDetalleCaso(int pDetalleID)
        {
            CasoBL.DeleteDetalleCaso(pDetalleID);
        }
        public Caso SaveCaso(Caso pCaso)
        {
            try
            {
                return CasoBL.SaveCaso(pCaso);
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region Seguridad
        public List<Formulario> GetFormularios()
        {
            return FormularioBL.GetFormularios();
        }
        public List<Formulario> GetFormulariosFiltro(Formulario pFormulario)
        {
            return FormularioBL.GetFormulariosFiltro(pFormulario);
        }
        public List<FormularioReporte> GetFormulariosPerfil(int pPerfilID)
        {
            return FormularioBL.GetFormulariosPerfil(pPerfilID);
        }
        public void DeleteFormularioPerfil(int pFormularioPerfilID)
        {
            FormularioBL.DeleteFormularioPerfil(pFormularioPerfilID);
        }
        public void SaveFormularioPerfil(FormularioPerfil pFormularioPerfil)
        {
            FormularioBL.SaveFormularioPerfil(pFormularioPerfil);
        }
        public Formulario SaveFormulario(Formulario pFormulario)
        {
            return FormularioBL.SaveFormulario(pFormulario);
        }
        public void DeleteFormulario(int pFormularioID)
        {
            FormularioBL.DeleteFormulario(pFormularioID);
        }
        #endregion

        #region Usuarios
        public Usuario GetUsuario(Usuario pUsuario, Boolean pCompleto = false)
        {
            try
            {
                return UsuarioBL.GetUsuario(pUsuario, pCompleto);

            }
            catch (Exception ex) { throw ex; }

        }
        public Usuario CambiarClave(Usuario pUsuario)
        {
            try
            {
                return UsuarioBL.CambiarClave(pUsuario);
            }
            catch (Exception ex) { throw ex; }
        }
        public string ValidarUsuario(Usuario pUsuario)
        {
            try
            {
                return UsuarioBL.ValidarUsuario(pUsuario);
            }
            catch (Exception ex) { throw ex; }
        }
        public List<Usuario> GetUsuarios()
        {
            try
            {
                return UsuarioBL.GetUsuarios();
            }
            catch (Exception ex) { throw ex; }

        }
        public List<Usuario> GetUsuariosFiltro(Usuario pUsuario, Boolean pTodos = false)
        {
            try
            {
                return UsuarioBL.GetUsuariosFiltro(pUsuario, pTodos);
            }
            catch (Exception ex) { throw ex; }
        }
        public void DeleteUsuario(int pUsuarioID)
        {
            try
            {
                UsuarioBL.DeleteUsuario(pUsuarioID);
            }
            catch (Exception ex) { throw ex; }
        }
        public Usuario SaveUsuario(Usuario pUsuario)
        {
            try
            {
                return UsuarioBL.SaveUsuario(pUsuario);
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region Perfiles
        public  List<Perfil> GetPerfiles()
        {
            return PerfilBL.GetPerfiles();
        }
        public  List<Perfil> GetPerfilesFiltro(Perfil pPerfil)
        {
            try
            {
                return PerfilBL.GetPerfilesFiltro(pPerfil);
            }
            catch (Exception ex) { throw ex; }
        }
        public  void DeletePerfil(int pPerfilID)
        {
            try
            {
                PerfilBL.DeletePerfil(pPerfilID);
            }
            catch (Exception ex) { throw ex; }
        }
        public  Perfil SavePerfil(Perfil pPerfil)
        {
            try
            {
                return PerfilBL.SavePerfil(pPerfil);
            }
            catch (Exception ex) { throw ex; }
        }
        public  List<PerfilReporte> GetPerfilesUsuario(int pUsuarioID)
        {
            try
            {

                return PerfilBL.GetPerfilesUsuario(pUsuarioID);
            }
            catch (Exception ex) { throw ex; }
        }
        public  void SaveUsuarioPerfil(UsuarioPerfil pUsuarioPerfil)
        {
            try
            {
                PerfilBL.SaveUsuarioPerfil(pUsuarioPerfil);
            }
            catch (Exception ex) { throw ex; }
        }
        public  void DeleteUsuarioPerfil(int pUsuarioPerfilID)
        {
            try
            {
                PerfilBL.DeleteUsuarioPerfil(pUsuarioPerfilID);
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
    }
}
