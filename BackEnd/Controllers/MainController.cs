using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers;

[Route("api")]
[ApiController]
public class MainController : ControllerBase
{
    private DBContext _context;
    public MainController(DBContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    [ActionName(nameof(GetOneEmployeeAsync))]
    public async Task<ActionResult<User>> GetOneEmployeeAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return user;
    }

    [HttpPost(template:"employee/create")]
    public async Task<ActionResult<User>> CreateEmployee([FromBody]User newUser)
    {
        if (ModelState.IsValid)
        {
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            newUser.Password = hasher.HashPassword(newUser, newUser.Password);
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            newUser.ConfirmPassword = null!;
            newUser.Password = null!;
            return CreatedAtAction(
                nameof(GetOneEmployeeAsync),
                new { id = newUser.EmployeeId },
                newUser);
        }
        else
        {
            return BadRequest(ModelState);
        }
    }

    [HttpPost(template:"employee/login")]
    public async Task<ActionResult<User>> Login([FromBody]LoginUser loginUser)
    {
        if (ModelState.IsValid)
        {
            User? check = await _context.Users.SingleOrDefaultAsync(c => c.Email == loginUser.Email);
            check!.Password = null!;
            check.ConfirmPassword = null!;
            return AcceptedAtAction(nameof(GetOneEmployeeAsync), new {id = check.EmployeeId}, check);
        }
        else
        {
            return BadRequest(ModelState);
        }
    }
}


