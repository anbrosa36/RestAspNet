using RestApplication.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApplication.Model
{
    [Table("Persons")]
    public class Person : BaseEntity
    {
        
        [Column("FirstName")]
        public string FirstName { get; set; }
        [Column("LastName")]
        public string LastName { get; set; }
        [Column("Address")]
        public string Address { get; set; }
        [Column("Gender")]
        public string Gender { get; set; }
    }
}
