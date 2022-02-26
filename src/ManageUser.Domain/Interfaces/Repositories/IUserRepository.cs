using ManageUser.Domain.Entities;
using System.Linq.Expressions;

namespace ManageUser.Domain.Interfaces.Repositories
{
    public interface IUserRepository: IBaseRepository<User>
    {
        Task<IList<User>> FindByPredicateAsync(Expression<Func<User, bool>> entity);
    }
}
