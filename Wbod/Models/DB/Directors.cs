using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Wbod.Models.DB
{
    public partial class Directors
    {
        public Directors()
        {
            Directorship = new HashSet<Directorship>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Gender { get; set; }
        public string Info { get; set; }
        public string Photo { get; set; }
        public int? Age { get; set; }
        public int? Citizenship { get; set; }
        public int? Ethnicity { get; set; }
        [DisplayName("Education Level")]
        public int? Educationlevel { get; set; }
        [DisplayName("Place of Education")]
        public int? Placeofeducation { get; set; }
        [DisplayName("Field of Education")]
        public int? Fieldofstudies { get; set; }
        [DisplayName("Title/Darjah")]
        public int? Titledarjah { get; set; }
        [DisplayName("Family Ties 1")]
        public int? Familytiesone { get; set; }
        [DisplayName("Family Ties 2")]
        public int? Familytiestwo { get; set; }
        [DisplayName("Professional Body")]
        public int? Professionalbody { get; set; }
        [DisplayName("Voluntary Body")]
        public int? Voluntarybody { get; set; }
        [DisplayName("CWE PLC")]
        public int? Cweplc { get; set; }
        [DisplayName("CWE Non-PLC")]
        public int? Cwenonplc { get; set; }
        [DisplayName("CWE Govt")]
        public int? Cwegovt { get; set; }
        [DisplayName("CWE Private Academic")]
        public int? Cweacademic { get; set; }
        [DisplayName("Year of Birth")]
        public int? Yearofbirth { get; set; }
        [NotMapped]
        [DisplayName("Photo")]
        public IFormFile MyImage { set; get; }

        public Citizenshiptable CitizenshipNavigation { get; set; }
        public Cweacadtable CweacademicNavigation { get; set; }
        public Cwegovtable CwegovtNavigation { get; set; }
        public Cwenonplctable CwenonplcNavigation { get; set; }
        public Cweplctable CweplcNavigation { get; set; }
        public Educationlevel EducationlevelNavigation { get; set; }
        public Ethnicitytable EthnicityNavigation { get; set; }
        public Familytiesonetable FamilytiesoneNavigation { get; set; }
        public Familytiestwotable FamilytiestwoNavigation { get; set; }
        public Fieldofstudiestable FieldofstudiesNavigation { get; set; }
        public Gendertable GenderNavigation { get; set; }
        public Placeofeducationtable PlaceofeducationNavigation { get; set; }
        public Professionalbodytable ProfessionalbodyNavigation { get; set; }
        public Titletable TitledarjahNavigation { get; set; }
        public Voluntarybodytable VoluntarybodyNavigation { get; set; }
        public ICollection<Directorship> Directorship { get; set; }
    }
}
