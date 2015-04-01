using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TDD.Entities.Library;

namespace TDD.Repositories.Library.Common
{
    /// <summary>
    /// Repository crud
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractRepository<T, U> : IUnitOfWork, IDbRepository<T, U> 
        where T : class, IEntity 
        where U : DbContext
    {
        //private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instance du DbContext
        /// </summary>
        public U DbContext { get; set; }
        public static bool DebugMode { get; set; }

        /// <inheritdoc />
        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> result = null;
            try
            {
                result = DbContext.Set<T>();
                if (DebugMode)
                {
                    // Log
                }
            }
            catch(Exception ex)
            {
                throw new RepositoryException(ex);
            }

            return result;
        }

        /// <inheritdoc />
        public virtual T GetById(int id)
        {
            //logger.Debug(ListAll().Where(e => e.Id == id).ToString());
            try {
                return DbContext.Set<T>().Where(e => e.Id == id).FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw new RepositoryException(id.ToString(), ex);
            }

        }

        /// <inheritdoc />
        public virtual IQueryable<T> Query(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> result = null;
            try
            {
                result = DbContext.Set<T>().Where(predicate);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
            return result;
        }

        /// <inheritdoc />
        public virtual IOrderedQueryable<T> Query(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> sort)
        {
            //logger.Debug(Query(predicate).OrderBy(sort).ToString());
            IOrderedQueryable<T> result = null;
            try
            {
                result = DbContext.Set<T>().Where(predicate).OrderBy(sort);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
            return result;
        }

        /// <inheritdoc />
        public virtual IQueryable<T> Query(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> sort, int nbEntity, int page)
        {
            IQueryable<T> result = null;
            try
            {
                result = DbContext.Set<T>().Where(predicate).OrderBy(sort).Skip(page * nbEntity).Take(nbEntity);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
            return result;
        }

        public virtual int Count()
        {
            int result = 0;
            try
            {
                result = DbContext.Set<T>().Count();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
            return result;
        }
        public int Count(Expression<Func<T, bool>> predicate)
        {
            int result = 0;
            try
            {
                result = DbContext.Set<T>().Where(predicate).Count();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
            return result;
        }


        /// <inheritdoc />
        public virtual void Insert(T entity)
        {
            try
            {
                DbContext.Set<T>().Add(entity);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        /// <inheritdoc />
        public virtual void Remove(T entity)
        {
            try
            {
                DbContext.Entry<T>(entity).State = EntityState.Deleted;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public void Delete(IEnumerable<T> entities)
        {
            foreach (T e in entities.ToList())
                Remove(e);
        }

        public virtual void Update(T entity)
        {
            try
            {
                DbContext.Entry<T>(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        /// <inheritdoc />
        public virtual void Save()
        {
            try
            {
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }       
    }
}
