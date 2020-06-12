using AFORO255.MS.TEST.Security.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Security.Repository.Data
{
    public interface IContextDatabase
    {
        DbSet<Access> Access { get; set; }
    }
}
