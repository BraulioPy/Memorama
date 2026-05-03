using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorama.Application.Interfaces
{
    public interface IPersistenceService
    {
        // Guarda cualquier objeto T en un archivo con el nombre especificado
        void Save<T>(string fileName, T data);

        // Recupera el objeto T desde el archivo. Si no existe, devuelve el valor por defecto.
        T Load<T>(string fileName);

        // Verifica si el archivo ya existe
        bool Exists(string fileName);

        // Devuelve true si se borró, false si no existía el archivo.
        bool Delete(string fileName);
    }
}
