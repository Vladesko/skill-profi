using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statements.Application.Statements.Commands.DeleteCommand
{
    public class DeleteStatementCommandValidator : AbstractValidator<DeleteStatementCommand>
    {
        public DeleteStatementCommandValidator()
        {
            RuleFor(deleteStatement => deleteStatement.Id).NotEqual(Guid.Empty);
        }
    }
}
