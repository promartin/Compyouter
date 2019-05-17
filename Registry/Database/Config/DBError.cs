using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry.Database.Config
{
    [Serializable]
    class DBError : Exception
    {
        public DBError(string message, Exception e) : base(message, e)
        {

        }
    }
}
