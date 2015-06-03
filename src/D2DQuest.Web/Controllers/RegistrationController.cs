using System;
using System.Web.Mvc;
using D2DQuest.Contracts.Commands;
using D2DQuest.Web.MessageHelpers;
using D2DQuest.Web.ViewModels;

namespace D2DQuest.Web.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly Lazy<IRegisterWordCommand> _command;

        private readonly Lazy<IRegistrationMessageHelper> _messageHelper;

        public RegistrationController(Lazy<IRegisterWordCommand> command, Lazy<IRegistrationMessageHelper> messageHelper)
        {
            _command = command;
            _messageHelper = messageHelper;
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationViewModel registration)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _command.Value.Register(registration.UserUid, registration.Word);
                    registration.Message = _messageHelper.Value.GetSuccessMessage();
                    registration.Word = String.Empty;
                }
                catch (Exception exc)
                {
                    registration.Message = _messageHelper.Value.GetErrorMessage(exc);
                }
            }

            if (Request.IsAjaxRequest())
                return Json(registration);
            else
                return View(registration);
        }
    }
}
