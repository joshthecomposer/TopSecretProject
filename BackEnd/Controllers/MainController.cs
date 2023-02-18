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
}


