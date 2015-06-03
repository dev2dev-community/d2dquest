using System;
using System.Linq;

namespace D2DQuest.Contracts.Exceptions
{
    public class WrappedUnexpectedException : ApplicationException
    {
        public WrappedUnexpectedException(string message, Exception exc)
            :base(message, exc)
        {
            // empty
        }
    }
}
