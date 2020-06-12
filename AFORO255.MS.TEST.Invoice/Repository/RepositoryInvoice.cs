using AFORO255.MS.TEST.Invoice.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Invoice.Repository
{
    public class RepositoryInvoice : IRepositoryInvoice
    {
        private readonly IContextDatabase _context;
        public RepositoryInvoice(IContextDatabase context)
        {
            _context = context;
        }

        public IEnumerable<Model.Invoice> GetAll()
        {
            return _context.Invoices.ToList();
        }

    }
}
