using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TargetInvoiceSystem.Core.ServicesInterfaces;

namespace TargetInvoiceSystem.Infrastructure.Services
{
    public class Repository<Tentity> : IRepository<Tentity> where Tentity : class
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(Tentity entity)
        {
            _context.Set<Tentity>().Remove(entity);            
        }

        public async Task<IEnumerable<Tentity>> GetAllAsync()
        {
            return await _context.Set<Tentity>().ToListAsync();
        }

        public async Task<Tentity> GetByIdAsync(object id)
        {
            return await _context.Set<Tentity>().FindAsync(id);
        }

        public async Task<Tentity> InsertAsync(Tentity entity)
        {
            await _context.Set<Tentity>().AddAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(Tentity entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
