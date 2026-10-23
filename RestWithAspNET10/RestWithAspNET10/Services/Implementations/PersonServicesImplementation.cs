using RestWithAspNET10.Model;
using RestWithAspNET10.Repositories;

namespace RestWithAspNET10.Services.Implementations
{
    public class PersonServicesImplementation : IPersonServices
    {
        private readonly IRepository<Person> _repository;

        public PersonServicesImplementation(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
