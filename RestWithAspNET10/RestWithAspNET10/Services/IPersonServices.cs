using RestWithAspNET10.Model;

namespace RestWithAspNET10.Services
{
    public interface IPersonServices
    {
        List<Person> FindAll();
        Person FindById(long id);
        Person Create(Person person);
        Person Update(Person person);
        void Delete(long id);
    }
}
