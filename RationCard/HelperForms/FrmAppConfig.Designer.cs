namespace RationCard.HelperForms
{
    partial class FrmAppConfig
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
            this.drVwAppConfig = new System.Windows.Forms.DataGridView();
            this.btnGetConfigs = new System.Windows.Forms.Button();
            this.txtKeytext = new System.Windows.Forms.TextBox();
            this.btnRemoveConfig = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddOrEditCofig = new System.Windows.Forms.Button();
            this.txtKeyValue = new System.Windows.Forms.TextBox();
            this.cmbUserList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCloneFromUserList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCloneConfig = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.drVwAppConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // drVwAppConfig
            // 
            this.drVwAppConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drVwAppConfig.Location = new System.Drawing.Point(12, 254);
            this.drVwAppConfig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.drVwAppConfig.Name = "drVwAppConfig";
            this.drVwAppConfig.RowTemplate.Height = 24;
            this.drVwAppConfig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.drVwAppConfig.Size = new System.Drawing.Size(758, 374);
            this.drVwAppConfig.TabIndex = 64;
            this.drVwAppConfig.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.drVwAppConfig_CellDoubleClick);
            // 
            // btnGetConfigs
            // 
            this.btnGetConfigs.Location = new System.Drawing.Point(559, 124);
            this.btnGetConfigs.Name = "btnGetConfigs";
            this.btnGetConfigs.Size = new System.Drawing.Size(212, 43);
            this.btnGetConfigs.TabIndex = 63;
            this.btnGetConfigs.Text = "Get Configs";
            this.btnGetConfigs.UseVisualStyleBackColor = true;
            this.btnGetConfigs.Click += new System.EventHandler(this.btnGetConfigs_Click);
            // 
            // txtKeytext
            // 
            this.txtKeytext.Location = new System.Drawing.Point(125, 112);
            this.txtKeytext.Name = "txtKeytext";
            this.txtKeytext.Size = new System.Drawing.Size(400, 22);
            this.txtKeytext.TabIndex = 61;
            // 
            // btnRemoveConfig
            // 
            this.btnRemoveConfig.Location = new System.Drawing.Point(558, 178);
            this.btnRemoveConfig.Name = "btnRemoveConfig";
            this.btnRemoveConfig.Size = new System.Drawing.Size(212, 43);
            this.btnRemoveConfig.TabIndex = 56;
            this.btnRemoveConfig.Text = "Remove Config";
            this.btnRemoveConfig.UseVisualStyleBackColor = true;
            this.btnRemoveConfig.Click += new System.EventHandler(this.btnRemoveConfig_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 55;
            this.label3.Text = "ValueText";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 54;
            this.label2.Text = "KeyText";
            // 
            // btnAddOrEditCofig
            // 
            this.btnAddOrEditCofig.Location = new System.Drawing.Point(558, 12);
            this.btnAddOrEditCofig.Name = "btnAddOrEditCofig";
            this.btnAddOrEditCofig.Size = new System.Drawing.Size(212, 43);
            this.btnAddOrEditCofig.TabIndex = 53;
            this.btnAddOrEditCofig.Text = "Add / Edit Configs";
            this.btnAddOrEditCofig.UseVisualStyleBackColor = true;
            this.btnAddOrEditCofig.Click += new System.EventHandler(this.btnAddOrEditCofig_Click);
            // 
            // txtKeyValue
            // 
            this.txtKeyValue.Location = new System.Drawing.Point(125, 159);
            this.txtKeyValue.Multiline = true;
            this.txtKeyValue.Name = "txtKeyValue";
            this.txtKeyValue.Size = new System.Drawing.Size(400, 62);
            this.txtKeyValue.TabIndex = 52;
            // 
            // cmbUserList
            // 
            this.cmbUserList.FormattingEnabled = true;
            this.cmbUserList.Location = new System.Drawing.Point(184, 12);
            this.cmbUserList.Name = "cmbUserList";
            this.cmbUserList.Size = new System.Drawing.Size(341, 24);
            this.cmbUserList.TabIndex = 66;
            this.cmbUserList.SelectedIndexChanged += new System.EventHandler(this.cmbUserList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 65;
            this.label1.Text = "User Login Id";
            // 
            // cmbCloneFromUserList
            // 
            this.cmbCloneFromUserList.FormattingEnabled = true;
            this.cmbCloneFromUserList.Location = new System.Drawing.Point(184, 63);
            this.cmbCloneFromUserList.Name = "cmbCloneFromUserList";
            this.cmbCloneFromUserList.Size = new System.Drawing.Size(341, 24);
            this.cmbCloneFromUserList.TabIndex = 68;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 17);
            this.label4.TabIndex = 67;
            this.label4.Text = "Clone Config From User";
            // 
            // btnCloneConfig
            // 
            this.btnCloneConfig.Location = new System.Drawing.Point(558, 69);
            this.btnCloneConfig.Name = "btnCloneConfig";
            this.btnCloneConfig.Size = new System.Drawing.Size(212, 43);
            this.btnCloneConfig.TabIndex = 69;
            this.btnCloneConfig.Text = "Clone Config";
            this.btnCloneConfig.UseVisualStyleBackColor = true;
            this.btnCloneConfig.Click += new System.EventHandler(this.btnCloneConfig_Click);
            // 
            // FrmAppConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 639);
            this.Controls.Add(this.btnCloneConfig);
            this.Controls.Add(this.cmbCloneFromUserList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbUserList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.drVwAppConfig);
            this.Controls.Add(this.btnGetConfigs);
            this.Controls.Add(this.txtKeytext);
            this.Controls.Add(this.btnRemoveConfig);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddOrEditCofig);
            this.Controls.Add(this.txtKeyValue);
            this.Name = "FrmAppConfig";
            this.Text = "FrmAppConfig";
            this.Load += new System.EventHandler(this.FrmAppConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.drVwAppConfig)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView drVwAppConfig;
        private System.Windows.Forms.Button btnGetConfigs;
        private System.Windows.Forms.TextBox txtKeytext;
        private System.Windows.Forms.Button btnRemoveConfig;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddOrEditCofig;
        private System.Windows.Forms.TextBox txtKeyValue;
        private System.Windows.Forms.ComboBox cmbUserList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCloneFromUserList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCloneConfig;
    }
}