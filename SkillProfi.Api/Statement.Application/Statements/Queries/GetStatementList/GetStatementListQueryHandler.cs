using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Statements.Application.Interfaces;

namespace Statements.Application.Statements.Queries.GetStatementList
{
    public class GetStatementListQueryHandler : IRequestHandler<GetStatementListQuery, StatementListViewModel>
    {
        private readonly IStatementDbContext _context;
        private readonly IMapper _mapper;
        public GetStatementListQueryHandler(IStatementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<StatementListViewModel> Handle(GetStatementListQuery request, CancellationToken cancellationToken)
        {
            var statementsQuery = await _context.Statements.ProjectTo<StatementLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new StatementListViewModel { Statements = statementsQuery };
        }
    }
}
