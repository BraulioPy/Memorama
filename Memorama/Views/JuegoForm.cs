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
using Memorama.Domain.ValueObjects;
using MaterialSkin;
using MaterialSkin.Controls;
using Memorama.Application.Constants;
using Memorama.Application.DTOs.Records;
using System.Drawing.Text;
namespace Memorama
{
    public partial class JuegoForm : MaterialForm
    {
        private readonly IGameService _gameService;
        private readonly GameInfoModelView _gameInfo;
        private readonly IPersistenceService _dbManager;
        private readonly JuegoUIManager _uiManager;

        public JuegoForm(IGameService gameService, GameInfoModelView gameInfo, IPersistenceService dbManager)
        {
            InitializeComponent();

            _gameService = gameService; // Guardamos la referencia que nos mandó Program.cs
            _gameInfo = gameInfo; // Guardamos la configuración del juego que nos mandó MenuPrincipal.cs
            _dbManager = dbManager;
            _uiManager = new JuegoUIManager(this); // Creamos una instancia del gestor de UI, pasándole el formulario actual

            //aqui ya empiezan los cambios que hice yo

            this.WindowState = FormWindowState.Maximized;

            //le asignamos .parent a cada componente para poder manipularlos, ya que con el material form es complicado cambiarlos
            panelTablero.Parent = PanelFondo;
            label_tiempo.Parent = PanelFondo;
            n_intentos.Parent = PanelFondo;
            Intentos.Parent = PanelFondo;
            label_Info.Parent = PanelFondo;
            button21.Parent = PanelFondo;

            //Configuracion del boton para que se vea transparente al mometo de poner el cursor en el
            button21.FlatStyle = FlatStyle.Flat;
            button21.FlatAppearance.BorderColor = Color.White;
            button21.FlatAppearance.BorderSize = 2;
            button21.BackColor = Color.Transparent;
            button21.ForeColor = Color.White;
            button21.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            button21.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 0, 0);
            button21.FlatAppearance.MouseDownBackColor = Color.FromArgb(120, 255, 255, 255);

            panelTablero.BackColor = Color.Transparent;
            button21.BackColor = Color.Transparent;

            Transparente(label_Info);
            Transparente(label_tiempo);
            Transparente(n_intentos);
            Transparente(Intentos);

            //Dibuja la imagen de fondo en la posicion correcta para simular transparencia
            panelTablero.Paint += (s, e) =>
            {
                Point loc = PanelFondo.PointToClient(panelTablero.PointToScreen(Point.Empty));
                e.Graphics.DrawImage(
                    PanelFondo.BackgroundImage,
                    new Rectangle(0, 0, panelTablero.Width, panelTablero.Height),
                    new Rectangle(
                        loc.X *PanelFondo.BackgroundImage.Width/PanelFondo.Width,
                        loc.Y*PanelFondo.BackgroundImage.Height/PanelFondo.Height,
                        panelTablero.Width*PanelFondo.BackgroundImage.Width/PanelFondo.Width,
                        panelTablero.Height*PanelFondo.BackgroundImage.Height/PanelFondo.Height),
                    GraphicsUnit.Pixel
                    );
            };

            //Se ejecuta cuando el form ya está completamente cargado y maximizado, ahí es donde acomodamos todo con las coordenadas correctas.
            this.Load += (s, e) =>
            {
                panelTablero.Location = new Point(
                    (PanelFondo.Width - panelTablero.Width) / 2,
                    (PanelFondo.Height-panelTablero.Height)/2+70);

                button21.Location = new Point(
                    panelTablero.Left+(panelTablero.Width-button21.Width)/2,
                    panelTablero.Top-button21.Height-10
                    );

                Font Tipografia = new Font("Segoe UI", 20, FontStyle.Bold);

                label_Info.Font = Tipografia;
                label_tiempo.Font = Tipografia;
                n_intentos.Font = Tipografia;
                Intentos.Font = Tipografia;

                label_Info.Location = new Point(20, 20);
                label_tiempo.Location = new Point(20, 120);
                Intentos.Location = new Point(20,75);
                n_intentos.Location = new Point(Intentos.Right+10, 75);
            };


            //aqui terminan :3


            //Inicio de Sintaxis basica para MaterialSkin.2
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green800,Primary.Green900,Primary.Green500,Accent.Green400,TextShade.WHITE);
            ////Fin de Sintaxis basica para MaterialSkin.2

