using Library.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Library.Database;

public class MongoDbFactory : IMongoDbConnectionFactory
{
    private readonly MongoDbOptions _mongoDbOptions;

    public MongoDbFactory(IOptions<MongoDbOptions> mongoDbOptions)
    {
        _mongoDbOptions = mongoDbOptions.Value;
    }

    public IMongoDatabase GetDatabase()
    {
        var mongoClient = new MongoClient(_mongoDbOptions.ConnectionString);
        return mongoClient.GetDatabase(_mongoDbOptions.DbName);
    }
}