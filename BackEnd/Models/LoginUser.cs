#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models;

public class LoginUser
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}