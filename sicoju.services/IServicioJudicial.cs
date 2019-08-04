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
    [ServiceContract]
    public interface IServicioJudicial
    {
        #region Casos
        [OperationContract]
        List<Caso> GetCasosFiltro(Caso pCaso);
        [OperationContract]
        Caso GetCaso(int pCasoID);
        [OperationContract]
        List<Involucrado> GetInvolucrados();
        [OperationContract]
        void DeleteDetalleCaso(int pDetalleID);
        [OperationContract]
        Caso SaveCaso(Caso pCaso);
        #endregion

        #region Seguridad
        [OperationContract]
        List<Formulario> GetFormularios();
        [OperationContract]
        List<Formulario> GetFormulariosFiltro(Formulario pFormulario);
        [OperationContract]
        List<FormularioReporte> GetFormulariosPerfil(int pPerfilID);
        [OperationContract]
        void DeleteFormularioPerfil(int pFormularioPerfilID);
        [OperationContract]
        void SaveFormularioPerfil(FormularioPerfil pFormularioPerfil);
        [OperationContract]
        Formulario SaveFormulario(Formulario pFormulario);
        [OperationContract]
        void DeleteFormulario(int pFormularioID);
        #endregion

        #region Usuarios
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        Usuario GetUsuario(Usuario pUsuario, Boolean pCompleto = false);
        [OperationContract]
        Usuario CambiarClave(Usuario pUsuario);
        [OperationContract]
        string ValidarUsuario(Usuario pUsuario);
        [OperationContract]
        List<Usuario> GetUsuarios();
        [OperationContract]
        List<Usuario> GetUsuariosFiltro(Usuario pUsuario, Boolean pTodos = false);
        [OperationContract]
        void DeleteUsuario(int pUsuarioID);
        [OperationContract]
        Usuario SaveUsuario(Usuario pUsuario);
        #endregion

        #region Perfiles
        [OperationContract]
        List<Perfil> GetPerfiles();
        [OperationContract]
        List<Perfil> GetPerfilesFiltro(Perfil pPerfil);
        [OperationContract]
        void DeletePerfil(int pPerfilID);
        [OperationContract]
        Perfil SavePerfil(Perfil pPerfil);
        [OperationContract]
        List<PerfilReporte> GetPerfilesUsuario(int pUsuarioID);
        [OperationContract]
        void SaveUsuarioPerfil(UsuarioPerfil pUsuarioPerfil);
        [OperationContract]
        void DeleteUsuarioPerfil(int pUsuarioPerfilID);
        #endregion

        #region Personas
        [OperationContract]
        Involucrado GetInformacionPersona(string pIdentificacion);
        #endregion
    }
}
