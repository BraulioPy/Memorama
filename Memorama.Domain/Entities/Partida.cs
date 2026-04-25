using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorama.Domain.Entities
{
    public class Partida
    {
        public int Intentos { get; private set; }
        public int SegundosTranscurridos { get; private set; }
        public int ParesEncontrados { get; private set; }
        public bool EstaFinalizada { get; private set; }
        public int TotalParesObjetivo { get; private set; }

        public Partida(int totalParesObjetivo)
        {
            TotalParesObjetivo = totalParesObjetivo;
            Reiniciar();
        }

        public void RegistrarIntento()
        {
            Intentos++;
        }

        public void RegistrarParejaEncontrada()
        {
            ParesEncontrados++;
            if (ParesEncontrados == TotalParesObjetivo)
            {
                EstaFinalizada = true;
            }
        }

        public void IncrementarTiempo()
        {
            SegundosTranscurridos++;
        }

        public void Reiniciar()
        {
            Intentos = 0;
            SegundosTranscurridos = 0;
            ParesEncontrados = 0;
            EstaFinalizada = false;
        }
    }
}
