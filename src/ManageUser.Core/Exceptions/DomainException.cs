using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ManageUser.Core.Exceptions
{
    public class DomainException : Exception
    {
        private readonly List<string> _erros;

        internal IReadOnlyCollection<string> Errors => _erros;

        public DomainException()
        {
        }

        public DomainException(string message, List<string> errors) : base(message)
        {
        }

        public DomainException(string? message) : base(message)
        {
        }

        public DomainException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}
