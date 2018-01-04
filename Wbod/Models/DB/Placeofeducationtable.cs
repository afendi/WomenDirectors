using System;
using System.Collections.Generic;

namespace Wbod.Models.DB
{
    public partial class Placeofeducationtable
    {
        public Placeofeducationtable()
        {
            Directors = new HashSet<Directors>();
        }

        public int Id { get; set; }
        public string Place { get; set; }

        public ICollection<Directors> Directors { get; set; }
    }
}
