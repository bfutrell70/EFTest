using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest.Models
{
    public class Connector
    {
        [Key]
        public int uid { get; set; }

        public string Name { get; set; }

        public string sku { get; set; }

        // each connector should only match one lookup record.
        public Lookup Lookup { get; set; }
    }
}
