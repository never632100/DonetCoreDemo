using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DataProvide
{
    public class MySqlContext:IMySqlContext,IDisposable
    {
        private readonly IOptions<AppSettings> _settings;
        public MySqlContext(IOptions<AppSettings> setting)
        {
            _settings = setting;
        }

        private MySqlConnection _connection;
        public MySqlConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new MySqlConnection(_settings.Value.MySqlConnectionStrings);
                    _connection.Open();
                }
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
                if (_connection.State == System.Data.ConnectionState.Broken)
                {
                    _connection.Close();
                    _connection.Open();
                }
                return _connection;
            }
        }

        protected bool disposed;
        protected virtual void Dispose(bool disposing)
        {
            lock (this)
            {
                if (disposed)
                    return;
                if (disposing)
                {
                    if (_connection != null)
                    {
                        _connection.Dispose();
                    }
                }

                disposed = true;
            }
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
