using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statements.Application.Statements.Commands.CreateStatement
{
    public class CreateStatementCommandValidator : AbstractValidator<CreateStatementCommand>
    {
        public CreateStatementCommandValidator()
        {
            RuleFor(createStatement => createStatement.Name).NotEmpty();
            RuleFor(createStatement => createStatement.Id).NotEqual(Guid.Empty);
        }
    }
}
