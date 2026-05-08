using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorama.Domain.Entities
{
    public class Tablero
    {
        public List<Carta> Cartas { get; private set; }

        public Tablero()
        {
            Cartas = new List<Carta>();
        }

        // Esta lógica reemplaza el llenado del arreglo 'valor' que teníamos en Form1
        public void GenerarCartas(List<string> iconos)
        {
            Cartas.Clear();
            List<string> listaDuplicada = iconos.Concat(iconos).ToList();
            for (int i = 0; i < listaDuplicada.Count; i++)
            {
                // (i / 2) + 1 genera los pares: 1,1, 2,2, 3,3...
                int valorCarta = (i / 2) + 1;
                Cartas.Add(new Carta(i, listaDuplicada[i]));
            }
        }

        // Aquí mudamos la lógica de mezcla (Random) del 'button21_Click'
        public void Mezclar()
        {
            Random mezcla = new Random();
            int n = Cartas.Count;
            while (n > 1)
            {
                n--;
                int k = mezcla.Next(n + 1);
                Carta temp = Cartas[k];
                Cartas[k] = Cartas[n];
                Cartas[n] = temp;
            }
        }
    }
}
