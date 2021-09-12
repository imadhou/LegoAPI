using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.Errors
{
    public class LoginException: Exception
    {
        public LoginException(string message): base(message)
        {

        }
    }
}
