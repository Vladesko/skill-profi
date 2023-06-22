using Statements.Application.Common.Exceptions;
using Statements.Application.Statements.Commands.DeleteCommand;
using Statements.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statements.Tests.Statements.Commands.DeleteCommand
{
    public class DeleteStatementCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task DeleteStatementCommandHandler_Success()
        {
            //Arange
            var handler = new DeleteStatementCommandHandler(Context);

            //Act
            await handler.Handle(
                new DeleteStatementCommand
                {
                    Id = StatementContextFactory.StatementIdForDelete
                },
                CancellationToken.None
                );

            //Assert
            Assert.Null(await Context.Statements.SingleOrDefaultAsync(statement => statement.Id == StatementContextFactory.StatementIdForDelete));
        }
        [Fact]
        public async Task DeleteStatementCommandHAndler_Throw_NotFoundException()
        {
            //Arrange
            var handler = new DeleteStatementCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => 
               await handler.Handle(
                new DeleteStatementCommand
                {
                    Id = Guid.NewGuid(),
                },
                CancellationToken.None
                ));
            
        }
    }
}
