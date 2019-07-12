namespace RationCard.HelperForms
{
    partial class OrphanRecord
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
            this.label7 = new System.Windows.Forms.Label();
            this.grdVwOrphanCards = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.grVwOrphanCustomers = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFetchOrphanRecords = new System.Windows.Forms.Button();
            this.cmbUserList = new System.Windows.Forms.ComboBox();
            this.btnOrphanRecord = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdVwOrphanCards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grVwOrphanCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(194, 17);
            this.label7.TabIndex = 27;
            this.label7.Text = "Orphan Record in Rationcard";
            // 
            // grdVwOrphanCards
            // 
            this.grdVwOrphanCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVwOrphanCards.Location = new System.Drawing.Point(12, 102);
            this.grdVwOrphanCards.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdVwOrphanCards.Name = "grdVwOrphanCards";
            this.grdVwOrphanCards.RowTemplate.Height = 24;
            this.grdVwOrphanCards.Size = new System.Drawing.Size(1091, 225);
            this.grdVwOrphanCards.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 364);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 17);
            this.label1.TabIndex = 29;
            this.label1.Text = "Orphan Record in Customer";
            // 
            // grVwOrphanCustomers
            // 
            this.grVwOrphanCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grVwOrphanCustomers.Location = new System.Drawing.Point(12, 399);
            this.grVwOrphanCustomers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grVwOrphanCustomers.Name = "grVwOrphanCustomers";
            this.grVwOrphanCustomers.RowTemplate.Height = 24;
            this.grVwOrphanCustomers.Size = new System.Drawing.Size(1091, 237);
            this.grVwOrphanCustomers.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "User Login Id";
            // 
            // txtFetchOrphanRecords
            // 
            this.txtFetchOrphanRecords.Location = new System.Drawing.Point(398, 12);
            this.txtFetchOrphanRecords.Name = "txtFetchOrphanRecords";
            this.txtFetchOrphanRecords.Size = new System.Drawing.Size(306, 61);
            this.txtFetchOrphanRecords.TabIndex = 32;
            this.txtFetchOrphanRecords.Text = "FetchOrphan Records";
            this.txtFetchOrphanRecords.UseVisualStyleBackColor = true;
            this.txtFetchOrphanRecords.Click += new System.EventHandler(this.txtFetchOrphanRecords_Click);
            // 
            // cmbUserList
            // 
            this.cmbUserList.FormattingEnabled = true;
            this.cmbUserList.Location = new System.Drawing.Point(135, 23);
            this.cmbUserList.Name = "cmbUserList";
            this.cmbUserList.Size = new System.Drawing.Size(228, 24);
            this.cmbUserList.TabIndex = 52;
            this.cmbUserList.SelectedIndexChanged += new System.EventHandler(this.cmbUserList_SelectedIndexChanged);
            // 
            // btnOrphanRecord
            // 
            this.btnOrphanRecord.Location = new System.Drawing.Point(797, 12);
            this.btnOrphanRecord.Name = "btnOrphanRecord";
            this.btnOrphanRecord.Size = new System.Drawing.Size(306, 61);
            this.btnOrphanRecord.TabIndex = 53;
            this.btnOrphanRecord.Text = "Delete Orphan Records";
            this.btnOrphanRecord.UseVisualStyleBackColor = true;
            this.btnOrphanRecord.Click += new System.EventHandler(this.btnOrphanRecord_Click);
            // 
            // OrphanRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 653);
            this.Controls.Add(this.btnOrphanRecord);
            this.Controls.Add(this.cmbUserList);
            this.Controls.Add(this.txtFetchOrphanRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grVwOrphanCustomers);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.grdVwOrphanCards);
            this.Name = "OrphanRecord";
            this.Text = "OrphanRecord";
            this.Load += new System.EventHandler(this.OrphanRecord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdVwOrphanCards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grVwOrphanCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView grdVwOrphanCards;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grVwOrphanCustomers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button txtFetchOrphanRecords;
        private System.Windows.Forms.ComboBox cmbUserList;
        private System.Windows.Forms.Button btnOrphanRecord;
    }
}