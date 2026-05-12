using MaterialSkin;
using MaterialSkin.Controls;
using Memorama.Application.Constants;
using Memorama.Application.DTOs;
using Memorama.Application.DTOs.Records;
using Memorama.Application.Interfaces;
using Memorama.Controls;
using Memorama.Controls.Components;
using Memorama.Domain.Enums;
using Memorama.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memorama
{
    public partial class MenuPrincipal : MaterialForm
    {
        private readonly IGameService _gameService;//Lo uso para luego mandarle la inyección del servicio al form que invoque jaja
        private readonly IPersistenceService _dbManager;
        private readonly IMotivationService _motivatioService;
        private LoadingComponent _loading;

        // Congela el dibujado a nivel de Windows
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, bool wParam, int lParam);
        private const int WM_SETREDRAW = 11;

        public MenuPrincipal(IGameService gameService, IPersistenceService dbManager, IMotivationService motivationService)
        {
            InitializeComponent();

            _gameService = gameService;
            _dbManager = dbManager;
            _motivatioService = motivationService;

            //Inicio de Sintaxis basica para MaterialSkin.2
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green800, Primary.Green900, Primary.Green500, Accent.Green400, TextShade.WHITE);
            //Fin de Sintaxis basica para MaterialSkin.2

            _loading = new LoadingComponent();
            _loading.Dock = DockStyle.Fill;
            _loading.Visible = true;
            Controls.Add(_loading);
            _loading.BringToFront();

            DoubleBuffered = true;
            Load += MenuPrincipal_load;
        }

        private async void MenuPrincipal_load(object sender, EventArgs e)
        {
            // Forzar que el loading se pinte antes de congelar
            _loading.Refresh();
            await Task.Yield();

            // ── Congelar dibujado del form completo ──
            SendMessage(Handle, WM_SETREDRAW, false, 0);

            await Task.Delay(2000);

            List<GameRecordDTO> Top5Record = _motivatioService.ConsultarHistoricos(5);

            var _MenuBotones = new OptionMenu();
            //creamos el componente de Historics una vez al inicio
            var _Historics = new HistoricsComponent(Top5Record);

            var selector = new ThemeSelectorComponent();

            selector.Visible = false;
            this.Controls.Add(selector);
            
            selector.Location = new Point((this.Width - selector.Width) / 2, (this.Height - selector.Height) / 2);
            selector.BringToFront();

            _Historics.Dock = DockStyle.Fill;
            _Historics.Visible = false;
            _MenuBotones.Dock = DockStyle.Fill;// <--- aqui hacemos que se llene con el ancho dispoible

            

            //Primero evaluamos, ¿El usuario presionó Historicos?
            _MenuBotones.OnHistorics += async (sender2, ev) =>
            {
                _loading.Visible = true;
                _loading.BringToFront();
                await Task.Delay(400);
                lblcreditos.Hide();
                _MenuBotones.Hide();
                _Historics.Show();
                _Historics.BringToFront();
                await Task.Delay(100);
                _loading.Visible = false;
            };

            _Historics.OnRegresar += async (sender2, ev) =>
            {
                _loading.Visible = true;
                _loading.BringToFront();
                await Task.Delay(400);
                lblcreditos.Show();
                _MenuBotones.Show();
                _Historics.Hide();
                await Task.Delay(100);
                _loading.Visible = false;
            };

            tableroLayoutPanel.Controls.Add(_Historics, 0, 3);
            tableroLayoutPanel.Controls.Add(_MenuBotones, 0, 3);

            //Si el usuario no presionó la opcion de ver los historicos, entonces la ejecucion sigue normal
            List<MenuButtonModelView> BotonesDisponibles = new List<MenuButtonModelView>
            {
                new MenuButtonModelView { _ModoDeJuego = "FÁCIL",      _CartasTotales = 16, _Segundos = 180, ColorHex = "#D5EDDF" },
                new MenuButtonModelView { _ModoDeJuego = "INTERMEDIO", _CartasTotales = 32, _Segundos = 120, ColorHex = "#F1F1D0" },
                new MenuButtonModelView { _ModoDeJuego = "DÍFICIL",    _CartasTotales = 50, _Segundos =  90, ColorHex = "#FADAD5" }
            };
            _MenuBotones.SetConfiguracion(BotonesDisponibles);

            _MenuBotones.ConsultarConfiguracionDePartida += async (config) =>
            {
                _loading.Visible = true;
                _loading.BringToFront();
                await Task.Delay(500);

                List<string> Temas = new List<string> { "Action", "Alert", "Av", "Communication", "Content", "Device", "Editor", "File", "Hardware", "Home", "Image", "Maps","Navigation","Notification","Places","Social"};
                selector.ConfigurarTemas(Temas);

                _loading.Visible = false;

                selector.Visible = true;
                selector.BringToFront();

                selector.OnTemaSeleccionado += async (temaElegido) =>
                {
                    selector.Visible = false;
                    
                    _loading.Visible = true;
                    _loading.BringToFront();
                    await Task.Delay(500);

                    config.Tema = (CategoriaIcono)Enum.Parse(typeof(CategoriaIcono), temaElegido);

                    JuegoForm TableroJuego = new JuegoForm(_gameService, config, _dbManager, _motivatioService);
                    TableroJuego.FormClosed += (sender2, arg) =>
                    {
                        MenuPrincipal nuevoMenu = new MenuPrincipal(_gameService, _dbManager, _motivatioService);
                        Program.contexto.MainForm = nuevoMenu;
                        nuevoMenu.Show();
                    };
                    Program.contexto.MainForm = TableroJuego;
                    TableroJuego.Show();
                    Dispose();
                    Close();
                };
            };

            //Aqui ya empieza lo que yo he cambiado, ademas de algunos cambios anteriores, pero pequeños

            panel1.BringToFront();
            tableroLayoutPanel.Parent = panel1;
            tableroLayoutPanel.BackColor = Color.Transparent;

            lblTitulo.Parent = panel1;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Anchor = AnchorStyles.Bottom;
            lblTitulo.Font = new Font("Century Gothic", 72, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 64, 0);
            lblTitulo.AutoSize = true;
            tableroLayoutPanel.SetRow(lblTitulo, 1);
            tableroLayoutPanel.SetColumn(lblTitulo, 0);
            lblTitulo.Location = new Point((panel1.Width - lblTitulo.Width) / 2, 20);
            lblTitulo.BringToFront();

            lblcreditos.BackColor = Color.Transparent;
            lblcreditos.Anchor = AnchorStyles.None;
            lblcreditos.Font = new Font("Century Gothic", 24, FontStyle.Regular);
            lblcreditos.ForeColor = Color.FromArgb(0, 64, 0);
            lblcreditos.AutoSize = true;
            tableroLayoutPanel.SetRow(lblcreditos, 2);
            tableroLayoutPanel.SetColumn(lblcreditos, 0);
            lblcreditos.BringToFront();

            _MenuBotones.BackColor = Color.Transparent;
            _MenuBotones.Size = new Size(400, 250);

            // ── Descongelar: el form se pinta completo de una sola vez ─────
            SendMessage(Handle, WM_SETREDRAW, true, 0);
            Invalidate(true);   // fuerza repintado completo de todos los hijos

            // Loading sigue encima durante ese primer paint
            _loading.BringToFront();
            await Task.Delay(150);
            _loading.Visible = false;
        }
    }
}