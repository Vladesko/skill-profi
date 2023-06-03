using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statements.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entity, object key) : base($"Entity \"{entity}\" ({key}) not found")
        {
            
        }
    }
}
