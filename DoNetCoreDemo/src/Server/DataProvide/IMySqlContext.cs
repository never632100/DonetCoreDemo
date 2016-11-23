using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Server.DataProvide
{
    public interface IMySqlContext
    {
        MySqlConnection Connection { get; }
        void Dispose();
    }
}
