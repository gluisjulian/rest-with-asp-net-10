using RestWithAspNET10.Context;
using RestWithAspNET10.Model;

namespace RestWithAspNET10.Repositories.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly MSSQLContext _context;

        public BookRepository(MSSQLContext context)
        {
            _context = context;
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindById(long id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return null;

            return book;
        }

        public Book Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public Book Update(Book book)
        {
            var existingBook = _context.Books.Find(book.Id);
            if (existingBook == null) return null;

            _context.Entry(existingBook).CurrentValues.SetValues(book);
            _context.SaveChanges();
            return book;
        }

        public void Delete(long id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            if (book != null)

                _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
