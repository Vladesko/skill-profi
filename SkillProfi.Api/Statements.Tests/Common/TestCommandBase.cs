using AutoMapper;
using Statements.Application.Common;
using Statements.Application.Interfaces;

namespace Statements.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly StatementDbContext Context;
        public TestCommandBase()
        {
            Context = StatementContextFactory.Create();
        }
        public void Dispose()
        {
            StatementContextFactory.Destroy(Context);
        }
    }
}
