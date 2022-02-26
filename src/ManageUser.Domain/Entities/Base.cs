using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageUser.Domain.Entities
{
    public abstract class Base
    {
        public long Id { get; set; }

        internal List<string> _errors { get; set; }
        public IReadOnlyCollection<string> Errors => _errors;

        public abstract bool Validate();
    }
}
