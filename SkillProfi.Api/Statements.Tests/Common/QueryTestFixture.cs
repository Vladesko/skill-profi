using AutoMapper;
using Statements.Application.Common;
using Statements.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statements.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public StatementDbContext Context;
        public IMapper Mapper;
        public QueryTestFixture()
        {
            Context = StatementContextFactory.Create();
            var configurationProvider = new MapperConfiguration(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(typeof(IStatementDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();

        }
        public void Dispose()
        {
            StatementContextFactory.Destroy(Context);
        }
    }
    [CollectionDefinition("QueryCollection")]
    public class Querycollection : ICollectionFixture<QueryTestFixture> { }
}
