using Memorama.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Memorama.Infrastructure.Services
{
    public class IconService : IIconService
    {
        public List<string> ObtenerNombresDeIconos(int cantidad)
        {
            var assembly = Assembly.GetExecutingAssembly();
            // AJUSTA ESTO: NombreProyecto.Carpeta.Archivo
            var resourceName = "Memorama.Infrastructure.Resources.iconsManager.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string jsonFull = reader.ReadToEnd();
                // Limpiamos el prefijo de seguridad de Google
                string jsonLimpio = jsonFull.Replace(")]}'", "");

                using (JsonDocument doc = JsonDocument.Parse(jsonLimpio))
                {
                    var icons = doc.RootElement.GetProperty("icons");
                    var todosLosNombres = icons.EnumerateArray()
                        .Select(icon => icon.GetProperty("name").GetString())
                        .ToList();

                    Random rnd = new Random();
                    return todosLosNombres.OrderBy(x => rnd.Next()).Take(cantidad).ToList();
                }
            }
        }
    }
}
