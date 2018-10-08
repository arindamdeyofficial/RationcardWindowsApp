namespace RationCard
{
    partial class FrmRationcardHome
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
            this.txtChoice = new System.Windows.Forms.TextBox();
            this.btnRationCardHome = new System.Windows.Forms.Button();
            this.btnCardSearch = new System.Windows.Forms.Button();
            this.btnOpenQuickEntryDoc = new System.Windows.Forms.Button();
            this.btnCatwiseCount = new System.Windows.Forms.Button();
            this.btnRationCardEntry = new System.Windows.Forms.Button();
            this.btnFrontDeskEntry = new System.Windows.Forms.Button();
            this.lblMasterDataFetchComplete = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtChoice
            // 
            this.txtChoice.Location = new System.Drawing.Point(156, 24);
            this.txtChoice.Name = "txtChoice";
            this.txtChoice.Size = new System.Drawing.Size(270, 22);
            this.txtChoice.TabIndex = 0;
            this.txtChoice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChoice_KeyPress);
            // 
            // btnRationCardHome
            // 
            this.btnRationCardHome.Image = global::RationCard.Properties.Resources.RationCardHome;
            this.btnRationCardHome.Location = new System.Drawing.Point(47, 82);
            this.btnRationCardHome.Name = "btnRationCardHome";
            this.btnRationCardHome.Size = new System.Drawing.Size(217, 55);
            this.btnRationCardHome.TabIndex = 1;
            this.btnRationCardHome.UseVisualStyleBackColor = true;
            this.btnRationCardHome.Click += new System.EventHandler(this.btnRationCardHome_Click);
            // 
            // btnCardSearch
            // 
            this.btnCardSearch.Image = global::RationCard.Properties.Resources.CardSearch;
            this.btnCardSearch.Location = new System.Drawing.Point(348, 199);
            this.btnCardSearch.Name = "btnCardSearch";
            this.btnCardSearch.Size = new System.Drawing.Size(184, 55);
            this.btnCardSearch.TabIndex = 2;
            this.btnCardSearch.UseVisualStyleBackColor = true;
            this.btnCardSearch.Click += new System.EventHandler(this.btnCardSearch_Click);
            // 
            // btnOpenQuickEntryDoc
            // 
            this.btnOpenQuickEntryDoc.Location = new System.Drawing.Point(303, 458);
            this.btnOpenQuickEntryDoc.Name = "btnOpenQuickEntryDoc";
            this.btnOpenQuickEntryDoc.Size = new System.Drawing.Size(229, 37);
            this.btnOpenQuickEntryDoc.TabIndex = 3;
            this.btnOpenQuickEntryDoc.Text = "Open Quick Barcode";
            this.btnOpenQuickEntryDoc.UseVisualStyleBackColor = true;
            this.btnOpenQuickEntryDoc.Click += new System.EventHandler(this.btnOpenQuickEntryDoc_Click);
            // 
            // btnCatwiseCount
            // 
            this.btnCatwiseCount.Image = global::RationCard.Properties.Resources.CatwiseCount;
            this.btnCatwiseCount.Location = new System.Drawing.Point(47, 316);
            this.btnCatwiseCount.Name = "btnCatwiseCount";
            this.btnCatwiseCount.Size = new System.Drawing.Size(208, 55);
            this.btnCatwiseCount.TabIndex = 4;
            this.btnCatwiseCount.UseVisualStyleBackColor = true;
            this.btnCatwiseCount.Click += new System.EventHandler(this.btnCatwiseCount_Click);
            // 
            // btnRationCardEntry
            // 
            this.btnRationCardEntry.Image = global::RationCard.Properties.Resources.RationCardEntry;
            this.btnRationCardEntry.Location = new System.Drawing.Point(47, 199);
            this.btnRationCardEntry.Name = "btnRationCardEntry";
            this.btnRationCardEntry.Size = new System.Drawing.Size(237, 55);
            this.btnRationCardEntry.TabIndex = 5;
            this.btnRationCardEntry.UseVisualStyleBackColor = true;
            this.btnRationCardEntry.Click += new System.EventHandler(this.btnRationCardEntry_Click);
            // 
            // btnFrontDeskEntry
            // 
            this.btnFrontDeskEntry.Image = global::RationCard.Properties.Resources.FrontDeskEntry;
            this.btnFrontDeskEntry.Location = new System.Drawing.Point(306, 82);
            this.btnFrontDeskEntry.Name = "btnFrontDeskEntry";
            this.btnFrontDeskEntry.Size = new System.Drawing.Size(226, 55);
            this.btnFrontDeskEntry.TabIndex = 6;
            this.btnFrontDeskEntry.UseVisualStyleBackColor = true;
            this.btnFrontDeskEntry.Click += new System.EventHandler(this.btnFrontDeskEntry_Click);
            // 
            // lblMasterDataFetchComplete
            // 
            this.lblMasterDataFetchComplete.AutoSize = true;
            this.lblMasterDataFetchComplete.Location = new System.Drawing.Point(44, 408);
            this.lblMasterDataFetchComplete.Name = "lblMasterDataFetchComplete";
            this.lblMasterDataFetchComplete.Size = new System.Drawing.Size(0, 17);
            this.lblMasterDataFetchComplete.TabIndex = 7;
            // 
            // FrmRationcardHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 511);
            this.Controls.Add(this.lblMasterDataFetchComplete);
            this.Controls.Add(this.btnFrontDeskEntry);
            this.Controls.Add(this.btnRationCardEntry);
            this.Controls.Add(this.btnCatwiseCount);
            this.Controls.Add(this.btnOpenQuickEntryDoc);
            this.Controls.Add(this.btnCardSearch);
            this.Controls.Add(this.btnRationCardHome);
            this.Controls.Add(this.txtChoice);
            this.Name = "FrmRationcardHome";
            this.Text = "FrmRationcardHome";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRationcardHome_FormClosing);
            this.Load += new System.EventHandler(this.FrmRationcardHome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtChoice;
        private System.Windows.Forms.Button btnRationCardHome;
        private System.Windows.Forms.Button btnCardSearch;
        private System.Windows.Forms.Button btnOpenQuickEntryDoc;
        private System.Windows.Forms.Button btnCatwiseCount;
        private System.Windows.Forms.Button btnRationCardEntry;
        private System.Windows.Forms.Button btnFrontDeskEntry;
        private System.Windows.Forms.Label lblMasterDataFetchComplete;
    }
}