            // Suscribirnos a los eventos del servicio
            _gameService.OnCartaRevelada = (idx, val) => ActualizarBoton(idx, val);
            _gameService.OnParejaEncontrada = (idx1, idx2) => MarcarPareja(idx1, idx2);
            _gameService.OnParejaNoEncontrada = (idx1, idx2) => OcultarPareja(idx1, idx2);
            // En el constructor de JuegoForm.cs
            _gameService.OnPartidaFinalizada = () =>
            {
                timer_partida.Stop(); // IMPORTANTE: Detenemos el Tick físicamente
                GameRecordDTO gameFinishedData = new GameRecordDTO()
                {
                    ModoDeJuego = _gameInfo.ModoDeJuego,
                    CartasTotales = _gameInfo.CartasTotales,
                    SegundosUsados = _gameService.Segundos,
                    SegundosTotales = _gameInfo.Segundos,
                    IntentosUsados = _gameService.Intentos,
                    IntentosTotales = _gameInfo.Intentos
                };
                List<GameRecordDTO> ExistingRecordData = _dbManager.Load<List<GameRecordDTO>>(StorageKeys.Records) ?? new List<GameRecordDTO>();

                // Consultamos al servicio para saber por qué terminó
                if (_gameService.Segundos <= 0)
                {
                    gameFinishedData.EsVictoria = false;
                    MessageBox.Show("¡Game Over! Se acabó el tiempo.");
                    this.Close(); // Cerramos el formulario para volver al menú principal
                }
                else
                {
                    if (_gameService.Intentos > _gameInfo.Intentos)
                    {
                        gameFinishedData.EsVictoria = false;
                        MessageBox.Show($"¡Has excedido el numero de {_gameInfo.Intentos} intentos!");
                        this.Close();
                    }
                    else {
                        gameFinishedData.EsVictoria = true;
                        MessageBox.Show("¡Felicidades! Completaste el tablero.");
                        this.Close();
                    }
                }
                ExistingRecordData.Add(gameFinishedData);
                _dbManager.Save(StorageKeys.Records, ExistingRecordData);
                button21.Visible = true; // Volvemos a mostrar el botón de inicio[cite: 1]
            };
        }

        private void button21_Click(object sender, EventArgs e)
        {
            panelTablero.Controls.Clear();
            _gameService.IniciarNuevaPartida(_gameInfo.CartasTotales, _gameInfo.Segundos, _gameInfo.Intentos);

            //YIYI cambios

            int btnSize = 80, espaciado = 5;

            int columnas = (_gameInfo.CartasTotales == 16) ? 4 : (_gameInfo.CartasTotales == 32) ? 8 : (_gameInfo.CartasTotales == 50) ? 10 : 4;
            //es para calcular automaticamente las columnas para una cuadricula mas cuadrada

            panelTablero.Width = columnas * (btnSize + espaciado*2) + espaciado*2;
            //ajusta el ancho del tablero para que quepan exctamente las columnas

            panelTablero.Left = (PanelFondo.Width - panelTablero.Width) / 2;
            //recentra el tablero despues de cambiar el ancho

            //Fin YIYI cambios

            // Generación automática de botones
            for (int i = 0; i < _gameInfo.CartasTotales; i++)
            {
                var btn = new MemoryButton(i);
                btn.Margin = new Padding(espaciado);
                btn.Click += (s, ev) => _gameService.SeleccionarCarta(btn.Indice);
                panelTablero.Controls.Add(btn);
            }
            //YIYIcambio
            panelTablero.Invalidate();
            timer_partida.Start();
            button21.Visible = false;

            // Forma súper rápida de mostrar un aviso tipo "Logro"
            _uiManager.MostrarAviso("¡NIVEL SUPERADO! Eres un crack 🏆🎉", 2);
        }
        private void timer_partida_Tick_1(object sender, EventArgs e)
        {
            _gameService.AvanzarTiempo();
            label_tiempo.Text = _gameService.Segundos >= 60 ? ("Tiempo Restante: " + (_gameService.Segundos / 60) + "min" + "-" + (_gameService.Segundos - (_gameService.Segundos/60)*60) + "s") : "Tiempo Restante: " + (_gameService.Segundos + "s");
            n_intentos.Text = _gameService.Intentos.ToString() + " [ " + _gameInfo.Intentos.ToString() + " max. ]";
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
        private void Transparente(Label label)
        {
            label.Paint += (s, e) =>
            {
                Point loc = PanelFondo.PointToClient(label.PointToScreen(Point.Empty));
                e.Graphics.DrawImage(
                    PanelFondo.BackgroundImage,
                    new Rectangle(0, 0, label.Width, label.Height),
                    new Rectangle(
                        loc.X * PanelFondo.BackgroundImage.Width / PanelFondo.Width,
                        loc.Y * PanelFondo.BackgroundImage.Height / PanelFondo.Height,
                        label.Width * PanelFondo.BackgroundImage.Width / PanelFondo.Width,
                        label.Height * PanelFondo.BackgroundImage.Height / PanelFondo.Height),
                    GraphicsUnit.Pixel);
                e.Graphics.DrawString(label.Text, label.Font, Brushes.White, 0, 0);
            };
        }
    }
}
