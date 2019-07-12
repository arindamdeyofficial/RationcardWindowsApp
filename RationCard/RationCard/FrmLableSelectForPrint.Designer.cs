namespace RationCard
{
    partial class FrmLableSelectForPrint
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkRationCardNo = new System.Windows.Forms.CheckBox();
            this.chkAdhar = new System.Windows.Forms.CheckBox();
            this.chkMobileNo = new System.Windows.Forms.CheckBox();
            this.chkHof = new System.Windows.Forms.CheckBox();
            this.chkNoOfCard = new System.Windows.Forms.CheckBox();
            this.chkCardHolderName = new System.Windows.Forms.CheckBox();
            this.chkAge = new System.Windows.Forms.CheckBox();
            this.chkAddress = new System.Windows.Forms.CheckBox();
            this.chkActiveSince = new System.Windows.Forms.CheckBox();
            this.chkRelWithHof = new System.Windows.Forms.CheckBox();
            this.chkGaurdianName = new System.Windows.Forms.CheckBox();
            this.chkRemarks = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(211, 233);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(182, 49);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Himalaya", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(178, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please Select columns to print";
            // 
            // chkRationCardNo
            // 
            this.chkRationCardNo.AutoSize = true;
            this.chkRationCardNo.Checked = true;
            this.chkRationCardNo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRationCardNo.Location = new System.Drawing.Point(33, 65);
            this.chkRationCardNo.Name = "chkRationCardNo";
            this.chkRationCardNo.Size = new System.Drawing.Size(159, 21);
            this.chkRationCardNo.TabIndex = 2;
            this.chkRationCardNo.Text = "Ration Card Number";
            this.chkRationCardNo.UseVisualStyleBackColor = true;
            // 
            // chkAdhar
            // 
            this.chkAdhar.AutoSize = true;
            this.chkAdhar.Checked = true;
            this.chkAdhar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAdhar.Location = new System.Drawing.Point(33, 102);
            this.chkAdhar.Name = "chkAdhar";
            this.chkAdhar.Size = new System.Drawing.Size(161, 21);
            this.chkAdhar.TabIndex = 3;
            this.chkAdhar.Text = "Epic / Adhar Number";
            this.chkAdhar.UseVisualStyleBackColor = true;
            // 
            // chkMobileNo
            // 
            this.chkMobileNo.AutoSize = true;
            this.chkMobileNo.Checked = true;
            this.chkMobileNo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMobileNo.Location = new System.Drawing.Point(33, 140);
            this.chkMobileNo.Name = "chkMobileNo";
            this.chkMobileNo.Size = new System.Drawing.Size(125, 21);
            this.chkMobileNo.TabIndex = 4;
            this.chkMobileNo.Text = "Mobile Number";
            this.chkMobileNo.UseVisualStyleBackColor = true;
            // 
            // chkHof
            // 
            this.chkHof.AutoSize = true;
            this.chkHof.Checked = true;
            this.chkHof.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHof.Location = new System.Drawing.Point(33, 181);
            this.chkHof.Name = "chkHof";
            this.chkHof.Size = new System.Drawing.Size(151, 21);
            this.chkHof.TabIndex = 5;
            this.chkHof.Text = "Head Of the Family";
            this.chkHof.UseVisualStyleBackColor = true;
            // 
            // chkNoOfCard
            // 
            this.chkNoOfCard.AutoSize = true;
            this.chkNoOfCard.Checked = true;
            this.chkNoOfCard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNoOfCard.Location = new System.Drawing.Point(225, 65);
            this.chkNoOfCard.Name = "chkNoOfCard";
            this.chkNoOfCard.Size = new System.Drawing.Size(102, 21);
            this.chkNoOfCard.TabIndex = 6;
            this.chkNoOfCard.Text = "No. of Card";
            this.chkNoOfCard.UseVisualStyleBackColor = true;
            // 
            // chkCardHolderName
            // 
            this.chkCardHolderName.AutoSize = true;
            this.chkCardHolderName.Checked = true;
            this.chkCardHolderName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCardHolderName.Location = new System.Drawing.Point(225, 102);
            this.chkCardHolderName.Name = "chkCardHolderName";
            this.chkCardHolderName.Size = new System.Drawing.Size(147, 21);
            this.chkCardHolderName.TabIndex = 7;
            this.chkCardHolderName.Text = "Card Holder Name";
            this.chkCardHolderName.UseVisualStyleBackColor = true;
            // 
            // chkAge
            // 
            this.chkAge.AutoSize = true;
            this.chkAge.Checked = true;
            this.chkAge.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAge.Location = new System.Drawing.Point(225, 140);
            this.chkAge.Name = "chkAge";
            this.chkAge.Size = new System.Drawing.Size(55, 21);
            this.chkAge.TabIndex = 8;
            this.chkAge.Text = "Age";
            this.chkAge.UseVisualStyleBackColor = true;
            // 
            // chkAddress
            // 
            this.chkAddress.AutoSize = true;
            this.chkAddress.Checked = true;
            this.chkAddress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAddress.Location = new System.Drawing.Point(225, 181);
            this.chkAddress.Name = "chkAddress";
            this.chkAddress.Size = new System.Drawing.Size(82, 21);
            this.chkAddress.TabIndex = 9;
            this.chkAddress.Text = "Address";
            this.chkAddress.UseVisualStyleBackColor = true;
            // 
            // chkActiveSince
            // 
            this.chkActiveSince.AutoSize = true;
            this.chkActiveSince.Checked = true;
            this.chkActiveSince.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActiveSince.Location = new System.Drawing.Point(400, 64);
            this.chkActiveSince.Name = "chkActiveSince";
            this.chkActiveSince.Size = new System.Drawing.Size(167, 21);
            this.chkActiveSince.TabIndex = 11;
            this.chkActiveSince.Text = "Active / Inactive Since";
            this.chkActiveSince.UseVisualStyleBackColor = true;
            // 
            // chkRelWithHof
            // 
            this.chkRelWithHof.AutoSize = true;
            this.chkRelWithHof.Checked = true;
            this.chkRelWithHof.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRelWithHof.Location = new System.Drawing.Point(400, 102);
            this.chkRelWithHof.Name = "chkRelWithHof";
            this.chkRelWithHof.Size = new System.Drawing.Size(169, 21);
            this.chkRelWithHof.TabIndex = 12;
            this.chkRelWithHof.Text = "Relationship with HOF";
            this.chkRelWithHof.UseVisualStyleBackColor = true;
            // 
            // chkGaurdianName
            // 
            this.chkGaurdianName.AutoSize = true;
            this.chkGaurdianName.Checked = true;
            this.chkGaurdianName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGaurdianName.Location = new System.Drawing.Point(400, 143);
            this.chkGaurdianName.Name = "chkGaurdianName";
            this.chkGaurdianName.Size = new System.Drawing.Size(130, 21);
            this.chkGaurdianName.TabIndex = 13;
            this.chkGaurdianName.Text = "Gaurdian Name";
            this.chkGaurdianName.UseVisualStyleBackColor = true;
            // 
            // chkRemarks
            // 
            this.chkRemarks.AutoSize = true;
            this.chkRemarks.Checked = true;
            this.chkRemarks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemarks.Location = new System.Drawing.Point(400, 181);
            this.chkRemarks.Name = "chkRemarks";
            this.chkRemarks.Size = new System.Drawing.Size(86, 21);
            this.chkRemarks.TabIndex = 14;
            this.chkRemarks.Text = "Remarks";
            this.chkRemarks.UseVisualStyleBackColor = true;
            // 
            // FrmLableSelectForPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(603, 294);
            this.Controls.Add(this.chkRemarks);
            this.Controls.Add(this.chkGaurdianName);
            this.Controls.Add(this.chkRelWithHof);
            this.Controls.Add(this.chkActiveSince);
            this.Controls.Add(this.chkAddress);
            this.Controls.Add(this.chkAge);
            this.Controls.Add(this.chkCardHolderName);
            this.Controls.Add(this.chkNoOfCard);
            this.Controls.Add(this.chkHof);
            this.Controls.Add(this.chkMobileNo);
            this.Controls.Add(this.chkAdhar);
            this.Controls.Add(this.chkRationCardNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrint);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmLableSelectForPrint";
            this.Text = "FrmLableSelectForPrint";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkRationCardNo;
        private System.Windows.Forms.CheckBox chkAdhar;
        private System.Windows.Forms.CheckBox chkMobileNo;
        private System.Windows.Forms.CheckBox chkHof;
        private System.Windows.Forms.CheckBox chkNoOfCard;
        private System.Windows.Forms.CheckBox chkCardHolderName;
        private System.Windows.Forms.CheckBox chkAge;
        private System.Windows.Forms.CheckBox chkAddress;
        private System.Windows.Forms.CheckBox chkActiveSince;
        private System.Windows.Forms.CheckBox chkRelWithHof;
        private System.Windows.Forms.CheckBox chkGaurdianName;
        private System.Windows.Forms.CheckBox chkRemarks;
    }
}