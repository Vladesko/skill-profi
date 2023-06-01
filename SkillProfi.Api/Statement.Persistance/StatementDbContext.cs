using Microsoft.EntityFrameworkCore;
using Statements.Application.Interfaces;
using Statements.Domain;
using Statements.Persistance.EntityTypeConfiguration;

namespace Statements.Persistance
{
    public class StatementDbContext : DbContext, IStatementDbContext
    {
        public DbSet<Statement> Statements { get; set; }
        public StatementDbContext(DbContextOptions<StatementDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StatementConfiguration()); //Implementing the previously created configuration 
            base.OnModelCreating(builder);
        }
    }
}
