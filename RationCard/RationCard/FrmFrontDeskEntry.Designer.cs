namespace RationCard
{
    partial class FrmFrontDeskEntry
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
            this.txtRationcardNumber = new System.Windows.Forms.TextBox();
            this.grdVwSearchResult = new System.Windows.Forms.DataGridView();
            this.btnCreateBill = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdVwSearchResult)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRationcardNumber
            // 
            this.txtRationcardNumber.Location = new System.Drawing.Point(298, 33);
            this.txtRationcardNumber.Name = "txtRationcardNumber";
            this.txtRationcardNumber.Size = new System.Drawing.Size(300, 22);
            this.txtRationcardNumber.TabIndex = 0;
            this.txtRationcardNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRationcardNumber_KeyPress);
            // 
            // grdVwSearchResult
            // 
            this.grdVwSearchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVwSearchResult.Location = new System.Drawing.Point(12, 82);
            this.grdVwSearchResult.Name = "grdVwSearchResult";
            this.grdVwSearchResult.RowTemplate.Height = 24;
            this.grdVwSearchResult.Size = new System.Drawing.Size(824, 372);
            this.grdVwSearchResult.TabIndex = 24;
            // 
            // btnCreateBill
            // 
            this.btnCreateBill.Location = new System.Drawing.Point(298, 481);
            this.btnCreateBill.Name = "btnCreateBill";
            this.btnCreateBill.Size = new System.Drawing.Size(300, 41);
            this.btnCreateBill.TabIndex = 25;
            this.btnCreateBill.Text = "Generate Billing";
            this.btnCreateBill.UseVisualStyleBackColor = true;
            this.btnCreateBill.Visible = false;
            this.btnCreateBill.Click += new System.EventHandler(this.btnCreateBill_Click);
            // 
            // FrmFrontDeskEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 534);
            this.Controls.Add(this.btnCreateBill);
            this.Controls.Add(this.grdVwSearchResult);
            this.Controls.Add(this.txtRationcardNumber);
            this.Name = "FrmFrontDeskEntry";
            this.Text = "FrmFrontDeskEntry";
            this.Load += new System.EventHandler(this.FrmFrontDeskEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdVwSearchResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRationcardNumber;
        private System.Windows.Forms.DataGridView grdVwSearchResult;
        private System.Windows.Forms.Button btnCreateBill;
    }
}