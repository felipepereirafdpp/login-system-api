using Login_system.Dto.DtoUser;
using Login_system.Dto.User;

namespace Login_system.Interfaces;

public interface IUserService
{
    Task<List<UserDTO>> GetAllUsers();
    Task<UserDTO> GetById(ByIdDTO id);
    Task<UserDTO> UpdateUser(ByIdDTO id, UpdateUserDTO user);
    Task<bool> DeleteUser(ByIdDTO id);
    Task<UserDTO> GetByEmail(EmailDTO emailUser);
    
}
