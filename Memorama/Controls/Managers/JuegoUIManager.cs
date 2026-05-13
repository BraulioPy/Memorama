using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class JuegoUIManager
{
    private readonly Control _contenedor;

    public JuegoUIManager(Control contenedor)
    {
        _contenedor = contenedor;
    }

    public void MostrarAviso(string mensaje, int segundos, Control panelTablero)
    {
        int duracionMs = segundos * 1000;

        // 1. Creamos el Panel (La notificación)
        Panel panelAviso = new Panel();
        panelAviso.Size = new Size(280, 45); // Más pequeña y fina para que parezca notificación
        panelAviso.BackColor = Color.FromArgb(200, 214, 234, 248); // Azul Pastel suave con transparencia
        panelAviso.BorderStyle = BorderStyle.None;

        // 2. TRUCO: BORDES REDONDEADOS
        // Esto corta las esquinas del panel
        panelAviso.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelAviso.Width, panelAviso.Height, 20, 20));

        // 3. LA ETIQUETA (Sin MaterialLabel para evitar que fuerce el color blanco/negro)
        Label lblTexto = new Label();
        lblTexto.Text = mensaje;
        lblTexto.ForeColor = Color.FromArgb(44, 62, 80); // Un gris muy oscuro casi azul para el texto
        lblTexto.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Letra más fina y moderna
        lblTexto.TextAlign = ContentAlignment.MiddleCenter;
        lblTexto.Dock = DockStyle.Fill;
        lblTexto.BackColor = Color.Transparent; // Para que se vea el fondo pastel

        panelAviso.Controls.Add(lblTexto);
        _contenedor.Controls.Add(panelAviso);

        // 4. UBICACIÓN INTELIGENTE (Responsiva al tablero)
        int margen = 20;
        int posX, posY;
        string direccionAnimacion = "Bajar"; // Por defecto baja desde el top

        // Verificamos si el aviso cabe arriba del tablero
        if (panelTablero.Top > (panelAviso.Height + margen + 10))
        {
            // Hay espacio arriba: Centrado y con aire respecto al tablero
            posX = (_contenedor.Width - panelAviso.Width) / 2;
            posY = panelTablero.Top - panelAviso.Height - margen;
            direccionAnimacion = "Bajar";
        }
        else if ((_contenedor.Height - panelTablero.Bottom) > (panelAviso.Height + margen + 10))
        {
            // No hay espacio arriba, pero hay espacio ABAJO
            posX = (_contenedor.Width - panelAviso.Width) / 2;
            posY = panelTablero.Bottom + margen;
            direccionAnimacion = "Subir";
        }
        else
        {
            // El tablero es gigante (Modo Rétame): Lo mandamos a la DERECHA
            posX = _contenedor.Width - panelAviso.Width - margen;
            posY = margen + 50; // Un poco abajo del título
            direccionAnimacion = "Izquierda";
        }

        panelAviso.Location = new Point(posX, posY);
        panelAviso.BringToFront();

        // 5. ANIMACIÓN ADAPTATIVA
        AnimarEntradaDinamica(panelAviso, posX, posY, direccionAnimacion);

        var timer = new Timer { Interval = duracionMs };
        timer.Tick += (s, e) => {
            _contenedor.Controls.Remove(panelAviso);
            panelAviso.Dispose();
            timer.Stop();
            timer.Dispose();
        };
        timer.Start();
    }

    // Importamos la función para redondear esquinas
    [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
    private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

    private void AnimarEntradaDinamica(Control control, int destinoX, int destinoY, string direccion)
    {
        Timer t = new Timer { Interval = 15 };

        // Configuración inicial según dirección
        if (direccion == "Bajar") control.Top = destinoY - 30;
        else if (direccion == "Subir") control.Top = destinoY + 30;
        else if (direccion == "Izquierda") control.Left = destinoX + 30;

        t.Tick += (s, e) => {
            bool llego = false;
            if (direccion == "Bajar")
            {
                if (control.Top < destinoY) control.Top += 3; else llego = true;
            }
            else if (direccion == "Subir")
            {
                if (control.Top > destinoY) control.Top -= 3; else llego = true;
            }
            else if (direccion == "Izquierda")
            {
                if (control.Left > destinoX) control.Left -= 3; else llego = true;
            }

            if (llego) { t.Stop(); t.Dispose(); }
        };
        t.Start();
    }

    public void Transparente(Panel PanelFondo , Label label)
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