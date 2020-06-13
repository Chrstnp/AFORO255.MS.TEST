using AFORO255.MS.TEST.Pay.Model;
using Microsoft.EntityFrameworkCore;

namespace AFORO255.MS.TEST.Pay.Repository.Data
{
    public class ContextDatabase : DbContext, IContextDatabase
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {
        }

        public DbSet<Operation> Operations { get; set; }
        public DbContext Instance => this;
    }
}
