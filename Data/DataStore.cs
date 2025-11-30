using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace LibraryManagement.Data
{
    internal class DataStore : IDataStore
    {
        public List<T> Load<T>(string fileName)
        {
            if (!File.Exists(fileName))
                return new List<T>();

            var json = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<T>>(json);
        }

        public void Save<T>(string fileName, List<T> items)
        {
            var json = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);
        }
    }
}
