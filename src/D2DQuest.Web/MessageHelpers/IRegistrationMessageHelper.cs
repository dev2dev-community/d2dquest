using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2DQuest.Web.MessageHelpers
{
    public interface IRegistrationMessageHelper
    {
        string GetSuccessMessage();
        string GetErrorMessage(Exception exc);
    }
}
