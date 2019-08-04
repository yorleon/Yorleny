using sicoju.data;
using sicoju.entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sicoju.Repositorio
{
    /// <summary>
    /// Repositorio utilizado para encapusular clases que no requieran un grado de complejidad mayor al hereado por <see cref="BaseData{T}"/>.
    /// </summary>
    public class BaseRepositorio
    {

    }
    public partial class PerfilRepositorio : BaseData<Perfil>
    {

        public static List<Perfil> GetPerfiles(Perfil pPerfil)
        {
            try
            {
                using (var db = new Judicial())
                {

                    var query = from u in db.Perfil
                                where u.Activo == pPerfil.Activo
                                select u;

                    if (pPerfil.PerfilID != 0)
                        query = query.Where(u => u.PerfilID == pPerfil.PerfilID);

                    if (pPerfil.Descripcion != "")
                        query = query.Where(u => u.Descripcion == pPerfil.Descripcion);

                    return query.ToList();


                }
            }
            catch (Exception ex) { throw ex; }
        }

    }

    public partial class FormularioRepositorio : BaseData<Formulario> {

        public static List<Formulario> GetFormularios(Formulario pFormulario)
        {
            try
            {
                using (var db = new Judicial())
                {

                    var query = from u in db.Formulario
                                where u.Activo == pFormulario.Activo
                                select u;

                    if (pFormulario.FormularioID != 0)
                        query = query.Where(u => u.FormularioID== pFormulario.FormularioID);

                    if (pFormulario.Descripcion != "")
                        query = query.Where(u => u.Descripcion == pFormulario.Descripcion);

                    return query.ToList();


                }
            }
            catch (Exception ex) { throw ex; }
        }

    }

}
