using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers;

[Route("api/timeclock")]
[ApiController]
public class TimeClockController : ControllerBase
{
    private DBContext _context;
    public TimeClockController(DBContext context)
    {
        _context = context;
    }

    [HttpPost(template:"punch")]
    public Task<ActionResult<User>> Punch([FromBody]TimePunch punch)
    {
        if (ModelState.IsValid)
        {
            //TODO
        }
        else
        {
            //TODO
        }
        return null!;
    }

}