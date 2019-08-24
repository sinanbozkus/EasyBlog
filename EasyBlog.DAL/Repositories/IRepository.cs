using EasyBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyBlog.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity Get(Func<TEntity, bool> predicate);
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll(Func<TEntity, bool> predicate = null);
    }
}
