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
            this.btnOpenQuickEntryDoc = new System.Windows.Forms.Button();
            this.lblMasterDataFetchComplete = new System.Windows.Forms.Label();
            this.btnStock = new System.Windows.Forms.Button();
            this.btnFrontDeskEntry = new System.Windows.Forms.Button();
            this.btnRationCardEntry = new System.Windows.Forms.Button();
            this.btnCatwiseCount = new System.Windows.Forms.Button();
            this.btnCardSearch = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
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
            // lblMasterDataFetchComplete
            // 
            this.lblMasterDataFetchComplete.AutoSize = true;
            this.lblMasterDataFetchComplete.Location = new System.Drawing.Point(44, 408);
            this.lblMasterDataFetchComplete.Name = "lblMasterDataFetchComplete";
            this.lblMasterDataFetchComplete.Size = new System.Drawing.Size(0, 17);
            this.lblMasterDataFetchComplete.TabIndex = 7;
            // 
            // btnStock
            // 
            this.btnStock.Image = global::RationCard.Properties.Resources.stock;
            this.btnStock.Location = new System.Drawing.Point(47, 269);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(112, 55);
            this.btnStock.TabIndex = 8;
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnFrontDeskEntry
            // 
            this.btnFrontDeskEntry.Image = global::RationCard.Properties.Resources.FrontDeskEntry;
            this.btnFrontDeskEntry.Location = new System.Drawing.Point(47, 175);
            this.btnFrontDeskEntry.Name = "btnFrontDeskEntry";
            this.btnFrontDeskEntry.Size = new System.Drawing.Size(226, 55);
            this.btnFrontDeskEntry.TabIndex = 6;
            this.btnFrontDeskEntry.UseVisualStyleBackColor = true;
            this.btnFrontDeskEntry.Click += new System.EventHandler(this.btnFrontDeskEntry_Click);
            // 
            // btnRationCardEntry
            // 
            this.btnRationCardEntry.Image = global::RationCard.Properties.Resources.RationCardEntry;
            this.btnRationCardEntry.Location = new System.Drawing.Point(47, 80);
            this.btnRationCardEntry.Name = "btnRationCardEntry";
            this.btnRationCardEntry.Size = new System.Drawing.Size(237, 55);
            this.btnRationCardEntry.TabIndex = 5;
            this.btnRationCardEntry.UseVisualStyleBackColor = true;
            this.btnRationCardEntry.Click += new System.EventHandler(this.btnRationCardEntry_Click);
            // 
            // btnCatwiseCount
            // 
            this.btnCatwiseCount.Image = global::RationCard.Properties.Resources.CatwiseCount;
            this.btnCatwiseCount.Location = new System.Drawing.Point(324, 175);
            this.btnCatwiseCount.Name = "btnCatwiseCount";
            this.btnCatwiseCount.Size = new System.Drawing.Size(208, 55);
            this.btnCatwiseCount.TabIndex = 4;
            this.btnCatwiseCount.UseVisualStyleBackColor = true;
            this.btnCatwiseCount.Click += new System.EventHandler(this.btnCatwiseCount_Click);
            // 
            // btnCardSearch
            // 
            this.btnCardSearch.Image = global::RationCard.Properties.Resources.CardSearch;
            this.btnCardSearch.Location = new System.Drawing.Point(360, 80);
            this.btnCardSearch.Name = "btnCardSearch";
            this.btnCardSearch.Size = new System.Drawing.Size(172, 55);
            this.btnCardSearch.TabIndex = 2;
            this.btnCardSearch.UseVisualStyleBackColor = true;
            this.btnCardSearch.Click += new System.EventHandler(this.btnCardSearch_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(47, 458);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(208, 37);
            this.btnAdmin.TabIndex = 9;
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // FrmRationcardHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 511);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnStock);
            this.Controls.Add(this.lblMasterDataFetchComplete);
            this.Controls.Add(this.btnFrontDeskEntry);
            this.Controls.Add(this.btnRationCardEntry);
            this.Controls.Add(this.btnCatwiseCount);
            this.Controls.Add(this.btnOpenQuickEntryDoc);
            this.Controls.Add(this.btnCardSearch);
            this.Controls.Add(this.txtChoice);
            this.Name = "FrmRationcardHome";
            this.Text = "Rationcard Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRationcardHome_FormClosing);
            this.Load += new System.EventHandler(this.FrmRationcardHome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtChoice;
        private System.Windows.Forms.Button btnCardSearch;
        private System.Windows.Forms.Button btnOpenQuickEntryDoc;
        private System.Windows.Forms.Button btnCatwiseCount;
        private System.Windows.Forms.Button btnRationCardEntry;
        private System.Windows.Forms.Button btnFrontDeskEntry;
        private System.Windows.Forms.Label lblMasterDataFetchComplete;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnAdmin;
    }
}