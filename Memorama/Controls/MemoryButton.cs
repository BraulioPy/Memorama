using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Memorama.Controls
{
    public class MemoryButton : Button
    {
        // Propiedad para vincular el botón físico con el objeto 'Carta' del Domain
        public int Indice { get; private set; }

        public MemoryButton(int indice)
        {
            this.Indice = indice;
            this.Size = new Size(80, 80); // Un poco más grandes para que se vean bien
            this.BackColor = Color.LightSteelBlue;
            this.FlatStyle = FlatStyle.Flat;
            this.Font = new Font("Arial", 16, FontStyle.Bold);
            this.Text = ""; // Empieza oculto
        }

        public void Revelar(int valor)
        {
            this.Text = valor.ToString();
            this.BackColor = Color.White;
        }

        public void Ocultar()
        {
            this.Text = "";
            this.BackColor = Color.LightSteelBlue;
            this.Enabled = true;
        }

        public void MarcarComoEncontrado()
        {
            this.BackColor = Color.LightGreen;
            this.Enabled = false; // Ya no se puede cliquear
        }
    }
}
