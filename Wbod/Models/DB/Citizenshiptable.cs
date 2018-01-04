using System;
using System.Collections.Generic;

namespace Wbod.Models.DB
{
    public partial class Citizenshiptable
    {
        public Citizenshiptable()
        {
            Directors = new HashSet<Directors>();
        }

        public int Id { get; set; }
        public string Citizentype { get; set; }

        public ICollection<Directors> Directors { get; set; }
    }
}
