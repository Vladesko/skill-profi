using MediatR;
using Microsoft.EntityFrameworkCore;
using Statements.Application.Common.Exceptions;
using Statements.Application.Interfaces;
using Statements.Domain;

namespace Statements.Application.Statements.Commands.DeleteCommand
{
    public class DeleteStatementCommandHandler : IRequestHandler<DeleteStatementCommand>
    {
        private readonly IStatementDbContext _context;
        public DeleteStatementCommandHandler(IStatementDbContext context)
        {
            _context = context;
        }
        public async Task Handle(DeleteStatementCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Statements.FirstOrDefaultAsync(Statement => Statement.Id == request.Id, cancellationToken);
            if (entity == null) 
                throw new NotFoundException(nameof(Statement), request.Id);

            _context.Statements.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
