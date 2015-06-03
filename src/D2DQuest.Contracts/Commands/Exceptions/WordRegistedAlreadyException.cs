using D2DQuest.Contracts.Exceptions;

namespace D2DQuest.Contracts.Commands.Exceptions
{
    public class WordRegistedAlreadyException : LogicException
    {
        public WordRegistedAlreadyException(string visiterUid, string word)
            :base("Word already registered for this visiter.")
        {
            VisiterUid = visiterUid;
            Word = word;
        }

        public string Word { get; private set; }

        public string VisiterUid { get; private set; }
    }
}
