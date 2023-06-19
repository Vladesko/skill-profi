using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statements.Application.Statements.Queries.GetStatementDetails
{
    public class GetStatementDetailsQueryValidator : AbstractValidator<GetStatementDetailsQuery>
    {
        public GetStatementDetailsQueryValidator()
        {
            RuleFor(getStatement => getStatement.Id).NotEqual(Guid.Empty);
        }
    }
}
