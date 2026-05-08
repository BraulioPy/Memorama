using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memorama.Domain.Entities;

namespace Memorama.Application.Interfaces
{
    public interface IGameService
    {
        // Propiedades para que la UI consulte el estado
        int Intentos { get; }
        int Segundos { get; }
        bool EstaBloqueado { get; }

        // Métodos de control
        void IniciarNuevaPartida(int totalCartas, int _segundosTotales, int _intentosMaximos);
        void SeleccionarCarta(int indice);
        void AvanzarTiempo();

        // Eventos para avisar a la UI que algo cambió sin que el servicio conozca el Form
        // Esto es clave para el desacoplamiento
        System.Action<int, string> OnCartaRevelada { get; set; } // índice, valor
        System.Action<int, int> OnParejaEncontrada { get; set; } // índice1, índice2
        System.Action<int, int> OnParejaNoEncontrada { get; set; } // índice1, índice2
        System.Action OnPartidaFinalizada { get; set; }
    }
}
