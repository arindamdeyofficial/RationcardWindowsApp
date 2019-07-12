namespace RationCard.HelperForms
{
    partial class FrmFrameworkVersion
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
            this.drVwDotNetVersions = new System.Windows.Forms.DataGridView();
            this.lblLatestVersion = new System.Windows.Forms.Label();
            this.lblIsLatest = new System.Windows.Forms.Label();
            this.lblLink = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnCopylink = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.drVwDotNetVersions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // drVwDotNetVersions
            // 
            this.drVwDotNetVersions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drVwDotNetVersions.Location = new System.Drawing.Point(12, 20);
            this.drVwDotNetVersions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.drVwDotNetVersions.Name = "drVwDotNetVersions";
            this.drVwDotNetVersions.RowTemplate.Height = 24;
            this.drVwDotNetVersions.Size = new System.Drawing.Size(734, 225);
            this.drVwDotNetVersions.TabIndex = 51;
            // 
            // lblLatestVersion
            // 
            this.lblLatestVersion.AutoSize = true;
            this.lblLatestVersion.Location = new System.Drawing.Point(488, 324);
            this.lblLatestVersion.Name = "lblLatestVersion";
            this.lblLatestVersion.Size = new System.Drawing.Size(95, 17);
            this.lblLatestVersion.TabIndex = 52;
            this.lblLatestVersion.Text = "LatestVersion";
            // 
            // lblIsLatest
            // 
            this.lblIsLatest.AutoSize = true;
            this.lblIsLatest.Location = new System.Drawing.Point(505, 281);
            this.lblIsLatest.Name = "lblIsLatest";
            this.lblIsLatest.Size = new System.Drawing.Size(57, 17);
            this.lblIsLatest.TabIndex = 53;
            this.lblIsLatest.Text = "IsLatest";
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLink.Location = new System.Drawing.Point(12, 441);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(871, 18);
            this.lblLink.TabIndex = 54;
            this.lblLink.Text = "https://docs.microsoft.com/en-us/dotnet/framework/migration-guide/how-to-determin" +
    "e-which-versions-are-installed";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(15, 478);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1411, 290);
            this.webBrowser1.TabIndex = 55;
            // 
            // btnCopylink
            // 
            this.btnCopylink.Location = new System.Drawing.Point(1299, 430);
            this.btnCopylink.Name = "btnCopylink";
            this.btnCopylink.Size = new System.Drawing.Size(127, 43);
            this.btnCopylink.TabIndex = 58;
            this.btnCopylink.Text = "Copy Link";
            this.btnCopylink.UseVisualStyleBackColor = true;
            this.btnCopylink.Click += new System.EventHandler(this.btnCopylink_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::RationCard.Properties.Resources.dotNet4;
            this.pictureBox2.Location = new System.Drawing.Point(756, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(674, 369);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 57;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RationCard.Properties.Resources.dotnet1to4;
            this.pictureBox1.Location = new System.Drawing.Point(12, 250);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(421, 167);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 56;
            this.pictureBox1.TabStop = false;
            // 
            // FrmFrameworkVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1438, 780);
            this.Controls.Add(this.btnCopylink);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.lblLink);
            this.Controls.Add(this.lblIsLatest);
            this.Controls.Add(this.lblLatestVersion);
            this.Controls.Add(this.drVwDotNetVersions);
            this.Name = "FrmFrameworkVersion";
            this.Text = "FrameworkVersion";
            this.Load += new System.EventHandler(this.FrmFrameworkVersion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.drVwDotNetVersions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView drVwDotNetVersions;
        private System.Windows.Forms.Label lblLatestVersion;
        private System.Windows.Forms.Label lblIsLatest;
        private System.Windows.Forms.Label lblLink;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnCopylink;
    }
}