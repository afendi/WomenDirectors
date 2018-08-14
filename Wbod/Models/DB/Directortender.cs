using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wbod.Models.DB
{
    public partial class Directortender
    {
        public Directortender()
        {
            Directorship = new HashSet<Directorship>();
        }

        public int Id { get; set; }
        public string Positiontype { get; set; }

        public ICollection<Directorship> Directorship { get; set; }
    }
}
