using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorama.Application.Interfaces
{
    public interface IIconService
    {
        // Pedimos una lista de strings (ej. "home", "favorite")
        List<string> ObtenerNombresDeIconos(int cantidad);
    }
}
