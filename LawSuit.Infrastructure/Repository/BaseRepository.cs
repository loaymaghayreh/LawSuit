using LawSuit.Application.Service.Interface;
using LawSuit.Infrastructure.LawSuitDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawSuit.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task CreateAsync(T entity)
        {      
           await _context.AddAsync<T>(entity);
           _context.SaveChanges();            
            
        }
        public async Task AddRangeAsync(List<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            _context.SaveChanges();

        }
        public async Task UpdateAsync(T entity)
        {
           _context.Set<T>().Attach(entity);
           _context.Entry(entity).State = EntityState.Modified;
           await _context.SaveChangesAsync();
        }

    }
}
