using AutoMapper;
using Shouldly;
using Statements.Application.Statements.Queries.GetStatementList;
using Statements.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statements.Tests.Statements.Queries.GetListStatementQuery
{
    [Collection("QueryCollection")]
    public class GetListStatementQueryHandlerTests
    {
        private readonly StatementDbContext Context;
        private readonly IMapper Mapper;

        public GetListStatementQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async void GetStatementListQueryHandler_Success()
        {
            //Arrange
            var handler = new GetStatementListQueryHandler(Context, Mapper);

            //Act
            var result = await handler.Handle(
                new GetStatementListQuery(), CancellationToken.None
                );

            //Assert
            result.ShouldBeOfType<StatementListViewModel>();
            result.Statements.Count.ShouldBe(3);
        }
    }
}
