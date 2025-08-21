using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SessionService.Context
{
    public class SessionServiceDbContextFactory : IDesignTimeDbContextFactory<SessionServiceDbContext>
    {
        public SessionServiceDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var builder = new DbContextOptionsBuilder<SessionServiceDbContext>();
            builder.UseSqlServer(connectionString);

            return new SessionServiceDbContext(builder.Options);
        }
    }
}
