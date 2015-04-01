 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using TDD.Entities.Library;

namespace TDD.Repositories.Library.Common
{
    /// <summary>
    /// Contrat imposant les méthodes de base
    /// </summary>
    /// <typeparam name="T">Objet de type IEntity (Id obligatoire)</typeparam>
    public interface IRepository<T> where T : IEntity
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        int Count();
        void Insert(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
