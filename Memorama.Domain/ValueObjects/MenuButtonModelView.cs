using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorama.Domain.ValueObjects
{
    public class MenuButtonModelView
    {
        private int _cartasTotales; //Esta En realidad no existe por fuera, es como un espacio temporal para guardar el dato
        public string _ModoDeJuego { get; set; }
        public int _CartasTotales
        {
            get => _cartasTotales;
            // Si el valor es par, se queda igual. Si es impar, se le resta 1.
            set => _cartasTotales = (value % 2 == 0) ? value : value - 1;
        }
        public int _Pares { get { return _CartasTotales / 2; } }
        public int _Segundos { get; set; }
        public string ColorHex { get; set; } // Guardas "#00FF00" o "Green"
    }
}
