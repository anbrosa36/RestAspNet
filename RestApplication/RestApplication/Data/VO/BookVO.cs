using System.ComponentModel.DataAnnotations.Schema;

namespace RestApplication.Data.VO
{
    public class BookVO
    {
        public int Id { get; set; }

        public string Autor { get; set; }

        
        public DateTime LaunchDate { get; set; }

        
        public decimal Price { get; set; }

        
        public string Title { get; set; }
    }
}
