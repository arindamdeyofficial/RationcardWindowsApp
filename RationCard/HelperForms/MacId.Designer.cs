namespace RationCard
{
    partial class MacId
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
            this.lblDbOperationSTatus = new System.Windows.Forms.Label();
            this.btnGetMacIds = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStartFormName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMacIdType = new System.Windows.Forms.TextBox();
            this.btnRemoveMacId = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddMacId = new System.Windows.Forms.Button();
            this.txtAddMacId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grdVwAppStart = new System.Windows.Forms.DataGridView();
            this.btnAppHistoryFlush = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.grViewCompMacs = new System.Windows.Forms.DataGridView();
            this.btnGetAppHistory = new System.Windows.Forms.Button();
            this.btnGetMacId = new System.Windows.Forms.Button();
            this.lblActiveIp = new System.Windows.Forms.Label();
            this.lblActiveGateway = new System.Windows.Forms.Label();
            this.lblActiveMacId = new System.Windows.Forms.Label();
            this.lblActivePublicIp = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.drVwMacIdAssigned = new System.Windows.Forms.DataGridView();
            this.cmbUserList = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdVwAppStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grViewCompMacs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drVwMacIdAssigned)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDbOperationSTatus
            // 
            this.lblDbOperationSTatus.AutoSize = true;
            this.lblDbOperationSTatus.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblDbOperationSTatus.Location = new System.Drawing.Point(949, 95);
            this.lblDbOperationSTatus.Name = "lblDbOperationSTatus";
            this.lblDbOperationSTatus.Size = new System.Drawing.Size(166, 17);
            this.lblDbOperationSTatus.TabIndex = 34;
            this.lblDbOperationSTatus.Text = "DB Operation Successful";
            // 
            // btnGetMacIds
            // 
            this.btnGetMacIds.Location = new System.Drawing.Point(1175, 9);
            this.btnGetMacIds.Name = "btnGetMacIds";
            this.btnGetMacIds.Size = new System.Drawing.Size(120, 43);
            this.btnGetMacIds.TabIndex = 33;
            this.btnGetMacIds.Text = "Get MAC ID";
            this.btnGetMacIds.UseVisualStyleBackColor = true;
            this.btnGetMacIds.Click += new System.EventHandler(this.btnGetMacIds_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(579, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 17);
            this.label6.TabIndex = 32;
            this.label6.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(666, 81);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(163, 22);
            this.txtRemarks.TabIndex = 31;
            this.txtRemarks.Text = "My PC";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(885, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 30;
            this.label5.Text = "Start Page";
            // 
            // txtStartFormName
            // 
            this.txtStartFormName.Location = new System.Drawing.Point(966, 49);
            this.txtStartFormName.Name = "txtStartFormName";
            this.txtStartFormName.Size = new System.Drawing.Size(200, 22);
            this.txtStartFormName.TabIndex = 29;
            this.txtStartFormName.Text = "RationcardHome";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(858, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 17);
            this.label4.TabIndex = 28;
            this.label4.Text = "Mac Id Type";
            // 
            // txtMacIdType
            // 
            this.txtMacIdType.Location = new System.Drawing.Point(966, 15);
            this.txtMacIdType.Name = "txtMacIdType";
            this.txtMacIdType.Size = new System.Drawing.Size(200, 22);
            this.txtMacIdType.TabIndex = 27;
            this.txtMacIdType.Text = "DIRECT";
            // 
            // btnRemoveMacId
            // 
            this.btnRemoveMacId.Location = new System.Drawing.Point(1175, 107);
            this.btnRemoveMacId.Name = "btnRemoveMacId";
            this.btnRemoveMacId.Size = new System.Drawing.Size(120, 43);
            this.btnRemoveMacId.TabIndex = 25;
            this.btnRemoveMacId.Text = "Remove MAC ID";
            this.btnRemoveMacId.UseVisualStyleBackColor = true;
            this.btnRemoveMacId.Click += new System.EventHandler(this.btnRemoveMacId_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(594, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Mac Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(568, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "User Login";
            // 
            // btnAddMacId
            // 
            this.btnAddMacId.Location = new System.Drawing.Point(1175, 58);
            this.btnAddMacId.Name = "btnAddMacId";
            this.btnAddMacId.Size = new System.Drawing.Size(120, 43);
            this.btnAddMacId.TabIndex = 21;
            this.btnAddMacId.Text = "Add MAC ID";
            this.btnAddMacId.UseVisualStyleBackColor = true;
            this.btnAddMacId.Click += new System.EventHandler(this.btnAddMacId_Click);
            // 
            // txtAddMacId
            // 
            this.txtAddMacId.Location = new System.Drawing.Point(666, 46);
            this.txtAddMacId.Name = "txtAddMacId";
            this.txtAddMacId.Size = new System.Drawing.Size(163, 22);
            this.txtAddMacId.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 35;
            this.label1.Text = "App Start History";
            // 
            // grdVwAppStart
            // 
            this.grdVwAppStart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVwAppStart.Location = new System.Drawing.Point(12, 191);
            this.grdVwAppStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdVwAppStart.Name = "grdVwAppStart";
            this.grdVwAppStart.RowTemplate.Height = 24;
            this.grdVwAppStart.Size = new System.Drawing.Size(1137, 276);
            this.grdVwAppStart.TabIndex = 36;
            // 
            // btnAppHistoryFlush
            // 
            this.btnAppHistoryFlush.Location = new System.Drawing.Point(1163, 268);
            this.btnAppHistoryFlush.Name = "btnAppHistoryFlush";
            this.btnAppHistoryFlush.Size = new System.Drawing.Size(129, 51);
            this.btnAppHistoryFlush.TabIndex = 37;
            this.btnAppHistoryFlush.Text = "Flush App History";
            this.btnAppHistoryFlush.UseVisualStyleBackColor = true;
            this.btnAppHistoryFlush.Click += new System.EventHandler(this.btnAppHistoryFlush_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 479);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 20);
            this.label7.TabIndex = 38;
            this.label7.Text = "Computer Mac Id";
            // 
            // grViewCompMacs
            // 
            this.grViewCompMacs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grViewCompMacs.Location = new System.Drawing.Point(12, 501);
            this.grViewCompMacs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grViewCompMacs.Name = "grViewCompMacs";
            this.grViewCompMacs.RowTemplate.Height = 24;
            this.grViewCompMacs.Size = new System.Drawing.Size(1000, 266);
            this.grViewCompMacs.TabIndex = 39;
            // 
            // btnGetAppHistory
            // 
            this.btnGetAppHistory.Location = new System.Drawing.Point(1163, 191);
            this.btnGetAppHistory.Name = "btnGetAppHistory";
            this.btnGetAppHistory.Size = new System.Drawing.Size(129, 54);
            this.btnGetAppHistory.TabIndex = 40;
            this.btnGetAppHistory.Text = "Get App History";
            this.btnGetAppHistory.UseVisualStyleBackColor = true;
            this.btnGetAppHistory.Click += new System.EventHandler(this.btnGetAppHistory_Click);
            // 
            // btnGetMacId
            // 
            this.btnGetMacId.Location = new System.Drawing.Point(1045, 501);
            this.btnGetMacId.Name = "btnGetMacId";
            this.btnGetMacId.Size = new System.Drawing.Size(250, 64);
            this.btnGetMacId.TabIndex = 41;
            this.btnGetMacId.Text = "Get Mac Id";
            this.btnGetMacId.UseVisualStyleBackColor = true;
            this.btnGetMacId.Click += new System.EventHandler(this.btnGetMacId_Click);
            // 
            // lblActiveIp
            // 
            this.lblActiveIp.AutoSize = true;
            this.lblActiveIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveIp.Location = new System.Drawing.Point(1103, 597);
            this.lblActiveIp.Name = "lblActiveIp";
            this.lblActiveIp.Size = new System.Drawing.Size(82, 20);
            this.lblActiveIp.TabIndex = 42;
            this.lblActiveIp.Text = "Active Ip";
            // 
            // lblActiveGateway
            // 
            this.lblActiveGateway.AutoSize = true;
            this.lblActiveGateway.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveGateway.Location = new System.Drawing.Point(1105, 643);
            this.lblActiveGateway.Name = "lblActiveGateway";
            this.lblActiveGateway.Size = new System.Drawing.Size(139, 20);
            this.lblActiveGateway.TabIndex = 43;
            this.lblActiveGateway.Text = "Active Gateway";
            // 
            // lblActiveMacId
            // 
            this.lblActiveMacId.AutoSize = true;
            this.lblActiveMacId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveMacId.Location = new System.Drawing.Point(1105, 689);
            this.lblActiveMacId.Name = "lblActiveMacId";
            this.lblActiveMacId.Size = new System.Drawing.Size(123, 20);
            this.lblActiveMacId.TabIndex = 44;
            this.lblActiveMacId.Text = "Active Mac Id";
            // 
            // lblActivePublicIp
            // 
            this.lblActivePublicIp.AutoSize = true;
            this.lblActivePublicIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActivePublicIp.Location = new System.Drawing.Point(1105, 737);
            this.lblActivePublicIp.Name = "lblActivePublicIp";
            this.lblActivePublicIp.Size = new System.Drawing.Size(140, 20);
            this.lblActivePublicIp.TabIndex = 45;
            this.lblActivePublicIp.Text = "Active Public Ip";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1074, 597);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 17);
            this.label8.TabIndex = 46;
            this.label8.Text = "Ip";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1036, 643);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 17);
            this.label9.TabIndex = 47;
            this.label9.Text = "Gateway";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1065, 692);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 17);
            this.label10.TabIndex = 48;
            this.label10.Text = "Mac";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1038, 740);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 17);
            this.label11.TabIndex = 49;
            this.label11.Text = "Public Ip";
            // 
            // drVwMacIdAssigned
            // 
            this.drVwMacIdAssigned.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drVwMacIdAssigned.Location = new System.Drawing.Point(12, 9);
            this.drVwMacIdAssigned.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.drVwMacIdAssigned.Name = "drVwMacIdAssigned";
            this.drVwMacIdAssigned.RowTemplate.Height = 24;
            this.drVwMacIdAssigned.Size = new System.Drawing.Size(535, 137);
            this.drVwMacIdAssigned.TabIndex = 50;
            // 
            // cmbUserList
            // 
            this.cmbUserList.FormattingEnabled = true;
            this.cmbUserList.Location = new System.Drawing.Point(666, 12);
            this.cmbUserList.Name = "cmbUserList";
            this.cmbUserList.Size = new System.Drawing.Size(163, 24);
            this.cmbUserList.TabIndex = 51;
            this.cmbUserList.SelectedIndexChanged += new System.EventHandler(this.cmbUserList_SelectedIndexChanged);
            // 
            // MacId
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 778);
            this.Controls.Add(this.cmbUserList);
            this.Controls.Add(this.drVwMacIdAssigned);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblActivePublicIp);
            this.Controls.Add(this.lblActiveMacId);
            this.Controls.Add(this.lblActiveGateway);
            this.Controls.Add(this.lblActiveIp);
            this.Controls.Add(this.btnGetMacId);
            this.Controls.Add(this.btnGetAppHistory);
            this.Controls.Add(this.grViewCompMacs);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnAppHistoryFlush);
            this.Controls.Add(this.grdVwAppStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDbOperationSTatus);
            this.Controls.Add(this.btnGetMacIds);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtStartFormName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMacIdType);
            this.Controls.Add(this.btnRemoveMacId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddMacId);
            this.Controls.Add(this.txtAddMacId);
            this.Name = "MacId";
            this.Text = "MacId";
            this.Load += new System.EventHandler(this.MacId_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdVwAppStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grViewCompMacs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drVwMacIdAssigned)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDbOperationSTatus;
        private System.Windows.Forms.Button btnGetMacIds;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStartFormName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMacIdType;
        private System.Windows.Forms.Button btnRemoveMacId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddMacId;
        private System.Windows.Forms.TextBox txtAddMacId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdVwAppStart;
        private System.Windows.Forms.Button btnAppHistoryFlush;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView grViewCompMacs;
        private System.Windows.Forms.Button btnGetAppHistory;
        private System.Windows.Forms.Button btnGetMacId;
        private System.Windows.Forms.Label lblActiveIp;
        private System.Windows.Forms.Label lblActiveGateway;
        private System.Windows.Forms.Label lblActiveMacId;
        private System.Windows.Forms.Label lblActivePublicIp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView drVwMacIdAssigned;
        private System.Windows.Forms.ComboBox cmbUserList;
    }
}