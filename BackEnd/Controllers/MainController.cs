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

    [HttpGet("{id}")]
    [ActionName(nameof(GetOneAdminAsync))]
    public async Task<ActionResult<User>> GetOneAdminAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return user;
    }

    [HttpPost("/api/employee/create")]
    public async Task<ActionResult<User>> PostEmployee([FromBody]User emp)
    {
        if (ModelState.IsValid)
        {
            _context.Users.Add(emp);
            await _context.SaveChangesAsync();
            return CreatedAtAction(
                nameof(GetOneAdminAsync),
                new { id = emp.EmployeeId },
                emp);
        }
        else
        {
            return BadRequest(ModelState);
        }
    }
}


