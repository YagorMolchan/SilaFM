using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pras.DAL.Context;
using Pras.DAL.Entities;
using Pras.DAL.Interfaces;

namespace Pras.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        internal PrasDbContext Context;
        internal DbSet<TEntity> DbSet;

        public Repository(PrasDbContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Find()
        {
            return DbSet;
        }

        public TEntity FindById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual void InsertOrUpdate(TEntity entity)
        {
            if (entity.IsNew)
                DbSet.Add(entity);
            else
            {
                DbSet.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
        }

        public virtual void Delete(Guid id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }
    }
}
