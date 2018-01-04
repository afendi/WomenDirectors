using System;
using System.Collections.Generic;

namespace Wbod.Models.DB
{
    public partial class Gendertable
    {
        public Gendertable()
        {
            Directors = new HashSet<Directors>();
        }

        public int Id { get; set; }
        public string Gendertype { get; set; }

        public ICollection<Directors> Directors { get; set; }
    }
}
