﻿using RestApplication.Data.Converter.Contract;
using RestApplication.Data.VO;
using RestApplication.Model;

namespace RestApplication.Data.Converter.Implementations
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public Person Parse(PersonVO origem)
        {
            if (origem == null) return null;

            return new Person
            {
                Id = origem.Id,
                FirstName = origem.FirstName,
                LastName = origem.LastName,
                Address = origem.Address,
                Gender = origem.Gender,

            };     
        }

        public PersonVO Parse(Person origem)
        {
            if (origem == null) return null;

            return new PersonVO
            {
                Id = origem.Id,
                FirstName = origem.FirstName,
                LastName = origem.LastName,
                Address = origem.Address,
                Gender = origem.Gender,

            };
        }

        public List<Person> Parse(List<PersonVO> origem)
        {
            if (origem == null) return null;

            return origem.Select(item => Parse(item)).ToList();
        }

        public List<PersonVO> Parse(List<Person> origem)
        {
            if (origem == null) return null;

            return origem.Select(item => Parse(item)).ToList();
        }
    }
}
