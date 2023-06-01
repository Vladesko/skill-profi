using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Statements.Domain;

namespace Statements.Persistance.EntityTypeConfiguration
{
    /// <summary>
    /// In this class you can add a new configuration for work with db and EF
    /// </summary>
    public class StatementConfiguration : IEntityTypeConfiguration<Statement>
    {
        public void Configure(EntityTypeBuilder<Statement> builder)
        {
            builder.HasKey(statement => statement.Id);
            builder.HasIndex(statement => statement.Id).IsUnique();
        }
    }
}
