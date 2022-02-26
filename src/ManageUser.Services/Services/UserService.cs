using AutoMapper;
using ManageUser.Core.Exceptions;
using ManageUser.Domain.Entities;
using ManageUser.Infra.Interfaces;
using ManageUser.Services.DTO;
using ManageUser.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageUser.Services.Services
{
    public class UserService : IUserService
    {
        public readonly IMapper _mapper;
        public readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var userExists = await _userRepository.GetByEmail(userDTO.Email);
            if (userExists != null)
            {
                throw new DomainException("Já existe um usuário com esse email");
            }
            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userCreate = await _userRepository.Create(user);

            return _mapper.Map<UserDTO>(userCreate);
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var userExists = await _userRepository.GetByEmail(userDTO?.Email);
            if (userExists == null)
                throw new DomainException("Usuário não encontrado");

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userUpdate = await _userRepository.Update(user);

            return _mapper.Map<UserDTO>(userUpdate);
        }

        public async Task Remove(int id)
        {
            await _userRepository.Remove(id);
        }

        public async Task<UserDTO> Get(int id)
        {
            var userFind = await _userRepository.Get(id);

            return _mapper.Map<UserDTO>(userFind);
        }

        public async Task<List<UserDTO>> GetAll()
        {
            var allUsers = await _userRepository.Get();

            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            var userFind = await _userRepository.GetByEmail(email);

            return _mapper.Map<UserDTO>(userFind);
        }

        public async Task<List<UserDTO>> SearchByEmail(string email)
        {
            var allUsers = await _userRepository.SearchByEmail(email);

            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<List<UserDTO>> SearchByName(string name)
        {
            var allUsers = await _userRepository.SearchByName(name);

            return _mapper.Map<List<UserDTO>>(allUsers);
        }

    }
}
