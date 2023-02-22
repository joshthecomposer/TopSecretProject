#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models;

public class User
{
    [Key]
    public int EmployeeId {get;set;}
    [Required]
    [MinLength(2)]
    public string FirstName { get; set; }
    [Required]
    [MinLength(2)]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public bool IsAdmin { get; set; }
    [Compare("ConfirmPassword")]
    public string Password { get; set; }
    [NotMapped]
    public string ConfirmPassword { get; set; }
}