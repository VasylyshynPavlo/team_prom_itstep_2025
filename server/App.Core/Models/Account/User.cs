using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace App.Core.Models.Account;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string HashedPassword { get; set; }
    public string Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Blocked { get; set; }
    public string? Avatar { get; set; }
    public char? Sex { get; set; }
    public DateTime? Birthday { get; set; }
    public string? PublicName { get; set; }
    public string? Phone { get; set; }

    public User(string username, string hashedPassword, string email, string role, char sex = 'n',
        DateTime? birthday = null, string? phone = null, string? avatar = null, 
        string? publicName = null)
    {
        Id = ObjectId.GenerateNewId();
        CreatedAt = DateTime.UtcNow;
        Email = email;
        Role = role;
        Username = username;
        Avatar = avatar;
        Blocked = false;
        PublicName = publicName;
        HashedPassword = hashedPassword;
        Sex = sex;
        Phone = phone;
        Birthday = birthday;
    }
}