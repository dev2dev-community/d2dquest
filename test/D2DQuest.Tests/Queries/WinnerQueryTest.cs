using System.Collections.Generic;
using System.Linq;
using D2DQuest.BusinessLogic.Queries;
using D2DQuest.Contracts.DataAccessLayer;
using D2DQuest.Contracts.Queries;
using D2DQuest.Contracts.Queries.Exceptions;
using D2DQuest.ObjectDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace D2DQuest.Tests.Queries
{
    [TestClass]
    public class WinnerQueryTest
    {
        private Mock<IUnitOfWork> _uowMock;
        private Mock<IUnitOfWorkFactory> _uowfMock;
        private List<WordRegistration> _wordRegistrations;
        private IWinnerQuery _query;
        private bool _isCommited;
        private bool _isDisposed;

        [TestInitialize]
        public void Initialize()
        {
            _wordRegistrations = new List<WordRegistration>
            {
                new WordRegistration
                {
                    Id = 1,
                    Visiter = new Visiter {Name = "Ivan"}
                },
                new WordRegistration
                {
                    Id = 2,
                    Visiter = new Visiter {Name = "Soro"}
                },
                new WordRegistration
                {
                    Id = 3,
                    Visiter = new Visiter {Name = "Morgan"}
                }
            };

            _uowMock = new Mock<IUnitOfWork>();
            _uowMock
                .Setup(m => m.Items<WordRegistration>())
                .Returns(_wordRegistrations.AsQueryable());
            _uowMock
                .Setup(m => m.Commit())
                .Callback(() => _isCommited = true);
            _uowMock
                .Setup(m => m.Dispose())
                .Callback(() => _isDisposed = true);

            _uowfMock = new Mock<IUnitOfWorkFactory>();
            _uowfMock
                .Setup(m => m.Create())
                .Returns(() => _uowMock.Object);

            _query = new WinnerQuery(_uowfMock.Object);
        }

        [TestMethod]
        public void GetWinnerMustReturnObjectTest()
        {
            var winner = _query.GetWinner();

            Assert.IsNotNull(winner);
        }

        [TestMethod]
        [ExpectedException(typeof(RegistrationsEmptyException))]
        public void GetWinnerWithEmptyRegistrationMustBeExceptionTest()
        {
            _wordRegistrations.Clear();

            var winner = _query.GetWinner();
        }
    }
}
