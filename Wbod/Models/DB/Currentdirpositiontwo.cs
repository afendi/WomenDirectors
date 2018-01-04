using System;
using System.Collections.Generic;

namespace Wbod.Models.DB
{
    public partial class Currentdirpositiontwo
    {
        public Currentdirpositiontwo()
        {
            Directorship = new HashSet<Directorship>();
        }

        public int Id { get; set; }
        public string Positiontype { get; set; }

        public ICollection<Directorship> Directorship { get; set; }
    }
}
