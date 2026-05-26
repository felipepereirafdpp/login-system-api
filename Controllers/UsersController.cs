using Login_system.Dto.Auth;
using Login_system.Dto.DtoUser;
using Login_system.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("Users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly Login_systemContext _context;
    public UsersController(Login_systemContext context)
    {
        _context = context;
    }

    // GET: api/Users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> ListarUsuarios()
    {
        var user = await _context.Users.ToListAsync();
        var dados = user
            .Select(user => new UserDTO
            {
                Name = user.Name,
                Email = user.Email,
                Id = user.Id,
            })
            .ToList();
        return Ok(dados);
    }

    // GET: api/Users/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTO>> ListarUsuariosID(System.Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        var dados = (new UserDTO
        {
            Name = user.Name,
            Email = user.Email,
            Id = user.Id,


        });
         
        return Ok(dados);
    }

    // PUT: api/Users/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUsers(System.Guid id, UpdateUserDTO userUpdate)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }
        user.Name = userUpdate.Name;
        user.Email = userUpdate.Email;

        await _context.SaveChangesAsync();

        return Ok("Dados Atualizados com Susseso !");
    }

    // POST: api/Users
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<RegisterUser>> RegistrarUsers(RegisterUser RegistroUser)
    {
        Users user = new Users { 
               Name = RegistroUser.Name,
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok(user);

    }

    // DELETE: api/Users/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsers(System.Guid? id)
    {
        var users = await _context.Users.FindAsync(id);
        if (users == null)
        {
            return NotFound();
        }

        _context.Users.Remove(users);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UsersExists(System.Guid? id)
    {
        return _context.Users.Any(e => e.Id == id);
    }
}
