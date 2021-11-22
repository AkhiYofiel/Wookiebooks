using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WookieBooks.Models
{
    public class Book
    {
      
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        
        public string? Description { get; set; }
        [Required]
        public string Author { get; set; }
       
        public string? CoverImage { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
