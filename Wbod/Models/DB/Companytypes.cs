using System;
using System.Collections.Generic;

namespace Wbod.Models.DB
{
    public partial class Companytypes
    {
        public Companytypes()
        {
            Companies = new HashSet<Companies>();
        }

        public int Id { get; set; }
        public string Typenames { get; set; }

        public ICollection<Companies> Companies { get; set; }
    }
}
