using Login_system.Dto.Auth;
using Login_system.Dto.Auth.DtoExit;
using Login_system.Exceptions;
using Login_system.Interfaces;
using Login_system.Models;
using Login_system.Services.EmailService;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;



namespace Login_system.Services.Auth;

public class AuthService : IAuthService
{


    // Campo privado somente leitura que guarda a instância do DbContext
    // Ele é usado para acessar o banco de dados dentro da classe Service
    private readonly Login_systemContext _context;
    private readonly EmailsService _emailService;


    // Construtor da classe UserService
    // O ASP.NET Core injeta automaticamente o Login_systemContext aqui (Dependency Injection)
    public AuthService(Login_systemContext context, EmailsService emailService)
    {
        // Atribui o DbContext recebido pelo construtor ao campo privado da classe
        // Assim ele pode ser usado em todos os métodos da service
        _context = context;
        _emailService = emailService;
    }

    private string GenerateToken(Users user)
    {
        // dados que vao dentro do token, nesse caso o id, email e nome do usuario
        var claims = new[]
        {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name)
            };

        // A chave de segurança é usada para assinar o token e garantir que ele não seja alterado
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("FELIPE12092008")
        );

        // COMO O TOKEN VAI SER ASSINADO, PRECISAMOS DE UMA CHAVE E DE UM ALGORITMO DE ASSINATURA
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Criamos o token JWT usando as claims, a data de expiração e as credenciais de assinatura
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );
        // Por fim, usamos o JwtSecurityTokenHandler para escrever o token em formato string e retornamos ele
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    public static string GenerateNumericToken(int length = 6)
    {
        char[] digits = new char[length];

        using (var rng = RandomNumberGenerator.Create())
        {
            byte[] data = new byte[length];
            rng.GetBytes(data);

            for (int i = 0; i < length; i++)
            {
                // Mapeia o byte aleatório (0-255) para um dígito seguro (0-9)
                digits[i] = (char)('0' + (data[i] % 10));
            }
        }
        return new string(digits);
    }


    public async Task<ResponseTokenDTO> RegisterUsers(RegisterUserDTO dadosUser)
    {
        var temArroba = new EmailAddressAttribute().IsValid(dadosUser.Email); ;
        if (!temArroba)
        {
            throw new EmailSemArrobaException();
        }
        var validarEmail = await _context.Users.AnyAsync(u => u.Email == dadosUser.Email);
        if (validarEmail)
        {
            throw new EmailJaCadastradoException();
        }

        var user = new Users
        {
            Name = dadosUser.Name,
            Email = dadosUser.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dadosUser.Password)
        };
        try
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new ExceptionsAuthSalvarBanco("Erro ao salvar o usuário.", ex);
        }

        var token = GenerateToken(user); // Pega as informações do usuário e gera um token JWT

        return new ResponseTokenDTO // retona o token e as informações do usuarioa para o cliente 
        {
            Token = token,
            ExpiresAt = DateTime.UtcNow.AddHours(1),
            UserId = user.Id,
            Name = user.Name,
            Email = user.Email
        };

    }

    public async Task<ResponseTokenDTO> LoginUsers(LoginDTO dadosLoginUser)
    {

        if (string.IsNullOrWhiteSpace(dadosLoginUser.Email) || string.IsNullOrWhiteSpace(dadosLoginUser.Password))
        {
            throw new ExceptionsAuthLogin("Email e senha são obrigatórios.");
        }

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dadosLoginUser.Email);
        if (user == null)
        {
            throw new ExceptionsAuthLogin();
        }
        var senhaValida = BCrypt.Net.BCrypt.Verify(dadosLoginUser.Password, user.PasswordHash);
        if (!senhaValida)
        {
            throw new ExceptionsAuthLogin();
        }

        var token = GenerateToken(user);
        return new ResponseTokenDTO
        {
            Token = token,
            ExpiresAt = DateTime.UtcNow.AddHours(1),
            UserId = user.Id,
            Email = user.Email,
            Name = user.Name

        };
    }
    public async Task<ResponseForgotPasswordDTO> ForgotPassword(ForgotPasswordDTO emailPassordReset)
    {
        if (string.IsNullOrWhiteSpace(emailPassordReset.Email))
        {
            throw new ExceptionsAuthFogotPassword();
        }
        var userEmail = await _context.Users.FirstOrDefaultAsync(u => u.Email == emailPassordReset.Email);
        if (userEmail == null)
        {
            throw new ExceptionsAuthFogotPassword();
        }
        string tokenGerado = GenerateNumericToken(6);

        var passwordResetToken = new PasswordResetToken
        {
            Token = tokenGerado,
            ExpiresAt = DateTime.UtcNow.AddMinutes(5),
            UserId = userEmail.Id,
        };
        try
        {
            _context.PasswordResetTokens.Add(passwordResetToken);
            await _context.SaveChangesAsync();
            await _emailService.EnviarEmail(emailPassordReset.Email, tokenGerado);
        }
        catch (Exception ex) {
            throw new ExceptionsAuthSalvarBanco("Erro ao  solicitar redefinição de senha.", ex);
        }

        return new ResponseForgotPasswordDTO
        {
            Mensagem = "Solicitação de redefinição de senha enviada para o email."
        };
    }

    public async Task<ResponseResetPasswordDTO> ResetPassword(ResetPasswordDTO userReset)
    {
        if (string.IsNullOrWhiteSpace(userReset.Token) || string.IsNullOrWhiteSpace(userReset.ConfirmPassword) || string.IsNullOrWhiteSpace(userReset.NewPassword))
        {
            throw new ExceptionsAuthResetPassword();
        }
        if (userReset.NewPassword != userReset.ConfirmPassword)
        {
            throw new ExceptionsAuthResetPassword("A nova senha e a confirmação de senha não coincidem.");
        }
        var tokenBanco = await _context.PasswordResetTokens.FirstOrDefaultAsync(u => u.Token == userReset.Token);
        if (tokenBanco == null)
        {
            throw new ExceptionsAuthResetPassword("Token de redefinição inválido.");
        }
        if (tokenBanco.Used)
        {
            throw new ExceptionsAuthResetPassword("Token de redefinição já utilizado.");
        }
        if (tokenBanco.ExpiresAt < DateTime.UtcNow)
        {
            throw new ExceptionsAuthResetPassword("Token Inspirado");
        }

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == tokenBanco.UserId);
        if (user == null)
        {
            throw new ExceptionsAuthResetPassword("Usuário não encontrado para o token fornecido.");
        }
            var senhaNova = user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userReset.NewPassword);
            tokenBanco.Used = true;
        try
        {
            await _context.SaveChangesAsync();
        } catch (DbUpdateException ex)
        {
            throw new ExceptionsAuthSalvarBanco("Erro ao salvar a nova senha.", ex);

        }
        return new ResponseResetPasswordDTO
        {
            Message = "Senha redefinida com sucesso."
        };


    } 
}
       

    

