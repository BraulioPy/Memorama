namespace Memorama
{
    partial class JuegoForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JuegoForm));
            this.timer_partida = new System.Windows.Forms.Timer(this.components);
            this.PanelFondo = new System.Windows.Forms.Panel();
            this.panelTablero = new System.Windows.Forms.FlowLayoutPanel();
            this.button21 = new System.Windows.Forms.Button();
            this.n_intentos = new System.Windows.Forms.Label();
            this.Intentos = new System.Windows.Forms.Label();
            this.label_tiempo = new System.Windows.Forms.Label();
            this.label_Info = new System.Windows.Forms.Label();
            this.PanelFondo.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer_partida
            // 
            this.timer_partida.Interval = 1000;
            this.timer_partida.Tick += new System.EventHandler(this.timer_partida_Tick_1);
            // 
            // PanelFondo
            // 
            this.PanelFondo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelFondo.BackgroundImage")));
            this.PanelFondo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelFondo.Controls.Add(this.panelTablero);
            this.PanelFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelFondo.Location = new System.Drawing.Point(3, 64);
            this.PanelFondo.Name = "PanelFondo";
            this.PanelFondo.Size = new System.Drawing.Size(591, 307);
            this.PanelFondo.TabIndex = 2;
            // 
            // panelTablero
            // 
            this.panelTablero.AutoScroll = true;
            this.panelTablero.BackColor = System.Drawing.Color.Transparent;
            this.panelTablero.Location = new System.Drawing.Point(5, 64);
            this.panelTablero.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelTablero.Name = "panelTablero";
            this.panelTablero.Size = new System.Drawing.Size(800, 450);
            this.panelTablero.TabIndex = 0;
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.Color.Transparent;
            this.button21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button21.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button21.FlatAppearance.BorderSize = 2;
            this.button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button21.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button21.ForeColor = System.Drawing.Color.White;
            this.button21.Location = new System.Drawing.Point(207, 19);
            this.button21.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(110, 41);
            this.button21.TabIndex = 7;
            this.button21.Text = "Iniciar";
            this.button21.UseVisualStyleBackColor = false;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // n_intentos
            // 
            this.n_intentos.AutoSize = true;
            this.n_intentos.BackColor = System.Drawing.Color.Transparent;
            this.n_intentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.n_intentos.ForeColor = System.Drawing.Color.White;
            this.n_intentos.Location = new System.Drawing.Point(405, 33);
            this.n_intentos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.n_intentos.Name = "n_intentos";
            this.n_intentos.Size = new System.Drawing.Size(33, 20);
            this.n_intentos.TabIndex = 8;
            this.n_intentos.Text = "......";
            // 
            // Intentos
            // 
            this.Intentos.AutoSize = true;
            this.Intentos.BackColor = System.Drawing.Color.Transparent;
            this.Intentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Intentos.ForeColor = System.Drawing.Color.White;
            this.Intentos.Location = new System.Drawing.Point(455, 33);
            this.Intentos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Intentos.Name = "Intentos";
            this.Intentos.Size = new System.Drawing.Size(72, 20);
            this.Intentos.TabIndex = 9;
            this.Intentos.Text = "Intentos:";
            // 
            // label_tiempo
            // 
            this.label_tiempo.AutoSize = true;
            this.label_tiempo.BackColor = System.Drawing.Color.Transparent;
            this.label_tiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tiempo.ForeColor = System.Drawing.Color.White;
            this.label_tiempo.Location = new System.Drawing.Point(148, 19);
            this.label_tiempo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_tiempo.Name = "label_tiempo";
            this.label_tiempo.Size = new System.Drawing.Size(31, 20);
            this.label_tiempo.TabIndex = 10;
            this.label_tiempo.Text = "0.0";
            // 
            // label_Info
            // 
            this.label_Info.AutoSize = true;
            this.label_Info.BackColor = System.Drawing.Color.Transparent;
            this.label_Info.Location = new System.Drawing.Point(3, 24);
            this.label_Info.Name = "label_Info";
            this.label_Info.Size = new System.Drawing.Size(140, 13);
            this.label_Info.TabIndex = 11;
            this.label_Info.Text = "Informacion de la partida:";
            // 
            // JuegoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 374);
            this.Controls.Add(this.label_Info);
            this.Controls.Add(this.label_tiempo);
            this.Controls.Add(this.Intentos);
            this.Controls.Add(this.n_intentos);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.PanelFondo);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JuegoForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.PanelFondo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer_partida;
        private System.Windows.Forms.Panel PanelFondo;
        private System.Windows.Forms.FlowLayoutPanel panelTablero;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Label n_intentos;
        private System.Windows.Forms.Label Intentos;
        private System.Windows.Forms.Label label_tiempo;
        private System.Windows.Forms.Label label_Info;
    }
}

