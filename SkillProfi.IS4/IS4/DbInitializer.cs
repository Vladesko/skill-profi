using IS4.Entities;

namespace IS4
{
    public static class DbInitializer
    {
        public static void Initialize(AuthorizeDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
