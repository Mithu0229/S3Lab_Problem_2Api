using Data.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class ExmDBContext : DbContext
    {
        public ExmDBContext(DbContextOptions<ExmDBContext> options)
             : base(options)
        {
        }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<PObject> PObjects { get; set; }
        public DbSet<DataField> DataFields { get; set; }
        public DbSet<Reading> Readings { get; set; }


    }
    
}
