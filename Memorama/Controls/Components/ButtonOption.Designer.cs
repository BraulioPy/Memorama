namespace Memorama.Controls.Components
{
    partial class ButtonOption
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonDesign = new MaterialSkin.Controls.MaterialButton();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.panelColor = new System.Windows.Forms.Panel();
            this.materialCard1.SuspendLayout();
            this.panelColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonDesign
            // 
            this.ButtonDesign.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonDesign.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.ButtonDesign.Depth = 0;
            this.ButtonDesign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonDesign.HighEmphasis = true;
            this.ButtonDesign.Icon = null;
            this.ButtonDesign.Location = new System.Drawing.Point(0, 0);
            this.ButtonDesign.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ButtonDesign.MouseState = MaterialSkin.MouseState.HOVER;
            this.ButtonDesign.Name = "ButtonDesign";
            this.ButtonDesign.NoAccentTextColor = System.Drawing.Color.Empty;
            this.ButtonDesign.Size = new System.Drawing.Size(160, 40);
            this.ButtonDesign.TabIndex = 0;
            this.ButtonDesign.Text = "materialButton1";
            this.ButtonDesign.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.ButtonDesign.UseAccentColor = false;
            this.ButtonDesign.UseVisualStyleBackColor = true;
            this.ButtonDesign.Click += new System.EventHandler(this.ButtonDesign_Click);
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.panelColor);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(0, 0);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(5);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Size = new System.Drawing.Size(160, 40);
            this.materialCard1.TabIndex = 1;
            // 
            // panelColor
            // 
            this.panelColor.Controls.Add(this.ButtonDesign);
            this.panelColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelColor.Location = new System.Drawing.Point(0, 0);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(160, 40);
            this.panelColor.TabIndex = 1;
            // 
            // ButtonOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.materialCard1);
            this.Name = "ButtonOption";
            this.Size = new System.Drawing.Size(160, 40);
            this.materialCard1.ResumeLayout(false);
            this.panelColor.ResumeLayout(false);
            this.panelColor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton ButtonDesign;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.Panel panelColor;
    }
}
