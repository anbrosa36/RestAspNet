using RestApplication.Data.VO;
using RestApplication.Model;

namespace RestApplication.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindById(int id);
        List<BookVO> FindAll();
        BookVO Update(BookVO book);
        void Delete(int id);
    }
}
