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
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green800, Primary.Green900, Primary.Green500, Accent.Green400, TextShade.WHITE);
            //Fin de Sintaxis basica para MaterialSkin.2

            var _MenuBotones = new OptionMenu();

            _MenuBotones.Dock = DockStyle.Fill; // <--- aqui hacemos que se llene con el ancho dispoible

            List<MenuButtonModelView> BotonesDisponibles = new List<MenuButtonModelView> {
                new MenuButtonModelView{_ModoDeJuego = "FÁCIL", _CartasTotales = 16,_Segundos = 180, ColorHex = "#D5EDDF" }, //Verde muuuuy clarito
                new MenuButtonModelView{_ModoDeJuego = "INTERMEDIO", _CartasTotales = 32,_Segundos = 120, ColorHex = "#F1F1D0" }, //Amarillo pastel
                new MenuButtonModelView{_ModoDeJuego = "DÍFICIL", _CartasTotales = 50,_Segundos = 90, ColorHex = "#FADAD5" } //Rojo pastel
            };
            _MenuBotones.SetConfiguracion(BotonesDisponibles);
            _MenuBotones.ConsultarConfiguracionDePartida += (config) =>
            {
                JuegoForm TableroJuego = new JuegoForm(_gameService, config);
                TableroJuego.FormClosed += (s, arg) =>{
                    MenuPrincipal nuevoMenu = new MenuPrincipal(_gameService);
                    Program.contexto.MainForm = nuevoMenu;
                    nuevoMenu.Show();
                };
                Program.contexto.MainForm = TableroJuego;
                TableroJuego.Show();

                this.Dispose();
                this.Close();
            };
            tableroLayoutPanel.Controls.Add(_MenuBotones, 0, 3);

            //Aqui ya empieza lo que yo he cambiado, ademas de algunos cambios anteriores, pero pequeños

            panel1.BringToFront();

            tableroLayoutPanel.Parent = panel1;
            tableroLayoutPanel.BackColor = Color.Transparent;

            lblTitulo.Parent = panel1;
            lblTitulo.BackColor = Color.Transparent;

            tableroLayoutPanel.SetRow(lblTitulo, 1);
            tableroLayoutPanel.SetColumn(lblTitulo, 0);

            lblTitulo.Anchor = AnchorStyles.Bottom;

            lblTitulo.Font = new Font("Century Gothic", 72, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0,64,0);
            lblTitulo.AutoSize = true;

            lblTitulo.Location =new Point(
                (panel1.Width-lblTitulo.Width)/2,35
                );
            lblTitulo.BringToFront();

            lblcreditos.BackColor = Color.Transparent;

            tableroLayoutPanel.SetRow(lblcreditos, 2);
            tableroLayoutPanel.SetColumn(lblcreditos, 0);

            lblcreditos.Anchor = AnchorStyles.None;
            lblcreditos.Font = new Font("Century Gothic", 24, FontStyle.Regular);
            lblcreditos.ForeColor = Color.FromArgb(0, 64, 0);
            lblcreditos.AutoSize = true;

            lblcreditos.BringToFront();

            _MenuBotones.BackColor = Color.Transparent;
            _MenuBotones.Size = new Size(400, 250);
        }
    }
}
