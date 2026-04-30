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
        public event Action<int> ConsultarNivelSeleccionado;
        public OptionMenu()
        {
            InitializeComponent();
        }
        public void SetConfiguracion(List<MenuButtonModelView> Botones)
        {

            for (int i = 0; i < Botones.Count; i++)
            {
                var botonWidget = new ButtonOption() {
                    Titulo = Botones[i]._Titulo,
                    CantidadPares = Botones[i]._Pares,
                    // Convertimos el string de Domain a un Color de UI
                    ColorNivel = ColorTranslator.FromHtml(Botones[i].ColorHex),

                };

                botonWidget.ChecarParesOpcion += (opcion) =>
                {
                    ConsultarNivelSeleccionado?.Invoke(opcion);
                };
                ButtonsMenuFlow.Controls.Add(botonWidget);
            }
        }
    }
}
