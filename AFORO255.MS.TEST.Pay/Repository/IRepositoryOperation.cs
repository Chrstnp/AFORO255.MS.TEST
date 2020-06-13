using AFORO255.MS.TEST.Pay.Model;
using System.Collections.Generic;

namespace AFORO255.MS.TEST.Pay.Repository
{
    public interface IRepositoryOperation
    {
        Operation RegisterPayment(Operation payTransaction);
        IEnumerable<Operation> GetAll();
    }
}
