using System;
using System.Collections.Generic;

namespace Wbod.Models.DB
{
    public partial class Sessions
    {
        public Sessions()
        {
            Directorship = new HashSet<Directorship>();
        }

        public int Id { get; set; }
        public string Sessionyear { get; set; }

        public ICollection<Directorship> Directorship { get; set; }
    }
}
