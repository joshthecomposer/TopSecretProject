using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Server.Controllers;

[Route("api/schedule")]
[ApiController]
public class ScheduleController : ControllerBase
{
    private DBContext _context;
    public ScheduleController(DBContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    [ActionName(nameof(GetOneSchedleAsync))]
    public async Task<ActionResult<Schedule>> GetOneScheduleAsync(int id)
    {
        var day = await _context.Schedules.FindAsync(id);
        if (day == null)
        {
            return NotFound();
        }
        else
        {
            return day;
        }
    }

    [HttpPost(template:"schedule")]
    public async Task<ActionResult<User>> Schedule([FromBody]Schedule day)
    {
        if (ModelState.IsValid)
        {
            _context.Add(day);
            await _context.SaveChangesAsync();
            return CreatedAtAction(
                nameof(GetOneScheduleAsync), 
                new {id = day.ScheduleId}, 
                day);
        }
        else
        {
            return BadRequest(ModelState);
        }
    }
    // Thought is this route is for holidays/pto/sick days might need tweaking to say check against pto days or sick days remaining
    [HttpPost(template:"specialSchedule")]
    public async Task<ActionResult<User>> SpecialSchedule([FromBody]Schedule day)
    {
        if (ModelState.IsValid)
        {
            _context.Add(day);
            await _context.SaveChangesAsync();
            return CreatedAtAction(
                nameof(GetOneScheduleAsync), 
                new {id = day.ScheduleId}, 
                day);
        }
        else
        {
            return BadRequest(ModelState);
        }
    }
    

    [HttpGet(template:"schedule/{id}/latest")]
    public async Task<ActionResult<Schedule>> GetRecent(int id)
    {
        var day = await _context.Schedules.Where(d=>d.EmployeeId == id).OrderBy(t=>t.Day).LastOrDefaultAsync();
        Console.WriteLine(day);
        return day!;
    }

    [HttpGet(template:"schedule/{id}/all")]
    public async Task<ActionResult<List<Schedule>>> GetOneUserDays(int id)
    {
        var user = await _context.Users.Include(u => u.Days).FirstOrDefaultAsync(u => u.EmployeeId == id);
        List<Schedule> days = user!.Days;
        foreach(TimePunch d in days)
        {
            d.Employee = null;
        }
        return days;
    }

    [HttpGet(template:"schedule/all")]
    public async Task<ActionResult<List<User>>> GetAllUsersWithSchedules()
    {
        List<User> users = await _context.Users.Include(u => u.Days).ToListAsync();
        foreach(User u in users)
        {
            foreach(Schedule s in u.Days)
            {
                s.Employee = null;
            }
        }
        return users;
    }
}