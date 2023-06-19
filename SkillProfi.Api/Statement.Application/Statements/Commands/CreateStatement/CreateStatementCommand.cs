using MediatR;

namespace Statements.Application.Statements.Commands.CreateStatement
{
    public class CreateStatementCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
