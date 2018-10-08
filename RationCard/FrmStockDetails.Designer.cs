namespace RationCard
{
    partial class FrmStockDetails
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
            this.grdVwStocks = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.btnSearchStock = new System.Windows.Forms.Button();
            this.btnPrintStockReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdVwStocks)).BeginInit();
            this.SuspendLayout();
            // 
            // grdVwStocks
            // 
            this.grdVwStocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVwStocks.Location = new System.Drawing.Point(12, 67);
            this.grdVwStocks.Name = "grdVwStocks";
            this.grdVwStocks.RowTemplate.Height = 24;
            this.grdVwStocks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdVwStocks.Size = new System.Drawing.Size(977, 602);
            this.grdVwStocks.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(294, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 17);
            this.label4.TabIndex = 66;
            this.label4.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 65;
            this.label1.Text = "From";
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(345, 12);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(200, 22);
            this.dtTo.TabIndex = 64;
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(74, 12);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(200, 22);
            this.dtFrom.TabIndex = 63;
            // 
            // btnSearchStock
            // 
            this.btnSearchStock.Location = new System.Drawing.Point(562, 10);
            this.btnSearchStock.Name = "btnSearchStock";
            this.btnSearchStock.Size = new System.Drawing.Size(162, 51);
            this.btnSearchStock.TabIndex = 68;
            this.btnSearchStock.Text = "Filter Stock";
            this.btnSearchStock.UseVisualStyleBackColor = true;
            this.btnSearchStock.Click += new System.EventHandler(this.btnSearchStock_Click);
            // 
            // btnPrintStockReport
            // 
            this.btnPrintStockReport.Location = new System.Drawing.Point(819, 10);
            this.btnPrintStockReport.Name = "btnPrintStockReport";
            this.btnPrintStockReport.Size = new System.Drawing.Size(170, 51);
            this.btnPrintStockReport.TabIndex = 82;
            this.btnPrintStockReport.Text = "Print Stock Report";
            this.btnPrintStockReport.UseVisualStyleBackColor = true;
            this.btnPrintStockReport.Visible = false;
            this.btnPrintStockReport.Click += new System.EventHandler(this.btnPrintStockReport_Click);
            // 
            // FrmStockDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 681);
            this.Controls.Add(this.btnPrintStockReport);
            this.Controls.Add(this.btnSearchStock);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.grdVwStocks);
            this.Name = "FrmStockDetails";
            this.Text = "FrmStockDetails";
            this.Load += new System.EventHandler(this.FrmStockDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdVwStocks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdVwStocks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Button btnSearchStock;
        private System.Windows.Forms.Button btnPrintStockReport;
    }
}