using Statements.Application.Statements.Commands.CreateStatement;
using Statements.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statements.Tests.Statements.Commands.CreateCommand
{
    public class CreateStatementCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CrateStatementCommandHandler_Success()
        {
            //Arrange
            var handler = new CreateStatementCommandHandler(Context);

            string name = "NameCreate";
            string description = "DesCreate";
            string title = "TitleCreate";
            string email = "EmailCreate";

            //Act
            var statementId = await handler.Handle(
                new CreateStatementCommand
                {
                    Name = name,
                    Description = description,
                    Email = email,
                    Title = title,
                },
                CancellationToken.None
                );

            //Assert
            Assert.NotNull(
                await Context.Statements.SingleOrDefaultAsync(statement => 
                statement.Id == statementId &&
                statement.Name == name &&
                statement.Title == title &&
                statement.Description == description &&
                statement.Email == email)
                );
        }
    }
}
