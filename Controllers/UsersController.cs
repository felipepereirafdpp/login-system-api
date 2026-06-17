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
    private readonly IUserService _userService;
    public UsersController( IUserService userService )
    {
       
        _userService = userService;
    }

    // GET: api/Users
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> ListarUsuarios()
    {
        
        var user = await _userService.GetAllUsers();
      
        return Ok(user);
       
    }

    // GET: api/Users/5
    [Authorize]
    [HttpGet("id/{id}")]
    public async Task<ActionResult<UserDTO>> ListarUsuariosID(Guid id)
    {
        var idDto = new ByIdDTO { Id = id };

        var userId =  await _userService.GetById(idDto);
     
        return Ok(userId);
    }

    [Authorize]
    [HttpGet("email/{email}")]
    public async Task<ActionResult<UserDTO>> GetByEmail(string email)
    {
        var emailDto = new EmailDTO { Email = email };

        var userEmail = await _userService.GetByEmail(emailDto);
       
        return Ok(userEmail);
    }

    // PUT: api/Users/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUsers(Guid id, UpdateUserDTO userUpdate)
    {

        var user = await _userService.UpdateUser(userUpdate);
        
        return Ok(user);

       
    }


    // DELETE: api/Users/5
    [HttpDelete("{id}")]
    public async Task<bool> DeleteUser(ByIdDTO id)
    {
        var userDelete =  await _userService.DeleteUser(id);
        if (!userDelete)
        {
            return false;
        }

        return true;
    }

   
}


