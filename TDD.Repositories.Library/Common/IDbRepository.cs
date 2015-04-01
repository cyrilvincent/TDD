using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Entity;
using TDD.Entities.Library;

namespace TDD.Repositories.Library.Common
{
    /// <summary>
    /// Contrat imposant les méthodes de base
    /// </summary>
    /// <typeparam name="T">Objet de type IEntity (Id obligatoire)</typeparam>
    public interface IDbRepository<T, U> : IRepository<T>, IUnitOfWork where T : IEntity where U : DbContext
    {
        U DbContext { get; set; }
        IQueryable<T> Query(Expression<Func<T, bool>> predicate);
        IOrderedQueryable<T> Query(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> sort);
        IQueryable<T> Query(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> sort, int nbEntity, int page);
        int Count(Expression<Func<T, bool>> predicate);
        void Delete(IEnumerable<T> entities);

    }
}
