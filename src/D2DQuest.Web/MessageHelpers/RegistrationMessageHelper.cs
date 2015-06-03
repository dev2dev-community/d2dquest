using System;
using D2DQuest.Contracts.Commands.Exceptions;

namespace D2DQuest.Web.MessageHelpers
{
    public class RegistrationMessageHelper : IRegistrationMessageHelper
    {
        public string GetSuccessMessage()
        {
            return "Молодец, продолжай искать!";
        }

        public string GetErrorMessage(Exception exc)
        {
            var errorType = exc.GetType();
            if (errorType.Equals(typeof(VisiterNotExistException)))
            {
                return "Возможно неверный личный номер. Он указан на бейдже.";
            }
            else if (errorType.Equals(typeof(WordNotExistException)))
            {
                return "Неправильное слово, ищи лучше!";
            }
            else if (errorType.Equals(typeof(WordRegistedAlreadyException)))
            {
                return "Ай-ай, нельзя регистрировать одно слово два раза!";
            }
            else
            {
                return "Кажется, случилось что-то плохое и неведомое...";
            }
        }
    }
}