using System;
using System.Collections.Generic;

namespace Wbod.Models.DB
{
    public partial class Ethnicitytable
    {
        public Ethnicitytable()
        {
            Directors = new HashSet<Directors>();
        }

        public int Id { get; set; }
        public string Race { get; set; }

        public ICollection<Directors> Directors { get; set; }
    }
}
