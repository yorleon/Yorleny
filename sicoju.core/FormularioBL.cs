using sicoju.entities.Entities;
using sicoju.General;
using sicoju.Repositorio;
using System;
using System.Collections.Generic;

namespace sicoju.core
{
    public class FormularioBL
    {
        public static List<Formulario> GetFormularios()
        {
            return FormularioRepositorio.Get();
        }
        public static List<Formulario> GetFormulariosFiltro(Formulario pFormulario)
        {
            try
            {
                return FormularioRepositorio.GetFormularios(pFormulario);
            }
            catch (Exception ex) { throw ex; }
        }
        public static List<FormularioReporte> GetFormulariosPerfil(int pPerfilID)
        {
            var vFormularios = new List<FormularioReporte>();
            try
            {
                var vListaFormulariosPerfil = FormularioPerfilRepositorio.GetFormularios(pPerfilID);
                foreach (var vFormulario in vListaFormulariosPerfil)
                {
                    vFormularios.Add(new FormularioReporte()
                    {
                        ID = vFormulario.FormularioPerfilID,
                        Formulario = vFormulario.Formulario.Descripcion
                    });
                }

                return vFormularios;
            }
            catch (Exception ex) { throw ex; }
        }
        public static void DeleteFormularioPerfil(int pFormularioPerfilID)
        {
            try
            {
                var vFormulario = FormularioPerfilRepositorio.Get(pFormularioPerfilID);
                FormularioPerfilRepositorio.Delete(vFormulario);
            }
            catch (Exception ex) { throw ex; }
        }
        public static void SaveFormularioPerfil(FormularioPerfil pFormularioPerfil)
        {
            try
            {
                FormularioPerfilRepositorio.Insert(pFormularioPerfil);
            }
            catch (Exception ex) { throw ex; }
        }
        public static Formulario SaveFormulario(Formulario pFormulario)
        {
            try
            {
                return pFormulario.FormularioID > 0 ? FormularioRepositorio.Update(pFormulario) : FormularioRepositorio.Insert(pFormulario, true);

            }
            catch (Exception ex) { throw ex; }
        }
        public static void DeleteFormulario(int pFormularioID)
        {
            try
            {
                var vFormulario = FormularioRepositorio.Get(pFormularioID);
                FormularioRepositorio.Delete(vFormulario);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
