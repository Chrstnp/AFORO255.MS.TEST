using AFORO255.MS.TEST.Security.Model;
using AFORO255.MS.TEST.Security.Repository.Data;
using System.Collections.Generic;
using System.Linq;

namespace AFORO255.MS.TEST.Security.Repository
{
    public class RepositoryAccess : IRepositoryAccess
    {
        private readonly IContextDatabase _context;
        public RepositoryAccess(IContextDatabase context)
        {
            _context = context;
        }

        public IEnumerable<Access> GetAll()
        {
            return _context.Access.ToList();
        }
    }
}
