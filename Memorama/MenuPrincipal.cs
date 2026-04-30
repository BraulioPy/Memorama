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
using Memorama.Application.Interfaces;
using Memorama.Controls;
using Memorama.Domain.ValueObjects;

namespace Memorama
{
    public partial class MenuPrincipal : MaterialForm
    {
        private readonly IGameService _gameService;
        public MenuPrincipal(IGameService gameService)
        {
            InitializeComponent();
            _gameService = gameService; //Lo uso para luego mandarle la inyección del servicio al form que invoque jaja

            //Inicio de Sintaxis basica para MaterialSkin.2
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            //Fin de Sintaxis basica para MaterialSkin.2

            var _MenuBotones = new OptionMenu();

            _MenuBotones.Dock = DockStyle.Fill; // <--- aqui hacemos que se llene con el ancho dispoible

            List<MenuButtonModelView> BotonesDisponibles = new List<MenuButtonModelView> {
                new MenuButtonModelView{_Titulo = "FÁCIL", _Pares = 8, ColorHex = "#4CAF50" }, //Verde clarito
                new MenuButtonModelView{_Titulo = "INTERMEDIO", _Pares = 16, ColorHex = "#FFC107" }, //(Ámbar/Amarillo mate)
                new MenuButtonModelView{_Titulo = "DÍFICIL", _Pares = 24, ColorHex = "#F44336" } //Rojo Material
            };
            _MenuBotones.SetConfiguracion(BotonesDisponibles);
            _MenuBotones.ConsultarNivelSeleccionado += (pares) =>
            {
                ayudaLabel.Text = $"Nivel seleccionado con {pares} pares.";
            };
            tableroLayoutPanel.Controls.Add(_MenuBotones, 0, 1);
        }
    }
}
