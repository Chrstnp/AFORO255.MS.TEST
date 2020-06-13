using AFORO255.MS.TEST.Transaction.Model;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Transaction.Repository
{
    public interface IRepositoryTransation
    {
        IMongoCollection<PayTransaction> PayHistory { get; }
    }
}
