using AutoMapper;
using Statements.Application.Interfaces;
using Statements.Application.Statements.Commands.CreateStatement;

namespace Statements.WebApi.Models
{
    public class CreateStatementDto : IMapWith<CreateStatementCommand>
    {
        public string Email { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateStatementDto, CreateStatementCommand>()
                .ForMember(statementCommand => statementCommand.Name, option => option.MapFrom(statementDto => statementDto.Name))
                .ForMember(statementCommand => statementCommand.Email, option => option.MapFrom(statementDto => statementDto.Email))
                .ForMember(statementCommand => statementCommand.Title, option => option.MapFrom(statementDto => statementDto.Title))
                .ForMember(statementCommand => statementCommand.Description, option => option.MapFrom(statementDto => statementDto.Description));
        }
    }
}
