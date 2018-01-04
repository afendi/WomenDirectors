using System;
using System.Collections.Generic;

namespace Wbod.Models.DB
{
    public partial class Directorrenum
    {
        public Directorrenum()
        {
            Directorship = new HashSet<Directorship>();
        }

        public int Id { get; set; }
        public string Positiontype { get; set; }

        public ICollection<Directorship> Directorship { get; set; }
    }
}
