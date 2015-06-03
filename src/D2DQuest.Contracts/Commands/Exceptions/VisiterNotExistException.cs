using D2DQuest.Contracts.Exceptions;

namespace D2DQuest.Contracts.Commands.Exceptions
{
    public class VisiterNotExistException : LogicException
    {
        public VisiterNotExistException(string visiterUid)
            :base("Visiter not exist.")
        {
            this.VisiterUid = visiterUid;
        }

        public string VisiterUid { get; private set; }
    }
}
