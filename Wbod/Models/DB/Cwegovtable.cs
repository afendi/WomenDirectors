﻿using System;
using System.Collections.Generic;

namespace Wbod.Models.DB
{
    public partial class Cwegovtable
    {
        public Cwegovtable()
        {
            Directors = new HashSet<Directors>();
        }

        public int Id { get; set; }
        public string Positiontype { get; set; }

        public ICollection<Directors> Directors { get; set; }
    }
}
