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

        CreateIndexes();
    }
    
    public IMongoCollection<User> Users => _database.GetCollection<User>("Users");

    private void CreateIndexes()
    {
        Users.Indexes.CreateOne(new CreateIndexModel<User>(
            Builders<User>.IndexKeys.Ascending(u => u.Email),
            new CreateIndexOptions { Unique = true }));

        Users.Indexes.CreateOne(new CreateIndexModel<User>(
            Builders<User>.IndexKeys.Ascending(u => u.Username),
            new CreateIndexOptions { Unique = true }));
    }
}