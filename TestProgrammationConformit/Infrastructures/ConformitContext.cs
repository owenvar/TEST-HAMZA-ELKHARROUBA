using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Infrastructures
{
    public class ConformitContext : DbContext
    {
        
        public ConformitContext(DbContextOptions<ConformitContext> options) : base(options)
        {
        }

        public DbSet<Evenement> Evenement { get; set; }
        public DbSet<Personne> Personne { get; set; }
        public DbSet<Commentaire> Commentaire { get; set; }
    }
}
