
using Login_system.Dto.DtoUser;
using Login_system.Dto.User;
using Login_system.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Login_system.Services.User;

public class UserService : IUserService
{

    // Campo privado somente leitura que guarda a instância do DbContext
    // Ele é usado para acessar o banco de dados dentro da classe Service
    private readonly Login_systemContext _context;


    // Construtor da classe UserService
    // O ASP.NET Core injeta automaticamente o Login_systemContext aqui (Dependency Injection)
    public UserService(Login_systemContext context)
    {
        // Atribui o DbContext recebido pelo construtor ao campo privado da classe
        // Assim ele pode ser usado em todos os métodos da service
        _context = context;
    }

    public async Task<List<UserDTO>> GetAllUsers()
    {
        var dados = await _context.Users
            .OrderBy(u => u.Name)
            .Select(user => new UserDTO
            {
                Name = user.Name,
                Email = user.Email,
                Id = user.Id,
            })
            .ToListAsync();

        return (dados);
    }

    public async Task<UserDTO> GetById(ByIdDTO id)
    {
        var user = await _context.Users.FindAsync(id.Id);
        if (user == null)
        {
            throw new Exception("Usuario não encontrado");
        }
        var dados = (new UserDTO
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        });
        return (dados);
    }

    public async Task<UserDTO> GetByEmail(EmailDTO email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == email.Email);
        if (user == null)
        {
            throw new Exception("Email de usuario não encontrato");
        }
        var dados = (new UserDTO
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        });
        return (dados);
    }

    public async Task<UserDTO> UpdateUser(UpdateUserDTO dadosNovos)
    {

        var user = await _context.Users.FindAsync(dadosNovos.Id);
        if (user == null)
        {
            throw new Exception("Usuario não encontrado !");
        }
        user.Name = dadosNovos.Name;
        user.Email = dadosNovos.Email;

        await _context.SaveChangesAsync();

        var usuarioAtualizado = (new UserDTO
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email


        });
        return (usuarioAtualizado);

    }

    public async Task<Boolean> DeleteUser(ByIdDTO id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return false;
            
        }
        _context.Remove(user);
        await _context.SaveChangesAsync();


        return true;

    }

    
}