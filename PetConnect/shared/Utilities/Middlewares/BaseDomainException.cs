using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Middlewares;

public abstract class BaseDomainException : Exception
{
    protected BaseDomainException(string message) : base(message)
    {
    }

    protected BaseDomainException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}

