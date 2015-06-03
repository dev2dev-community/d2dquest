using System;
using System.Linq;

namespace D2DQuest.Contracts.DataAccessLayer
{
    public class ConnectionProvider : IConnectionProvider
    {
        private readonly string _connectionOrname;

        public ConnectionProvider(string connectionOrname)
        {
            if (String.IsNullOrWhiteSpace(connectionOrname))
                throw new ArgumentNullException("connectionOrname");

            _connectionOrname = connectionOrname;
        }

        public string GetConnectionStringOrItName()
        {
            return _connectionOrname;
        }
    }
}
