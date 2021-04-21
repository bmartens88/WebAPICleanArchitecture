using BasMa.Api.Template.Core.Domain.Common;
using System;
using System.Threading.Tasks;

namespace BasMa.Api.Template.Core.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task<int> Complete();
    }
}
