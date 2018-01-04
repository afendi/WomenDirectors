using System;
using System.Collections.Generic;

namespace Wbod.Models.DB
{
    public partial class Directornom
    {
        public Directornom()
        {
            Directorship = new HashSet<Directorship>();
        }

        public int Id { get; set; }
        public string Positiontype { get; set; }

        public ICollection<Directorship> Directorship { get; set; }
    }
}
