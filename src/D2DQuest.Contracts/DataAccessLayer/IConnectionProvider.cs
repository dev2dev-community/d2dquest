using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2DQuest.Contracts.DataAccessLayer
{
    public interface IConnectionProvider
    {
        string GetConnectionStringOrItName();
    }
}
