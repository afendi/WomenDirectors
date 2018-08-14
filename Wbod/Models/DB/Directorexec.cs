using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wbod.Models.DB
{
    public partial class Directorexec
    {
        public Directorexec()
        {
            Directorship = new HashSet<Directorship>();
        }

        public int Id { get; set; }
        public string Positiontype { get; set; }

        public ICollection<Directorship> Directorship { get; set; }
    }
}
