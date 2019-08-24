using EasyBlog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EasyBlog.DAL.Repositories
{
    public class  Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll(Func<TEntity, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
