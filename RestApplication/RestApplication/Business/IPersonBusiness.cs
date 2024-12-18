﻿using RestApplication.Data.VO;
using RestApplication.Model;

namespace RestApplication.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create (PersonVO person);
        PersonVO FindById(int id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(int id);
    }
}
