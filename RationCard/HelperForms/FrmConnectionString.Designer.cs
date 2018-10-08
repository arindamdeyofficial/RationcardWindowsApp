namespace RationCard.HelperForms
{
    partial class FrmConnectionString
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtEncryptedConStr = new System.Windows.Forms.TextBox();
            this.txtSimpleConStr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(441, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "ConnectionEncrypt and Decrypt: 1st txt simple 2nd textbox Encrypted";
            // 
            // txtEncryptedConStr
            // 
            this.txtEncryptedConStr.Location = new System.Drawing.Point(90, 201);
            this.txtEncryptedConStr.Multiline = true;
            this.txtEncryptedConStr.Name = "txtEncryptedConStr";
            this.txtEncryptedConStr.Size = new System.Drawing.Size(945, 110);
            this.txtEncryptedConStr.TabIndex = 6;
            this.txtEncryptedConStr.TextChanged += new System.EventHandler(this.txtEncryptedConStr_TextChanged);
            // 
            // txtSimpleConStr
            // 
            this.txtSimpleConStr.Location = new System.Drawing.Point(87, 56);
            this.txtSimpleConStr.Multiline = true;
            this.txtSimpleConStr.Name = "txtSimpleConStr";
            this.txtSimpleConStr.Size = new System.Drawing.Size(945, 112);
            this.txtSimpleConStr.TabIndex = 5;
            this.txtSimpleConStr.TextChanged += new System.EventHandler(this.txtSimpleConStr_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Encrypted";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Simple";
            // 
            // FrmConnectionString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 325);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEncryptedConStr);
            this.Controls.Add(this.txtSimpleConStr);
            this.Name = "FrmConnectionString";
            this.Text = "FrmConnectionString";
            this.Load += new System.EventHandler(this.FrmConnectionString_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEncryptedConStr;
        private System.Windows.Forms.TextBox txtSimpleConStr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}