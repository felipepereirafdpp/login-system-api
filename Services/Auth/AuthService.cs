using Login_system.Dto.Auth;
using Login_system.Exceptions;
using Login_system.Interfaces;
using Login_system.Models;
using Login_system.Services.Auth.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Net.NetworkInformation;
using System.Security.Claims;
using System.Text;



namespace Login_system.Services.Auth
{
    public class AuthService : IAuthService
    {   
        

        // Campo privado somente leitura que guarda a instância do DbContext
        // Ele é usado para acessar o banco de dados dentro da classe Service
        private readonly Login_systemContext _context;


        // Construtor da classe UserService
        // O ASP.NET Core injeta automaticamente o Login_systemContext aqui (Dependency Injection)
        public AuthService(Login_systemContext context)
        {
            // Atribui o DbContext recebido pelo construtor ao campo privado da classe
            // Assim ele pode ser usado em todos os métodos da service
            _context = context;
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
            catch(DbUpdateException ex)
            {
                throw new ExceptionsAuthSalvarBanco("Erro ao salvar o usuário no banco de dados.", ex);
            }

            var token = GenerateToken(user); // Pega as informações do usuário e gera um token JWT

            return new ResponseTokenDTO // retona o token e as informações do usuarioa para o cliente 
            {
                Token = token,
                ExpiresAt = DateTime.UtcNow.AddHours(2),
                UserId = user.Id,
                Name = user.Name,
                Email = user.Email
            };

        }

    }


}

