using System;
using System.Collections.Generic;
using System.Linq;
using D2DQuest.BusinessLogic.Commands;
using D2DQuest.Contracts.Commands;
using D2DQuest.Contracts.Commands.Exceptions;
using D2DQuest.Contracts.DataAccessLayer;
using D2DQuest.ObjectDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace D2DQuest.Tests.Commands
{
    [TestClass]
    public class RegisterWordCommandTests
    {
        private Mock<IUnitOfWork> _uowMock;
        private Mock<IUnitOfWorkFactory> _uowfMock;
        private List<WordRegistration> _wordRegistrations;
        private IRegisterWordCommand _command;
        private bool _isCommited;
        private bool _isDisposed;
        private KeyWord[] _words;
        private Visiter[] _visiters;

        [TestInitialize]
        public void Initialize()
        {
            _words = new[]
            {
                new KeyWord {Id = 1, Word = "lol"},
                new KeyWord {Id = 2, Word = "foo"},
                new KeyWord {Id = 3, Word = "bar"}
            };
            _visiters = new[]
            {
                new Visiter {Id = 1, Name = "Ivan", Uid = "XX11"},
                new Visiter {Id = 2, Name = "Oskar", Uid = "A0A1"}
            };
            _wordRegistrations = new List<WordRegistration>();

            _uowMock = new Mock<IUnitOfWork>();
            _uowMock
                .Setup(m => m.Items<KeyWord>())
                .Returns(_words.AsQueryable());
            _uowMock
                .Setup(m => m.Items<Visiter>())
                .Returns(_visiters.AsQueryable());
            _uowMock
                .Setup(m => m.Items<WordRegistration>())
                .Returns(_wordRegistrations.AsQueryable());
            _uowMock
                .Setup(m => m.Commit())
                .Callback(() => _isCommited = true);
            _uowMock
                .Setup(m => m.Dispose())
                .Callback(() => _isDisposed = true);
            _uowMock
                .Setup(m => m.Add(It.IsAny<WordRegistration>()))
                .Callback<WordRegistration>(e => _wordRegistrations.Add(e));

            _uowfMock = new Mock<IUnitOfWorkFactory>();
            _uowfMock
                .Setup(m => m.Create())
                .Returns(() => _uowMock.Object);

            _command = new RegisterWordCommand(_uowfMock.Object);
        }

        [TestMethod]
        public void WordMustBeRegisteredTest()
        {
            _command.Register("A0A1", "lol");

            AssertRegistrationExisting("A0A1", "lol");

            AssertUnitOfWorkPattern();
        }

        [TestMethod]
        public void WordMustBeRegisteredWithDifferentCaseTest()
        {
            _command.Register("xx11", "BaR");

            AssertRegistrationExisting("xx11", "BaR");

            AssertUnitOfWorkPattern();
        }

        [TestMethod]
        [ExpectedException(typeof(WordRegistedAlreadyException))]
        public void DoubleRegistrationMustBeExceptionTest()
        {
            _wordRegistrations.Add(new WordRegistration { Visiter = _visiters[0], Word = _words[0]});

            _command.Register(_visiters[0].Uid, _words[0].Word);
        }

        [TestMethod]
        [ExpectedException(typeof(WordNotExistException))]
        public void IfWordNotExitMustBeExceptionTest()
        {
            _command.Register("XX11", "word");
        }

        [TestMethod]
        [ExpectedException(typeof(VisiterNotExistException))]
        public void IfVisiterNotExitMustBeExceptionTest()
        {
            _command.Register("visiter", "lol");
        }

        private void AssertRegistrationExisting(string visiterId, string word)
        {
            var registration =
                _wordRegistrations
                    .FirstOrDefault(it => String.Equals(it.Visiter.Uid, visiterId, StringComparison.CurrentCultureIgnoreCase) &&
                                          String.Equals(it.Word.Word, word, StringComparison.CurrentCultureIgnoreCase));

            Assert.IsNotNull(registration, "Registation not found, but must exist.");
        }

        private void AssertUnitOfWorkPattern()
        {
            Assert.IsTrue(_isCommited);
            Assert.IsTrue(_isDisposed);
        }
    }
}
