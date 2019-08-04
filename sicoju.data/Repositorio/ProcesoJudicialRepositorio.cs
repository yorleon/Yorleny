using sicoju.data;
using sicoju.entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace sicoju.Repositorio
{
    /// <summary>
    /// Repositorio encargado de encapsular todas las clases involucradas en el proceso judicial.
    /// </summary>
    public class ProcesoJudicialRepositorio
    {

    }
    public partial class DetalleCasoRepositorio : BaseData<DetalleCaso> { }
    public partial class CasoRepositorio : BaseData<Caso>
    {
        public static Caso GuardarCaso(Caso pCaso)
        {
            try
            {
                using (var db = new Judicial())
                {
                    foreach (var vDetalle in pCaso.DetalleCaso)
                    {
                        db.Entry(vDetalle).State = vDetalle.DetalleCasoID > 0 ? EntityState.Modified : EntityState.Added;
                    }

                    db.Entry(pCaso).State = pCaso.CasoID > 0 ? EntityState.Modified : EntityState.Added;
                    db.SaveChanges();

                    return pCaso;
                }

            }
            catch (Exception ex) { throw ex; }
        }
        public static List<Caso> GetCasos(Caso pCaso)
        {
            try
            {
                using (var db = new Judicial())
                {
                    var query = from p in db.Caso
                                 .Include("DetalleCaso")
                                 .Include("DetalleCaso.Involucrado")
                                 .Include("DetalleCaso.TipoInvolucrado")

                                select p;


                    if (pCaso.JuezID.HasValue && pCaso.JuezID != 0)
                        query = query.Where(p => p.JuezID == pCaso.JuezID);

                    if (pCaso.CasoID != 0)
                        query = query.Where(p => p.CasoID == pCaso.CasoID);

                    //DESDE                                 //HASTA
                    if (pCaso.FechaIngreso.HasValue && pCaso.FechaIngreso.HasValue)
                        query = query.Where(p => p.FechaIngreso.Value >= pCaso.FechaIngreso.Value && p.FechaIngreso <= pCaso.FechaIngreso.Value);

                    //DESDE                                 //HASTA
                    if (pCaso.FechaCierre.HasValue && pCaso.FechaCierre.HasValue)
                        query = query.Where(p => p.FechaCierre.Value >= pCaso.FechaCierre.Value && p.FechaCierre <= pCaso.FechaCierre.Value);

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
