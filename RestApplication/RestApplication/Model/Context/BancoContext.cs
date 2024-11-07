using Microsoft.EntityFrameworkCore;

namespace RestApplication.Model.Context
{
    public class BancoContext : DbContext
    {
        public BancoContext()
        {

        }
        public BancoContext(DbContextOptions<BancoContext> options): base(options) { }
        
        public DbSet<Person>Persons { get; set; }
    }
}
