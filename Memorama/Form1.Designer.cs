namespace Memorama
{
    partial class Form1
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
            this.panelTablero = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_tiempo = new System.Windows.Forms.Label();
            this.button21 = new System.Windows.Forms.Button();
            this.timer_partida = new System.Windows.Forms.Timer(this.components);
            this.panelTablero.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTablero
            // 
            this.panelTablero.Controls.Add(this.label1);
            this.panelTablero.Controls.Add(this.label2);
            this.panelTablero.Controls.Add(this.label3);
            this.panelTablero.Controls.Add(this.label_tiempo);
            this.panelTablero.Controls.Add(this.button21);
            this.panelTablero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTablero.Location = new System.Drawing.Point(0, 0);
            this.panelTablero.Name = "panelTablero";
            this.panelTablero.Size = new System.Drawing.Size(800, 450);
            this.panelTablero.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Intentos:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(96, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "......";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(144, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tiempo Restante:";
            // 
            // label_tiempo
            // 
            this.label_tiempo.AutoSize = true;
            this.label_tiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tiempo.Location = new System.Drawing.Point(316, 0);
            this.label_tiempo.Name = "label_tiempo";
            this.label_tiempo.Size = new System.Drawing.Size(39, 25);
            this.label_tiempo.TabIndex = 3;
            this.label_tiempo.Text = "0.0";
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(361, 3);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(88, 38);
            this.button21.TabIndex = 4;
            this.button21.Text = "Iniciar";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // timer_partida
            // 
            this.timer_partida.Interval = 1000;
            this.timer_partida.Tick += new System.EventHandler(this.timer_partida_Tick_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelTablero);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelTablero.ResumeLayout(false);
            this.panelTablero.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelTablero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_tiempo;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Timer timer_partida;
    }
}

