#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models;
public class Admin
{
    [Key]
    public int AdminId { get; set; }
    [Required]
    [MinLength(2)]
    public string FirstName { get; set; }
    [Required]
    [MinLength(2)]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Compare("ConfirmPassword")]
    public string Password { get; set; }
    [NotMapped]
    public string ConfirmPassword { get; set; }
}
