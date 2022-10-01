using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderProgram.Data
{
    public class Connection
    {
        public string connection;
        public int port;
        public string? password;

        public Connection(string connection, int port, string? password)
        {
            this.connection = connection;
            this.port = port;
            this.password = password;
        }
        public Connection(string connection, int port)
        {
            this.connection = connection;
            this.port = port;
        }
        public Connection()
        {
            connection = "";
            port = 0;
            password = null;
        }

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(connection) || port == 0;
        }
    }
}
