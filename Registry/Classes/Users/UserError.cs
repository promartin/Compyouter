using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry.Classes.Users
{
    class UserError : Exception
    {
        public UserError(string message) : base(message)
        {

        }
    }
}
