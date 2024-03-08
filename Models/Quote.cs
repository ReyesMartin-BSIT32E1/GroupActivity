using System.ComponentModel.DataAnnotations;

namespace GroupActivity.Models
{
    public class Quote
    {
        [Key]
        public int QuoteId { get; set; }
        [Required]
        public string QuoteText { get; set; }
        public string Author { get; set;}
    }
}
