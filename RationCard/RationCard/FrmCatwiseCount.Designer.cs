namespace RationCard
{
    partial class FrmCatwiseCount
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
            this.grdCatwiseCount = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.grdCatwiseCount)).BeginInit();
            this.SuspendLayout();
            // 
            // grdCatwiseCount
            // 
            this.grdCatwiseCount.AllowUserToAddRows = false;
            this.grdCatwiseCount.AllowUserToDeleteRows = false;
            this.grdCatwiseCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCatwiseCount.Location = new System.Drawing.Point(16, 11);
            this.grdCatwiseCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdCatwiseCount.Name = "grdCatwiseCount";
            this.grdCatwiseCount.ReadOnly = true;
            this.grdCatwiseCount.RowTemplate.Height = 28;
            this.grdCatwiseCount.Size = new System.Drawing.Size(347, 214);
            this.grdCatwiseCount.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(45, 246);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(300, 26);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // FrmCatwiseCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(386, 283);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.grdCatwiseCount);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmCatwiseCount";
            this.Text = "FrmCatwiseCount";
            this.Load += new System.EventHandler(this.FrmCatwiseCount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCatwiseCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdCatwiseCount;
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}