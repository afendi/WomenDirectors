using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Wbod.Models
{
    public class SimpleCompany
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
    }

    public class SimpleDirectorship
    {
        public int Id { get; set; }
        [Display(Name = "Current Directorship Position 1")]
        public string CDP1 { get; set; }
        [Display(Name = "Current Directorship Position 2")]
        public string CDP2 { get; set; }
        [Display(Name = "Director Audit")]
        public string DirectorAudit { get; set; }
        [Display(Name = "Director Renumeration")]
        public string DirectorRenumeration { get; set; }
        [Display(Name = "Director Nomination")]
        public string DirectorNomination { get; set; }
        public int Duration { get; set; }
        public int? Directorid { get; set; }
        public int? Companyid { get; set; }
        public int? SessionId { get; set; }
        public string Company { get; set; }
        public string DirectorName { get; set; }
        public string Year { get; set; }
    }

}
