using Microsoft.EntityFrameworkCore;
using RestWithAspNET10.Context;

namespace RestWithAspNET10.Configurations
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration["MSSQLServerConnection:MSSQLServerConnectionString"];
            if (String.IsNullOrEmpty(connectionString)) 
            {
                throw new ArgumentNullException("ConnectionStrig not found!");
            }            
            
            services.AddDbContext<MSSQLContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });
            return services;
        }
    }
}
