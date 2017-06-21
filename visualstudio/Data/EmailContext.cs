using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using visualstudio.Models;

namespace visualstudio.Models
{
    public class EmailContext : DbContext
    {
        public EmailContext (DbContextOptions<EmailContext> options)
            : base(options)
        {
        }

        public DbSet<visualstudio.Models.Email> Email { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EmailDb;Trusted_Connection=True;");
        }

        public DbSet<visualstudio.Models.PastDueTemplate> EmailTemplate { get; set; }
    }
}
