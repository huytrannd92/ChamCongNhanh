using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Domain.Exceptions
{
    public class ScheduleDomainException : Exception
    {
        public ScheduleDomainException()
        { }

        public ScheduleDomainException(string message)
            : base(message)
        { }

        public ScheduleDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
