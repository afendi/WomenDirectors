using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wbod.Models.DB
{
    public partial class Companies
    {
        public Companies()
        {
            Directorship = new HashSet<Directorship>();
        }

        public int Id { get; set; }
        [Display(Name = "Company Name")]
        [Required]
        public string Companyname { get; set; }
        [Display(Name = "GLC Status")]
        public int? Isglc { get; set; }
        [Display(Name = "Company Sector")]
        public int? Companysector { get; set; }
        [Display(Name = "Company Type")]
        public int? Companytype { get; set; }
        [Display(Name = "Company List")]
        public int? Companylist { get; set; }
        [Display(Name = "Number of Boardmembers")]
        [Required]
        public int? Companyboardsize { get; set; }
        [Display(Name = "Is Active?")]
        public bool Companyisactive { get; set; }

        public Companylists CompanylistNavigation { get; set; }
        public Companysectors CompanysectorNavigation { get; set; }
        public Companytypes CompanytypeNavigation { get; set; }
        public Glcstatus IsglcNavigation { get; set; }
        public ICollection<Directorship> Directorship { get; set; }
    }
}
