using MaterialSkin;
using MaterialSkin.Controls;
using Memorama.Application.Constants;
using Memorama.Application.DTOs.Records;
using Memorama.Application.Interfaces;
using Memorama.Controls;
using Memorama.Controls.Components;
using Memorama.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memorama
{
    public partial class MenuPrincipal : MaterialForm
    {
        private readonly IGameService _gameService;
        private readonly IPersistenceService _dbManager;
        private readonly IMotivationService _motivatioService;
        public MenuPrincipal(IGameService gameService, IPersistenceService dbManager, IMotivationService motivationService)
        {
            InitializeComponent();
      
            _gameService = gameService; //Lo uso para luego mandarle la inyección del servicio al form que invoque jaja
            _dbManager = dbManager;
            _motivatioService = motivationService;
            List<GameRecordDTO> Top5Record = _motivatioService.ConsultarHistoricos(5);

            //Inicio de Sintaxis basica para MaterialSkin.2
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green800, Primary.Green900, Primary.Green500, Accent.Green400, TextShade.WHITE);
            //Fin de Sintaxis basica para MaterialSkin.2

            var _MenuBotones = new OptionMenu();

            //creamos el componente de Historics una vez al inicio
            var _Historics = new HistoricsComponent(Top5Record);
            _Historics.Dock = DockStyle.Fill;
            _Historics.Visible = false;

            _MenuBotones.Dock = DockStyle.Fill; // <--- aqui hacemos que se llene con el ancho dispoible

            //Primero evaluamos, ¿El usuario presionó Historicos?
            _MenuBotones.OnHistorics += (s, ev) =>
            {
                lblcreditos.Hide();
                _MenuBotones.Hide();
                _Historics.Show();
                _Historics.BringToFront();
            };

            _Historics.OnRegresar += (s, e) =>
            {
                lblcreditos.Show();
                _MenuBotones.Show();
                _Historics.Hide();
            };
            tableroLayoutPanel.Controls.Add(_Historics, 0, 3);

            //Si el usuario no presionó la opcion de ver los historicos, entonces la ejecucion sigue normal

            List<MenuButtonModelView> BotonesDisponibles = new List<MenuButtonModelView> {
                new MenuButtonModelView{_ModoDeJuego = "FÁCIL", _CartasTotales = 16,_Segundos = 180, ColorHex = "#D5EDDF" }, //Verde muuuuy clarito
                new MenuButtonModelView{_ModoDeJuego = "INTERMEDIO", _CartasTotales = 32,_Segundos = 120, ColorHex = "#F1F1D0" }, //Amarillo pastel
                new MenuButtonModelView{_ModoDeJuego = "DÍFICIL", _CartasTotales = 50,_Segundos = 90, ColorHex = "#FADAD5" } //Rojo pastel
            };
            _MenuBotones.SetConfiguracion(BotonesDisponibles);
            _MenuBotones.ConsultarConfiguracionDePartida += (config) =>
            {
                JuegoForm TableroJuego = new JuegoForm(_gameService, config, _dbManager, _motivatioService);
                TableroJuego.FormClosed += (s, arg) =>{
                    MenuPrincipal nuevoMenu = new MenuPrincipal(_gameService, _dbManager, _motivatioService);
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
                (panel1.Width-lblTitulo.Width)/2,20
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
