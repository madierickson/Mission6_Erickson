using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Erickson.Models
{
    public class Form
    {
        //Here is a change
        [Key]
        public int MovieID { get; set; }

        [ForeignKey("CategoryID")]
        public string CategoryID { get; set; }
        public Category Category { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public bool? Edited { get; set; } 
        public string? LentTo { get; set; } 
        public string? Notes { get; set; } 
    }
}
