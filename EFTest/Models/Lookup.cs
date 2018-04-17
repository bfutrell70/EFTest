using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest.Models
{
    public class Lookup
    {
        public string sku { get; set; }

        public decimal Price { get; set; }

        public decimal Weight { get; set; }

        // a collection of plugs since a single sku can have multiple records (straight and angled)
        // there is also a possiblity that a plug sku isn't in the lookup table
        public virtual ICollection<Plug> Plugs { get; set; }

        // a collection of connectors since a single sku can have multiple records (straight and angled)
        // there is also a possiblity that a connector sku isn't in the lookup table
        public virtual ICollection<Connector> Connectors { get; set; }

        // a cord sku should only appear once.
        // there is also a possiblity that a cord sku isn't in the lookup table
        public virtual Cord Cord { get; set; }
        
    }
}
