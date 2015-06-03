using System;
using System.Linq;

namespace D2DQuest.Contracts.Exceptions
{
    public class LogicException : ApplicationException
    {
        public LogicException(string message)
            :base(message)
        {
            // empty
        }
    }
}
