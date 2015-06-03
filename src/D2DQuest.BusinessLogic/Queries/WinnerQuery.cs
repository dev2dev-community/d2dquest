using System;
using System.Linq;
using D2DQuest.Contracts.DataAccessLayer;
using D2DQuest.Contracts.Queries;
using D2DQuest.Contracts.Queries.Exceptions;
using D2DQuest.ObjectDomain;

namespace D2DQuest.BusinessLogic.Queries
{
    public class WinnerQuery : IWinnerQuery
    {
        private readonly Random _rnd;
        private readonly IUnitOfWorkFactory _uowFactory;

        public WinnerQuery(IUnitOfWorkFactory uowFactory)
        {
            if (uowFactory == null) 
                throw new ArgumentNullException("uowFactory");
            
            _uowFactory = uowFactory;
            _rnd = new Random(DateTime.Now.Millisecond);
        }

        public Visiter GetWinner()
        {
            try
            {
                using (var uow = _uowFactory.Create())
                {
                    if (uow.Items<WordRegistration>().Count() == 0)
                        throw new RegistrationsEmptyException();

                    var min = uow.Items<WordRegistration>().Select(r => r.Id).Min();
                    var max = uow.Items<WordRegistration>().Select(r => r.Id).Max();

                    while (true)
                    {
                        var winnerRegistrationId = GenerateRandom(min, max);
                        var winnerRegistration =
                            uow.Items<WordRegistration>().FirstOrDefault(r => r.Id == winnerRegistrationId);

                        if (winnerRegistration != null)
                            return winnerRegistration.Visiter;
                    }
                }
            }
            catch (RegistrationsEmptyException)
            {
                throw;
            }
            catch (Exception exc)
            {
                throw new WinnerQueryException(exc);
            }
        }

        private int GenerateRandom(int min, int max)
        {
            return _rnd.Next(min, max);
        }
    }
}