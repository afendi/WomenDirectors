using System;
using System.Collections.Generic;

namespace Wbod.Models.DB
{
    public partial class Glcstatus
    {
        public Glcstatus()
        {
            Companies = new HashSet<Companies>();
        }

        public int Id { get; set; }
        public string Isglcstatus { get; set; }

        public ICollection<Companies> Companies { get; set; }
    }
}
