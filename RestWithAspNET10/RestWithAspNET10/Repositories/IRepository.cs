using RestWithAspNET10.Model;
using RestWithAspNET10.Model.Base;

namespace RestWithAspNET10.Repositories
{
    public interface IRepository<T> where T : BaseEntity //Precisa estender BaseEntity para funcionar
    {
        List<T> FindAll();
        T FindById(long id);
        T Create(T item);
        T Update(T item);
        void Delete(long id);
        bool Exists(long id);
    }
}
