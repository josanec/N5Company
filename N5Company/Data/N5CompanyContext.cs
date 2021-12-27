using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using N5Company.Models;

namespace N5Company.Data
{
    public class N5CompanyContext : DbContext
    {
        public N5CompanyContext (DbContextOptions<N5CompanyContext> options)
            : base(options)
        {
        }

        public DbSet<N5Company.Models.Permissions> Permissions { get; set; }

        public DbSet<N5Company.Models.PermissionTypes> PermissionTypes { get; set; }
    }
}
