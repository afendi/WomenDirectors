using System;
using System.Collections.Generic;

namespace Wbod.Models.DB
{
    public partial class Professionalbodytable
    {
        public Professionalbodytable()
        {
            Directors = new HashSet<Directors>();
        }

        public int Id { get; set; }
        public string Organizationtype { get; set; }

        public ICollection<Directors> Directors { get; set; }
    }
}
