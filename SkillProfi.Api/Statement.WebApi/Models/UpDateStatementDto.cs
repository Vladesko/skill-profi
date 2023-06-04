using AutoMapper;
using Statements.Application.Interfaces;
using Statements.Application.Statements.Commands.UpDateStatement;
using static Statements.Domain.Statement;

namespace Statements.WebApi.Models
{
    public class UpDateStatementDto : IMapWith<UpDateStatementCommand>
    {
        public State State { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpDateStatementDto, UpDateStatementCommand>()
                .ForMember(staementDto => staementDto.Status, option => option.MapFrom(statementCommand => statementCommand.State));
        }
    }
}
