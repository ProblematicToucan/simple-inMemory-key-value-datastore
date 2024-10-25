using System.Xml;
using System.Xml.Serialization;
using Formulatrix.Repo.Interface;

namespace Formulatrix.Repo.Utilities.Serializer;

public class XmlSerializer : ISerializer
{
    public void Validate(string data)
    {
        if (string.IsNullOrWhiteSpace(data))
        {
            throw new NullReferenceException("Null data format");
        }

        try
        {
            XmlDocument doc = new();
            doc.LoadXml(data); // Load the XML string
        }
        catch (XmlException)
        {
            throw new FormatException("Invalid XML format");
        }
    }
}