using MediatR;
using Statements.Application.Interfaces;
using Statements.Domain;

namespace Statements.Application.Statements.Commands.CreateStatement
{
    public class CreateStatementCommandHandler : IRequestHandler<CreateStatementCommand, Guid>
    {
        private readonly IStatementDbContext _context;
        public CreateStatementCommandHandler(IStatementDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateStatementCommand request, CancellationToken cancellationToken)
        {
            Statement statement = new Statement()
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Name = request.Name,
                Email = request.Email,
                Description = request.Description,
                Created = DateTime.Now,
                Statatus = Statement.State.Check,
                Updated = null
            };

            await _context.Statements.AddAsync(statement, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return statement.Id;
        }
    }
}
