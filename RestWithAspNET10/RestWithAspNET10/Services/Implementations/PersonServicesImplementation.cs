using RestWithAspNET10.Context;
using RestWithAspNET10.Model;

namespace RestWithAspNET10.Services.Implementations
{
    public class PersonServicesImplementation : IPersonServices
    {
        private readonly MSSQLContext _context;

        public PersonServicesImplementation(MSSQLContext context)
        {
            _context = context;
        }


        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            var person = _context.Persons.Find(id);
            if (person == null) return null;

            return person;
        }

        public Person Create(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
            return person;
        }

        public Person Update(Person person)
        {
            var existingPerson = _context.Persons.Find(person.Id);
            if (existingPerson == null) return null;

            _context.Entry(existingPerson).CurrentValues.SetValues(person);
            _context.SaveChanges();
            return person;
        }

        public void Delete(long id)
        {
            var person = _context.Persons.FirstOrDefault(x => x.Id == id);
            if (person != null)

            _context.Persons.Remove(person);
            _context.SaveChanges();
        }
    }
}
