using Microsoft.EntityFrameworkCore;
using User.Domain.Entities;

namespace User.Infra.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
    }
}

