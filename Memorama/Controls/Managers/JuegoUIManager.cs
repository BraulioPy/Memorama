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

    public void MostrarAviso(string mensaje, int segundos)
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

        // 4. UBICACIÓN (Centrado horizontal, un cuarto arriba en Y)
        int posX = (_contenedor.Width - panelAviso.Width) / 2;
        int posY = (_contenedor.Height - panelAviso.Height) / 5; // Un poco más arriba para que no estorbe
        panelAviso.Location = new Point(posX, posY);

        panelAviso.BringToFront();

        // 5. ANIMACIÓN Y AUTODESTRUCCIÓN
        AnimarEntrada(panelAviso, posY);

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

    private void AnimarEntrada(Control control, int destinoY)
    {
        control.Top = destinoY - 30; // Empieza un poco más arriba
        Timer t = new Timer { Interval = 15 };
        t.Tick += (s, e) => {
            if (control.Top < destinoY) control.Top += 2; // Baja suavemente
            else { t.Stop(); t.Dispose(); }
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