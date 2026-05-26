using Login_system.Dto.DtoUser;
using Login_system.Dto.User;

namespace Login_system.Interfaces;

public interface IUserService
{
    List<UserDTO> GetAllUsers();
    UserDTO GetById(ByIdDTO id);
    UserDTO UpdateUser(ByIdDTO id, UpdateUserDTO user);
    bool DeleteUser(ByIdDTO id);
    UserDTO GetByEmail(ByEmail emailUser);   
}
