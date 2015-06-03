using System;
using System.Web.Mvc;
using D2DQuest.Contracts.Queries;
using D2DQuest.Web.MessageHelpers;

namespace D2DQuest.Web.Controllers
{
    public class RaffleController : Controller
    {
        private readonly IWinnerQuery _winnerQuery;
        private readonly Lazy<IRaffleMessageHelper> _messageHelper;

        public RaffleController(IWinnerQuery winnerQuery, Lazy<IRaffleMessageHelper> messageHelper)
        {
            if (winnerQuery == null) 
                throw new ArgumentNullException("winnerQuery");
            if (messageHelper == null) 
                throw new ArgumentNullException("messageHelper");

            _winnerQuery = winnerQuery;
            _messageHelper = messageHelper;
        }

        public ActionResult Raffle()
        {
            string result = null;

            try
            {
                var visiter = _winnerQuery.GetWinner();
                result = String.Format("{0} [{1}]", visiter.Name, visiter.Uid);
            }
            catch (Exception exc)
            {
                result = _messageHelper.Value.GetErrorMessage(exc);
            }

            return View((object)result);
        }
    }
}
