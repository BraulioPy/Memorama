using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memorama.Controls.Components
{
    public partial class LoadingComponent : UserControl
    {
        public LoadingComponent()
        {
            InitializeComponent();

                this.Dock = DockStyle.Fill;
                this.BackColor = Color.FromArgb(200, 0, 0, 0); // Negro semitransparente
                ConfigurarDiseno();
        }
        private void ConfigurarDiseno()
        {
            Label lblCargando = new Label
            {
                Text = "Cargando aventura...",
                Font = new Font("Bahnschrift", 22, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                BackColor = Color.Transparent
            };
            this.Controls.Add(lblCargando);

            // Centrar el texto
            this.Resize += (s, e) => {
                lblCargando.Left = (this.Width - lblCargando.Width) / 2;
                lblCargando.Top = (this.Height - lblCargando.Height) / 2;
            };
        }
    }
}
