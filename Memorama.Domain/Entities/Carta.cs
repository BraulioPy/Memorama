using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorama.Domain.Entities
{
    public class Carta
    {
        public int Id { get; set; }
        public int Valor { get; set; } // El número (1-10) que debe coincidir (si queremos poner un simbolo modificamos esto)
        public bool EstaVolteada { get; set; }
        public bool EsParejaEncontrada { get; set; }

        public Carta(int id, int valor)
        {
            Id = id;
            Valor = valor;
            EstaVolteada = false;
            EsParejaEncontrada = false;
        }
    }
}
