using Memorama.Application.Interfaces;
using Memorama.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memorama
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Agregamos "System.Windows.Forms." antes de cada Application para evitar que la situación esta se confunda con el
            //Memorama.Application va?
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            // 1. Instanciamos el servicio (la lógica) aquí, fuera del formulario
            IGameService gameService = new GameService();

            // 2. Se lo pasamos al formulario por el constructor
            // Esto es lo que hace que la arquitectura sea flexible
            System.Windows.Forms.Application.Run(new JuegoForm(gameService));
        }
    }
}
