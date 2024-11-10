using RestApplication.Hypermedia;
using RestApplication.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApplication.Data.VO
{
    public class PersonVO : ISupportsHyperMedia
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Address { get; set; }
        
        public string Gender { get; set; }
        public List<HyperMediaLink> Links { get ; set ; } = new List<HyperMediaLink>();
    }
}
