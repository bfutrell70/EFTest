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
            // plugs
            // plug has optional Lookup object
            // Lookup object has 0 or more Plug objects (straight/angled)
            modelBuilder.Entity<Plug>().ToTable("Plugs").HasKey(x => x.uid);
            //HasOptional(x => x.Lookup);

            // connectors
            // connector has optional Lookup object
            // Lookup object has 0 or more Connector objects (straight/angled)
            modelBuilder.Entity<Connector>().ToTable("Connectors").HasKey(x => x.uid);
            //HasOptional(x => x.Lookup);

            // cords
            modelBuilder.Entity<Cord>().ToTable("Cords").HasKey(x => x.uid);
                //HasOptional(x => x.Lookup);

            // lookups
            // a value can be in the lookup table but not be related to any plug, connector or cord record.
            modelBuilder.Entity<Lookup>().ToTable("Lookups").HasKey(x => x.sku);
            modelBuilder.Entity<Lookup>().HasMany(x => x.Plugs).WithOptional().HasForeignKey(x => x.sku);
            modelBuilder.Entity<Lookup>().HasMany(x => x.Connectors).WithOptional().HasForeignKey(x => x.sku);
            modelBuilder.Entity<Lookup>().HasOptional(x => x.Cord);

            // Looking at WebEngine's EUContext class it does not call the base class's OnModelCreating method
            //base.OnModelCreating(modelBuilder);
        }
    }
}