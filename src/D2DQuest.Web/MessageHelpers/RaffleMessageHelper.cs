using System;
using D2DQuest.Contracts.Queries.Exceptions;

namespace D2DQuest.Web.MessageHelpers
{
    public class RaffleMessageHelper : IRaffleMessageHelper
    {
        public string GetErrorMessage(Exception exc)
        {
            if (exc.GetType() == typeof (RegistrationsEmptyException))
            {
                return "Пока еще нет ни одного победителя...";
            }

            return "Все сломалось.";
        }
    }
}