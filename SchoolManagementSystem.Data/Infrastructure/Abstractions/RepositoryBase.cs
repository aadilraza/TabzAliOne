using PagedList;
using SchoolManagementSystem.Data.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace SchoolManagementSystem.Data.Infrastructure.Abstractions
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private SchoolEntities _dataContext;
        private readonly IDbSet<T> _dbSet;
        protected IDatabaseFactory DatabaseFactory { get; private set; }
        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            _dbSet = DataContext.Set<T>();
        }
        protected SchoolEntities DataContext
        {
            get { return _dataContext ?? (_dataContext = DatabaseFactory.Get()); }
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            //entity = _dbSet.Attach(entity);
            //_dataContext.Entry(entity).State = EntityState.Modified;
            _dbSet.AddOrUpdate(entity);
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }
        public virtual T GetById(long id)
        {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable();
        }
        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).AsEnumerable();
        }

        public virtual IPagedList<T> GetPage<TOrder>(Page page, Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order)
        {
            var results = _dbSet.OrderBy(order).Where(where).GetPage(page).ToList();
            var total = _dbSet.Count(where);
            return new StaticPagedList<T>(results, page.PageNumber, page.PageSize, total);
        }
    }
}
