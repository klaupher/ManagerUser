using ManageUser.Domain.Entities;
using ManageUser.Domain.Interfaces.Repositories;
using ManageUser.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ManageUser.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseClass
    {
        private readonly ManagerUserContext _context;

        public BaseRepository(ManagerUserContext context)
        {
            _context = context;
        }

        public virtual async Task<T> CreateAsync(T obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> UpdateAsync(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return obj;
        }
        public virtual async Task RemoveAsync(long id)
        {
            var obj = await GetAsync(id);

            if (obj != null)
            {
                _context.Remove(id);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<T> GetAsync(long id)
        {
            return await _context.Set<T>()
                                .AsNoTracking()
                                .Where(x => x.Id == id)
                                .SingleAsync();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>()
                                .AsNoTracking()
                                .ToListAsync();

        }
    }
}
