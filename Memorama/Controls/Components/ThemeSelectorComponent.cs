using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Memorama.Controls.Components
{
    public partial class ThemeSelectorComponent : UserControl
    {
        public event Action<string> OnTemaSeleccionado;
        public ThemeSelectorComponent()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(242, 242, 242);
            Diseño();
           this.SizeChanged+=(s,e)=> RedondearBordes(30);
            this.BackColor = Color.WhiteSmoke;
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
        public void ConfigurarTemas(List<string> listaTemas)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var nombreTema in listaTemas)
            {
                MaterialButton btn = new MaterialButton
                {
                    Text = nombreTema,
                    AutoSize = false,
                    Size = new Size(flowLayoutPanel1.Width - 25, 40),
                    Type = MaterialButton.MaterialButtonType.Contained,
                    UseAccentColor = false,
                    Cursor = Cursors.Hand
                };
                btn.Click += (s, e) =>
                {
                    OnTemaSeleccionado?.Invoke(nombreTema);
                };
                flowLayoutPanel1.Controls.Add(btn);
            }
        }
    }
}
