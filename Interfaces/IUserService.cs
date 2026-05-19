using Login_system.Dto.DtoUser;
using Login_system.Dto.User;

namespace Login_system.Interfaces
{
    public interface IUserService
    {
        List<string> GetAllUsers();
        string GetById(ByIdDTO id);
        string UpdateUser(ByIdDTO id, UpdateUserDTO user);
        string DeleteUser(ByIdDTO id);
        string GetByEmail(ByEmail emailUser)
;    }
}
