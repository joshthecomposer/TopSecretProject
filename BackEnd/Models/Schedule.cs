#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models;

public class Schedule
{
    [Key]
    public int ScheduleId { get; set; }
    //foreign key
    [Required]
    public int EmployeeId { get; set; }
    public DateTime Day {get; set;}
    public DateTime StartTime {get; set;}
    public DateTime EndTime {get; set;}

    // Special cases that can be changed on edit or a special add form where if true *2 for pay or can't clock in / auto clock in but all set to a default of false
    public bool Holiday {get; set;} = false;
    public string Pto {get; set;} = "Not Applicable";
    public bool Sick {get; set;} = false;
    public bool OverTime {get; set;} = false;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public User? Employee { get; set; }
}