using System.Xml.Serialization;

namespace LetsSpeak
{
    internal class Serializer
    {
        private static readonly string filePath = AppDomain.CurrentDomain.BaseDirectory;

        public void SaveFile(string fileName, Dictionary<string, string> dictionary)
        {
            var path = Path.Combine(filePath, fileName);
            var content = System.Text.Json.JsonSerializer.Serialize(dictionary);
            File.WriteAllText(path, content);
        }

        public Dictionary<string, string> LoadFile(string fileName)
        {
            var path = Path.Combine(filePath, fileName);
            var content = File.ReadAllText(path);
            var dictionary = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(content);

            return dictionary;
        }
    }
}
