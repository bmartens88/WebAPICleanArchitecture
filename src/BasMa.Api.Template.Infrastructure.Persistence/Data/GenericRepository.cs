using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using BasMa.Api.Template.Core.Application.Interfaces;
using BasMa.Api.Template.Core.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasMa.Api.Template.Infrastructure.Persistence.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly DbContext Context;

        public GenericRepository(DbContext context)
        {
            Context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);

            return entity;
        }

        public async Task<int> CountAsync(ISpecification<T> spec) =>
            await ApplySpecification(spec).CountAsync();

        public void Delete(T entity) =>
            Context.Set<T>().Remove(entity);

        public async Task<T> FirstAsync(ISpecification<T> spec) =>
            await ApplySpecification(spec).FirstAsync();

        public async Task<T> FirstOrDefaultAsync(ISpecification<T> spec) =>
            await ApplySpecification(spec).FirstOrDefaultAsync();

        public async Task<T> GetByIdAsync(int id) =>
            await Context.Set<T>().FindAsync(id);

        public async Task<IReadOnlyList<T>> ListAllAsync() =>
            await Context.Set<T>().ToListAsync();

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec) =>
            await ApplySpecification(spec).ToListAsync();

        public void Update(T entity) =>
            Context.Entry(entity).State = EntityState.Modified;

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            var evaluator = new SpecificationEvaluator();
            return evaluator.GetQuery(Context.Set<T>().AsQueryable(), spec);
        }
    }
}
