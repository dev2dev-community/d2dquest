using System;
using System.Linq;

namespace D2DQuest.Contracts.Commands
{
    public interface IRegisterWordCommand
    {
        void Register(string visiterUid, string word);
    }
}
