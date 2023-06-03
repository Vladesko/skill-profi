using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statements.Application.Statements.Queries.GetStatementList
{
    public class GetStatementListQuery : IRequest<StatementListViewModel>
    {
    }
}
