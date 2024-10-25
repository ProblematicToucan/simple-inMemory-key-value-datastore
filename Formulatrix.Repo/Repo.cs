using Formulatrix.Repo.Interface;
using Formulatrix.Repo.Utilities.Storage;

namespace Formulatrix.Repo;
public class Repo(IStorage? storage = null)
{
    protected virtual IStorage Storage { get; set; } = storage ?? new InMemoryStorage();

    public void Register(string itemName, string itemContent, int itemType)
    {
        Storage.Register(itemName, itemContent, itemType).GetAwaiter().GetResult();
    }

    public string? Retrieve(string itemName)
    {
        return Storage.Retrieve(itemName).GetAwaiter().GetResult();
    }

    public string? GetType(string itemName)
    {
        return Storage.GetType(itemName).GetAwaiter().GetResult();
    }

    public void Deregister(string itemName)
    {
        Storage.Deregister(itemName).GetAwaiter().GetResult();
    }
}
