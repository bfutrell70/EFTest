using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest.Models
{
    public class Plug
    {
        [Key]
        public int uid { get; set; }

        public string Name { get; set; }

        public string sku { get; set; }

        // each plug should only match one lookup record.
        // there may be the possibility that there isn't a corresponding Lookup object for the plug.
        public virtual Lookup Lookup { get; set; }

    }
}
