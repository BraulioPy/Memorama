using Memorama.Application.DTOs.Records;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memorama.Controls.Components
{
    public partial class HistoricsComponent : UserControl
    {
        //Evento para avisarle al MenuPrincipal que el usuario quiere regresar
        public event EventHandler OnRegresar;
        private Panel panelContenedor;
        private Panel panelCristal;

        public HistoricsComponent(List<GameRecordDTO> Top5RecordData)
        {
            InitializeComponent();
            //Configuracion en el diseño del HistoricsComponent
            ConfigurarEstiloBase();
            ConfigurarPaneles();
            ConfigurarTitulo();
            ConfigurarTabla();
            ConfigurarBoton();
            //Funcion que muestra los datos de prueba en el DataGridView
            CargarDatosPrueba(Top5RecordData);
        }

        private void ConfigurarEstiloBase()
        {
            this.BackColor = Color.Transparent;
            this.Dock = DockStyle.Fill;
            this.DoubleBuffered = true;
        }

        private void ConfigurarPaneles()
        {
            panelContenedor = new Panel
            {
                Width = 800,
                Height = 250,
                BackColor = Color.Transparent
            };

            this.Resize += (s, e) => {
                panelContenedor.Left = (this.Width - panelContenedor.Width) / 2;
                panelContenedor.Top = (this.Height - panelContenedor.Height) / 2 + 30;
            };

            panelCristal = new Panel
            {
                Parent = panelContenedor,
                Width = panelContenedor.Width,
                Height = panelContenedor.Height,
                BackColor = Color.FromArgb(180, 255, 255, 255)
            };

            panelCristal.Paint += DibujarEfectoCristal;
            this.Controls.Add(panelContenedor);
        }

        private void DibujarEfectoCristal(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath path = new GraphicsPath())
            {
                int radio = 30;
                Rectangle rect = new Rectangle(0, 0, panelCristal.Width - 1, panelCristal.Height - 1);
                path.AddArc(rect.X, rect.Y, radio, radio, 180, 90);
                path.AddArc(rect.X + rect.Width - radio, rect.Y, radio, radio, 270, 90);
                path.AddArc(rect.X + rect.Width - radio, rect.Y + rect.Height - radio, radio, radio, 0, 90);
                path.AddArc(rect.X, rect.Y + rect.Height - radio, radio, radio, 90, 90);
                path.CloseFigure();

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(180, 245, 255, 250)))
                    e.Graphics.FillPath(brush, path);

                using (Pen pen = new Pen(Color.FromArgb(200, 27, 94, 32), 4))
                    e.Graphics.DrawPath(pen, path);
            }
        }

        private void ConfigurarTitulo()
        {
            Label lblTituloHistoricos = new Label
            {
                Parent = panelCristal,
                Text = "✦ Históricos de Partidas ✦",
                Font = new Font("Bahnschrift", 20, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                AutoSize = true,
                Top = 20
            };
            lblTituloHistoricos.Left = (panelCristal.Width - lblTituloHistoricos.Width) / 2;
        }

        private void ConfigurarTabla()
        {
            dgvHistoricos.Parent = panelCristal;
            dgvHistoricos.Dock = DockStyle.None;

            dgvHistoricos.Width = 760;
            dgvHistoricos.Height = 145;
            dgvHistoricos.Top = 60;
            dgvHistoricos.Left = (panelCristal.Width - dgvHistoricos.Width) / 2;

            dgvHistoricos.BackgroundColor = Color.White;
            dgvHistoricos.BorderStyle = BorderStyle.None;
            dgvHistoricos.RowHeadersVisible = false;
            dgvHistoricos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistoricos.AllowUserToAddRows = false;
            dgvHistoricos.ReadOnly = true;
            dgvHistoricos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistoricos.EnableHeadersVisualStyles = false;


            // Encabezados
            dgvHistoricos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(200, 27, 94, 32);
            dgvHistoricos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvHistoricos.ColumnHeadersDefaultCellStyle.Font = new Font("Bahnschrift", 13, FontStyle.Bold);
            dgvHistoricos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Filas Normales
            dgvHistoricos.DefaultCellStyle.Font = new Font("Bahnschrift", 11);
            dgvHistoricos.DefaultCellStyle.ForeColor = Color.Black;
            dgvHistoricos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHistoricos.DefaultCellStyle.BackColor = Color.FromArgb(180, 255, 255, 255);
            dgvHistoricos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 129, 199, 132);
            dgvHistoricos.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Filas Alternadas
            dgvHistoricos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(160, 232, 245, 233);
            dgvHistoricos.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
        }

        private void ConfigurarBoton()
        {
            if (buttonRegresar == null) return;

            buttonRegresar.Parent = panelCristal;
            buttonRegresar.Width = 180;
            buttonRegresar.Height = 40;

            // Botón arriba para dar espacio a la tabla grande
            buttonRegresar.Top = dgvHistoricos.Bottom + 5;
            buttonRegresar.Left = (panelCristal.Width - buttonRegresar.Width) / 2;

            buttonRegresar.BackColor = Color.FromArgb(27, 94, 32);
            buttonRegresar.ForeColor = Color.White;
            buttonRegresar.FlatStyle = FlatStyle.Flat;
            buttonRegresar.Font = new Font("Bahnschrift", 11, FontStyle.Bold);
            buttonRegresar.Text = "← Regresar";

            GraphicsPath buttonPath = new GraphicsPath();
            buttonPath.AddArc(0, 0, 20, 20, 180, 90);
            buttonPath.AddArc(buttonRegresar.Width - 20, 0, 20, 20, 270, 90);
            buttonPath.AddArc(buttonRegresar.Width - 20, buttonRegresar.Height - 20, 20, 20, 0, 90);
            buttonPath.AddArc(0, buttonRegresar.Height - 20, 20, 20, 90, 90);
            buttonRegresar.Region = new Region(buttonPath);
        }

        private void buttonRegresar_Click(object sender, EventArgs e)
        {
            OnRegresar?.Invoke(this, EventArgs.Empty);
        }

        private void CargarDatosPrueba(List<GameRecordDTO> Top5RecordData)
        {
            dgvHistoricos.Columns.Clear();
            dgvHistoricos.Columns.Add("Fecha", "Fecha");
            dgvHistoricos.Columns.Add("Dificultad", "Dificultad");
            dgvHistoricos.Columns.Add("Tiempo", "Tiempo");
            dgvHistoricos.Columns.Add("Intentos", "Intentos");
            if(Top5RecordData != null)
            {
                Top5RecordData.ForEach(data =>
                {
                    dgvHistoricos.Rows.Add(
                        data.FechaDeJuego.ToString(),
                        data.ModoDeJuego,
                        (data.SegundosUsados / 60) + "min" + "-" + (data.SegundosUsados - (data.SegundosUsados / 60) * 60) + "s" + "/" + (data.SegundosTotales / 60) + "min" + "-" + (data.SegundosTotales - (data.SegundosTotales / 60) * 60) + "s",
                        data.IntentosUsados + "/" + data.IntentosTotales);
                });
            }
            else
            {
                dgvHistoricos.Rows.Add(
                    "No",
                    "Hay",
                    "Datos",
                    "Disponibles"
                    );
            }
        }


    }
}