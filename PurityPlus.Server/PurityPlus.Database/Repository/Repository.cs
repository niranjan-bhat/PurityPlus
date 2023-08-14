using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PurityPlus.Database.Repository
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private PurityPlusDbContext _dbContext { get; }

        private DbSet<TEntity> _table;

        public Repository(PurityPlusDbContext dbContext)
        {
            _dbContext = dbContext;
            _table = dbContext.Set<TEntity>(); 
        }
        

        public void Add(TEntity entity)
        {
           _table.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _table.Where(predicate);
        }

        public IQueryable<TEntity> QueryAll()
        {
            return _table;
        }

        public async Task<TEntity> GetById(Guid id)
        {
           return await _table.FindAsync(id);
        }
        public IQueryable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _table;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }
    }
}
