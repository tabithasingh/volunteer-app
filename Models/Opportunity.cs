using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AuthSystem.Models
{

    [Table("Opportunity")]
    public class Opportunity
    {
        
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; }

    }

}