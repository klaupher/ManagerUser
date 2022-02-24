using ManageUser.Domain.Entities;
using ManageUser.Infra.Context;
using ManageUser.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageUser.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ManagerUserContext _context;

        public UserRepository(ManagerUserContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users
                            .Where
                            (
                                x =>
                                x.Email.ToUpper() == email.ToUpper()

                            )
                            .AsNoTracking()
                            .SingleAsync();
        }

        public async Task<User> SearchByEmail(string email)
        {
            return await _context.Users
                    .Where(
                        x => x.Email.ToUpper().Contains(email.ToUpper())
                    )
                    .AsNoTracking()
                    .SingleAsync();
        }

        public async Task<User> SearchByName(string name)
        {
            return await _context.Users
                     .Where(
                         x => x.Name.ToUpper().Contains(name.ToUpper())
                     )
                     .AsNoTracking()
                     .SingleAsync();
        }
    }
}
