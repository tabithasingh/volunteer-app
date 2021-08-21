using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AuthSystem.Models
{

    [Table("Volunteer")]
    public class Volunteer
    {

        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Username { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string PasswordHash { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string PreferredCenters { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Skills { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Availability { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Address { get; set; }

        [Column(TypeName = "int")]
        public int Phone { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Education { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Licenses { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string EmergencyName { get; set; }

        [Column(TypeName = "int")]
        public int EmergencyPhone { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string EmergencyEmail { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string EmergencyAddress { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string DriverLicense { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string SocialSecurityCard { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ApprovalStatus { get; set; }

    }
}