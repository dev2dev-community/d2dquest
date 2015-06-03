using System;
using System.Linq;
using D2DQuest.Contracts.Commands.Exceptions;
using D2DQuest.Contracts.DataAccessLayer;
using D2DQuest.ObjectDomain;
using D2DQuest.Contracts.Exceptions;
using D2DQuest.Contracts.Commands;

namespace D2DQuest.BusinessLogic.Commands
{
    public class RegisterWordCommand : IRegisterWordCommand
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public RegisterWordCommand(IUnitOfWorkFactory uowFactory)
        {
            if (uowFactory == null)
                throw new ArgumentNullException("uowFactory");

            _uowFactory = uowFactory;
        }

        public void Register(string visiterUid, string word)
        {
            try
            {
                using (var uow = _uowFactory.Create())
                {
                    var keyWord = uow.Items<KeyWord>().FirstOrDefault(w => w.Word.ToLower() == word.ToLower());

                    if (keyWord == null)
                        throw new WordNotExistException(word);

                    var visiter = uow.Items<Visiter>().FirstOrDefault(v => v.Uid.ToUpper() == visiterUid.ToUpper());

                    if (visiter == null)
                        throw new VisiterNotExistException(visiterUid);

                    if (uow.Items<WordRegistration>().Any(r => r.Visiter.Id == visiter.Id && r.Word.Id == keyWord.Id))
                        throw new WordRegistedAlreadyException(visiterUid, word);

                    uow.Add(new WordRegistration { Time = DateTime.UtcNow, Word = keyWord, Visiter = visiter });

                    uow.Commit();
                }
            }
            catch (LogicException)
            {
                throw;
            }
            catch (WrappedUnexpectedException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new RegisterWordCommandException(ex, visiterUid, word);
            }
        }
    }
}
