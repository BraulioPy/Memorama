using Memorama.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorama.Domain.ValueObjects
{
    public class GameInfoModelView
    {
        private int _cartasTotales; //Esta En realidad no existe por fuera, es como un espacio temporal para guardar el dato
        public int CartasTotales
        {
            get => _cartasTotales;
            // Si el valor es par, se queda igual. Si es impar, se le resta 1.
            set => _cartasTotales = (value % 2 == 0) ? value : value - 1;
        }
        public int Pares { get { 
                return CartasTotales/2;
            } 
        }
        public int Intentos
        {
            get{ return
                    (int)(CartasTotales > 8 ? (
                    CartasTotales > 16 ? ((CartasTotales + CartasTotales * .25) * .75
                    ) : (CartasTotales + CartasTotales * .25)
                ) : ((CartasTotales + CartasTotales * .25) * 1.5));
            }
        }
        public int Segundos { get; set; }
        public string ModoDeJuego { get; set; }
        public string ColorHex { get; set; }
        public CategoriaIcono Tema { get; set; } = CategoriaIcono.Todos;
    }
}
