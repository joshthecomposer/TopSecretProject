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
    [NotEmailExists]
    public string Email { get; set; }
    [Required]
    public bool IsAdmin { get; set; }
    [Compare("ConfirmPassword")]
    public string Password { get; set; }
    [NotMapped]
    public string ConfirmPassword { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<TimePunch> Punches { get; set; } = new List<TimePunch>();
}

public class NotEmailExistsAttribute : ValidationAttribute
{
protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {   
        if (value == null)
        {
            return new ValidationResult("Email is required.");
        }
        DBContext _context = (DBContext)validationContext.GetService(typeof(DBContext))!;
        if (_context.Users.Any(e=>e.Email == value.ToString()))
        {
            return new ValidationResult("This email already exists");
        } else {
            return ValidationResult.Success!;
        }
    }
}