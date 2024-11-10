using RestApplication.Data.Converter.Contract;
using RestApplication.Data.VO;
using RestApplication.Model;

namespace RestApplication.Data.Converter.Implementations
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO origem)
        {
            if (origem == null) return null;

            return new Book
            {
                Id = origem.Id,
                Autor = origem.Autor,
                LaunchDate= origem.LaunchDate,
                Price= origem.Price,
                Title = origem.Title
            };
        }

        public BookVO Parse(Book origem)
        {
            if (origem == null) return null;

            return new BookVO
            {
                Id = origem.Id,
                Autor = origem.Autor,
                LaunchDate = origem.LaunchDate,
                Price = origem.Price,
                Title = origem.Title
            };
        }

        public List<Book> Parse(List<BookVO> origem)
        {
            if (origem == null) return null;

            return origem.Select(item => Parse(item)).ToList();
        }

        public List<BookVO> Parse(List<Book> origem)
        {
            if (origem == null) return null;

            return origem.Select(item => Parse(item)).ToList();
        }
    }
}
