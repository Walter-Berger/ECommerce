namespace IdentityService.Data;

public class DatabaseContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
}
