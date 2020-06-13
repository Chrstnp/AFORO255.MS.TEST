using AFORO255.MS.TEST.Pay.Model;
using AFORO255.MS.TEST.Pay.Repository.Data;
using System.Collections.Generic;
using System.Linq;

namespace AFORO255.MS.TEST.Pay.Repository
{
    public class RepositoryOperation : IRepositoryOperation
    {
        private readonly IContextDatabase _context;

        public RepositoryOperation(IContextDatabase context)
        {
            _context = context;
        }

        public IEnumerable<Operation> GetAll()
        {
            return _context.Operations.ToList();
        }

        public Operation RegisterPayment(Operation operation)
        {
            _context.Operations.Add(operation);
            _context.SaveChanges();
            return operation;
        }

    }
}
