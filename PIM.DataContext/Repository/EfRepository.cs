using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PIM.DataContext.Repository
{
    public class EfRepository : IRepository
    {
        private DbContext _context;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="context"></param>
        public EfRepository(DbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Add an entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Add<T>(T entity) where T : class
        {
            this._context.Set<T>().Add(entity);
        }

        /// <summary>
        /// Add an entity if does not exist
        /// Update the entity if exist
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void AddOrUpdate<T>(T entity) where T : class
        {
            this._context.Set<T>().AddOrUpdate(entity);
        }

        /// <summary>
        /// Attach the entity to context
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Attach<T>(T entity) where T : class
        {
            this._context.Set<T>().Attach(entity);
        }

        /// <summary>
        /// Get the number of items for the entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public int Count<T>() where T : class
        {
            return this._context.Set<T>().Count();
        }

        /// <summary>
        /// Get the number of items returned by the query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public int Count<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return this._context.Set<T>().Count(predicate);
        }

        /// <summary>
        /// Delete the entities of the query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        public void Delete<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            this._context.Set<T>().RemoveRange(Find<T>(predicate));
        }

        /// <summary>
        /// Delete a list of entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        public void Delete<T>(List<T> entities) where T : class
        {
            this._context.Set<T>().RemoveRange(entities);
        }

        /// <summary>
        /// Delete the entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Delete<T>(T entity) where T : class
        {
            this._context.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Get all entities returned by the query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return this._context.Set<T>().Where(predicate);
        }

        /// <summary>
        /// Get the first entity of the query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T FindOne<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return this._context.Set<T>().FirstOrDefault(predicate);
        }

        /// <summary>
        /// Get all entities of a given type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> Get<T>() where T : class
        {
            return this._context.Set<T>().AsQueryable();
        }

        /// <summary>
        /// Get entity by key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(object key) where T : class
        {
            return this._context.Set<T>().Find(key);
        }

        /// <summary>
        /// Commit changes to DB
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return this._context.SaveChanges();
        }

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Update<T>(T entity) where T : class
        {
            this._context.Entry(entity).State = EntityState.Modified;
        }



    }
}
