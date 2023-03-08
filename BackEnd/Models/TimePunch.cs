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
    public DateTime? PunchIn { get; set; }
    public DateTime? PunchOut { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public User? Employee { get; set; }
}