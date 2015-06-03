using System;
using D2DQuest.Contracts.Exceptions;

namespace D2DQuest.Contracts.Queries.Exceptions
{
    public class WinnerQueryException : WrappedUnexpectedException
    {
        public WinnerQueryException(Exception exc) :
            base("Query for winner failed.", exc)
        {
            // empty
        }
    }
}
