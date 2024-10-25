using System.Text.Json;
using Formulatrix.Repo.Interface;

namespace Formulatrix.Repo.Utilities.Serializer;

public class JsonSerializer : ISerializer
{
    public void Validate(string data)
    {
        if (string.IsNullOrWhiteSpace(data))
        {
            throw new NullReferenceException("Null data format");
        }

        try
        {
            JsonDocument.Parse(data);
        }
        catch (JsonException)
        {
            throw new FormatException("Invalid JSON format");
        }
    }
}
