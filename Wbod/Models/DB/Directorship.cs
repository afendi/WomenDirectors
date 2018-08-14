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
        [Display(Name = "Audit Committee")]
        public int Daudit { get; set; }
        [Display(Name = "Renumeration Committee")]
        public int Drenum { get; set; }
        [Display(Name = "Nomination Committee")]
        public int Dnom { get; set; }
        [Display(Name = "ESOS Committee")]
        public int Desos { get; set; }
        [Display(Name = "Risk Mngmnt Committee")]
        public int Drisk { get; set; }
        [Display(Name = "Executive Committee")]
        public int Dexec { get; set; }
        [Display(Name = "Tender Committee")]
        public int Dtender { get; set; }
        [Display(Name = "Finance & Inv Committee")]
        public int Dfinance { get; set; }
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
        public Directoresos DesosNavigation { get; set; }
        public Directorrisk DriskNavigation { get; set; }
        public Directorexec DexecNavigation { get; set; }
        public Directortender DtenderNavigation { get; set; }
        public Directorfinance DfinanceNavigation { get; set; }
        public Sessions Session { get; set; }
    }
}
