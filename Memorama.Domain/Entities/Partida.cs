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
        public int IntentosMaximos { get; private set; }
        public int SegundosTranscurridos { get; private set; }
        public int SegundosTotales { get; private set; }
        public int ParesEncontrados { get; private set; }
        public bool EstaFinalizada { get; private set; }
        public int TotalParesObjetivo { get; private set; }

        public Partida(int totalParesObjetivo, int segundosTotales, int intentosMaximos)
        {
            TotalParesObjetivo = totalParesObjetivo;
            SegundosTotales = segundosTotales;
            SegundosTranscurridos = SegundosTotales;
            IntentosMaximos = intentosMaximos;
            Reiniciar();
        }

        public void RegistrarIntento(bool fallo)
        {
            if (!fallo) Intentos++;
        }

        public void RegistrarParejaEncontrada()
        {
            ParesEncontrados++;
            if (ParesEncontrados == TotalParesObjetivo)
            {
                EstaFinalizada = true;
            }
        }
        public void ForzarFinalizacion()
        {
            EstaFinalizada = true;
        }

        public void DecrementarTiempo()
        {
            if (SegundosTranscurridos > 0)
                SegundosTranscurridos--;
        }
        public void Reiniciar()
        {
            Intentos = 0;
            SegundosTranscurridos = SegundosTotales;
            
            ParesEncontrados = 0;
            EstaFinalizada = false;
        }
    }
}
