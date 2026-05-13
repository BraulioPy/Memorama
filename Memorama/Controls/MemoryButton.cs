using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memorama.Controls
{
    public class MemoryButton : Button
    {
        //Datos que se necesitaran para animar un "volteo" de carta
        private Timer _timer = new Timer();//este reloj controla la animacion
        private int _animacioncont = 0;//contador de pasos de la animacion
        private bool _shake = false;//ese señala que animacion hacer

        // Propiedad para vincular el botón físico con el objeto 'Carta' del Domain
        private static PrivateFontCollection _fontCollection = new PrivateFontCollection();
        private static Font _iconFont;

        public int Indice { get; private set; }

        public MemoryButton(int indice)
        {
            this.Indice = indice;
            this.Size = new Size(80, 80); // Un poco más grandes para que se vean bien
            this.BackColor = Color.FromArgb(255, 144, 190, 154);
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Font = new Font("Bahnschrift", 16, FontStyle.Bold);
            this.Text = ""; // Empieza oculto
            CargarFuenteMaterial();
        }
        private void CargarFuenteMaterial()
        {
            if (_iconFont != null) return; // Ya está cargada

            try
            {
                // Buscamos en la carpeta 'Resources' dentro de donde se ejecuta el .exe
                string pathFuente = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "MaterialSymbols_28.ttf");

                if (File.Exists(pathFuente))
                {
                    _fontCollection.AddFontFile(pathFuente);
                    _iconFont = new Font(_fontCollection.Families[0], 24f);
                }
                else
                {
                    // Si no existe, usamos una por defecto para no romper el programa
                    _iconFont = new Font("Segoe UI Symbol", 24f);
                }
            }
            catch { _iconFont = new Font("Arial", 24f); }
        }

        public void Revelar(string nombreIcono)
        {
            this.Font = _iconFont;
            this.Text = nombreIcono; // Aquí Google Font dibujará el icono
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
        }

        public void Ocultar()
        {
            this.Text = "";
            this.BackColor = Color.FromArgb(255, 144, 190, 154);
            this.Enabled = true;
            Iniciar_animacion(true);
        }

        public void MarcarComoEncontrado()
        {
            this.BackColor = Color.FromArgb(139,195,74);
            this.ForeColor = Color.White;
            this.Enabled = false; // Ya no se puede cliquear
        }

        //El override significa que estamos reemplazando el comportamiento original del boton
        protected override void OnPaint(PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radio = 30; // tamaño del redondeo
            //Estas 4 lineas dibujan las 4 esquinas redondeadas
            path.AddArc(0, 0, radio, radio, 180, 90);
            path.AddArc(Width - radio, 0, radio, radio, 270, 90);
            path.AddArc(Width - radio, Height - radio, radio, radio, 0, 90);
            path.AddArc(0, Height - radio, radio, radio, 90, 90);

            //Cierra la figura, conectando el ultimo punto del path con el primero
            path.CloseAllFigures();

            //Asigna el path como la region visible del control
            this.Region = new Region(path);
            base.OnPaint(e);
        }
        private void Iniciar_animacion (bool shake)
        {
            _shake = shake;
            _animacioncont= 0;
            _timer.Interval = 5;
            _timer.Tick += (s, e) =>
            {
                _animacioncont++;
                if (_shake)
                {
                    //shake mueve la carta de lado a lado
                    //si el paso es par,cambiamos el margen
                    int offset = (_animacioncont % 2 == 0) ? 5 : -5;
                    this.Margin = new Padding(5 + offset, 5, 5, 5);

                    //despues de 3 pasos la carta regresaa  su lugar  y para el reloj

                    if (_animacioncont >= 3)
                    {
                        this.Margin = new Padding(5);//regresa al margen original
                        _timer.Stop();
                    }
                }
            };
            _timer.Start();
        }
    }
}
