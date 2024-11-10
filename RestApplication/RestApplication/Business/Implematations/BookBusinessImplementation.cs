using NuGet.Protocol.Core.Types;
using RestApplication.Data.Converter.Implementations;
using RestApplication.Data.VO;
using RestApplication.Model;
using RestApplication.Repository;
using System;

namespace RestApplication.Business.Implematations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;

        private readonly BookConverter _converter;

        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public BookVO Create(BookVO book)
        {
            var personEntity = _converter.Parse(book);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }


        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public BookVO FindById(int id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public BookVO Update(BookVO book)
        {
            var personEntity = _converter.Parse(book);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }
    }
}
