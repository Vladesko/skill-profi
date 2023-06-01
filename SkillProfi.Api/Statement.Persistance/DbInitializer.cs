namespace Statements.Persistance
{
    public static class DbInitializer
    {
        public static void Initialize(StatementDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
