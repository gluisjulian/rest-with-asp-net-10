using Microsoft.EntityFrameworkCore;
using RestWithAspNET10.Model;

namespace RestWithAspNET10.Context
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options) : base(options)
        {
            
        }

        public DbSet<Person> Persons { get; set; }
    }
}
