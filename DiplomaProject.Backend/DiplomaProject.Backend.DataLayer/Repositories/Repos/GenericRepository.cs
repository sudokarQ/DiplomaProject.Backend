﻿using DiplomaProject.Backend.Common.Models.Dto.Client;
using DiplomaProject.Backend.Common.Models.Entity;
using DiplomaProject.Backend.DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DiplomaProject.Backend.DataLayer.Repositories.Repos
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly PostgreSqlContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(PostgreSqlContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        //public Task<List<TEntity>> GetAllAsync()
        //    => _dbSet.AsNoTracking().ToListAsync();


        public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate) // Исправить
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async Task CreateAsync(TEntity item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity item)
        {
            _dbSet.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(TEntity item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }

        public TEntity FirstOrDefault(Func<TEntity, bool> predicate)
        {
            return _dbSet.FirstOrDefault(predicate); //can't convert threading cancelletion token
        }
    }
}
