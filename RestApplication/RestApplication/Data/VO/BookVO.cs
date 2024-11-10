using RestApplication.Hypermedia;
using RestApplication.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApplication.Data.VO
{
    public class BookVO : ISupportsHyperMedia
    {
        public int Id { get; set; }

        public string Autor { get; set; }

        
        public DateTime LaunchDate { get; set; }

        
        public decimal Price { get; set; }

        
        public string Title { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
