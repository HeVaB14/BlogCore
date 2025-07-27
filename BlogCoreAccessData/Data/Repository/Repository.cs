using BlogCore.AccessData.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccessData.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        // DbContext es la clase base para todos los contextos de base de datos en Entity Framework Core
        protected readonly DbContext Context;
        internal DbSet<T> dbSet;
        // Constructor que recibe el DbContext y lo asigna a la propiedad Context
        public Repository(DbContext context)
        {
            Context = context;
            this.dbSet = context.Set<T>();
        }
        // Método para agregar una entidad al DbSet
        public void Add(T entity)
        {
           dbSet.Add(entity);
        }
        // Método para obtener una entidad por su ID
        public T Get(int id)
        {

            return dbSet.Find(id);
        }
        // Método para obtener todas las entidades, con opciones de filtrado, ordenamiento e inclusión de propiedades relacionadas
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            // Aplicar filtro si se proporciona
            if (filter!=null)
            {
                query = query.Where(filter);
            }
            // Incluir propiedades relacionadas si se especifican
            if (includeProperties != null)
            {
                foreach(var includeProperty in includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            // Aplicar ordenamiento si se proporciona
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            // Devolver la lista de entidades
            return query.ToList();
        }
        // Método para obtener la primera entidad que cumple con un filtro, o null si no hay coincidencias

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            // Aplicar filtro si se proporciona
            if (filter != null)
            {
                query = query.Where(filter);
            }
            // Incluir propiedades relacionadas si se especifican
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            // Devolver la primera entidad que cumple con el filtro, o null si no hay coincidencias
            return query.FirstOrDefault();

        }

        // Método para eliminar una entidad por su ID
        public void Remove(int id)
        {
           T entityToRemove = dbSet.Find(id);
          
        }
        // Método para eliminar una entidad específica
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
