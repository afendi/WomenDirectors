using System;
using System.Collections.Generic;

namespace Wbod.Models.DB
{
    public partial class Companylists
    {
        public Companylists()
        {
            Companies = new HashSet<Companies>();
        }

        public int Id { get; set; }
        public string Companylistsname { get; set; }

        public ICollection<Companies> Companies { get; set; }
    }
}
