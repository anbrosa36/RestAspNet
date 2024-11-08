﻿using RestApplication.Model;

namespace RestApplication.Business
{
    public interface IPersonBusiness
    {
        Person Create (Person person);
        Person FindById(int id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(int id);
    }
}
