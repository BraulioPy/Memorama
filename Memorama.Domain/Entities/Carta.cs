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
        public string Contenido { get; set; } // Antes era int Valor
        public bool EstaVolteada { get; set; }
        public bool EsParejaEncontrada { get; set; }

        public Carta(int id, string contenido)
        {
            Id = id;
            Contenido = contenido;
            EstaVolteada = false;
            EsParejaEncontrada = false;
        }
    }
}
