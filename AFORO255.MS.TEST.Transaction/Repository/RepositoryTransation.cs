using AFORO255.MS.TEST.Transaction.Model;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace AFORO255.MS.TEST.Transaction.Repository
{
    public class RepositoryTransation : IRepositoryTransation
    {
        private readonly IMongoDatabase _database = null;
        private readonly IConfiguration _configuration;

        public RepositoryTransation(IConfiguration configuration)
        {
            _configuration = configuration;
            var client = new MongoClient(_configuration["cnmongo"]);
            if (client != null)
                _database = client.GetDatabase(_configuration["mongodb"]);
        }

        public IMongoCollection<PayTransaction> PayHistory
        {
            get
            {
                return _database.GetCollection<PayTransaction>("PayTransaction");
            }
        }
    }
}
