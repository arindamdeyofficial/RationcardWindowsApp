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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRationBillDetails));
            this.grdVwMembers = new System.Windows.Forms.DataGridView();
            this.btnSaveBill = new System.Windows.Forms.Button();
            this.lblDt = new System.Windows.Forms.Label();
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
            this.lblSerialText = new System.Windows.Forms.Label();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.btnDelitem = new System.Windows.Forms.Button();
            this.picNetwork = new System.Windows.Forms.PictureBox();
            this.btnSaveAndPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdVwMembers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVwItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNetwork)).BeginInit();
            this.SuspendLayout();
            // 
            // grdVwMembers
            // 
            this.grdVwMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVwMembers.Location = new System.Drawing.Point(16, 144);
            this.grdVwMembers.Name = "grdVwMembers";
            this.grdVwMembers.ReadOnly = true;
            this.grdVwMembers.RowTemplate.Height = 24;
            this.grdVwMembers.RowTemplate.ReadOnly = true;
            this.grdVwMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdVwMembers.Size = new System.Drawing.Size(510, 274);
            this.grdVwMembers.TabIndex = 25;
            this.grdVwMembers.TabStop = false;
            this.grdVwMembers.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdVwMembers_DataBindingComplete);
            // 
            // btnSaveBill
            // 
            this.btnSaveBill.Location = new System.Drawing.Point(1000, 186);
            this.btnSaveBill.Name = "btnSaveBill";
            this.btnSaveBill.Size = new System.Drawing.Size(188, 48);
            this.btnSaveBill.TabIndex = 26;
            this.btnSaveBill.Text = "Save Bill";
            this.btnSaveBill.UseVisualStyleBackColor = true;
            this.btnSaveBill.Visible = false;
            this.btnSaveBill.Click += new System.EventHandler(this.btnSaveBill_Click);
            // 
            // lblDt
            // 
            this.lblDt.AutoSize = true;
            this.lblDt.Location = new System.Drawing.Point(12, 55);
            this.lblDt.Name = "lblDt";
            this.lblDt.Size = new System.Drawing.Size(46, 17);
            this.lblDt.TabIndex = 27;
            this.lblDt.Text = "Date: ";
            // 
            // lblCashMemoCounter
            // 
            this.lblCashMemoCounter.AutoSize = true;
            this.lblCashMemoCounter.Location = new System.Drawing.Point(107, 19);
            this.lblCashMemoCounter.Name = "lblCashMemoCounter";
            this.lblCashMemoCounter.Size = new System.Drawing.Size(83, 17);
            this.lblCashMemoCounter.TabIndex = 29;
            this.lblCashMemoCounter.Text = "MemoCount";
            // 
            // grdVwItems
            // 
            this.grdVwItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVwItems.Location = new System.Drawing.Point(12, 496);
            this.grdVwItems.Name = "grdVwItems";
            this.grdVwItems.RowTemplate.Height = 24;
            this.grdVwItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdVwItems.Size = new System.Drawing.Size(1176, 268);
            this.grdVwItems.TabIndex = 30;
            this.grdVwItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdVwItems_CellDoubleClick);
            // 
            // lblFpsDealer
            // 
            this.lblFpsDealer.AutoSize = true;
            this.lblFpsDealer.Font = new System.Drawing.Font("Microsoft New Tai Lue", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFpsDealer.Location = new System.Drawing.Point(504, 9);
            this.lblFpsDealer.Name = "lblFpsDealer";
            this.lblFpsDealer.Size = new System.Drawing.Size(209, 19);
            this.lblFpsDealer.TabIndex = 31;
            this.lblFpsDealer.Text = "F.P.S. DEALER :- JAYNTA GHOSH";
            // 
            // lblFPSCodeNo
            // 
            this.lblFPSCodeNo.AutoSize = true;
            this.lblFPSCodeNo.Font = new System.Drawing.Font("Microsoft New Tai Lue", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFPSCodeNo.Location = new System.Drawing.Point(719, 9);
            this.lblFPSCodeNo.Name = "lblFPSCodeNo";
            this.lblFPSCodeNo.Size = new System.Drawing.Size(219, 19);
            this.lblFPSCodeNo.TabIndex = 32;
            this.lblFPSCodeNo.Text = "F.P.S. CODE NO. - 134301100020";
            // 
            // lblAddrLn1
            // 
            this.lblAddrLn1.AutoSize = true;
            this.lblAddrLn1.Font = new System.Drawing.Font("Microsoft New Tai Lue", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddrLn1.Location = new System.Drawing.Point(719, 37);
            this.lblAddrLn1.Name = "lblAddrLn1";
            this.lblAddrLn1.Size = new System.Drawing.Size(214, 19);
            this.lblAddrLn1.TabIndex = 33;
            this.lblAddrLn1.Text = "27, R.N.C. Rd. (W), SUBHASGRAM";
            // 
            // lblAddrLn2
            // 
            this.lblAddrLn2.AutoSize = true;
            this.lblAddrLn2.Font = new System.Drawing.Font("Microsoft New Tai Lue", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddrLn2.Location = new System.Drawing.Point(441, 37);
            this.lblAddrLn2.Name = "lblAddrLn2";
            this.lblAddrLn2.Size = new System.Drawing.Size(261, 19);
            this.lblAddrLn2.TabIndex = 34;
            this.lblAddrLn2.Text = "R.S.M. WARD NO. - 19, P.S. - SONARPUR";
            // 
            // lblAddrLn3
            // 
            this.lblAddrLn3.AutoSize = true;
            this.lblAddrLn3.Font = new System.Drawing.Font("Microsoft New Tai Lue", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddrLn3.Location = new System.Drawing.Point(951, 37);
            this.lblAddrLn3.Name = "lblAddrLn3";
            this.lblAddrLn3.Size = new System.Drawing.Size(130, 19);
            this.lblAddrLn3.TabIndex = 35;
            this.lblAddrLn3.Text = "KOLKATA - 700147";
            // 
            // lblBillNoText
            // 
            this.lblBillNoText.AutoSize = true;
            this.lblBillNoText.Location = new System.Drawing.Point(16, 19);
            this.lblBillNoText.Name = "lblBillNoText";
            this.lblBillNoText.Size = new System.Drawing.Size(61, 17);
            this.lblBillNoText.TabIndex = 36;
            this.lblBillNoText.Text = "Bill No. -";
            // 
            // lblCustomerPaid
            // 
            this.lblCustomerPaid.AutoSize = true;
            this.lblCustomerPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerPaid.Location = new System.Drawing.Point(585, 276);
            this.lblCustomerPaid.Name = "lblCustomerPaid";
            this.lblCustomerPaid.Size = new System.Drawing.Size(140, 20);
            this.lblCustomerPaid.TabIndex = 37;
            this.lblCustomerPaid.Text = "Recieved Amount";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(585, 164);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(46, 20);
            this.lblTotal.TabIndex = 38;
            this.lblTotal.Text = "Total";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.Location = new System.Drawing.Point(585, 313);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(125, 20);
            this.lblBalance.TabIndex = 39;
            this.lblBalance.Text = "Balance Return";
            // 
            // lblCustomerToPayRs
            // 
            this.lblCustomerToPayRs.AutoSize = true;
            this.lblCustomerToPayRs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerToPayRs.Location = new System.Drawing.Point(875, 164);
            this.lblCustomerToPayRs.Name = "lblCustomerToPayRs";
            this.lblCustomerToPayRs.Size = new System.Drawing.Size(46, 20);
            this.lblCustomerToPayRs.TabIndex = 40;
            this.lblCustomerToPayRs.Text = "Total";
            // 
            // lblBalRs
            // 
            this.lblBalRs.AutoSize = true;
            this.lblBalRs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalRs.Location = new System.Drawing.Point(851, 313);
            this.lblBalRs.Name = "lblBalRs";
            this.lblBalRs.Size = new System.Drawing.Size(70, 20);
            this.lblBalRs.TabIndex = 42;
            this.lblBalRs.Text = "Balance";
            // 
            // txtCustPaid
            // 
            this.txtCustPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustPaid.Location = new System.Drawing.Point(838, 276);
            this.txtCustPaid.Name = "txtCustPaid";
            this.txtCustPaid.Size = new System.Drawing.Size(83, 26);
            this.txtCustPaid.TabIndex = 43;
            this.txtCustPaid.TextChanged += new System.EventHandler(this.txtCustPaid_TextChanged);
            this.txtCustPaid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustPaid_KeyPress);
            // 
            // lblTotalRsRounded
            // 
            this.lblTotalRsRounded.AutoSize = true;
            this.lblTotalRsRounded.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRsRounded.Location = new System.Drawing.Point(875, 199);
            this.lblTotalRsRounded.Name = "lblTotalRsRounded";
            this.lblTotalRsRounded.Size = new System.Drawing.Size(46, 20);
            this.lblTotalRsRounded.TabIndex = 44;
            this.lblTotalRsRounded.Text = "Total";
            // 
            // lblTotalRoundedOff
            // 
            this.lblTotalRoundedOff.AutoSize = true;
            this.lblTotalRoundedOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRoundedOff.Location = new System.Drawing.Point(585, 199);
            this.lblTotalRoundedOff.Name = "lblTotalRoundedOff";
            this.lblTotalRoundedOff.Size = new System.Drawing.Size(157, 20);
            this.lblTotalRoundedOff.TabIndex = 45;
            this.lblTotalRoundedOff.Text = "Total (Rounded Off)";
            // 
            // lblMembersText
            // 
            this.lblMembersText.AutoSize = true;
            this.lblMembersText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMembersText.Location = new System.Drawing.Point(12, 108);
            this.lblMembersText.Name = "lblMembersText";
            this.lblMembersText.Size = new System.Drawing.Size(89, 20);
            this.lblMembersText.TabIndex = 46;
            this.lblMembersText.Text = "Members :";
            // 
            // lblItemsText
            // 
            this.lblItemsText.AutoSize = true;
            this.lblItemsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemsText.Location = new System.Drawing.Point(19, 421);
            this.lblItemsText.Name = "lblItemsText";
            this.lblItemsText.Size = new System.Drawing.Size(60, 20);
            this.lblItemsText.TabIndex = 47;
            this.lblItemsText.Text = "Items :";
            // 
            // cmbCommodity
            // 
            this.cmbCommodity.FormattingEnabled = true;
            this.cmbCommodity.Location = new System.Drawing.Point(18, 454);
            this.cmbCommodity.Name = "cmbCommodity";
            this.cmbCommodity.Size = new System.Drawing.Size(395, 24);
            this.cmbCommodity.TabIndex = 48;
            this.cmbCommodity.SelectedIndexChanged += new System.EventHandler(this.cmbCommodity_SelectedIndexChanged);
            this.cmbCommodity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCommodity_KeyPress);
            this.cmbCommodity.Leave += new System.EventHandler(this.cmbCommodity_Leave);
            this.cmbCommodity.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbCommodity_MouseClick);
            // 
            // lblDiscountText
            // 
            this.lblDiscountText.AutoSize = true;
            this.lblDiscountText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountText.Location = new System.Drawing.Point(585, 239);
            this.lblDiscountText.Name = "lblDiscountText";
            this.lblDiscountText.Size = new System.Drawing.Size(76, 20);
            this.lblDiscountText.TabIndex = 50;
            this.lblDiscountText.Text = "Discount";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(875, 239);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(46, 20);
            this.lblDiscount.TabIndex = 49;
            this.lblDiscount.Text = "Total";
            // 
            // lblSerialText
            // 
            this.lblSerialText.AutoSize = true;
            this.lblSerialText.Location = new System.Drawing.Point(237, 19);
            this.lblSerialText.Name = "lblSerialText";
            this.lblSerialText.Size = new System.Drawing.Size(75, 17);
            this.lblSerialText.TabIndex = 52;
            this.lblSerialText.Text = "SerialNo. -";
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.AutoSize = true;
            this.lblSerialNumber.Location = new System.Drawing.Point(328, 19);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Size = new System.Drawing.Size(81, 17);
            this.lblSerialNumber.TabIndex = 51;
            this.lblSerialNumber.Text = "SerialCount";
            // 
            // btnDelitem
            // 
            this.btnDelitem.Location = new System.Drawing.Point(487, 440);
            this.btnDelitem.Name = "btnDelitem";
            this.btnDelitem.Size = new System.Drawing.Size(132, 50);
            this.btnDelitem.TabIndex = 53;
            this.btnDelitem.Text = "Delete Item";
            this.btnDelitem.UseVisualStyleBackColor = true;
            this.btnDelitem.Click += new System.EventHandler(this.btnDelitem_Click);
            // 
            // picNetwork
            // 
            this.picNetwork.Image = ((System.Drawing.Image)(resources.GetObject("picNetwork.Image")));
            this.picNetwork.Location = new System.Drawing.Point(1106, 74);
            this.picNetwork.Name = "picNetwork";
            this.picNetwork.Size = new System.Drawing.Size(82, 76);
            this.picNetwork.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNetwork.TabIndex = 54;
            this.picNetwork.TabStop = false;
            // 
            // btnSaveAndPrint
            // 
            this.btnSaveAndPrint.Location = new System.Drawing.Point(1000, 276);
            this.btnSaveAndPrint.Name = "btnSaveAndPrint";
            this.btnSaveAndPrint.Size = new System.Drawing.Size(188, 55);
            this.btnSaveAndPrint.TabIndex = 55;
            this.btnSaveAndPrint.Text = "Save and Print Bill";
            this.btnSaveAndPrint.UseVisualStyleBackColor = true;
            this.btnSaveAndPrint.Click += new System.EventHandler(this.btnSaveAndPrint_Click);
            // 
            // FrmRationBillDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 776);
            this.Controls.Add(this.btnSaveAndPrint);
            this.Controls.Add(this.picNetwork);
            this.Controls.Add(this.btnDelitem);
            this.Controls.Add(this.lblSerialText);
            this.Controls.Add(this.lblSerialNumber);
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
            this.Controls.Add(this.lblDt);
            this.Controls.Add(this.btnSaveBill);
            this.Controls.Add(this.grdVwMembers);
            this.Name = "FrmRationBillDetails";
            this.Text = "Ration Bill";
            this.Load += new System.EventHandler(this.RationBillDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdVwMembers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVwItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNetwork)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdVwMembers;
        private System.Windows.Forms.Button btnSaveBill;
        private System.Windows.Forms.Label lblDt;
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
        private System.Windows.Forms.Label lblSerialText;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.Button btnDelitem;
        private System.Windows.Forms.PictureBox picNetwork;
        private System.Windows.Forms.Button btnSaveAndPrint;
    }
}