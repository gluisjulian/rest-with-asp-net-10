using RestWithAspNET10.Model;

namespace RestWithAspNET10.Services
{
    public interface IBookService
    {
        List<Book> FindAll();
        Book FindById(long id);
        Book Create(Book book);
        Book Update(Book book);
        void Delete(long id);
    }
}
