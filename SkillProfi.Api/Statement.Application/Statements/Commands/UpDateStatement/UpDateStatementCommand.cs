using MediatR;
using static Statements.Domain.Statement;

namespace Statements.Application.Statements.Commands.UpDateStatement
{
    public class UpDateStatementCommand : IRequest
    {
        public Guid Id { get; set; }
        public State Status { get; set; }
    }
}
