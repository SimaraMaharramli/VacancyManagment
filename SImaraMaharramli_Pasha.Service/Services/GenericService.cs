using Microsoft.EntityFrameworkCore;
using SImaraMaharramli_Pasha.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SImaraMaharramli_Pasha.Service.Services
{
    public class GenericService<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericService(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        // Create (Ekleme)
        public async Task<bool> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            var result =await _context.SaveChangesAsync();      
            return result>0;
        }

        // Read (Listeleme)
     

        // Update (Güncelleme)
        public async Task<bool> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            var result= await _context.SaveChangesAsync();
            return result>0;
        }

        // Delete (Silme)
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return false;

            _dbSet.Remove(entity);
            var result= await _context.SaveChangesAsync();
            return result>0;
        }
    }
}
