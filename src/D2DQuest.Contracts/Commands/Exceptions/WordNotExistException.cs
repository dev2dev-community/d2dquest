using System;
using D2DQuest.Contracts.Exceptions;

namespace D2DQuest.Contracts.Commands.Exceptions
{
    public class WordNotExistException : LogicException
    {
        public WordNotExistException(string word)
            :base("Word not exist.")
        {
            Word = word;
        }

        public string Word { get; private set; }
    }
}
