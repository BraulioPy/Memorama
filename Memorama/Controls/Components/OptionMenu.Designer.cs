namespace Memorama.Controls
{
    partial class OptionMenu
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
            this.ButtonsMenuFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.centradorLayout = new System.Windows.Forms.TableLayoutPanel();
            this.centradorLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonsMenuFlow
            // 
            this.ButtonsMenuFlow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButtonsMenuFlow.AutoSize = true;
            this.ButtonsMenuFlow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonsMenuFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ButtonsMenuFlow.Location = new System.Drawing.Point(92, 129);
            this.ButtonsMenuFlow.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonsMenuFlow.Name = "ButtonsMenuFlow";
            this.ButtonsMenuFlow.Size = new System.Drawing.Size(0, 0);
            this.ButtonsMenuFlow.TabIndex = 0;
            this.ButtonsMenuFlow.WrapContents = false;
            // 
            // centradorLayout
            // 
            this.centradorLayout.AutoSize = true;
            this.centradorLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.centradorLayout.BackColor = System.Drawing.Color.Transparent;
            this.centradorLayout.ColumnCount = 1;
            this.centradorLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.centradorLayout.Controls.Add(this.ButtonsMenuFlow, 0, 0);
            this.centradorLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centradorLayout.Location = new System.Drawing.Point(0, 0);
            this.centradorLayout.Margin = new System.Windows.Forms.Padding(0);
            this.centradorLayout.Name = "centradorLayout";
            this.centradorLayout.RowCount = 1;
            this.centradorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.centradorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 259F));
            this.centradorLayout.Size = new System.Drawing.Size(184, 259);
            this.centradorLayout.TabIndex = 0;
            // 
            // OptionMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.centradorLayout);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "OptionMenu";
            this.Size = new System.Drawing.Size(184, 259);
            this.centradorLayout.ResumeLayout(false);
            this.centradorLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel ButtonsMenuFlow;
        private System.Windows.Forms.TableLayoutPanel centradorLayout;
    }
}
