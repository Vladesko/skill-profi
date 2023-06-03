using AutoMapper;
using Statements.Application.Interfaces;
using Statements.Domain;
using static Statements.Domain.Statement;

namespace Statements.Application.Statements.Queries.GetStatementList
{
    public class StatementLookupDto : IMapWith<Statement>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public State Statatus { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Statement, StatementLookupDto>()
                .ForMember(statementL => statementL.Id, options => options.MapFrom(statement => statement.Id))
                .ForMember(statementL => statementL.Name, options => options.MapFrom(statement => statement.Name))
                .ForMember(statementL => statementL.Email, options => options.MapFrom(statement => statement.Email))
                .ForMember(statementL => statementL.Title, options => options.MapFrom(statement => statement.Title))
                .ForMember(statementL => statementL.Statatus, options => options.MapFrom(statement => statement.Statatus));
        }
    }
}
