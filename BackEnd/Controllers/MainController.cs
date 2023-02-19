using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers;

[Route("api/ssp")]
[ApiController]
public class MainController : ControllerBase
{
    private DBContext _context;
    public MainController(DBContext context)
    {
        _context = context;
    }
    
    [HttpGet("/user")]
    public User TestGet()
    {
        User testUser = new User {UserId = 1, UserName = "Hello"};
        return testUser;
    }

    [HttpGet("/api/admins/{AdminId}")]
    public async Task<ActionResult<Admin>> GetOneAdmin(int id)
    {
        var admin = await _context.Admins.FindAsync(id);
        if (admin == null)
        {
            return NotFound();
        }
        return admin;
    }

    [HttpPost("/api/admin/create")]
    public async Task<ActionResult<Admin>> PostAdmin([FromBody] Admin admin)
    {
        if (ModelState.IsValid)
        {
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
            return CreatedAtAction(
                nameof(GetOneAdmin),
                new { id = admin.AdminId },
                admin);
        }
        else
        {
            return BadRequest(ModelState);
        }

    }
}


