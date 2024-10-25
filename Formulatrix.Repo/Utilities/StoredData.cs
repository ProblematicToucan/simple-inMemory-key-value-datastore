namespace Formulatrix.Repo.Utilities;

// Data wrapper to hold the serialized data and its type
public class StoredData(string data, string dataType)
{
    public string Data { get; set; } = data;
    public string DataType { get; set; } = dataType;
}