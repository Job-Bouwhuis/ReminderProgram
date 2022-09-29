using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace ReminderProgram.Data;

public sealed class Redis : IDisposable
{
    private ConnectionMultiplexer? redis { get; set; }
    private IDatabase? db { get; set; }

    public delegate void RedisConnectedEvent();
    public RedisConnectedEvent? OnRedisConnect { get; set; }


    public bool IsConnected
    {
        get => redis != null && redis.IsConnected;
    }

    private Connection connection { get; init; }

    /// <summary>
    /// represents an empty RedisValue class
    /// </summary>
    public static RedisValue EmptyValue { get; } = new RedisValue();

    /// <summary>
    /// creates a new instance of this class, and creates a new connection to the Redis database if the given values are valid
    /// </summary>
    public Redis(string connection, int port, string? password = null) => this.connection = new Connection(connection, port, password);

    /// <summary>
    /// creates a new instance of this class, and creates a new connection to the Redis database if the given values are valid
    /// </summary>
    public Redis(Connection connection) => this.connection = connection;

    public async Task<bool> ConnectAsync()
    {
        try
        {
            await Task.Run(() =>
            {

                try
                {
                    redis = ConnectionMultiplexer.Connect(new ConfigurationOptions { EndPoints = { $"{connection.connection}:{connection.port}" }, Password = connection.password });
                    db = redis.GetDatabase();
                }
                catch
                {
                    return false;
                }

                return true;
            });
            throw new Exception("Connecting task failed to execute.");
        }
        finally
        {
            if (IsConnected)
                OnRedisConnect?.Invoke();
        }
    }
    public bool Connect()
    {
        try
        {
            try
            {
                redis = ConnectionMultiplexer.Connect(new ConfigurationOptions { EndPoints = { $"{connection.connection}:{connection.port}" }, Password = connection.password });
                db = redis.GetDatabase();
                return true;
            }
            catch
            {
                return false;
            }
        }
        finally
        {
            if (IsConnected)
                OnRedisConnect?.Invoke();
        }
    }

    /// <summary>
    /// Adds the given string with the given value. if the key already exists its value is updated
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns>true if the operation was successfull, otherwise false</returns>++
    public bool Set(string key, string value)
    {
        try
        {
            return db != null && db.StringSet(key, value);
        }
        catch
        {
            return false;
        }
    }
    /// <summary>
    /// gets the value associated with the given key
    /// </summary>
    /// <param name="key"></param>
    /// <returns>the value that was found. returns empty when the database is not connected or when the key does not exist in the database</returns>
    public RedisValue Get(string key)
    {
        try
        {
            return db == null ? EmptyValue : db.StringGet(key);
        }
        catch
        {
            return false;
        }
    }
    /// <summary>
    /// gets the value associated with the given key
    /// </summary>
    /// <param name="key"></param>
    /// <returns>the value that was found. returns empty when the database is not connected or when the key does not exist in the database</returns>
    public bool Get(string key, out RedisValue value)
    {
        try
        {
            return (value = Get(key)).HasValue;
        }
        catch
        {
            value = EmptyValue;
            return false;
        }
    }
    /// <summary>
    /// gets all keys within the database
    /// </summary>
    /// <returns>an array of RedisKeys that were found in the database</returns>
    public RedisKey[] GetAllKeys()
    {
        try
        {
            if (redis == null)
                return Array.Empty<RedisKey>();
            return redis.GetServer(redis.GetEndPoints().First()).Keys().ToArray();
        }
        catch
        {
            return Array.Empty<RedisKey>();
        }
    }

    /// <summary>
    /// Removes the expiration time from the given key
    /// </summary>
    /// <param name="key"></param>
    /// <returns>true if the operation was successfull, otherwise false</returns>
    public bool RemoveKeyExpire(string key)
    {
        try
        {
            return db != null && db.KeyPersist(key);
        }
        catch
        {
            return false;
        }
    }
    /// <summary>
    /// Sets the expiration time for the given key
    /// </summary>
    /// <param name="key"></param>
    /// <param name="expireTime"></param>
    /// <returns>true if the operation was successfull, otherwise false</returns>
    public bool SetKeyExpire(string key, TimeSpan expireTime)
    {
        try
        {
            return db != null && db.KeyExpire(key, expireTime);
        }
        catch
        {
            return false;
        }
    }
    /// <summary>
    /// checks if the given key exists within the database
    /// </summary>
    /// <param name="key"></param>
    /// <returns>true if it was found. if it was not found or the database is not connected it returns false</returns>
    public bool KeyExist(string key)
    {
        try
        {
            return db != null && db.KeyExists(key);
        }
        catch
        {
            return false;
        }
    }

    public void Dispose()
    {
        if(redis != null)
        {
            redis.Close();
            redis.Dispose();
        }
    }
}
