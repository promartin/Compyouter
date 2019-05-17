using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry.Classes.Components
{
    [Serializable]

    class ComputerError : Exception
    {
        public ComputerError(string message) : base(message)
        {

        }
    }
}
