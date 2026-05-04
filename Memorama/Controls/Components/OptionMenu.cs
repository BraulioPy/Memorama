using Memorama.Controls.Components;
using Memorama.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Memorama.Controls
{
    public partial class OptionMenu : UserControl
    {
        public event Action<GameInfoModelView> ConsultarConfiguracionDePartida;
        public event EventHandler OnHistorics;
        public OptionMenu()
        {
            InitializeComponent();
        }
        public void SetConfiguracion(List<MenuButtonModelView> Botones)
        {

            for (int i = 0; i < Botones.Count; i++)
            {
                var botonWidget = new ButtonOption() {
                    Titulo = Botones[i]._ModoDeJuego,
                    CantidadPares = Botones[i]._Pares,
                    // Convertimos el string de Domain a un Color de UI
                    ColorNivel = ColorTranslator.FromHtml(Botones[i].ColorHex),
                    ConfigurationGame = new GameInfoModelView
                    {
                        CartasTotales = Botones[i]._CartasTotales,
                        Segundos = Botones[i]._Segundos,
                        ModoDeJuego = Botones[i]._ModoDeJuego,
                        ColorHex = Botones[i].ColorHex
                    }
                };

                botonWidget.ConsultarConfiguracionBoton += (config) =>
                {
                    ConsultarConfiguracionDePartida?.Invoke(config);
                };
                ButtonsMenuFlow.Controls.Add(botonWidget);
            }

            //Aqui inician mis cambiosssssss

            var buttonHistorics = new ButtonOption()
            {
                Titulo = "HISTÓRICOS",
                ColorNivel = ColorTranslator.FromHtml("#B0BEC5")
            };
            
            buttonHistorics.ConsultarConfiguracionBoton += (config) =>
            {
                OnHistorics?.Invoke(this, EventArgs.Empty);
            };
            ButtonsMenuFlow.Controls.Add(buttonHistorics);

            //aqui terminannnnnnn 

            ButtonsMenuFlow.Padding = new Padding(0);
            ButtonsMenuFlow.Margin = new Padding(0);

            ButtonsMenuFlow.AutoSize = true;
            ButtonsMenuFlow.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
    }
}
