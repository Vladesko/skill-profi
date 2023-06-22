namespace Statements.Tests.Common
{
    public class StatementContextFactory
    {
        private const string GUIDVALUE = "5594F4EA-A06F-4FD4-A456-07A909872C1F"; 
        public static Guid StatementIdForDelete = Guid.Parse($"{GUIDVALUE}");
        public static Guid StatementIdForUpdate = Guid.Parse($"{GUIDVALUE}");
        public static Guid StatementForGetStatement = Guid.Parse($"{GUIDVALUE}");


        public static StatementDbContext Create()
        {
            var options = new DbContextOptionsBuilder<StatementDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var context = new StatementDbContext(options);
            context.Database.EnsureCreated();

            context = AddStatements(context);

            return context;
        }
        private static StatementDbContext AddStatements(StatementDbContext context)
        {
            context.Statements.AddRange(
                new Statement
                {
                    Created = DateTime.Now,
                    Description = "Desc1",
                    Title = "Title1",
                    Email = "email1",
                    Name = "Name1",
                    Statatus = Statement.State.Check,
                    Updated = null,
                    Id = Guid.Parse($"{GUIDVALUE}"),
                },
                new Statement
                {
                    Created = DateTime.Now,
                    Description = "Desc2",
                    Title = "Title2",
                    Email = "email2",
                    Name = "Name2",
                    Statatus = Statement.State.Check,
                    Updated = null,
                    Id = Guid.Parse("EB09D3CE-1492-4D6E-9519-8FF85FD1F3DA"),
                },
                new Statement
                {
                    Created = DateTime.Now,
                    Description = "Desc3",
                    Title = "Title3",
                    Email = "email3",
                    Name = "Name3",
                    Statatus = Statement.State.Check,
                    Updated = null,
                    Id = Guid.Parse("1993B5FA-0071-437A-8E47-7EB6C1C4456A"),
                }
                );

            context.SaveChanges();
            return context;
        }
        public static void Destroy(StatementDbContext context)
        {
            context.Database.EnsureCreated();
            context.Dispose();
        }
    }
}
