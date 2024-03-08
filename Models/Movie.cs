using System.ComponentModel.DataAnnotations;

namespace GroupActivity.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        [MaxLength(63)]
        public string Title { get; set; }
        [Range(1900,2100)]
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }
    }
}
