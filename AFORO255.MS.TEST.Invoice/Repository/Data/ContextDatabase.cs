using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Invoice.Repository.Data
{
    public class ContextDatabase : DbContext, IContextDatabase
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForNpgsqlUseIdentityColumns();
        }

        public DbContext Instance => this;

        public DbSet<Model.Invoice> Invoices { get; set; }
    }
}
