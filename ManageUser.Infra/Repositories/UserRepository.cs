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
            var user = await _context.Users
                            .Where
                            (
                                x =>
                                x.Email.ToUpper() == email.ToUpper()

                            )
                            .AsNoTracking()
                            .SingleAsync();
            return user;
        }

        public Task<User> SearchByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> SearchByName(string email)
        {
            throw new NotImplementedException();
        }
    }
}
