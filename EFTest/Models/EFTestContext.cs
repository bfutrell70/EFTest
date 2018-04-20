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

            //a bidirectional one-to-one-or-zero with cascade
            //modelBuilder.Entity<Project>().HasOptional(x => x.Detail)
            //.WithRequired(x => x.Project).WillCascadeOnDelete(true);

            // plugs
            // plug has optional Lookup object
            // Lookup object has 0 or more Plug objects (straight/angled)
            modelBuilder.Entity<Plug>().ToTable("Plugs").HasKey(x => x.uid).
                HasOptional(x => x.Lookup).
                WithMany(x => x.Plugs);


            // connectors
            // connector has optional Lookup object
            // Lookup object has 0 or more Connector objects (straight/angled)
            modelBuilder.Entity<Connector>().ToTable("Connectors").HasKey(x => x.uid).
                HasOptional(x => x.Lookup).
                WithMany(x => x.Connectors);


            // cords
            modelBuilder.Entity<Cord>().ToTable("Cords").HasKey(x => x.uid).
                HasOptional(x => x.Lookup).
                WithOptionalDependent(x => x.Cord);


            // lookups
            modelBuilder.Entity<Lookup>().ToTable("Lookups").HasKey(x => x.sku);
        }
    }
}