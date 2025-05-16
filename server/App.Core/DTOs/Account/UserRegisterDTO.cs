namespace App.Core.DTOs.Account;

public class RegisterUserDto
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Role { get; set; } = "user";
    public char Sex { get; set; } = 'n';
    public DateOnly? Birthday { get; set; }
    public string? Phone { get; set; }
    public string? Avatar { get; set; }
    public string? PublicName { get; set; }
}