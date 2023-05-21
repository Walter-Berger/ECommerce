namespace AuthService.API.Data;

public class DatabaseContext : IdentityDbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
}
