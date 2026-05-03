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
            this.panelColor = new System.Windows.Forms.Panel();
            this.ButtonDesign = new MaterialSkin.Controls.MaterialButton();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.panelColor.SuspendLayout();
            this.materialCard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelColor
            // 
            this.panelColor.Controls.Add(this.ButtonDesign);
            this.panelColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelColor.Location = new System.Drawing.Point(5, 5);
            this.panelColor.Margin = new System.Windows.Forms.Padding(0);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(225, 30);
            this.panelColor.TabIndex = 1;
            // 
            // ButtonDesign
            // 
            this.ButtonDesign.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonDesign.BackColor = System.Drawing.Color.Black;
            this.ButtonDesign.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDesign.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.ButtonDesign.Depth = 0;
            this.ButtonDesign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonDesign.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ButtonDesign.ForeColor = System.Drawing.Color.Transparent;
            this.ButtonDesign.HighEmphasis = true;
            this.ButtonDesign.Icon = null;
            this.ButtonDesign.Location = new System.Drawing.Point(0, 0);
            this.ButtonDesign.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ButtonDesign.MouseState = MaterialSkin.MouseState.HOVER;
            this.ButtonDesign.Name = "ButtonDesign";
            this.ButtonDesign.NoAccentTextColor = System.Drawing.Color.Empty;
            this.ButtonDesign.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.ButtonDesign.Size = new System.Drawing.Size(225, 30);
            this.ButtonDesign.TabIndex = 0;
            this.ButtonDesign.Text = "materialButton1";
            this.ButtonDesign.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.ButtonDesign.UseAccentColor = false;
            this.ButtonDesign.UseVisualStyleBackColor = false;
            this.ButtonDesign.Click += new System.EventHandler(this.ButtonDesign_Click);
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.panelColor);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(15, 12);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(4);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(5);
            this.materialCard1.Size = new System.Drawing.Size(235, 40);
            this.materialCard1.TabIndex = 1;
            // 
            // ButtonOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.materialCard1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ButtonOption";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(264, 66);
            this.panelColor.ResumeLayout(false);
            this.panelColor.PerformLayout();
            this.materialCard1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelColor;
        private MaterialSkin.Controls.MaterialButton ButtonDesign;
        private MaterialSkin.Controls.MaterialCard materialCard1;
    }
}
