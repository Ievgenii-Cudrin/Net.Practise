using AdoNetWithTwoTablesFromAleksandrCopy.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandrCopy.Helpers
{
    public class Connection : IConnection
    {
        string connectionString = ConfigurationManager.ConnectionStrings["UserDBConnection"].ConnectionString;

        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }
    }
}
