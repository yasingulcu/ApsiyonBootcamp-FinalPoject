using Apsiyon.Domain.Interfaces;
using Apsiyon.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Apsiyon.Infrastructure.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        ApsiyonDbContext _context;
        private DbSet<TEntity> _entitiy;
        public Repository(ApsiyonDbContext context)
        {
            _context = context;
            _entitiy = _context.Set<TEntity>();
        }
        public async Task Add(TEntity entity)
        {
            await _entitiy.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _entitiy.Remove(entity);
        }

        public void DeleteRange(List<TEntity> entities)
        {
            _entitiy.RemoveRange(entities);
        }

        public async Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter)
        {
            return await _entitiy.Where(filter).ToListAsync();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _entitiy.ToListAsync();
        }

        public async Task<TEntity> GetById(Expression<Func<TEntity, bool>> filter)
        {
            var result = await _entitiy.Where(filter).ToListAsync();
            return result.FirstOrDefault();
        }

        public void Update(TEntity entity)
        {
            _entitiy.Update(entity);
        }
    }
}
