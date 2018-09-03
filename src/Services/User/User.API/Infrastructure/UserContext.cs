using Microsoft.EntityFrameworkCore;

namespace User.API.Infrastructure
{
    public class UserContext: DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        public DbSet<User.API.Models.User> Users { get; set; }
    }
}
