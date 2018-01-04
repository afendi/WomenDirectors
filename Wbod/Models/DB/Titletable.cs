using System;
using System.Collections.Generic;

namespace Wbod.Models.DB
{
    public partial class Titletable
    {
        public Titletable()
        {
            Directors = new HashSet<Directors>();
        }

        public int Id { get; set; }
        public string Titletype { get; set; }

        public ICollection<Directors> Directors { get; set; }
    }
}
