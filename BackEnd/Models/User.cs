#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace Server.Models;

public class User
{
    [Key]
    public int UserId {get;set;}
    public string UserName {get;set;}
}