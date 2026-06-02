using Login_system.Dto.Auth;
using Login_system.Dto.Auth.DtoExit;


namespace Login_system.Interfaces;

public interface IAuthService
{
    Task<ResponseTokenDTO> LoginUsers(LoginDTO DadosUser);
    Task<ResponseTokenDTO> RegisterUsers(RegisterUserDTO register);
    Task<ResponseForgotPasswordDTO> ForgotPassword(ForgotPasswordDTO emailResetPassword);
    Task<ResetPasswordDTO> ResetPassword(ResetPasswordDTO resetDTO);
    Task<bool> ValidateToken(string token);

}
