using Microsoft.EntityFrameworkCore;
using Statements.Domain;

namespace Statements.Application.Interfaces
{
    public interface IStatementDbContext
    {
        DbSet<Statement> Statements { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
