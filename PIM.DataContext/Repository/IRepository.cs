using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PIM.DataContext.Repository
{
    public interface IRepository
    {
        T Get<T>(object key) where T : class;
        IQueryable<T> Get<T>() where T : class;
        T FindOne<T>(Expression<Func<T, bool>> predicate) where T : class;
        IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class;
        int Count<T>() where T : class;
        int Count<T>(Expression<Func<T, bool>> predicate) where T : class;
        void Add<T>(T entity) where T : class;
        void AddOrUpdate<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Delete<T>(List<T> entities) where T : class;
        void Delete<T>(Expression<Func<T, bool>> predicate) where T : class;
        int SaveChanges();
        void Attach<T>(T entity) where T : class;
    }
}