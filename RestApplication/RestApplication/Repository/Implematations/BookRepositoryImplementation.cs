using RestApplication.Model;
using RestApplication.Model.Context;
using System;

namespace RestApplication.Repository.Implematations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private BancoContext _context;

        public BookRepositoryImplementation(BancoContext context)
        {
            _context = context; 
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }

            return book;
        }

        public void Delete(int id)
        {
            var resulte = _context.Books.SingleOrDefault(b => b.BookId.Equals(id));
            if (resulte != null) 
            {
                try
                {
                    _context.Books.Remove(resulte);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(int id)
        {
            return _context.Books.Any(b => b.BookId.Equals(id));
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindById(int id)
        {
            return _context.Books.SingleOrDefault(b => b.BookId.Equals(id));
        }

        public Book Update(Book book)
        {
            if (!Exists(book.BookId)) return null;
            
            var result = _context.Books.SingleOrDefault(p => p.BookId.Equals(book.BookId));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return book;
        }
    }
}
