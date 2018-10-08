namespace RationCard.HelperForms
{
    partial class SecurityCodeMail
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
            this.btnSendSecurityCode = new System.Windows.Forms.Button();
            this.txtEmailId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEmails = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRemoveSecurityCode = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSendSecurityCode
            // 
            this.btnSendSecurityCode.Location = new System.Drawing.Point(15, 228);
            this.btnSendSecurityCode.Name = "btnSendSecurityCode";
            this.btnSendSecurityCode.Size = new System.Drawing.Size(193, 46);
            this.btnSendSecurityCode.TabIndex = 0;
            this.btnSendSecurityCode.Text = "Send Security Code";
            this.btnSendSecurityCode.UseVisualStyleBackColor = true;
            this.btnSendSecurityCode.Click += new System.EventHandler(this.btnSendSecurityCode_Click);
            // 
            // txtEmailId
            // 
            this.txtEmailId.Location = new System.Drawing.Point(93, 12);
            this.txtEmailId.Name = "txtEmailId";
            this.txtEmailId.Size = new System.Drawing.Size(281, 22);
            this.txtEmailId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Email";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(12, 120);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(362, 87);
            this.txtCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Security Code";
            // 
            // cmbEmails
            // 
            this.cmbEmails.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmails.FormattingEnabled = true;
            this.cmbEmails.Location = new System.Drawing.Point(76, 319);
            this.cmbEmails.Name = "cmbEmails";
            this.cmbEmails.Size = new System.Drawing.Size(261, 24);
            this.cmbEmails.TabIndex = 5;
            this.cmbEmails.SelectedIndexChanged += new System.EventHandler(this.cmbEmails_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Email";
            // 
            // btnRemoveSecurityCode
            // 
            this.btnRemoveSecurityCode.Location = new System.Drawing.Point(15, 366);
            this.btnRemoveSecurityCode.Name = "btnRemoveSecurityCode";
            this.btnRemoveSecurityCode.Size = new System.Drawing.Size(193, 45);
            this.btnRemoveSecurityCode.TabIndex = 7;
            this.btnRemoveSecurityCode.Text = "Remove Security Code";
            this.btnRemoveSecurityCode.UseVisualStyleBackColor = true;
            this.btnRemoveSecurityCode.Click += new System.EventHandler(this.btnRemoveSecurityCode_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "MobileNo.";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(93, 49);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(281, 22);
            this.txtMobileNo.TabIndex = 8;
            // 
            // SecurityCodeMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 459);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.btnRemoveSecurityCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbEmails);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmailId);
            this.Controls.Add(this.btnSendSecurityCode);
            this.Name = "SecurityCodeMail";
            this.Text = "SecurityCodeMail";
            this.Load += new System.EventHandler(this.SecurityCodeMail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendSecurityCode;
        private System.Windows.Forms.TextBox txtEmailId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEmails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRemoveSecurityCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMobileNo;
    }
}