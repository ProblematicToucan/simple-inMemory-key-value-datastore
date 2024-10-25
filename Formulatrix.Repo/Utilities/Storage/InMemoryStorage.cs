using System.Collections.Concurrent;
using Formulatrix.Repo.Interface;
using Formulatrix.Repo.Utilities.Serializer;

namespace Formulatrix.Repo.Utilities.Storage;

public class InMemoryStorage() : IStorage
{
    private readonly ConcurrentDictionary<string, StoredData> _storage = new();

    private readonly ISerializer _jsonSerializer = new JsonSerializer();
    private readonly ISerializer _xmlSerializer = new XmlSerializer();

    public Task Register(string key, string value, int itemType)
    {
        try
        {
            StoredData data;
            switch (itemType)
            {
                case 1:
                    _jsonSerializer.Validate(value);
                    data = new StoredData(value, "JSON");
                    break;
                case 2:
                    _xmlSerializer.Validate(value);
                    data = new StoredData(value, "XML");
                    break;
                default:
                    Console.WriteLine("Invalid item type value");
                    return Task.CompletedTask;
            }

            // Attempt to add to the dictionary without overriding
            if (!_storage.TryAdd(key, data))
            {
                throw new ArgumentException("The key already exists in the storage and was not overwritten.");
            }
        }
        catch (Exception ex)
        {
            // Console.WriteLine($"Validation failed: {ex.Message}");
            // return Task.CompletedTask;
            throw new ArgumentException($"Validation failed: {ex.Message}");
        }

        return Task.CompletedTask;
    }

    public Task<string?> Retrieve(string key)
    {
        if (_storage.TryGetValue(key, out var storedData))
        {
            return Task.FromResult<string?>(storedData.Data);
        }
        return Task.FromResult<string?>(default);
    }

    public Task Deregister(string key)
    {
        _storage.TryRemove(key, out _);
        return Task.CompletedTask;
    }

    public Task<string?> GetType(string key)
    {
        if (_storage.TryGetValue(key, out var storedData))
        {
            return Task.FromResult<string?>(storedData.DataType);
        }
        return Task.FromResult<string?>(default);
    }
}