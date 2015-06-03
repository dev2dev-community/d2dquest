using D2DQuest.Contracts.Exceptions;

namespace D2DQuest.Contracts.Queries.Exceptions
{
    public class RegistrationsEmptyException : LogicException
    {
        public RegistrationsEmptyException()
            :base("Registrations not exists.")
        {
            // empty
        }
    }
}
