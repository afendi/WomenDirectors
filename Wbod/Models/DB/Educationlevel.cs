using System;
using System.Collections.Generic;

namespace Wbod.Models.DB
{
    public partial class Educationlevel
    {
        public Educationlevel()
        {
            Directors = new HashSet<Directors>();
        }

        public int Id { get; set; }
        public string Edulevel { get; set; }

        public ICollection<Directors> Directors { get; set; }
    }
}
