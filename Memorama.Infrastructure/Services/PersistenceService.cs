using Memorama.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Memorama.Infrastructure.Services
{
    public class PersistenceService : IPersistenceService
    {
        private readonly string _basePath;

        public PersistenceService()
        {
            // Creamos una carpeta para la app en AppData/Local
            _basePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "MemoramaGame"
            );

            if (!Directory.Exists(_basePath))
                Directory.CreateDirectory(_basePath);
        }

        public void Save<T>(string fileName, T data)
        {
            string fullPath = Path.Combine(_basePath, $"{fileName}.json");
            string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fullPath, jsonString);
        }

        public T Load<T>(string fileName)
        {
            string fullPath = Path.Combine(_basePath, $"{fileName}.json");

            if (!File.Exists(fullPath))
                return default;

            string jsonString = File.ReadAllText(fullPath);
            return JsonSerializer.Deserialize<T>(jsonString);
        }

        public bool Exists(string fileName) => File.Exists(Path.Combine(_basePath, $"{fileName}.json"));

        public bool Delete(string fileName)
        {
            string fullPath = Path.Combine(_basePath, $"{fileName}.json");

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return true;
            }

            return false;
        }
    }
}
