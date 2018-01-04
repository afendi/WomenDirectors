using System;
using System.Collections.Generic;

namespace Wbod.Models.DB
{
    public partial class Companysectors
    {
        public Companysectors()
        {
            Companies = new HashSet<Companies>();
        }

        public int Id { get; set; }
        public string Sectornames { get; set; }

        public ICollection<Companies> Companies { get; set; }
    }
}
