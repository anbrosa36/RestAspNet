using RestApplication.Model;
using RestApplication.Model.Context;

namespace RestApplication.Services.Implematations
{
    public class PersonServiceImplementation : IPersonService
    {
        private BancoContext _context;

        public PersonServiceImplementation(BancoContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            //Logica de exclusão
        }

        public List<Person> FindAll()
        {
          return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Andre",
                LastName ="Sousa",
                Address = "Mogi das Cruzes - SP",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Person Name" + i,
                LastName = "Person LastName" + i,
                Address = "Some Address" + i ,
                Gender = "Male"
            };
        }

        
    }
}
