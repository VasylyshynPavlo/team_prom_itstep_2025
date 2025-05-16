using App.Core.Models.Account;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace App.Data;

public class AppDbContext
{
    private readonly IMongoDatabase _database;

    public AppDbContext(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        _database = client.GetDatabase(settings.Value.DatabaseName);
    }
    
    public IMongoCollection<User> Users => _database.GetCollection<User>("Users");

    public async Task CreateIndexesAsync()
    {
        var existingIndexes = await Users.Indexes.ListAsync();
        var indexes = await existingIndexes.ToListAsync();

        bool emailIndexExists = indexes.Any(index => index["name"].AsString == "Email_1");
        bool usernameIndexExists = indexes.Any(index => index["name"].AsString == "Username_1");

        if (!emailIndexExists)
        {
            await Users.Indexes.CreateOneAsync(new CreateIndexModel<User>(
                Builders<User>.IndexKeys.Ascending(u => u.Email),
                new CreateIndexOptions { Unique = true }));
        }

        if (!usernameIndexExists)
        {
            await Users.Indexes.CreateOneAsync(new CreateIndexModel<User>(
                Builders<User>.IndexKeys.Ascending(u => u.Username),
                new CreateIndexOptions { Unique = true }));
        }
    }
}