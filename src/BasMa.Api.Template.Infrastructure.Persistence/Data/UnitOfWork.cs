using BasMa.Api.Template.Core.Application.Interfaces;
using BasMa.Api.Template.Core.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace BasMa.Api.Template.Infrastructure.Persistence.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private Hashtable _repositories;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public async Task<int> Complete() =>
            await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            _repositories ??= new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<TEntity>)_repositories[type];
        }
    }
}
