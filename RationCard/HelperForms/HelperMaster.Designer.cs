namespace RationCard
{
    partial class HelperMaster
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
            this.btnMac = new System.Windows.Forms.Button();
            this.btnConnectionString = new System.Windows.Forms.Button();
            this.btnOrphanRecord = new System.Windows.Forms.Button();
            this.btnFramework = new System.Windows.Forms.Button();
            this.FrmSetup = new System.Windows.Forms.Button();
            this.btnSecurityCode = new System.Windows.Forms.Button();
            this.btnProductTable = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnCleanAuditTables = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMac
            // 
            this.btnMac.Location = new System.Drawing.Point(176, 22);
            this.btnMac.Name = "btnMac";
            this.btnMac.Size = new System.Drawing.Size(140, 38);
            this.btnMac.TabIndex = 26;
            this.btnMac.Text = "MacId";
            this.btnMac.UseVisualStyleBackColor = true;
            this.btnMac.Click += new System.EventHandler(this.btnMac_Click);
            // 
            // btnConnectionString
            // 
            this.btnConnectionString.Location = new System.Drawing.Point(15, 22);
            this.btnConnectionString.Name = "btnConnectionString";
            this.btnConnectionString.Size = new System.Drawing.Size(140, 38);
            this.btnConnectionString.TabIndex = 27;
            this.btnConnectionString.Text = "ConnectionString";
            this.btnConnectionString.UseVisualStyleBackColor = true;
            this.btnConnectionString.Click += new System.EventHandler(this.btnConnectionString_Click);
            // 
            // btnOrphanRecord
            // 
            this.btnOrphanRecord.Location = new System.Drawing.Point(15, 89);
            this.btnOrphanRecord.Name = "btnOrphanRecord";
            this.btnOrphanRecord.Size = new System.Drawing.Size(246, 50);
            this.btnOrphanRecord.TabIndex = 28;
            this.btnOrphanRecord.Text = "Orphan Rationcard and Customer";
            this.btnOrphanRecord.UseVisualStyleBackColor = true;
            this.btnOrphanRecord.Click += new System.EventHandler(this.btnOrphanRecord_Click);
            // 
            // btnFramework
            // 
            this.btnFramework.Location = new System.Drawing.Point(339, 22);
            this.btnFramework.Name = "btnFramework";
            this.btnFramework.Size = new System.Drawing.Size(140, 38);
            this.btnFramework.TabIndex = 29;
            this.btnFramework.Text = "Framework";
            this.btnFramework.UseVisualStyleBackColor = true;
            this.btnFramework.Click += new System.EventHandler(this.btnFramework_Click);
            // 
            // FrmSetup
            // 
            this.FrmSetup.Location = new System.Drawing.Point(12, 171);
            this.FrmSetup.Name = "FrmSetup";
            this.FrmSetup.Size = new System.Drawing.Size(140, 38);
            this.FrmSetup.TabIndex = 30;
            this.FrmSetup.Text = "Setup";
            this.FrmSetup.UseVisualStyleBackColor = true;
            this.FrmSetup.Click += new System.EventHandler(this.FrmSetup_Click);
            // 
            // btnSecurityCode
            // 
            this.btnSecurityCode.Location = new System.Drawing.Point(285, 95);
            this.btnSecurityCode.Name = "btnSecurityCode";
            this.btnSecurityCode.Size = new System.Drawing.Size(140, 38);
            this.btnSecurityCode.TabIndex = 31;
            this.btnSecurityCode.Text = "SecurityCode";
            this.btnSecurityCode.UseVisualStyleBackColor = true;
            this.btnSecurityCode.Click += new System.EventHandler(this.btnSecurityCode_Click);
            // 
            // btnProductTable
            // 
            this.btnProductTable.Location = new System.Drawing.Point(176, 168);
            this.btnProductTable.Name = "btnProductTable";
            this.btnProductTable.Size = new System.Drawing.Size(140, 38);
            this.btnProductTable.TabIndex = 32;
            this.btnProductTable.Text = "Product Tables";
            this.btnProductTable.UseVisualStyleBackColor = true;
            this.btnProductTable.Click += new System.EventHandler(this.btnProductTable_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(339, 168);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(140, 38);
            this.btnConfig.TabIndex = 33;
            this.btnConfig.Text = "Configurations";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnCleanAuditTables
            // 
            this.btnCleanAuditTables.Location = new System.Drawing.Point(519, 22);
            this.btnCleanAuditTables.Name = "btnCleanAuditTables";
            this.btnCleanAuditTables.Size = new System.Drawing.Size(169, 38);
            this.btnCleanAuditTables.TabIndex = 34;
            this.btnCleanAuditTables.Text = "Clean Audit Tables";
            this.btnCleanAuditTables.UseVisualStyleBackColor = true;
            this.btnCleanAuditTables.Click += new System.EventHandler(this.btnCleanAuditTables_Click);
            // 
            // HelperMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 233);
            this.Controls.Add(this.btnCleanAuditTables);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnProductTable);
            this.Controls.Add(this.btnSecurityCode);
            this.Controls.Add(this.FrmSetup);
            this.Controls.Add(this.btnFramework);
            this.Controls.Add(this.btnOrphanRecord);
            this.Controls.Add(this.btnConnectionString);
            this.Controls.Add(this.btnMac);
            this.Name = "HelperMaster";
            this.Text = "Helper";
            this.Load += new System.EventHandler(this.HelperMaster_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnMac;
        private System.Windows.Forms.Button btnConnectionString;
        private System.Windows.Forms.Button btnOrphanRecord;
        private System.Windows.Forms.Button btnFramework;
        private System.Windows.Forms.Button FrmSetup;
        private System.Windows.Forms.Button btnSecurityCode;
        private System.Windows.Forms.Button btnProductTable;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnCleanAuditTables;
    }
}

