using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memorama.Application.Interfaces;
using Memorama.Application.Services;
using Memorama.Controls;

namespace Memorama
{
    public partial class JuegoForm : Form
    {
        private readonly IGameService _gameService;
        public JuegoForm(IGameService gameService)
        {
            InitializeComponent();
            _gameService = gameService; // Guardamos la referencia que nos mandó Program.cs

            // Suscribirnos a los eventos del servicio
            _gameService.OnCartaRevelada = (idx, val) => ActualizarBoton(idx, val);
            _gameService.OnParejaEncontrada = (idx1, idx2) => MarcarPareja(idx1, idx2);
            _gameService.OnParejaNoEncontrada = (idx1, idx2) => OcultarPareja(idx1, idx2);
            _gameService.OnPartidaFinalizada = () => MessageBox.Show("¡Ganaste!");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            panelTablero.Controls.Clear();
            _gameService.IniciarNuevaPartida(20);

            // Generación automática de botones
            for (int i = 0; i < 20; i++)
            {
                var btn = new MemoryButton(i);
                btn.Click += (s, ev) => _gameService.SeleccionarCarta(btn.Indice);
                panelTablero.Controls.Add(btn);
            }
            timer_partida.Start();
        }
        private void timer_partida_Tick_1(object sender, EventArgs e)
        {
            _gameService.AvanzarTiempo();
            label_tiempo.Text = "Tiempo: " + _gameService.Segundos + "s";
            label2.Text = _gameService.Intentos.ToString();
        }

        // Métodos de ayuda para la UI
        private void ActualizarBoton(int indice, int valor)
        {
            var btn = (MemoryButton)panelTablero.Controls[indice];
            btn.Revelar(valor);
        }

        private void MarcarPareja(int idx1, int idx2)
        {
            ((MemoryButton)panelTablero.Controls[idx1]).MarcarComoEncontrado();
            ((MemoryButton)panelTablero.Controls[idx2]).MarcarComoEncontrado();
        }

        private void OcultarPareja(int idx1, int idx2)
        {
            ((MemoryButton)panelTablero.Controls[idx1]).Ocultar();
            ((MemoryButton)panelTablero.Controls[idx2]).Ocultar();
        }


    }
}
