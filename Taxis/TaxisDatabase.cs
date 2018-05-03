using System;
using System.Collections.Generic;
//using System.Data.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Taxis.Lib.Classes;

namespace Taxis
{
    public class TaxisDatabase: DbContext
    {
        public TaxisDatabase()
            :base("DbConnection")
        { }

        public DbSet<Sedan> Sedans { get; set; }
        public DbSet<Minivan> Minivans{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sedan>()
            .Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Sedans");
            });
            modelBuilder.Entity<Minivan>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Minivans");
            });
        }
    }

}
