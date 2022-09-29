using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace ReminderProgram.Data
{
    internal class Redis : IDisposable
    {
        private ConnectionMultiplexer? redis { get; init; }
        private IDatabase? db { get; init; }

        private string Connection { get; init; }
        private int Port { get; init; }
        private string? Password { get; init; }

        public static RedisValue Empty { get; } = new RedisValue();

        /// <summary>
        /// creates a new instance of this class, and creates a new connection to the Redis database if the given values are valid
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="port"></param>
        /// <param name="password"></param>
        public Redis(string connection, int port, string? password = null)
        {
            Connection = connection;
            Port = port;
            Password = password;

            redis = ConnectionMultiplexer.Connect(new ConfigurationOptions { EndPoints = { $"{connection}:{port}" }, Password = password });
            db = redis.GetDatabase();
        }

        public bool Set(string key, string value)
        {
            if (db == null)
                return false;
            return db.StringSet(key, value);
        }
        public RedisValue Get(string key)
        {
            if (db == null)
                return new RedisValue();
            return db.StringGet(key);
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
