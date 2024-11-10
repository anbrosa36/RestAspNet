using System.ComponentModel.DataAnnotations.Schema;

namespace RestApplication.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
    }
}
