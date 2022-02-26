using ManageUser.Domain.Entities;
using ManageUser.Domain.Interfaces.Repositories;
using ManageUser.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace ManageUser.Domain.Services
{
    public class UserService : IBaseService<Domain.Entities.User>, IUserService
    {
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateAsync(User user)
        {
            var userExists = await _userRepository.FindByPredicateAsync(u => u.Email == user.Email);

            if (userExists != null)
            {
                throw new ApplicationException("Já existe um usuário com esse email");
            }

            user.Validate();

            return await _userRepository.CreateAsync(user);
        }

        public async Task<User> UpdateAsync(User user)
        {
            var userExists = await _userRepository.FindByPredicateAsync(u => u.Email == user.Email);

            if (userExists == null)
                throw new ApplicationException("Usuário não encontrado");

            user.Validate();

            return await _userRepository.UpdateAsync(user);
        }

        public async Task RemoveAsync(int id)
        {
            await _userRepository.RemoveAsync(id);
        }

        public async Task<User> GetAsync(int id)
        {
            return await _userRepository.GetAsync(id);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public Task<IList<User>> FindByPredicateAsync(Expression<Func<User, bool>> entity)
        {
            throw new NotImplementedException();
        }
    }
}