namespace Memorama
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableroLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ayudaLabel = new MaterialSkin.Controls.MaterialLabel();
            this.tableroLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableroLayoutPanel
            // 
            this.tableroLayoutPanel.ColumnCount = 1;
            this.tableroLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableroLayoutPanel.Controls.Add(this.ayudaLabel, 0, 0);
            this.tableroLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableroLayoutPanel.Location = new System.Drawing.Point(3, 64);
            this.tableroLayoutPanel.Name = "tableroLayoutPanel";
            this.tableroLayoutPanel.RowCount = 2;
            this.tableroLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableroLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableroLayoutPanel.Size = new System.Drawing.Size(794, 383);
            this.tableroLayoutPanel.TabIndex = 0;
            // 
            // ayudaLabel
            // 
            this.ayudaLabel.AutoSize = true;
            this.ayudaLabel.Depth = 0;
            this.ayudaLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ayudaLabel.Location = new System.Drawing.Point(3, 0);
            this.ayudaLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.ayudaLabel.Name = "ayudaLabel";
            this.ayudaLabel.Size = new System.Drawing.Size(45, 19);
            this.ayudaLabel.TabIndex = 0;
            this.ayudaLabel.Text = "Pares:";
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableroLayoutPanel);
            this.Name = "MenuPrincipal";
            this.Text = "Memorama YiyiBraulio";
            this.tableroLayoutPanel.ResumeLayout(false);
            this.tableroLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableroLayoutPanel;
        private MaterialSkin.Controls.MaterialLabel ayudaLabel;
    }
}