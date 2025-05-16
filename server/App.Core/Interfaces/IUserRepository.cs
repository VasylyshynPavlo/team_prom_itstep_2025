using App.Core.Models.Account;

namespace App.Core.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(string id);
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByUsernameAsync(string username);
    Task<List<User>> GetAllAsync();
    Task AddAsync(User user);
    Task UpdateAsync(string id, User user);
    Task DeleteAsync(string id);
}