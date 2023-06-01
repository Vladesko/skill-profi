using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statements.Domain
{
    public class Statement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public State Statatus { get; set; }
        public enum State
        {
            Check,
            Approved,
            Denied,
        }
        
    }
}
