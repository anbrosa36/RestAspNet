using System.ComponentModel.DataAnnotations.Schema;

namespace RestApplication.Model
{
    [Table("Books")]
    public class Book
    {
        [Column("BookId")]
        public int BookId { get; set; }
        
        [Column("Autor")]
        public string Autor { get; set; }
        
        [Column("LaunchDate")]
        public DateTime LaunchDate { get; set; }
        
        [Column("Price")]
        public decimal Price { get; set; }

        [Column("Title")]
        public string Title { get; set; }
        
    }
}
