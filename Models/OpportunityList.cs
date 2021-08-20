using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models
{
    public class OpportunityList
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Opportunity Center")]
        public string OpportunityCenter { get; set; }

        [Required]
        [DisplayName("Opportunity Title")]
        public string OpportunityTitle { get; set; }
    }
}
