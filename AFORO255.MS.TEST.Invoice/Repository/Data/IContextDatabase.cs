using Microsoft.EntityFrameworkCore;
using AFORO255.MS.TEST.Invoice.Model;

namespace AFORO255.MS.TEST.Invoice.Repository.Data
{
    public interface IContextDatabase
    {
        DbSet<Model.Invoice> Invoices { get; set; }
    }
}
