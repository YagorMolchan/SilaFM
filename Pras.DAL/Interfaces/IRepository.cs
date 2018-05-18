using System;
using System.Linq;
using System.Threading.Tasks;
using Pras.DAL.Entities;

namespace Pras.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> Find();
        Task<TEntity> FindById(Guid id);
        void InsertOrUpdate(TEntity entity);
        void Delete(TEntity entity);
    }
}
