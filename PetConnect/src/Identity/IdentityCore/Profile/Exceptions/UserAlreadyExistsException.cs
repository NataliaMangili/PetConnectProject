using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Middlewares;

namespace IdentityCore.Profile.Exceptions;

public class UserAlreadyExistsException : BaseDomainException
{
    public UserAlreadyExistsException(string email): base($"A user with email '{email}' already exists.")
    {
    }
}
