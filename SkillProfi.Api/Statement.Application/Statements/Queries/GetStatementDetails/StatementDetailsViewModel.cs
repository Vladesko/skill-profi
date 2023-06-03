using AutoMapper;
using Statements.Application.Interfaces;
using Statements.Domain;
using static Statements.Domain.Statement;

namespace Statements.Application.Statements.Queries.GetStatementDetails
{
    public class StatementDetailsViewModel : IMapWith<Statement>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public State Statatus { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Statement, StatementDetailsViewModel>()
                .ForMember(statementVm => statementVm.Id, options => options.MapFrom(statement => statement.Id))
                .ForMember(statementVm => statementVm.Name, options => options.MapFrom(statement => statement.Name))
                .ForMember(statementVm => statementVm.Email, options => options.MapFrom(statement => statement.Email))
                .ForMember(statementVm => statementVm.Title, options => options.MapFrom(statement => statement.Title))
                .ForMember(statementVm => statementVm.Created, options => options.MapFrom(statement => statement.Created))
                .ForMember(statementVm => statementVm.Updated, options => options.MapFrom(statement => statement.Updated))
                .ForMember(statementVm => statementVm.Statatus, options => options.MapFrom(statement => statement.Statatus));
        }
    }
}
