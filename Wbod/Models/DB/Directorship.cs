using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wbod.Models.DB
{
    public partial class Directorship
    {
        public int Id { get; set; }
        [Display(Name = "CDP 1")]
        public int Cdp1 { get; set; }
        [Display(Name = "CDP 2")]
        public int Cdp2 { get; set; }
        [Display(Name = "Director Audit")]
        public int Daudit { get; set; }
        [Display(Name = "Director Renumeration")]
        public int Drenum { get; set; }
        [Display(Name = "Director Nomination")]
        public int Dnom { get; set; }
        [Required]
        public int Duration { get; set; }
        public int? Directorid { get; set; }
        public int? Companyid { get; set; }
        public int? SessionId { get; set; }

        public Currentdirpositionone Cdp1Navigation { get; set; }
        public Currentdirpositiontwo Cdp2Navigation { get; set; }
        public Companies Company { get; set; }
        public Directoraudit DauditNavigation { get; set; }
        public Directors Director { get; set; }
        public Directornom DnomNavigation { get; set; }
        public Directorrenum DrenumNavigation { get; set; }
        public Sessions Session { get; set; }
    }
}
