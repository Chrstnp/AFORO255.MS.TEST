using AFORO255.MS.TEST.Transaction.Dto;
using AFORO255.MS.TEST.Transaction.Model;
using AFORO255.MS.TEST.Transaction.Service;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Transaction.Repository
{
    public class ServiceTransaction : IServiceTransaction
    {
        private readonly IRepositoryTransation _historyRepository;

        public ServiceTransaction(IRepositoryTransation historyRepository)
        {
            _historyRepository = historyRepository;
        }

        public async Task<bool> Add(PayTransaction historyTransaction)
        {
            await _historyRepository.PayHistory.InsertOneAsync(historyTransaction);
            return true;
        }

        public async Task<IEnumerable<PayTransactionResponse>> GetAll()
        {
            var data = await _historyRepository.PayHistory.Find(_ => true).ToListAsync();
            var response = new List<PayTransactionResponse>();
            foreach (var item in data)
            {
                response.Add(new PayTransactionResponse()
                {
                    id_transaccion = item.id_transaccion,
                    id_invoice = item.id_invoice,
                    amount = item.amount,
                    date = item.date
                });
            }
            return response;
        }
    }
}
