using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CompanyNemetschek.Models;

namespace CompanyNemetschek.Data
{
    public class CompanyNemetschekContext : DbContext
    {
        public CompanyNemetschekContext (DbContextOptions<CompanyNemetschekContext> options)
            : base(options)
        {
        }

        public DbSet<CompanyNemetschek.Models.Human> Human { get; set; } = default!;

        public DbSet<CompanyNemetschek.Models.TeamLead>? TeamLead { get; set; }

        public DbSet<CompanyNemetschek.Models.Company>? Company { get; set; }
    }
}
