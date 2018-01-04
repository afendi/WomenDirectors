using System;
using System.Collections.Generic;

namespace Wbod.Models.DB
{
    public partial class Fieldofstudiestable
    {
        public Fieldofstudiestable()
        {
            Directors = new HashSet<Directors>();
        }

        public int Id { get; set; }
        public string Fieldname { get; set; }

        public ICollection<Directors> Directors { get; set; }
    }
}
