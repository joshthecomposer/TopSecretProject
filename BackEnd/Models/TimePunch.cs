#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models;

public class TimePunch
{
    [Key]
    public int TimePunchId { get; set; }
    //foreign key
    [Required]
    public int EmployeeId { get; set; }
    [Required]
    public bool PunchType { get; set; } //True is punching and False is punching out
    public DateTime PunchTime { get; set; } = DateTime.Now;

    public User? Employee { get; set; }
}