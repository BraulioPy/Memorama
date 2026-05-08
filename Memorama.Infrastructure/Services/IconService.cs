using Memorama.Application.Interfaces;
using Memorama.Domain.Enums;
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
        public List<string> ObtenerNombresDeIconos(int cantidad, CategoriaIcono categoria = CategoriaIcono.Todos)
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
                    var icons = doc.RootElement.GetProperty("icons").EnumerateArray();
                    IEnumerable<JsonElement> iconosFiltrados;

                    if (categoria != CategoriaIcono.Todos)
                    {
                        // Pasamos el Enum a string minúscula (ej: Maps -> "maps") para comparar con el JSON
                        string nombreCatBuscada = categoria.ToString().ToLower();

                        // Filtramos los iconos cuya lista de "categories" contenga la que buscamos
                        iconosFiltrados = icons.Where(icon =>
                            icon.GetProperty("categories").EnumerateArray()
                            .Any(c => c.GetString() == nombreCatBuscada)
                        );
                    }
                    else
                    {
                        // Si es "Todos", no filtramos nada
                        iconosFiltrados = icons;
                    }

                    // Ahora sí, de esos que quedaron, extraemos solo el string del "name"
                    var listaNombres = iconosFiltrados
                        .Select(icon => icon.GetProperty("name").GetString())
                        .ToList();

                    // Mezclamos y devolvemos la cantidad pedida
                    Random rnd = new Random();
                    return listaNombres.OrderBy(x => rnd.Next()).Take(cantidad).ToList();
                }
            }

        }
    }
}
