using sicoju.data;
using sicoju.entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sicoju.Repositorio
{
    public partial class InvolucradoRepositorio : BaseData<Involucrado>
    {
        public static List<Involucrado> GetInvolucrados(Involucrado pInvolucrado)
        {
            try
            {
                using (var db = new Judicial())
                {

                    var query = from u in db.Involucrado
                                where u.Activo == pInvolucrado.Activo
                                select u;

                    if (pInvolucrado.InvolucradoID != 0)
                        query = query.Where(u => u.InvolucradoID == pInvolucrado.InvolucradoID);

                    if (!string.IsNullOrWhiteSpace(pInvolucrado.Identificacion))
                        query = query.Where(u => u.Identificacion == pInvolucrado.Identificacion);

                    if (!string.IsNullOrWhiteSpace(pInvolucrado.Nombre))
                        query = query.Where(u => u.Nombre == pInvolucrado.Nombre);

                    if (!string.IsNullOrWhiteSpace(pInvolucrado.PrimerApellido))
                        query = query.Where(u => u.PrimerApellido == pInvolucrado.PrimerApellido || u.SegundoApellido == pInvolucrado.SegundoApellido);

                    if (!string.IsNullOrWhiteSpace(pInvolucrado.CorreoElectronico))
                        query = query.Where(u => u.CorreoElectronico.Contains(pInvolucrado.CorreoElectronico));

                    return query.ToList();


                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
