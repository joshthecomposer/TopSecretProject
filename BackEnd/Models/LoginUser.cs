#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Server.Models;

public class LoginUser
{
    [Required]
    [IsEmailExists]
    public string Email { get; set; }
    [Required]
    [IsPasswordCorrect("Email")]
    public string Password { get; set; }

}

public class IsEmailExistsAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {   
            if (value == null)
            {
                return new ValidationResult("Email is required.");
            }
            DBContext _context = (DBContext)validationContext.GetService(typeof(DBContext))!;
            if (!_context.Users.Any(e=>e.Email == value.ToString()))
            {
                return new ValidationResult("Invalid Email/Password");
            } else {
                return ValidationResult.Success!;
            }
        }
}

public class IsPasswordCorrectAttribute : ValidationAttribute
{
    private readonly string _dependentProperty;
    public IsPasswordCorrectAttribute(string dependentProperty)
        {
            _dependentProperty = dependentProperty;
        }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        DBContext _context = (DBContext)validationContext.GetService(typeof(DBContext))!;
        string pw = (string)value!;
        Object instance = validationContext.ObjectInstance;
        Type type = instance.GetType();
        var emailValue = type.GetProperty(_dependentProperty)!.GetValue(instance, null);
        User? check = _context.Users.SingleOrDefault(c => c.Email ==(string)emailValue!);

        if (check == null)
        {
            return new ValidationResult("Email/Password is Invalid");
        }

        PasswordHasher<User> hasher = new PasswordHasher<User>();
        var result = hasher.VerifyHashedPassword(check, check.Password, pw);
        if (result == 0)
        {
            return new ValidationResult("Email/Password is Invalid");
        }

        return ValidationResult.Success!;
    }
}

