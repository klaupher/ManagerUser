using ManageUser.Domain.Entities;

namespace ManageUser.Infra.Interfaces
{
    public interface IUserRepository: IBaseRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<User> SearchByEmail(string email);
        Task<User> SearchByName(string name);

    }
}
