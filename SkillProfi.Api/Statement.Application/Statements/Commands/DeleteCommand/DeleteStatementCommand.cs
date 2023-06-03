using MediatR;

namespace Statements.Application.Statements.Commands.DeleteCommand
{
    public class DeleteStatementCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
