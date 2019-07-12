namespace RationCard
{
    partial class FrmRationBillDetails
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
            this.grdVwMembers = new System.Windows.Forms.DataGridView();
            this.btnPrintBill = new System.Windows.Forms.Button();
            this.lblDt = new System.Windows.Forms.Label();
            this.lblCashMemo = new System.Windows.Forms.Label();
            this.lblCashMemoCounter = new System.Windows.Forms.Label();
            this.grdVwItems = new System.Windows.Forms.DataGridView();
            this.lblFpsDealer = new System.Windows.Forms.Label();
            this.lblFPSCodeNo = new System.Windows.Forms.Label();
            this.lblAddrLn1 = new System.Windows.Forms.Label();
            this.lblAddrLn2 = new System.Windows.Forms.Label();
            this.lblAddrLn3 = new System.Windows.Forms.Label();
            this.lblBillNoText = new System.Windows.Forms.Label();
            this.lblCustomerPaid = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblCustomerToPayRs = new System.Windows.Forms.Label();
            this.lblBalRs = new System.Windows.Forms.Label();
            this.txtCustPaid = new System.Windows.Forms.TextBox();
            this.lblTotalRsRounded = new System.Windows.Forms.Label();
            this.lblTotalRoundedOff = new System.Windows.Forms.Label();
            this.lblMembersText = new System.Windows.Forms.Label();
            this.lblItemsText = new System.Windows.Forms.Label();
            this.cmbCommodity = new System.Windows.Forms.ComboBox();
            this.lblDiscountText = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdVwMembers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVwItems)).BeginInit();
            this.SuspendLayout();
            // 
            // grdVwMembers
            // 
            this.grdVwMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVwMembers.Location = new System.Drawing.Point(493, 216);
            this.grdVwMembers.Name = "grdVwMembers";
            this.grdVwMembers.ReadOnly = true;
            this.grdVwMembers.RowTemplate.Height = 24;
            this.grdVwMembers.RowTemplate.ReadOnly = true;
            this.grdVwMembers.Size = new System.Drawing.Size(452, 461);
            this.grdVwMembers.TabIndex = 25;
            this.grdVwMembers.TabStop = false;
            this.grdVwMembers.DataSourceChanged += new System.EventHandler(this.grdVwSearchResult_DataSourceChanged);
            // 
            // btnPrintBill
            // 
            this.btnPrintBill.Location = new System.Drawing.Point(956, 332);
            this.btnPrintBill.Name = "btnPrintBill";
            this.btnPrintBill.Size = new System.Drawing.Size(332, 41);
            this.btnPrintBill.TabIndex = 26;
            this.btnPrintBill.Text = "Print Bill";
            this.btnPrintBill.UseVisualStyleBackColor = true;
            this.btnPrintBill.Visible = false;
            this.btnPrintBill.Click += new System.EventHandler(this.btnPrintBill_Click);
            // 
            // lblDt
            // 
            this.lblDt.AutoSize = true;
            this.lblDt.Location = new System.Drawing.Point(12, 70);
            this.lblDt.Name = "lblDt";
            this.lblDt.Size = new System.Drawing.Size(46, 17);
            this.lblDt.TabIndex = 27;
            this.lblDt.Text = "Date: ";
            // 
            // lblCashMemo
            // 
            this.lblCashMemo.AutoSize = true;
            this.lblCashMemo.Font = new System.Drawing.Font("Microsoft New Tai Lue", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashMemo.Location = new System.Drawing.Point(20, 9);
            this.lblCashMemo.Name = "lblCashMemo";
            this.lblCashMemo.Size = new System.Drawing.Size(156, 35);
            this.lblCashMemo.TabIndex = 28;
            this.lblCashMemo.Text = "Cash Memo";
            // 
            // lblCashMemoCounter
            // 
            this.lblCashMemoCounter.AutoSize = true;
            this.lblCashMemoCounter.Location = new System.Drawing.Point(296, 21);
            this.lblCashMemoCounter.Name = "lblCashMemoCounter";
            this.lblCashMemoCounter.Size = new System.Drawing.Size(83, 17);
            this.lblCashMemoCounter.TabIndex = 29;
            this.lblCashMemoCounter.Text = "MemoCount";
            // 
            // grdVwItems
            // 
            this.grdVwItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVwItems.Location = new System.Drawing.Point(15, 216);
            this.grdVwItems.Name = "grdVwItems";
            this.grdVwItems.RowTemplate.Height = 24;
            this.grdVwItems.Size = new System.Drawing.Size(455, 461);
            this.grdVwItems.TabIndex = 30;
            // 
            // lblFpsDealer
            // 
            this.lblFpsDealer.AutoSize = true;
            this.lblFpsDealer.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFpsDealer.Location = new System.Drawing.Point(411, 12);
            this.lblFpsDealer.Name = "lblFpsDealer";
            this.lblFpsDealer.Size = new System.Drawing.Size(293, 26);
            this.lblFpsDealer.TabIndex = 31;
            this.lblFpsDealer.Text = "F.P.S. DEALER :- JAYNTA GHOSH";
            // 
            // lblFPSCodeNo
            // 
            this.lblFPSCodeNo.AutoSize = true;
            this.lblFPSCodeNo.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFPSCodeNo.Location = new System.Drawing.Point(721, 9);
            this.lblFPSCodeNo.Name = "lblFPSCodeNo";
            this.lblFPSCodeNo.Size = new System.Drawing.Size(301, 26);
            this.lblFPSCodeNo.TabIndex = 32;
            this.lblFPSCodeNo.Text = "F.P.S. CODE NO. - 134301100020";
            // 
            // lblAddrLn1
            // 
            this.lblAddrLn1.AutoSize = true;
            this.lblAddrLn1.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddrLn1.Location = new System.Drawing.Point(411, 38);
            this.lblAddrLn1.Name = "lblAddrLn1";
            this.lblAddrLn1.Size = new System.Drawing.Size(303, 26);
            this.lblAddrLn1.TabIndex = 33;
            this.lblAddrLn1.Text = "27, R.N.C. Rd. (W), SUBHASGRAM";
            // 
            // lblAddrLn2
            // 
            this.lblAddrLn2.AutoSize = true;
            this.lblAddrLn2.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddrLn2.Location = new System.Drawing.Point(720, 44);
            this.lblAddrLn2.Name = "lblAddrLn2";
            this.lblAddrLn2.Size = new System.Drawing.Size(367, 26);
            this.lblAddrLn2.TabIndex = 34;
            this.lblAddrLn2.Text = "R.S.M. WARD NO. - 19, P.S. - SONARPUR";
            // 
            // lblAddrLn3
            // 
            this.lblAddrLn3.AutoSize = true;
            this.lblAddrLn3.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddrLn3.Location = new System.Drawing.Point(411, 64);
            this.lblAddrLn3.Name = "lblAddrLn3";
            this.lblAddrLn3.Size = new System.Drawing.Size(255, 26);
            this.lblAddrLn3.TabIndex = 35;
            this.lblAddrLn3.Text = "P.C. NO. KOLKATA - 700147";
            // 
            // lblBillNoText
            // 
            this.lblBillNoText.AutoSize = true;
            this.lblBillNoText.Location = new System.Drawing.Point(205, 21);
            this.lblBillNoText.Name = "lblBillNoText";
            this.lblBillNoText.Size = new System.Drawing.Size(61, 17);
            this.lblBillNoText.TabIndex = 36;
            this.lblBillNoText.Text = "Bill No. -";
            // 
            // lblCustomerPaid
            // 
            this.lblCustomerPaid.AutoSize = true;
            this.lblCustomerPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerPaid.Location = new System.Drawing.Point(952, 253);
            this.lblCustomerPaid.Name = "lblCustomerPaid";
            this.lblCustomerPaid.Size = new System.Drawing.Size(115, 20);
            this.lblCustomerPaid.TabIndex = 37;
            this.lblCustomerPaid.Text = "CustomerPaid";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(952, 141);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(46, 20);
            this.lblTotal.TabIndex = 38;
            this.lblTotal.Text = "Total";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.Location = new System.Drawing.Point(952, 290);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(70, 20);
            this.lblBalance.TabIndex = 39;
            this.lblBalance.Text = "Balance";
            // 
            // lblCustomerToPayRs
            // 
            this.lblCustomerToPayRs.AutoSize = true;
            this.lblCustomerToPayRs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerToPayRs.Location = new System.Drawing.Point(1242, 141);
            this.lblCustomerToPayRs.Name = "lblCustomerToPayRs";
            this.lblCustomerToPayRs.Size = new System.Drawing.Size(46, 20);
            this.lblCustomerToPayRs.TabIndex = 40;
            this.lblCustomerToPayRs.Text = "Total";
            // 
            // lblBalRs
            // 
            this.lblBalRs.AutoSize = true;
            this.lblBalRs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalRs.Location = new System.Drawing.Point(1218, 290);
            this.lblBalRs.Name = "lblBalRs";
            this.lblBalRs.Size = new System.Drawing.Size(70, 20);
            this.lblBalRs.TabIndex = 42;
            this.lblBalRs.Text = "Balance";
            // 
            // txtCustPaid
            // 
            this.txtCustPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustPaid.Location = new System.Drawing.Point(1205, 253);
            this.txtCustPaid.Name = "txtCustPaid";
            this.txtCustPaid.Size = new System.Drawing.Size(83, 26);
            this.txtCustPaid.TabIndex = 43;
            // 
            // lblTotalRsRounded
            // 
            this.lblTotalRsRounded.AutoSize = true;
            this.lblTotalRsRounded.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRsRounded.Location = new System.Drawing.Point(1242, 176);
            this.lblTotalRsRounded.Name = "lblTotalRsRounded";
            this.lblTotalRsRounded.Size = new System.Drawing.Size(46, 20);
            this.lblTotalRsRounded.TabIndex = 44;
            this.lblTotalRsRounded.Text = "Total";
            // 
            // lblTotalRoundedOff
            // 
            this.lblTotalRoundedOff.AutoSize = true;
            this.lblTotalRoundedOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRoundedOff.Location = new System.Drawing.Point(952, 176);
            this.lblTotalRoundedOff.Name = "lblTotalRoundedOff";
            this.lblTotalRoundedOff.Size = new System.Drawing.Size(157, 20);
            this.lblTotalRoundedOff.TabIndex = 45;
            this.lblTotalRoundedOff.Text = "Total (Rounded Off)";
            // 
            // lblMembersText
            // 
            this.lblMembersText.AutoSize = true;
            this.lblMembersText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMembersText.Location = new System.Drawing.Point(489, 176);
            this.lblMembersText.Name = "lblMembersText";
            this.lblMembersText.Size = new System.Drawing.Size(89, 20);
            this.lblMembersText.TabIndex = 46;
            this.lblMembersText.Text = "Members :";
            // 
            // lblItemsText
            // 
            this.lblItemsText.AutoSize = true;
            this.lblItemsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemsText.Location = new System.Drawing.Point(16, 104);
            this.lblItemsText.Name = "lblItemsText";
            this.lblItemsText.Size = new System.Drawing.Size(60, 20);
            this.lblItemsText.TabIndex = 47;
            this.lblItemsText.Text = "Items :";
            // 
            // cmbCommodity
            // 
            this.cmbCommodity.FormattingEnabled = true;
            this.cmbCommodity.Location = new System.Drawing.Point(15, 137);
            this.cmbCommodity.Name = "cmbCommodity";
            this.cmbCommodity.Size = new System.Drawing.Size(455, 24);
            this.cmbCommodity.TabIndex = 48;
            this.cmbCommodity.SelectedIndexChanged += new System.EventHandler(this.cmbCommodity_SelectedIndexChanged);
            // 
            // lblDiscountText
            // 
            this.lblDiscountText.AutoSize = true;
            this.lblDiscountText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountText.Location = new System.Drawing.Point(952, 216);
            this.lblDiscountText.Name = "lblDiscountText";
            this.lblDiscountText.Size = new System.Drawing.Size(157, 20);
            this.lblDiscountText.TabIndex = 50;
            this.lblDiscountText.Text = "Total (Rounded Off)";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(1242, 216);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(46, 20);
            this.lblDiscount.TabIndex = 49;
            this.lblDiscount.Text = "Total";
            // 
            // FrmRationBillDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 689);
            this.Controls.Add(this.lblDiscountText);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.cmbCommodity);
            this.Controls.Add(this.lblItemsText);
            this.Controls.Add(this.lblMembersText);
            this.Controls.Add(this.lblTotalRoundedOff);
            this.Controls.Add(this.lblTotalRsRounded);
            this.Controls.Add(this.txtCustPaid);
            this.Controls.Add(this.lblBalRs);
            this.Controls.Add(this.lblCustomerToPayRs);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblCustomerPaid);
            this.Controls.Add(this.lblBillNoText);
            this.Controls.Add(this.lblAddrLn3);
            this.Controls.Add(this.lblAddrLn2);
            this.Controls.Add(this.lblAddrLn1);
            this.Controls.Add(this.lblFPSCodeNo);
            this.Controls.Add(this.lblFpsDealer);
            this.Controls.Add(this.grdVwItems);
            this.Controls.Add(this.lblCashMemoCounter);
            this.Controls.Add(this.lblCashMemo);
            this.Controls.Add(this.lblDt);
            this.Controls.Add(this.btnPrintBill);
            this.Controls.Add(this.grdVwMembers);
            this.Name = "FrmRationBillDetails";
            this.Text = "RationBillDetails";
            this.Load += new System.EventHandler(this.RationBillDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdVwMembers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVwItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdVwMembers;
        private System.Windows.Forms.Button btnPrintBill;
        private System.Windows.Forms.Label lblDt;
        private System.Windows.Forms.Label lblCashMemo;
        private System.Windows.Forms.Label lblCashMemoCounter;
        private System.Windows.Forms.DataGridView grdVwItems;
        private System.Windows.Forms.Label lblFpsDealer;
        private System.Windows.Forms.Label lblFPSCodeNo;
        private System.Windows.Forms.Label lblAddrLn1;
        private System.Windows.Forms.Label lblAddrLn2;
        private System.Windows.Forms.Label lblAddrLn3;
        private System.Windows.Forms.Label lblBillNoText;
        private System.Windows.Forms.Label lblCustomerPaid;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblCustomerToPayRs;
        private System.Windows.Forms.Label lblBalRs;
        private System.Windows.Forms.TextBox txtCustPaid;
        private System.Windows.Forms.Label lblTotalRsRounded;
        private System.Windows.Forms.Label lblTotalRoundedOff;
        private System.Windows.Forms.Label lblMembersText;
        private System.Windows.Forms.Label lblItemsText;
        private System.Windows.Forms.ComboBox cmbCommodity;
        private System.Windows.Forms.Label lblDiscountText;
        private System.Windows.Forms.Label lblDiscount;
    }
}