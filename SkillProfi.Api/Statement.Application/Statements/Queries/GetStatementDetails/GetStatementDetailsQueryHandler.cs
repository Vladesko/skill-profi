using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Statements.Application.Common.Exceptions;
using Statements.Application.Interfaces;
using Statements.Domain;

namespace Statements.Application.Statements.Queries.GetStatementDetails
{
    public class GetStatementDetailsQueryHandler : IRequestHandler<GetStatementDetailsQuery, StatementDetailsViewModel>
    {
        private readonly IStatementDbContext _context;
        private readonly IMapper _mapper;
        public GetStatementDetailsQueryHandler(IStatementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<StatementDetailsViewModel> Handle(GetStatementDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Statements.FirstOrDefaultAsync(statement => statement.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Statement), request.Id);

            return _mapper.Map<StatementDetailsViewModel>(entity);
        }
    }
}
