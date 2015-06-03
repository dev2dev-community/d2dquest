using System;
using D2DQuest.Contracts.Exceptions;

namespace D2DQuest.Contracts.DataAccessLayer.Exceptions
{
    public class DbException : WrappedUnexpectedException
    {
        public DbException(Exception exc)
            :base("Db communicatio error.", exc)
        {
            // empty
        }
    }
}
