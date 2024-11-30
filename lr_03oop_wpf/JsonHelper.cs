using System.IO;
using System.Text.Json;

namespace lr_03oop_wpf
{
    public static class JsonHelper
    {
        public static void SaveToFile(string filePath, LibraryData data)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public static LibraryData LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath)) return new LibraryData();
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<LibraryData>(json) ?? new LibraryData();
        }
    }
}