﻿using System;
using System.Collections.Generic;

namespace Wbod.Models.DB
{
    public partial class Cwenonplctable
    {
        public Cwenonplctable()
        {
            Directors = new HashSet<Directors>();
        }

        public int Id { get; set; }
        public string Positiontype { get; set; }

        public ICollection<Directors> Directors { get; set; }
    }
}
