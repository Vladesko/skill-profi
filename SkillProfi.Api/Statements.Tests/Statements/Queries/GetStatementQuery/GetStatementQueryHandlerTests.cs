using AutoMapper;
using Shouldly;
using Statements.Application.Statements.Queries.GetStatementDetails;
using Statements.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statements.Tests.Statements.Queries.GetStatementQuery
{
    [Collection("QueryCollection")]
    public class GetStatementQueryHandlerTests
    {
        private readonly StatementDbContext Context;
        private readonly IMapper Mapper;

        public GetStatementQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetStatementDetailsQueryHandler_Success()
        {
            //Arrange
            var handler = new GetStatementDetailsQueryHandler(Context, Mapper);

            //Act
            var result = await handler.Handle(
                new GetStatementDetailsQuery
                {
                    Id = StatementContextFactory.StatementForGetStatement
                },
                CancellationToken.None
                );

            //Assert
            result.ShouldBeOfType<StatementDetailsViewModel>();
            result.Id.ShouldBe(StatementContextFactory.StatementForGetStatement);
        }
    }
}
