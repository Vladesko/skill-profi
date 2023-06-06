using IS4.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IS4.Entities
{
    public class AuthorizeDbContext : IdentityDbContext<AppUser>
    {
        public AuthorizeDbContext(DbContextOptions<AuthorizeDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
