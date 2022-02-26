using ManageUser.Services.DTO;

namespace ManageUser.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Create(UserDTO userDTO);
        Task<UserDTO> Update(UserDTO userDTO);
        Task Remove(int id);
        Task<UserDTO> Get(int id);
        Task<List<UserDTO>> GetAll();
        Task<UserDTO> GetByEmail(string email);
        Task<List<UserDTO>> SearchByName(string name);
        Task<List<UserDTO>> SearchByEmail(string email);

    }
}
