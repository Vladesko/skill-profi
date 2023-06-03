using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statements.Application.Statements.Queries.GetStatementList
{
    public class StatementListViewModel
    {
        public IList<StatementLookupDto> Statements { get; set; }  
    }
}
