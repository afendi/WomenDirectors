using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wbod.Models.DB;

namespace Wbod.Models
{
    public class DirectorAndDirectorshipVM
    {
        public Directors Directors { get; set; }
        public Directorship Directorship { get; set; }

        public DirectorAndDirectorshipVM()
        {

        }
    }
}
