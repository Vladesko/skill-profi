using AutoMapper.Configuration.Annotations;
using Statements.Application.Common.Exceptions;
using Statements.Application.Statements.Commands.UpDateStatement;
using Statements.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statements.Tests.Statements.Commands.UpDateCommand
{
    public class UpDateStatementCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateStatementCommandHandler_Success()
        {
            //Arrange
            var handler = new UpDateStatementCommandHandler(Context);

            //Act
            await handler.Handle(
                new UpDateStatementCommand
                {
                    Id = StatementContextFactory.StatementIdForUpdate,
                    Status = Statement.State.Approved
                },
                CancellationToken.None
                );

            //Assert
            Assert.NotNull(await Context.Statements.SingleOrDefaultAsync(statement => 
            statement.Id == StatementContextFactory.StatementIdForUpdate && 
            statement.Statatus == Statement.State.Approved &&
            statement.Updated != null));
        }
        [Fact]
        public async Task UpdateStatementCommandHandler_Throw_NotFoundException()
        {
            //Arrange
            var handler = new UpDateStatementCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
              await handler.Handle(new UpDateStatementCommand
              {
                  Id = Guid.NewGuid()
              },
              CancellationToken.None
              ));
        }
    }
}
