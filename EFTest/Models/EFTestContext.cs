using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest.Models
{
    public class EFTestContext : DbContext
    {
        public IDbSet<Plug> Plugs { get; set; }

        public IDbSet<Connector> Connectors { get; set; }

        public IDbSet<Cord> Cords { get; set; }

        public IDbSet<Lookup> Lookups { get; set; }

        public EFTestContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<EFTestContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }

    }
}
