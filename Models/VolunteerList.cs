using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models
{
    public class VolunteerList
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [DisplayName("Opportunity Center Preference(s)")]
        public string OpportunityCenterPreference { get; set; }

        [DisplayName("Skills/Interests")]
        public string SkillsInterests { get; set; }

        [Required]
        [DisplayName("Availability. Please enter in days of the week you are available. M-Monday T-Tuesday W-Wednesday R-Thursday F-Friday Sa-Saturday Su-Sunday")]
        public string Availability { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        public string Phonenumber { get; set; }

        [Required]
        public string Email { get; set; }

        [DisplayName("Educational Background")]
        public string EducationBackground { get; set; }

        [Required]
        [DisplayName("Current Licenses. Please type in N/A if none exists")]
        public string License { get; set; }

        [Required]
        [DisplayName("Emergency Contact Full Name")]
        public string EmergencyContactName { get; set; }

        [Required]
        [DisplayName("Emergency Contact Number")]
        public string EmergencyContactNumber { get; set; }

        [Required]
        [DisplayName("Emergency Contact Email")]
        public string EmergencyContactEmail { get; set; }

        [Required]
        [DisplayName("Emergency Contact Address")]
        public string EmergencyContactAddress { get; set; }

        [Required]
        [DisplayName("Is volunteer's driver license on file? Please check the box for yes")]
        public bool DriversLicenseAvailable { get; set; }

        [Required]
        [DisplayName("Is volunteer's social security on file? Please check the box for yes")]
        public bool SocialSecurityAvailable { get; set; }

        [Required]
        [DisplayName("Approval Status")]
        public string ApprovalStatus { get; set; }
    }
}
