using sicoju.entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sicoju.data
{
    /// <summary>
    /// Clase encargada de realizar las operaciones basicas (CRUD) toma como referencia el obtenido heredado
    /// </summary>
    public class BaseData<T> : IBase where T : class
    {
        /// <summary>
        /// Método encargado de retornar la entidad referenciada por medio de un identificador dentro de la base de datos
        /// </summary>
        /// <param name="id">Identificador de la entidad que se desea obtener, por lo general corresponde a la llave primaria </param>
        /// <returns>T</returns>
        /// <example> 
        /// Este ejemplo muestra como hacer uso de este metodo.
        /// <code>
        /// class Ejemplo 
        /// {
        ///     private Entidad ObtenerEntidad(id) 
        ///     {
        ///         return Entidad.Get(id);
        ///     }
        /// }
        /// </code>
        /// </example>
        public static T Get(int id)
        {
            try
            {
                using (var db = new Judicial())
                {
                    return db.Set<T>().Find(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método encargado de retornar la entidad referenciada por medio de un identificador dentro de la base de datos
        /// </summary>
        /// <param name="id">Identificador de la entidad que se desea obtener, por lo general corresponde a la llave primaria </param>
        /// <returns>T</returns>
        public static T Get(string id)
        {
            try
            {
                using (var db = new Judicial())
                {
                    return db.Set<T>().Find(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo encargado de retornar la lista de entidades registradas en base de datos
        /// </summary>
        /// <returns></returns>
        public static List<T> Get()
        {
            try
            {
                using (var db = new Judicial())
                {
                    return db.Set<T>().ToList();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo encargado de insertar la entidad referenciada
        /// </summary>
        /// <param name="entity">Corresponde a la entidad que se desea insertar</param>
        /// <returns></returns>
        public static Boolean Insert(T entity)
        {
            try
            {
                using (var bd = new Judicial())
                {
                    bd.Set<T>().Add(entity);
                    bd.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static T Insert(T entity, bool identity = false)
        {
            try
            {
                using (var bd = new Judicial())
                {
                    bd.Set<T>().Add(entity);
                    bd.SaveChanges();

                    return entity;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Metodo encargado de eliminar la entidad referenciada dentro de la base de datos
        /// </summary>
        /// <param name="entity">Corresponde a la entidad que se desea eliminar</param>
        /// <returns></returns>
        public static Boolean Delete(T entity)
        {
            try
            {
                using (var bd = new Judicial())
                {
                    bd.Set<T>().Attach(entity);
                    bd.Set<T>().Remove(entity);
                    bd.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo encargado de eliminar la lista de entidades referenciadas dentro de la base de datos
        /// </summary>
        /// <param name="entity">Corresponde a la entidad que se desea eliminar</param>
        /// <returns></returns>
        public static Boolean Delete(ICollection<T> entities)
        {
            try
            {
                using (var bd = new Judicial())
                {

                    foreach (var entity in entities)
                    {
                        bd.Set<T>().Attach(entity);
                        bd.Set<T>().Remove(entity);
                        bd.SaveChanges();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo encargado de actualizar la entidad referenciada dentro de la base de datos
        /// </summary>
        /// <param name="entity">Corresponde a la entidad que se desea actualizar</param>
        /// <returns></returns>
        public static T Update(T entity)
        {
            try
            {
                using (var bd = new Judicial())
                {
                    bd.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    bd.SaveChanges();
                    return entity;
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
