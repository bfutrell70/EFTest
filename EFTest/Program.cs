using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFTest.Models;
using System.Configuration;

namespace EFTest
{
    class Program
    {
        private static EFTestContext _context;

        static void Main(string[] args)
        {
            var connectionString =Properties.Settings.Default.EFTestConnectionString;
            _context = new EFTestContext(connectionString);

            AddTestData();
        }

        static void AddTestData()
        {
            var plugs = _context.Plugs;
            Console.WriteLine("Checking Plugs...");
            if (plugs.Count() == 0)
            {
                plugs.Add(new Plug { Name = "Plug 1", sku = "1" });
                plugs.Add(new Plug { Name = "Plug 2", sku = "2" });
                plugs.Add(new Plug { Name = "Plug 2 Angled Left", sku = "2" });
                plugs.Add(new Plug { Name = "Plug 3", sku = "3" });
                plugs.Add(new Plug { Name = "Plug 4", sku = "4" });
                Console.WriteLine("Added Plug data");
                _context.SaveChanges();
            }

            var connectors = _context.Connectors;
            Console.WriteLine("Checking Connectors...");
            if (connectors.Count() == 0)
            {
                connectors.Add(new Connector { Name = "Connector 5", sku = "5" });
                connectors.Add(new Connector { Name = "Connector 6", sku = "6" });
                connectors.Add(new Connector { Name = "Connector 7 Straight", sku = "7" });
                connectors.Add(new Connector { Name = "Connector 7 Angled Right", sku = "7" });
                connectors.Add(new Connector { Name = "Connector 8", sku = "8" });
                Console.WriteLine("Added Connector data");
                _context.SaveChanges();
            }

            var cords = _context.Cords;
            Console.WriteLine("Checking Cords...");
            if (cords.Count() == 0)
            {
                cords.Add(new Cord { Name = "Cord 9", sku = "9" });
                cords.Add(new Cord { Name = "Cord 10", sku = "10" });
                cords.Add(new Cord { Name = "Cord 11", sku = "11" });
                cords.Add(new Cord { Name = "Cord 12", sku = "12" });
                cords.Add(new Cord { Name = "Cord 13", sku = "13" });
                Console.WriteLine("Added Cord data");
                _context.SaveChanges();
            }

            var lookups = _context.Lookups;
            Console.WriteLine("Checking Lookups....");
            if (lookups.Count() == 0)
            {
                lookups.Add(new Lookup { sku = "1", Price = 5.00m, Weight = 1.0m });
                lookups.Add(new Lookup { sku = "2", Price = 5.50m, Weight = 1.1m });
                lookups.Add(new Lookup { sku = "3", Price = 6.00m, Weight = 1.2m });
                lookups.Add(new Lookup { sku = "4", Price = 6.50m, Weight = 1.3m });
                lookups.Add(new Lookup { sku = "6", Price = 7.00m, Weight = 1.4m });
                lookups.Add(new Lookup { sku = "7", Price = 8.00m, Weight = 1.5m });
                lookups.Add(new Lookup { sku = "8", Price = 8.50m, Weight = 1.6m });
                lookups.Add(new Lookup { sku = "9", Price = 9.00m, Weight = 1.7m });
                lookups.Add(new Lookup { sku = "11", Price = 10.00m, Weight = 1.8m });
                lookups.Add(new Lookup { sku = "13", Price = 1.20m, Weight = 1.9m });
                Console.WriteLine("Added Lookup data");
                _context.SaveChanges();
            }
        }


    }
}
