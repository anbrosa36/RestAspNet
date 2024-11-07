using RestApplication.Model;
using RestApplication.Model.Context;
using RestApplication.Repository;
using System;

namespace RestApplication.Business.Implematations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;

        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindById(int id)
        {
            return _repository.FindById(id);
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public Person Update(Person person)
        {

            return _repository.Update(person);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
