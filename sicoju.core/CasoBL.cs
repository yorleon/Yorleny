using sicoju.entities.Entities;
using sicoju.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sicoju.core
{
    public class CasoBL
    {
        public static List<Caso> GetCasosFiltro(Caso pCaso)
        {
            try
            {
                return CasoRepositorio.GetCasos(pCaso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Caso GetCaso(int pCasoID)
        {
            try
            {
                return CasoRepositorio.GetCasos(new Caso() { CasoID = pCasoID }).FirstOrDefault();

            }
            catch (Exception ex) { throw ex; }
        }
        public static List<Involucrado> GetInvolucrados()
        {
            try
            {
                return InvolucradoRepositorio.Get();
            }
            catch (Exception ex) { throw ex; }
        }
        public static void DeleteDetalleCaso(int pDetalleID)
        {
            var vExistente = DetalleCasoRepositorio.Get(pDetalleID);
            DetalleCasoRepositorio.Delete(vExistente);
        }
        public static Caso SaveCaso(Caso pCaso)
        {
            try
            {

                return pCaso != null && pCaso.CasoID > 0 ? CasoRepositorio.GuardarCaso(pCaso) : CasoRepositorio.Insert(pCaso, true);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
