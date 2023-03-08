using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Collections.Specialized;

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

    [HttpGet(template:"punch/{id}/all")]
    public async Task<ActionResult<List<TimePunch>>> GetOnePunches(int id, [FromQuery(Name="limit")] string input = null!)
    {
        var user = new User();
        if (input != null)
        {
            DateTime one = DateTime.Now;
            int i = Int32.Parse(input);
            DateTime two = one.AddDays(-i);
            user = await _context.Users.Include(u => u.Punches).Where(p=>p.CreatedAt >= two).FirstOrDefaultAsync(u => u.EmployeeId == id);
        }
        else
        {
            user = await _context.Users.Include(u => u.Punches).FirstOrDefaultAsync(u => u.EmployeeId == id);
        }
        List<TimePunch> punches = user!.Punches;
        foreach(TimePunch p in punches)
        {
            p.Employee = null;
        }
        return punches;
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