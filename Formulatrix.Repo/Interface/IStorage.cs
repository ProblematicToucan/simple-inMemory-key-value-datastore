namespace Formulatrix.Repo.Interface;
public interface IStorage
{
    // void Initialize();
    Task Register(string key, string value, int itemType);
    Task<string?> Retrieve(string key);
    Task<string?> GetType(string key);
    Task Deregister(string key);
}