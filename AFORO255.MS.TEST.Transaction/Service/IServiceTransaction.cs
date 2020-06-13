using AFORO255.MS.TEST.Transaction.Dto;
using AFORO255.MS.TEST.Transaction.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Transaction.Service
{
    public interface IServiceTransaction
    {
        Task<IEnumerable<PayTransactionResponse>> GetAll();

        Task<bool> Add(PayTransaction payTransaction);
    }
}
