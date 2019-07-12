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
            this.lblCardCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdVwSearchResult)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRationcardNumber
            // 
            this.txtRationcardNumber.Location = new System.Drawing.Point(12, 36);
            this.txtRationcardNumber.Name = "txtRationcardNumber";
            this.txtRationcardNumber.Size = new System.Drawing.Size(234, 22);
            this.txtRationcardNumber.TabIndex = 0;
            this.txtRationcardNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRationcardNumber_KeyPress);
            // 
            // grdVwSearchResult
            // 
            this.grdVwSearchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVwSearchResult.Location = new System.Drawing.Point(12, 82);
            this.grdVwSearchResult.Name = "grdVwSearchResult";
            this.grdVwSearchResult.RowTemplate.Height = 24;
            this.grdVwSearchResult.Size = new System.Drawing.Size(606, 372);
            this.grdVwSearchResult.TabIndex = 24;
            this.grdVwSearchResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdVwSearchResult_CellClick);
            this.grdVwSearchResult.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdVwSearchResult_KeyPress);
            // 
            // btnCreateBill
            // 
            this.btnCreateBill.Location = new System.Drawing.Point(191, 481);
            this.btnCreateBill.Name = "btnCreateBill";
            this.btnCreateBill.Size = new System.Drawing.Size(300, 41);
            this.btnCreateBill.TabIndex = 25;
            this.btnCreateBill.Text = "Generate Billing";
            this.btnCreateBill.UseVisualStyleBackColor = true;
            this.btnCreateBill.Visible = false;
            this.btnCreateBill.Click += new System.EventHandler(this.btnCreateBill_Click);
            // 
            // lblCardCount
            // 
            this.lblCardCount.AutoSize = true;
            this.lblCardCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardCount.Location = new System.Drawing.Point(265, 38);
            this.lblCardCount.Name = "lblCardCount";
            this.lblCardCount.Size = new System.Drawing.Size(140, 20);
            this.lblCardCount.TabIndex = 26;
            this.lblCardCount.Text = "Total Active card ";
            // 
            // FrmFrontDeskEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 534);
            this.Controls.Add(this.lblCardCount);
            this.Controls.Add(this.btnCreateBill);
            this.Controls.Add(this.grdVwSearchResult);
            this.Controls.Add(this.txtRationcardNumber);
            this.Name = "FrmFrontDeskEntry";
            this.Text = "Front Desk Entry";
            this.Load += new System.EventHandler(this.FrmFrontDeskEntry_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmFrontDeskEntry_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.grdVwSearchResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRationcardNumber;
        private System.Windows.Forms.DataGridView grdVwSearchResult;
        private System.Windows.Forms.Button btnCreateBill;
        private System.Windows.Forms.Label lblCardCount;
    }
}