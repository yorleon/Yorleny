using sicoju.entities.Entities;
using sicoju.Repositorio;
using System;
using System.Collections.Generic;

namespace sicoju.core
{
    public class InvolucradoBL
    {
        public static List<Involucrado> GetInvolucradosFiltro(Involucrado pInvolucrado)
        {
            try
            {
                return InvolucradoRepositorio.GetInvolucrados(pInvolucrado);
            }
            catch (Exception ex) { throw ex; }
        }
        public static void DeleteInvolucrado(int pInvolucradoID)
        {
            try
            {
                var vUsuario = InvolucradoRepositorio.Get(pInvolucradoID);
                InvolucradoRepositorio.Delete(vUsuario);
            }
            catch (Exception ex) { throw ex; }
        }
        public static Involucrado SaveInvolucrado(Involucrado pInvolucrado)
        {
            try
            {
                return pInvolucrado.InvolucradoID > 0 ? InvolucradoRepositorio.Update(pInvolucrado) : InvolucradoRepositorio.Insert(pInvolucrado, true);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
