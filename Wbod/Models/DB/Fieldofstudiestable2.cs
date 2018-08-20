using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wbod.Models.DB
{
    public partial class Fieldofstudiestable2
    {
        public Fieldofstudiestable2()
        {
            Directors = new HashSet<Directors>();
        }

        public int Id { get; set; }
        public string Fieldname { get; set; }

        public ICollection<Directors> Directors { get; set; }
    }
}
