using System;
using D2DQuest.Contracts.Exceptions;

namespace D2DQuest.Contracts.Commands.Exceptions
{
    public class RegisterWordCommandException : WrappedUnexpectedException
    {
        public RegisterWordCommandException(Exception exc, string uid, string word) 
            : base("Registration word fail.", exc)
        {
            Uid = uid;
            Word = word;
        }

        public string Uid { get; private set; }

        public string Word { get; private set; }
    }
}
