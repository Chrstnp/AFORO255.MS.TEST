using System.Collections.Generic;

namespace AFORO255.MS.TEST.Invoice.Repository
{
    public interface IRepositoryInvoice
    {
        IEnumerable<Model.Invoice> GetAll();
    }
}
