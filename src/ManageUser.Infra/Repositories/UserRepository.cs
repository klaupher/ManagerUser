using ManageUser.Domain.Entities;
using ManageUser.Domain.Interfaces.Repositories;
using ManageUser.Infra.Context;
using System.Linq.Expressions;

namespace ManageUser.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ManagerUserContext _context;

        public UserRepository(ManagerUserContext context) : base(context)
        {
            _context = context;
        }

        public Task<IList<User>> FindByPredicateAsync(Expression<Func<User, bool>> entity)
        {
            throw new NotImplementedException();
        }
    }
}
