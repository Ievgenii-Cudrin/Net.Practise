using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace AdoNetWithTwoTablesFromAleksandrCopy.Helpers
{
    public static class Connection
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["UserDBConnection"].ConnectionString;

        public static string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }
    }
}
