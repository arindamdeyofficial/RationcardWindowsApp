namespace RationCard
{
    partial class FrmStockSummary
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
            this.btnAddPrdToInventory = new System.Windows.Forms.Button();
            this.grdVwPrds = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtPrdName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.cmbSubDept = new System.Windows.Forms.ComboBox();
            this.txtBrandCompany = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbMcDesc = new System.Windows.Forms.ComboBox();
            this.cmbSubClass = new System.Windows.Forms.ComboBox();
            this.txtMcCode = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtArticleCode = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.chkDefaultProduct = new System.Windows.Forms.CheckBox();
            this.chkDefaultToGiveRation = new System.Windows.Forms.CheckBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.btnRefreshProduct = new System.Windows.Forms.Button();
            this.btnDelPrd = new System.Windows.Forms.Button();
            this.txtProdDesc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPrintStockReport = new System.Windows.Forms.Button();
            this.btnStckReportForDefaultProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdVwPrds)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddPrdToInventory
            // 
            this.btnAddPrdToInventory.Location = new System.Drawing.Point(208, 680);
            this.btnAddPrdToInventory.Name = "btnAddPrdToInventory";
            this.btnAddPrdToInventory.Size = new System.Drawing.Size(156, 49);
            this.btnAddPrdToInventory.TabIndex = 0;
            this.btnAddPrdToInventory.Text = "Add Product To Inventory";
            this.btnAddPrdToInventory.UseVisualStyleBackColor = true;
            this.btnAddPrdToInventory.Click += new System.EventHandler(this.btnAddPrdToInventory_Click);
            // 
            // grdVwPrds
            // 
            this.grdVwPrds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVwPrds.Location = new System.Drawing.Point(404, 12);
            this.grdVwPrds.Name = "grdVwPrds";
            this.grdVwPrds.RowTemplate.Height = 24;
            this.grdVwPrds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdVwPrds.Size = new System.Drawing.Size(722, 650);
            this.grdVwPrds.TabIndex = 25;
            this.grdVwPrds.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdVwPrds_CellDoubleClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(32, 680);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(132, 49);
            this.btnSearch.TabIndex = 26;
            this.btnSearch.Text = "Search Product";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtPrdName
            // 
            this.txtPrdName.Location = new System.Drawing.Point(117, 90);
            this.txtPrdName.Name = "txtPrdName";
            this.txtPrdName.Size = new System.Drawing.Size(247, 22);
            this.txtPrdName.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 30;
            this.label2.Text = "Product Name";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.cmbDept);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.cmbBrand);
            this.groupBox4.Controls.Add(this.cmbSubDept);
            this.groupBox4.Controls.Add(this.txtBrandCompany);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.cmbClass);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.cmbMcDesc);
            this.groupBox4.Controls.Add(this.cmbSubClass);
            this.groupBox4.Controls.Add(this.txtMcCode);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Location = new System.Drawing.Point(16, 290);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(348, 372);
            this.groupBox4.TabIndex = 46;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Herarchy";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(84, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 17);
            this.label12.TabIndex = 29;
            this.label12.Text = "Dept";
            // 
            // cmbDept
            // 
            this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.Location = new System.Drawing.Point(144, 24);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(149, 24);
            this.cmbDept.TabIndex = 30;
            this.cmbDept.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(55, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 17);
            this.label13.TabIndex = 31;
            this.label13.Text = "Sub Dept";
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(144, 290);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(149, 24);
            this.cmbBrand.TabIndex = 44;
            this.cmbBrand.SelectedIndexChanged += new System.EventHandler(this.cmbBrand_SelectedIndexChanged);
            // 
            // cmbSubDept
            // 
            this.cmbSubDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubDept.FormattingEnabled = true;
            this.cmbSubDept.Location = new System.Drawing.Point(144, 67);
            this.cmbSubDept.Name = "cmbSubDept";
            this.cmbSubDept.Size = new System.Drawing.Size(149, 24);
            this.cmbSubDept.TabIndex = 32;
            this.cmbSubDept.SelectedIndexChanged += new System.EventHandler(this.cmbSubDept_SelectedIndexChanged);
            // 
            // txtBrandCompany
            // 
            this.txtBrandCompany.Location = new System.Drawing.Point(144, 333);
            this.txtBrandCompany.Name = "txtBrandCompany";
            this.txtBrandCompany.Size = new System.Drawing.Size(149, 22);
            this.txtBrandCompany.TabIndex = 41;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(80, 121);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 17);
            this.label16.TabIndex = 33;
            this.label16.Text = "Class";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(72, 293);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(46, 17);
            this.label19.TabIndex = 43;
            this.label19.Text = "Brand";
            // 
            // cmbClass
            // 
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(144, 114);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(149, 24);
            this.cmbClass.TabIndex = 34;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(13, 338);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(109, 17);
            this.label20.TabIndex = 42;
            this.label20.Text = "Brand Company";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(51, 164);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 17);
            this.label15.TabIndex = 35;
            this.label15.Text = "Sub Class";
            // 
            // cmbMcDesc
            // 
            this.cmbMcDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMcDesc.FormattingEnabled = true;
            this.cmbMcDesc.Location = new System.Drawing.Point(144, 201);
            this.cmbMcDesc.Name = "cmbMcDesc";
            this.cmbMcDesc.Size = new System.Drawing.Size(149, 24);
            this.cmbMcDesc.TabIndex = 40;
            this.cmbMcDesc.SelectedIndexChanged += new System.EventHandler(this.cmbMcDesc_SelectedIndexChanged);
            // 
            // cmbSubClass
            // 
            this.cmbSubClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubClass.FormattingEnabled = true;
            this.cmbSubClass.Location = new System.Drawing.Point(144, 157);
            this.cmbSubClass.Name = "cmbSubClass";
            this.cmbSubClass.Size = new System.Drawing.Size(149, 24);
            this.cmbSubClass.TabIndex = 36;
            this.cmbSubClass.SelectedIndexChanged += new System.EventHandler(this.cmbSubClass_SelectedIndexChanged);
            // 
            // txtMcCode
            // 
            this.txtMcCode.Location = new System.Drawing.Point(144, 244);
            this.txtMcCode.Name = "txtMcCode";
            this.txtMcCode.Size = new System.Drawing.Size(149, 22);
            this.txtMcCode.TabIndex = 29;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(53, 244);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 17);
            this.label18.TabIndex = 37;
            this.label18.Text = "MC Code";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(58, 208);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 17);
            this.label17.TabIndex = 39;
            this.label17.Text = "MC Desc";
            // 
            // txtArticleCode
            // 
            this.txtArticleCode.Location = new System.Drawing.Point(117, 51);
            this.txtArticleCode.Name = "txtArticleCode";
            this.txtArticleCode.Size = new System.Drawing.Size(247, 22);
            this.txtArticleCode.TabIndex = 49;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(26, 56);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(84, 17);
            this.label21.TabIndex = 50;
            this.label21.Text = "Article Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 48;
            this.label3.Text = "Bar Code";
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(117, 12);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(247, 22);
            this.txtBarCode.TabIndex = 47;
            // 
            // chkDefaultProduct
            // 
            this.chkDefaultProduct.AutoSize = true;
            this.chkDefaultProduct.Location = new System.Drawing.Point(237, 171);
            this.chkDefaultProduct.Name = "chkDefaultProduct";
            this.chkDefaultProduct.Size = new System.Drawing.Size(127, 21);
            this.chkDefaultProduct.TabIndex = 53;
            this.chkDefaultProduct.Text = "Default product";
            this.chkDefaultProduct.UseVisualStyleBackColor = true;
            // 
            // chkDefaultToGiveRation
            // 
            this.chkDefaultToGiveRation.AutoSize = true;
            this.chkDefaultToGiveRation.Checked = true;
            this.chkDefaultToGiveRation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDefaultToGiveRation.Location = new System.Drawing.Point(127, 171);
            this.chkDefaultToGiveRation.Name = "chkDefaultToGiveRation";
            this.chkDefaultToGiveRation.Size = new System.Drawing.Size(104, 21);
            this.chkDefaultToGiveRation.TabIndex = 51;
            this.chkDefaultToGiveRation.Text = "Give Ration";
            this.chkDefaultToGiveRation.UseVisualStyleBackColor = true;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(44, 171);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(68, 21);
            this.chkActive.TabIndex = 52;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // btnRefreshProduct
            // 
            this.btnRefreshProduct.Location = new System.Drawing.Point(1005, 680);
            this.btnRefreshProduct.Name = "btnRefreshProduct";
            this.btnRefreshProduct.Size = new System.Drawing.Size(119, 49);
            this.btnRefreshProduct.TabIndex = 55;
            this.btnRefreshProduct.Text = "Refresh All Product";
            this.btnRefreshProduct.UseVisualStyleBackColor = true;
            this.btnRefreshProduct.Click += new System.EventHandler(this.btnRefreshProduct_Click);
            // 
            // btnDelPrd
            // 
            this.btnDelPrd.Location = new System.Drawing.Point(813, 680);
            this.btnDelPrd.Name = "btnDelPrd";
            this.btnDelPrd.Size = new System.Drawing.Size(172, 49);
            this.btnDelPrd.TabIndex = 56;
            this.btnDelPrd.Text = "Delete Product From Inventory";
            this.btnDelPrd.UseVisualStyleBackColor = true;
            this.btnDelPrd.Click += new System.EventHandler(this.btnDelPrd_Click);
            // 
            // txtProdDesc
            // 
            this.txtProdDesc.Location = new System.Drawing.Point(117, 132);
            this.txtProdDesc.Name = "txtProdDesc";
            this.txtProdDesc.Size = new System.Drawing.Size(247, 22);
            this.txtProdDesc.TabIndex = 58;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 17);
            this.label9.TabIndex = 57;
            this.label9.Text = "Description";
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(77, 211);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(200, 22);
            this.dtFrom.TabIndex = 59;
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(77, 253);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(200, 22);
            this.dtTo.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 61;
            this.label1.Text = "From";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 17);
            this.label4.TabIndex = 62;
            this.label4.Text = "To";
            // 
            // btnPrintStockReport
            // 
            this.btnPrintStockReport.Location = new System.Drawing.Point(404, 680);
            this.btnPrintStockReport.Name = "btnPrintStockReport";
            this.btnPrintStockReport.Size = new System.Drawing.Size(183, 49);
            this.btnPrintStockReport.TabIndex = 68;
            this.btnPrintStockReport.Text = "Print Stock Report";
            this.btnPrintStockReport.UseVisualStyleBackColor = true;
            this.btnPrintStockReport.Click += new System.EventHandler(this.btnPrintStockReport_Click);
            // 
            // btnStckReportForDefaultProduct
            // 
            this.btnStckReportForDefaultProduct.Location = new System.Drawing.Point(617, 680);
            this.btnStckReportForDefaultProduct.Name = "btnStckReportForDefaultProduct";
            this.btnStckReportForDefaultProduct.Size = new System.Drawing.Size(174, 49);
            this.btnStckReportForDefaultProduct.TabIndex = 69;
            this.btnStckReportForDefaultProduct.Text = "Print Stock For Default Products";
            this.btnStckReportForDefaultProduct.UseVisualStyleBackColor = true;
            this.btnStckReportForDefaultProduct.Click += new System.EventHandler(this.btnStckReportForDefaultProduct_Click);
            // 
            // FrmStockSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 741);
            this.Controls.Add(this.btnStckReportForDefaultProduct);
            this.Controls.Add(this.btnPrintStockReport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.txtProdDesc);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnDelPrd);
            this.Controls.Add(this.btnRefreshProduct);
            this.Controls.Add(this.chkDefaultProduct);
            this.Controls.Add(this.chkDefaultToGiveRation);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.txtArticleCode);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.txtPrdName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.grdVwPrds);
            this.Controls.Add(this.btnAddPrdToInventory);
            this.Name = "FrmStockSummary";
            this.Text = "Stock Summary";
            this.Load += new System.EventHandler(this.FrmStockSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdVwPrds)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddPrdToInventory;
        private System.Windows.Forms.DataGridView grdVwPrds;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtPrdName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbDept;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.ComboBox cmbSubDept;
        private System.Windows.Forms.TextBox txtBrandCompany;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbMcDesc;
        private System.Windows.Forms.ComboBox cmbSubClass;
        private System.Windows.Forms.TextBox txtMcCode;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtArticleCode;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.CheckBox chkDefaultProduct;
        private System.Windows.Forms.CheckBox chkDefaultToGiveRation;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnRefreshProduct;
        private System.Windows.Forms.Button btnDelPrd;
        private System.Windows.Forms.TextBox txtProdDesc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPrintStockReport;
        private System.Windows.Forms.Button btnStckReportForDefaultProduct;
    }
}