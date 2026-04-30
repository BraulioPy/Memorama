using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Memorama.Domain.ValueObjects;

namespace Memorama.Controls.Components
{
    public partial class ButtonOption : UserControl
    {
        //Definimos el evento y lo que retorna (los pares del nivel para que el tablero genere las cartas correspondientes)
        public event Action<GameInfoModelView> ConsultarConfiguracionBoton;
        public string Titulo
        {
            get => ButtonDesign.Text;
            set => ButtonDesign.Text = value;
        }
        public int CantidadPares { get; set; }
        public Color ColorNivel
        {
            get => panelColor.BackColor;
            set {
                panelColor.BackColor = value;
            }
        }
        public GameInfoModelView ConfigurationGame { get; set; } = new GameInfoModelView();
        public ButtonOption()
        {
            InitializeComponent();
            // Configuraciones por defecto para que no nazca vacío
            Titulo = "NIVEL";
            ColorNivel = Color.Green;
            
            // L-T-R-B: Izquierda, Arriba, Derecha, Abajo
            // Un margen de 10 en Top y Bottom creará una separación de 20px entre botones
            this.Margin = new Padding(0, 5, 0, 5);
        }

        private void ButtonDesign_Click(object sender, EventArgs e)
        {
            ConsultarConfiguracionBoton?.Invoke(ConfigurationGame);
        }

    }
}
