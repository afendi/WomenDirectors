﻿using System;
using System.Collections.Generic;

namespace Wbod.Models.DB
{
    public partial class Familytiestwotable
    {
        public Familytiestwotable()
        {
            Directors = new HashSet<Directors>();
        }

        public int Id { get; set; }
        public string Tiestype { get; set; }

        public ICollection<Directors> Directors { get; set; }
    }
}
