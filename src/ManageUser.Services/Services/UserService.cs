﻿using ManageUser.Domain.Entities;
using ManageUser.Infra.Interfaces;
using ManageUser.Services.Interfaces;
using System.Linq.Expressions;

namespace ManageUser.Services.Services
{
    public class UserService : IBaseService<Domain.Entities.User>
    {
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateAsync(User user)
        {
            var userExists = await _userRepository.GetByEmail(user.Email);

            if (userExists != null)
            {
                throw new ApplicationException("Já existe um usuário com esse email");
            }

            user.Validate();

            return await _userRepository.Create(user);
        }

        public async Task<User> UpdateAsync(User user)
        {
            var userExists = await _userRepository.GetByEmail(user.Email);

            if (userExists == null)
                throw new ApplicationException("Usuário não encontrado");

            user.Validate();

            return await _userRepository.Update(user);
        }

        public async Task RemoveAsync(int id)
        {
            await _userRepository.Remove(id);
        }

        public async Task<User> GetAsync(int id)
        {
            return await _userRepository.Get(id);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.Get();
        }

        public Task<IList<User>> FindByPredicateAsync(Expression<Func<User, bool>> entity)
        {
            throw new NotImplementedException();
        }
    }
}