using EvolveDb;
using Microsoft.Data.SqlClient;
using Serilog;

namespace RestWithAspNET10.Configurations
{
    public static class EvolveConfig
    {
        public static IServiceCollection AddEvolveConfiguration(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            if(environment.IsDevelopment())
            {
                var connectionString = configuration["MSSQLServerConnection:MSSQLServerConnectionString"];
                if (String.IsNullOrEmpty(connectionString))
                {
                    throw new ArgumentNullException("ConnectionStrig not found!");
                }

                try
                {
                    using var evolveConnection = new SqlConnection(connectionString);
                    var evolve = new Evolve(evolveConnection, msg => Log.Information(msg))
                    {
                        Locations = new List<string> { "db/migrations", "db/dataset" },
                        IsEraseDisabled = true
                    };
                    evolve.Migrate();
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "An error has occurred while migrating the database.");
                }
            }

            return services;
        }
    }
}
