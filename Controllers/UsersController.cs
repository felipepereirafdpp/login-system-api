using Login_system.Dto.Auth;
using Login_system.Dto.DtoUser;
using Login_system.Dto.User;
using Login_system.Interfaces;
using Login_system.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("Users")]
[ApiController]

[Authorize]
public class UsersController : ControllerBase
{
    private readonly Login_systemContext _context;
    private readonly IUserService _userService;
    public UsersController(Login_systemContext context, IUserService userService )
    {
        _context = context;
        _userService = userService;
    }

    // GET: api/Users
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> ListarUsuarios()
    {
        
        var user = _userService.GetAllUsers();
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
       
    }

    // GET: api/Users/5
    [Authorize]
    [HttpGet("id/{id}")]
    public async Task<ActionResult<UserDTO>> ListarUsuariosID(ByIdDTO id)
    {
        var userId = _userService.GetById(id);
        if (userId == null)
        {
            return NotFound();
        }
        return Ok(userId);
    }

    [Authorize]
    [HttpGet("email/{email}")]
    public async Task<ActionResult<UserDTO>> GetByEmail(EmailDTO email)
    {
        var userEmail = _userService.GetByEmail(email);
        if(userEmail == null)
        {
            return NotFound();
        }
        return Ok(userEmail);
    }

    // PUT: api/Users/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUsers(UpdateUserDTO userUpdate)
    {

        var user = _userService.UpdateUser(userUpdate);
        if(user == null)
        {
            return NotFound();
        }
        return Ok("Dados Atualizados");

       
    }


    // DELETE: api/Users/5
    [HttpDelete("{id}")]
    public async Task<bool> DeleteUser(ByIdDTO id)
    {
        var userDelete = _userService.DeleteUser(id);
        if(userDelete == null)
        {
            return false;
        }
        return true;
    }

    private bool UsersExists(System.Guid? id)
    {
        return _context.Users.Any(e => e.Id == id);
    }
}

//// POST: api/Users
//// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//[HttpPost]
//public async Task<ActionResult<RegisterUserDTO>> RegistrarUsers(RegisterUserDTO RegistroUser)
//{
//    Users user = new Users { 
//           Name = RegistroUser.Name,
//        PasswordHash = RegistroUser.Password,
//    };
//    _context.Users.Add(user);
//    await _context.SaveChangesAsync();

//    return Ok(user);

//}

