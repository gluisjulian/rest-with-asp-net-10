using RestWithAspNET10.Model;

namespace RestWithAspNET10.Services.Implementations
{
    public class PersonServicesImplementation : IPersonServices
    {
        public List<Person> FindAll()
        {
            var listaPerson = new List<Person>();

            var person1 = new Person
            {
                Id = 1,
                FirstName = "Gabriel",
                LastName = "Julian",
                Gender = "Male",
                Address = "Rua Teste, 123"
            };
            listaPerson.Add(person1);

            var person2 = new Person
            {
                Id = 2,
                FirstName = "Teste",
                LastName = "Teste",
                Gender = "Male",
                Address = "123 Street"
            };

            listaPerson.Add(person2);

            return listaPerson;
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Gabriel",
                LastName = "Julian",
                Gender = "Male",
                Address = "Rua Teste, 123"
            };
        }

        public Person Create(Person person)
        {
            return person;
        }

        public Person Update(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
