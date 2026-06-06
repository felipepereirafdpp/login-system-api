

using Login_system.Dto.Auth;
using Login_system.Interfaces;
using Login_system.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[Route("Auth")]
[ApiController]


public class AuthController : ControllerBase { 

    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    
    [HttpPost("login")]
    public async Task<IActionResult> LoginUsers(LoginDTO dadosLoginUser)
    {
        var token = await _authService.LoginUsers(dadosLoginUser);
       
        return Ok(token);
    }

    [HttpPost("Registro")]
    public async Task<IActionResult> RegisterUsers(RegisterUserDTO dadosUser)
    {
        var user = await _authService.RegisterUsers(dadosUser);
       
        return Ok(user);
    }

  
    [HttpPost("EsqueciSenha")]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordDTO emailResetPassword)
    {
        var user = await _authService.ForgotPassword(emailResetPassword);
      
        return Ok(user);
    }
   
    [HttpPost("ResetarSenha")]
    public async Task<IActionResult> ResetPassword(ResetPasswordDTO userReset)
    {
        var user = await _authService.ResetPassword(userReset);
       
        return Ok(user);
    }





}