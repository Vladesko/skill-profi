using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statements.Application.Statements.Queries.GetStatementDetails
{
    public class GetStatementDetailsQuery : IRequest<StatementDetailsViewModel>
    {
        public Guid Id { get; set; }
    }
}
