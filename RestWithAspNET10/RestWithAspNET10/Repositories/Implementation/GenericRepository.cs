using Microsoft.EntityFrameworkCore;
using RestWithAspNET10.Context;
using RestWithAspNET10.Model.Base;

namespace RestWithAspNET10.Repositories.Implementation
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MSSQLContext _context;
        private DbSet<T> _dataset;

        public GenericRepository(MSSQLContext context)
        {
            _context = context;
            _dataset = context.Set<T>();
        }

        public List<T> FindAll()
        {
            return _dataset.ToList();
        }

        public T FindById(long id)
        {
            return _dataset.Find(id);
        }

        public T Create(T item)
        {
            _dataset.Add(item);
            _context.SaveChanges();
            return item;
        }

        public T Update(T item)
        {
            var existingItem = _dataset.Find(item.Id);
            if (existingItem == null) return null;

            _context.Entry(existingItem).CurrentValues.SetValues(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(long id)
        {
            var item = _dataset.FirstOrDefault(x => x.Id == id);
            if (item != null)

            _dataset.Remove(item);
            _context.SaveChanges();
        }

        public bool Exists(long id)
        {
            return _dataset.Any(x => x.Id == id);
        }        

    }
}
