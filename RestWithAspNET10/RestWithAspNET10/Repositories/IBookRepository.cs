using RestWithAspNET10.Model;

namespace RestWithAspNET10.Repositories
{
    public interface IBookRepository
    {
        List<Book> FindAll();
        Book FindById(long id);
        Book Create(Book person);
        Book Update(Book person);
        void Delete(long id);
    }
}
