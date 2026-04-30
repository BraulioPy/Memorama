using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorama.Domain.ValueObjects
{
    public class MenuButtonModelView
    {
        public string _Titulo { get; set; }
        public int _Pares { get; set; }
        public string ColorHex { get; set; } // Guardas "#00FF00" o "Green"
    }
}
