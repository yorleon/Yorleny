using sicoju.data;
using sicoju.entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sicoju.Repositorio
{
    public class SeguridadRepositorio
    {

    }

    public partial class FormularioPerfilRepositorio : BaseData<FormularioPerfil>
    {
        public static List<FormularioPerfil> GetFormularios(int pPerfilID)
        {
            try
            {
                using (var db = new Judicial())
                {
                    return db.FormularioPerfil.Include("Perfil").Include("Formulario").Where(f => f.PerfilID == pPerfilID).ToList();
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
    public partial class UsuariosPerfilRepositorio : BaseData<UsuarioPerfil>
    {
        public static List<UsuarioPerfil> GetPerfiles(int pUsuarioID)
        {
            try
            {
                using (var db = new Judicial())
                {
                    return db.UsuarioPerfil.Include("Perfil").Where(f => f.UsuarioID == pUsuarioID).ToList();
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
    public partial class UsuariosRepositorio : BaseData<Usuario>
    {
        public static Usuario GetUsuario(Usuario pUsuario)
        {
            using (var db = new Judicial())
            {
                return db.Usuario
                         .FirstOrDefault(u => u.Identificacion == pUsuario.Identificacion);
            }
        }

        public static Usuario GetUsuario(Usuario pUsuario, bool Completo)
        {
            using (var db = new Judicial())
            {
                return db.Usuario
                        .Include("UsuarioPerfil")
                            .Include("UsuarioPerfil.Perfil")
                            .Include("UsuarioPerfil.Perfil.FormularioPerfil")
                            .Include("UsuarioPerfil.Perfil.FormularioPerfil.Formulario")
                            .FirstOrDefault(u => u.Identificacion == pUsuario.Identificacion);
            }
        }

        public static List<Usuario> GetUsuarios(Usuario pUsuario, Boolean pTodos = false)
        {
            try
            {
                using (var db = new Judicial())
                {

                    var query = from u in db.Usuario.Include("UsuarioPerfil").Include("UsuarioPerfil.Perfil")
                                select u;


                    if (!pTodos)
                        query = query.Where(u => u.Activo == pUsuario.Activo);

                    if (pUsuario.UsuarioID != 0)
                        query = query.Where(u => u.UsuarioID == pUsuario.UsuarioID);

                    if (pUsuario.Identificacion != "")
                        query = query.Where(u => u.Identificacion == pUsuario.Identificacion);

                    if (pUsuario.Nombre != "")
                        query = query.Where(u => u.Nombre == pUsuario.Nombre);

                    if (pUsuario.PrimerApellido != "")
                        query = query.Where(u => u.PrimerApellido == pUsuario.PrimerApellido || u.SegundoApellido == pUsuario.SegundoApellido);

                    if (!string.IsNullOrWhiteSpace(pUsuario.CorreoElectronico))
                        query = query.Where(u => u.CorreoElectronico.Contains(pUsuario.CorreoElectronico));

                    return query.ToList();


                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
