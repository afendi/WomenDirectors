using System;
using System.Collections.Generic;

namespace Wbod.Models.DB
{
    public partial class Currentdirpositionone
    {
        public Currentdirpositionone()
        {
            Directorship = new HashSet<Directorship>();
        }

        public int Id { get; set; }
        public string Positiontype { get; set; }

        public ICollection<Directorship> Directorship { get; set; }
    }
}
