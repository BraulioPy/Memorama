using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memorama.Controls.Components
{
    public partial class ThemeSelectorComponent : UserControl
    {
        public event Action<string> OnTemaSeleccionado;
        
        public ThemeSelectorComponent()
        {
            InitializeComponent();
            Diseño();
            this.SizeChanged += (s, e) => RedondearBordes(30);
            this.BackColor = Color.WhiteSmoke;
            ConfigurarBoton();
        }
        private void RedondearBordes(int radio)
        {
            GraphicsPath gp = new GraphicsPath();
            // Creamos un rectángulo con bordes redondeados
            gp.AddArc(0, 0, radio, radio, 180, 90);
            gp.AddArc(this.Width - radio, 0, radio, radio, 270, 90);
            gp.AddArc(this.Width - radio, this.Height - radio, radio, radio, 0, 90);
            gp.AddArc(0, this.Height - radio, radio, radio, 90, 90);

            this.Region = new Region(gp);
        }
        private void Diseño()
        {
            label1.Text = "SELECCIONA UN TEMA";
            label1.Font = new Font("Times New Roman", 28, FontStyle.Italic);
            label1.Anchor = AnchorStyles.Top;
            label1.ForeColor = Color.FromArgb(0, 64, 0); // El mismo verde oscuro que usas
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.AutoSize = false;
            label1.Dock = DockStyle.None; // Lo pega arriba
            label1.Height = 50; // Le da aire
        }
        private void ConfigurarBoton()
        {
            // Primero verificamos que el botón del diseñador exista
            if (buttonRegresar == null) return;

            buttonRegresar.UseVisualStyleBackColor = false;

            // Se hace visible
            buttonRegresar.Visible = true;

            // Tamaño y posición
            buttonRegresar.Width = 160;
            buttonRegresar.Height = 35;
            buttonRegresar.Location = new Point(this.Width - 180, 15);
            buttonRegresar.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Estilo de colores
            buttonRegresar.BackColor = Color.FromArgb(27, 94, 32);
            buttonRegresar.ForeColor = Color.White;
            buttonRegresar.FlatStyle = FlatStyle.Flat;
            buttonRegresar.FlatAppearance.BorderSize = 0;

            // Ajustamos colores de interacción para que no se pierda el estilo
            buttonRegresar.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 125, 50); // Verde más claro al pasar
            buttonRegresar.FlatAppearance.MouseDownBackColor = Color.FromArgb(10, 50, 15);  // Verde oscuro al click

            buttonRegresar.Cursor = Cursors.Hand;

            // Fuente y Texto
            buttonRegresar.Font = new Font("Bahnschrift", 11, FontStyle.Bold);
            buttonRegresar.Text = "← Regresar            \n\n";
            buttonRegresar.TextAlign = ContentAlignment.MiddleCenter;

            // Bordes redondeados
            GraphicsPath buttonPath = new GraphicsPath();
            int r = 25;
            buttonPath.AddArc(0, 0, r, r, 180, 90);
            buttonPath.AddArc(buttonRegresar.Width - r, 0, r, r, 270, 90);
            buttonPath.AddArc(buttonRegresar.Width - r, buttonRegresar.Height - r, r, r, 0, 90);
            buttonPath.AddArc(0, buttonRegresar.Height - r, r, r, 90, 90);
            buttonPath.CloseFigure();

            buttonRegresar.Region = new Region(buttonPath);

            // Evento para cerrar
            buttonRegresar.Click += (s, e) => { this.Visible = false; };
        }
        private static readonly Dictionary<string, string> _emojis = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "todos",         "🎯" },
            { "action",        "⚡" },
            { "alert",         "🔔" },
            { "av",            "🎬" },
            { "communication", "💬" },
            { "content",       "📝" },
            { "device",        "💻" },
            { "editor",        "✏️" },
            { "file",          "📁" },
            { "hardware",      "🖥️" },
            { "home",          "🏠" },
            { "image",         "🖼️" },
            { "maps",          "🗺️" },
            { "navigation",    "🧭" },
            { "notification",  "🔔" },
            { "places",        "📍" },
            { "social",        "👥" },
        };
        public void ConfigurarTemas(List<string> listaTemas)
        {
            flowLayoutPanel1.Controls.Clear();

            flowLayoutPanel1.Controls.Clear();

            foreach (var nombreTema in listaTemas)
            {
                Panel tarjeta = new Panel { Size = new Size(130, 150), Margin = new Padding(10), BackColor = Color.White };

                string key = nombreTema.ToLower().Trim();
                string emoji = _emojis.TryGetValue(key, out string e) ? e : "📦";

                Button btnIcono = new Button
                {
                    Size = new Size(130, 100),
                    Dock = DockStyle.Top,
                    FlatStyle = FlatStyle.Flat,
                    Text = emoji,
                    Font = new Font("Segoe UI Emoji", 36),
                    BackColor = Color.White,
                    Cursor = Cursors.Hand,
                    AutoEllipsis = false
                };
                btnIcono.FlatAppearance.BorderSize = 0;
                btnIcono.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 245, 245);

                Label lblTexto = new Label
                {
                    Text = nombreTema.ToUpper(),
                    Dock = DockStyle.Bottom,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Bahnschrift", 9, FontStyle.Bold),
                    ForeColor = Color.Gray
                };

                btnIcono.Click += (s, ev) => OnTemaSeleccionado?.Invoke(nombreTema);

                tarjeta.Controls.Add(lblTexto);
                tarjeta.Controls.Add(btnIcono);
                flowLayoutPanel1.Controls.Add(tarjeta);
            }
        }
    }
}
