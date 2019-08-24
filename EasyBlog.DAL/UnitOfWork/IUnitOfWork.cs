using EasyBlog.Core.Entities;
using EasyBlog.DAL.Repositories;
using System;

namespace EasyBlog.DAL.UnitOfWork
{
    public interface IUnitOfWork<TContext> : IDisposable
    {      
        TContext Dbcontext { get; }
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}
