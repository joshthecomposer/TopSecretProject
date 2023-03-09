using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Collections.Specialized;

namespace Server.Controllers;

[Route("api/timeclock")]
[ApiController]
public class TimePunchController : ControllerBase
{
    private DBContext _context;
    public TimePunchController(DBContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    [ActionName(nameof(GetOneTimePunchAsync))]
    public async Task<ActionResult<TimePunch>> GetOneTimePunchAsync(int id)
    {
        var punch = await _context.TimePunches.FindAsync(id);
        if (punch == null)
        {
            return NotFound();
        }
        else
        {
            return punch;
        }
    }

    [HttpPost(template:"punch")]
    public async Task<ActionResult<User>> Punch([FromBody]TimePunch punch)
    {



        if (ModelState.IsValid)
        {
            DateTime punchIn = (DateTime) punch.PunchIn!;
            punchIn = punchIn.ToLocalTime();
            punch.PunchIn = punchIn;

            _context.Add(punch);
            await _context.SaveChangesAsync();
            return CreatedAtAction(
                nameof(GetOneTimePunchAsync), 
                new {id = punch.TimePunchId}, 
                punch);
        }
        else
        {
            return BadRequest(ModelState);
        }
    }

    [HttpGet(template:"punch/{id}/latest")]
    public async Task<ActionResult<TimePunch>> GetLatest(int id)
    {
        var punch = await _context.TimePunches.Where(p=>p.EmployeeId == id).OrderBy(t=>t.CreatedAt).LastOrDefaultAsync();
        Console.WriteLine(punch);
        return punch!;
    }

    [HttpGet(template:"punch/{employeeId}/all")]
    public async Task<ActionResult<List<TimePunch>>> GetOnePunches(int employeeId, [FromQuery(Name="limit")] string queryParam = null!)
    {
        List<TimePunch> punches = new List<TimePunch>();
        if (queryParam == null)
        {
            var user = 
            await _context.Users
            .Include(u => u.Punches)
            .Select(u=> 
            new {
                EmployeeId = u.EmployeeId,
                Punches = u.Punches
                })
            .FirstOrDefaultAsync(u => u.EmployeeId == employeeId);
            return punches = user!.Punches;
        }
        else if (Int32.Parse(queryParam) < 1)
        {
            var user = 
            await _context.Users
            .Include(u => u.Punches)
            .Select(u=> new {
                EmployeeId = u.EmployeeId,
                Punches = u.Punches
                })
            .FirstOrDefaultAsync(u => u.EmployeeId == employeeId);
            return punches = user!.Punches;
        }
        else
        {
            DateTime date = DateTime.Now.AddDays(-(Int32.Parse(queryParam)));
            var user = 
            await _context.Users
            .Include(u => u.Punches)
            .Where(p => p.CreatedAt >= date)
            .Select(u=> new {
                EmployeeId = u.EmployeeId,
                Punches = u.Punches
                })
            .FirstOrDefaultAsync(u => u.EmployeeId == employeeId);
            return punches = user!.Punches;
        }
    }

    [HttpGet(template:"punch/all")]
    public async Task<ActionResult<List<User>>> GetAllUsersWithPunches()
    {
        List<User> users = await _context.Users.Include(u => u.Punches).ToListAsync();
        foreach(User u in users)
        {
            foreach(TimePunch p in u.Punches)
            {
                p.Employee = null;
            }
        }
        return users;
    }

    [HttpPut("punch/{id}")]
    public async Task<ActionResult<TimePunch>> UpdatePunch([FromBody] TimePunch newPunch, int id)
    {
        TimePunch? OldPunch = await _context.TimePunches.FirstOrDefaultAsync(p => p.TimePunchId == id);
        
        if (ModelState.IsValid)
        {
            DateTime punchOut = (DateTime) newPunch.PunchOut!;
            punchOut = punchOut.ToLocalTime();
            newPunch.PunchOut = punchOut;

            OldPunch!.EmployeeId = newPunch.EmployeeId;
            OldPunch.PunchIn = newPunch.PunchIn;
            OldPunch.PunchOut = newPunch.PunchOut;
            OldPunch.CreatedAt = newPunch.CreatedAt;
            OldPunch.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
        }
        return newPunch;
    }
}