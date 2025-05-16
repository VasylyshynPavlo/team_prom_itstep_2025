using App.Core.Interfaces;
using App.Core.Models.Account;
using App.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace App.Services.Repositories;

public class UserRepository(AppDbContext dbContext) : IUserRepository
{
    private readonly IMongoCollection<User> _users = dbContext.Users;

    public async Task<User?> GetByIdAsync(string id)
    {
        if (!ObjectId.TryParse(id, out var objectId))
            return null;

        return await _users.Find(u => u.Id == objectId).FirstOrDefaultAsync();
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _users.Find(u => u.Email == email).FirstOrDefaultAsync();
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _users.Find(u => u.Username == username).FirstOrDefaultAsync();
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _users.Find(_ => true).ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        await _users.InsertOneAsync(user);
    }

    public async Task UpdateAsync(string id, User user)
    {
        var objectId = ObjectId.Parse(id);
        await _users.ReplaceOneAsync(u => u.Id == objectId, user);
    }

    public async Task DeleteAsync(string id)
    {
        var objectId = ObjectId.Parse(id);
        await _users.DeleteOneAsync(u => u.Id == objectId);
    }
}