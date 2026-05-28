using Login_system.Dto.Auth;
using Login_system.Dto.DtoUser;

namespace Login_system.Interfaces;

public interface IAuthService
{
    Task<ResponseTokenDTO> LoginUsers(LoginDTO DadosUser);
    Task<ResponseTokenDTO> RegisterUsers(RegisterUserDTO register);
    Task<ForgotPasswordDTO> ForgotPassword(ForgotPasswordDTO senhaDTO);
    Task<ResetPasswordDTO> ResetPassword(ResetPasswordDTO resetDTO);
    Task<bool> ValidateToken(string token);

}
