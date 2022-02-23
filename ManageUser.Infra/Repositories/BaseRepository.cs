using ManageUser.Domain.Entities;
using ManageUser.Infra.Context;
using ManageUser.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ManageUser.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly ManagerUserContext _context;

        public BaseRepository(ManagerUserContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Create(T obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return obj;
        }
        public virtual async Task Remove(long id)
        {
            var obj = await Get(id);

            if (obj != null)
            {
                _context.Remove(id);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<T> Get(long id)
        {
            return await _context.Set<T>()
                                .AsNoTracking()
                                .Where(x => x.Id == id)
                                .SingleAsync();
        }


        public virtual async Task<List<T>> Get()
        {
            return await _context.Set<T>()
                                .AsNoTracking()
                                .ToListAsync();

        }


    }
}
