namespace Memorama.Controls.Components
{
    partial class HistoricsComponent
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvHistoricos = new System.Windows.Forms.DataGridView();
            this.buttonRegresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoricos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistoricos
            // 
            this.dgvHistoricos.AllowUserToResizeColumns = false;
            this.dgvHistoricos.AllowUserToResizeRows = false;
            this.dgvHistoricos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistoricos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistoricos.Location = new System.Drawing.Point(0, 0);
            this.dgvHistoricos.Name = "dgvHistoricos";
            this.dgvHistoricos.ReadOnly = true;
            this.dgvHistoricos.RowHeadersVisible = false;
            this.dgvHistoricos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvHistoricos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistoricos.Size = new System.Drawing.Size(304, 395);
            this.dgvHistoricos.TabIndex = 1;
            // 
            // buttonRegresar
            // 
            this.buttonRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonRegresar.Location = new System.Drawing.Point(115, 186);
            this.buttonRegresar.Name = "buttonRegresar";
            this.buttonRegresar.Size = new System.Drawing.Size(75, 23);
            this.buttonRegresar.TabIndex = 2;
            this.buttonRegresar.Text = "← Regresar";
            this.buttonRegresar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRegresar.UseVisualStyleBackColor = true;
            this.buttonRegresar.Click += new System.EventHandler(this.buttonRegresar_Click);
            // 
            // HistoricsComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonRegresar);
            this.Controls.Add(this.dgvHistoricos);
            this.Name = "HistoricsComponent";
            this.Size = new System.Drawing.Size(304, 395);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoricos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvHistoricos;
        private System.Windows.Forms.Button buttonRegresar;
    }
}
