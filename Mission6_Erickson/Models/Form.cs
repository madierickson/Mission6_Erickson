using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;

namespace Mission6_Erickson.Models
{
    public class Form
    {
        
        [Key]
        public int MovieID { get; set; }

        [ForeignKey("CategoryID")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        [Required(ErrorMessage ="Please enter the movie title")]
        public string Title { get; set; }
        public int Year { get; set; }
        [Range(1888,2025)]
        public string Director { get; set; }
        public string Rating { get; set; }
        public bool? Edited { get; set; } 
        public string? LentTo { get; set; } 
        public string? Notes { get; set; } 
    }
}
