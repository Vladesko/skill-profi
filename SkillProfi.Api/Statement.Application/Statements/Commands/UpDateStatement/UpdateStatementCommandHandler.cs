using MediatR;
using Microsoft.EntityFrameworkCore;
using Statements.Application.Common.Exceptions;
using Statements.Application.Interfaces;
using Statements.Domain;

namespace Statements.Application.Statements.Commands.UpDateStatement
{
    public class UpDateStatementCommandHandler : IRequestHandler<UpDateStatementCommand>
    {
        private readonly IStatementDbContext _context;
        public UpDateStatementCommandHandler(IStatementDbContext context)
        {
            _context = context;
        }
        public async Task Handle(UpDateStatementCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Statements.FirstOrDefaultAsync(statement => statement.Id == request.Id, cancellationToken);
           
            if (entity == null)
                throw new NotFoundException(nameof(Statement), request.Id);

            entity.Statatus = request.Status;
            entity.Updated = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
