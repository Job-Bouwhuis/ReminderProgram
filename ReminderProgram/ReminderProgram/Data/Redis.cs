using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace ReminderProgram.Data
{
    public class Redis : IDisposable
    {
        private ConnectionMultiplexer? redis { get; init; }
        private IDatabase? db { get; init; }

        private Connection connection { get; init; }

        /// <summary>
        /// represents an empty RedisValue class
        /// </summary>
        public static RedisValue EmptyValue { get; } = new RedisValue();

        /// <summary>
        /// creates a new instance of this class, and creates a new connection to the Redis database if the given values are valid
        /// </summary>
        public Redis(string connection, int port, string? password = null)
        {
            this.connection = new Connection(connection, port, password);

            redis = ConnectionMultiplexer.Connect(new ConfigurationOptions { EndPoints = { $"{connection}:{port}" }, Password = password });
            db = redis.GetDatabase();
        }
        /// <summary>
        /// creates a new instance of this class, and creates a new connection to the Redis database if the given values are valid
        /// </summary>
        public Redis(Connection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// Adds the given string with the given value. if the key already exists its value is updated
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>true if the operation was successfull, otherwise false</returns>++
        public bool Set(string key, string value) => db != null && db.StringSet(key, value);
        /// <summary>
        /// gets the value associated with the given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>the value that was found. returns empty when the database is not connected or when the key does not exist in the database</returns>
        public RedisValue Get(string key) => db == null ? EmptyValue : db.StringGet(key);
        /// <summary>
        /// gets the value associated with the given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>the value that was found. returns empty when the database is not connected or when the key does not exist in the database</returns>
        public bool Get(string key, out RedisValue value) => (value = Get(key)).HasValue;
        /// <summary>
        /// gets all keys within the database
        /// </summary>
        /// <returns>an array of RedisKeys that were found in the database</returns>
        public RedisKey[]? GetAllKeys() => redis?.GetServer(redis.GetEndPoints().First()).Keys().ToArray();

        /// <summary>
        /// Removes the expiration time from the given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>true if the operation was successfull, otherwise false</returns>
        public bool RemoveKeyExpire(string key) => db != null && db.KeyPersist(key);
        /// <summary>
        /// Sets the expiration time for the given key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expireTime"></param>
        /// <returns>true if the operation was successfull, otherwise false</returns>
        public bool SetKeyExpire(string key, TimeSpan expireTime) => db != null && db.KeyExpire(key, expireTime);
        /// <summary>
        /// checks if the given key exists within the database
        /// </summary>
        /// <param name="key"></param>
        /// <returns>true if it was found. if it was not found or the database is not connected it returns false</returns>
        public bool KeyExist(string key) => db != null && db.KeyExists(key);

        public void Dispose()
        {
            redis.Close();
            redis.Dispose();
        }
    }
}
