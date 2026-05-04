using Memorama.Application.Interfaces;
using Memorama.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorama.Application.Services
{
    public class GameService : IGameService
    {
        private Tablero _tablero;
        private Partida _partida;
        private int _indicePrimerCarta = -1;
        private bool _estaBloqueado = false;

        // Propiedades de la interfaz
        public int Intentos => _partida.Intentos;
        public int Segundos => _partida.SegundosTranscurridos;
        public bool EstaBloqueado => _estaBloqueado;

        // Acciones para avisar a la UI
        public System.Action<int, int> OnCartaRevelada { get; set; }
        public System.Action<int, int> OnParejaEncontrada { get; set; }
        public System.Action<int, int> OnParejaNoEncontrada { get; set; }
        public System.Action OnPartidaFinalizada { get; set; }

        public void IniciarNuevaPartida(int totalCartas, int _segundosTotales, int _intentosMaximos)
        {
            _tablero = new Tablero();
            _partida = new Partida(totalCartas/2, _segundosTotales, _intentosMaximos); // 10 parejas por defecto
            _tablero.GenerarCartas(totalCartas);
            _tablero.Mezclar();
            _partida.Reiniciar();
            _indicePrimerCarta = -1;
            _estaBloqueado = false;
        }

        public void AvanzarTiempo()
        {
            // Si el tiempo llega a 0 y la partida no se había ganado ya
            if (_partida.SegundosTranscurridos <= 0 && !_partida.EstaFinalizada)
            {
                _partida.ForzarFinalizacion(); //[cite: 3]
                OnPartidaFinalizada?.Invoke(); // Disparamos el evento hacia la UI
                _partida.Reiniciar(); // Reiniciamos la partida para evitar que siga bajando el tiempo en segundo plano
            }
            else
            {
                if (_partida.Intentos > _partida.IntentosMaximos)
                {
                    _partida.ForzarFinalizacion();
                    OnPartidaFinalizada?.Invoke();
                    _partida.Reiniciar(); // Reiniciamos la partida para evitar que siga bajando el tiempo en segundo plano
                }
            }

            _partida.DecrementarTiempo();
        }

        public async void SeleccionarCarta(int indice)
        {
            if (_estaBloqueado) return;

            var carta = _tablero.Cartas[indice];

            // Si la carta ya está visible, no hacer nada
            if (carta.EstaVolteada || carta.EsParejaEncontrada) return;

            // 1. Revelar la carta
            carta.EstaVolteada = true;
            OnCartaRevelada?.Invoke(indice, carta.Valor);

            if (_indicePrimerCarta == -1)
            {
                // Es la primera carta de la pareja
                _indicePrimerCarta = indice;
            }
            else
            {
                // Es la segunda carta, validamos match
                int indiceSegunda = indice;
                bool fallo = false;
                if (_tablero.Cartas[_indicePrimerCarta].Valor == _tablero.Cartas[indiceSegunda].Valor)
                {
                    fallo = !fallo;
                    // ¡Son iguales!
                    _tablero.Cartas[_indicePrimerCarta].EsParejaEncontrada = true;
                    _tablero.Cartas[indiceSegunda].EsParejaEncontrada = true;

                    _partida.RegistrarParejaEncontrada();
                    OnParejaEncontrada?.Invoke(_indicePrimerCarta, indiceSegunda);

                    if (_partida.EstaFinalizada)
                        OnPartidaFinalizada?.Invoke();
                }
                else
                {
                    // No son iguales, bloquear y esperar para ocultar
                    _estaBloqueado = true;
                    await Task.Delay(800); // Reemplaza al Timer visual de 800ms

                    _tablero.Cartas[_indicePrimerCarta].EstaVolteada = false;
                    _tablero.Cartas[indiceSegunda].EstaVolteada = false;

                    OnParejaNoEncontrada?.Invoke(_indicePrimerCarta, indiceSegunda);
                    _estaBloqueado = false;

                }
                _partida.RegistrarIntento(fallo);

                _indicePrimerCarta = -1;
            }
        }
    }
}
