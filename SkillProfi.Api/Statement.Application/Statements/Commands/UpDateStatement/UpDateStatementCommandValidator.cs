using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statements.Application.Statements.Commands.UpDateStatement
{
    public class UpDateStatementCommandValidator : AbstractValidator<UpDateStatementCommand>
    {
        public UpDateStatementCommandValidator()
        {
            RuleFor(updateStatement => updateStatement.Status).NotNull();
            RuleFor(updateStatement => updateStatement.Id).NotEqual(Guid.Empty);
        }
    }
}
