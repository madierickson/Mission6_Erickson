using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Erickson.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required(ErrorMessage = "Please enter the movie title")]
        public string Title { get; set; }

        [Required]
        [Range(1888, 2100, ErrorMessage = "Year must be 1888 or later")]
        public string Year { get; set; }  // Keeping as string to match the database

        public string? Director { get; set; }
        public string? Rating { get; set; }

        [Required]
        public bool Edited { get; set; }  // Database requires this as int, not bool

        public string? LentTo { get; set; }

        [Required]
        public bool CopiedToPlex { get; set; } // New required field from database

        public string? Notes { get; set; }
    }
}
