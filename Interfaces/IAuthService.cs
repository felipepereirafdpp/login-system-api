using Login_system.Dto.Auth;
using Login_system.Dto.DtoUser;

namespace Login_system.Interfaces;

public interface IAuthService
{
    Task<LoginDTO> LoginUsers();
    Task<RegisterUserDTO> RegisterUsers();
    Task<ForgotPasswordDTO> ForgotPassword();
    Task<ResetPasswordDTO> ResetPassword();
    Task<ResponseTokenDTO> ResponseToken();
    Task<ValidateTokenDTO> ValidateToken();

}
