using System.Data.Entity;
using Taxis.Lib.Classes;

namespace Taxis
{
    public class TaxisDatabase: DbContext
    {
        public TaxisDatabase()
            :base("DbConnection")
        { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Sedan> Sedans { get; set; }
        public DbSet<Minivan> Minivans{ get; set; }
    }
}
