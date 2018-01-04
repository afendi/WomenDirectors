using System;
using System.Collections.Generic;

namespace Wbod.Models.DB
{
    public partial class Dshipraw
    {
        public int Id { get; set; }
        public string Dirname { get; set; }
        public int Cdp1 { get; set; }
        public int Cdp2 { get; set; }
        public int Daudit { get; set; }
        public int Drenum { get; set; }
        public int Dnom { get; set; }
        public int Duration { get; set; }
        public string Coname { get; set; }
        public int? Directorid { get; set; }
        public int? Companyid { get; set; }
        public int? SessionId { get; set; }
    }
}
