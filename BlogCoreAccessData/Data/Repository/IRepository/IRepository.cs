using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccessData.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        // para obtener todo los repositorios genericos
        // T es una clase generica que se puede usar para cualquier entidad
        T Get(int id);
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string? includeProperties = null
            );

        //para obtener los registros individuales
        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string? includeProperties = null
            );
        void Add(T entity);
        void Remove(int id);
        void Remove(T entity);

    }
}
