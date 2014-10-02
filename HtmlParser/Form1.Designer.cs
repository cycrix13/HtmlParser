namespace HtmlParser
{
    partial class Form1
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
            this.btnImport = new System.Windows.Forms.Button();
            this.lstData = new System.Windows.Forms.ListView();
            this.columnNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnParse = new System.Windows.Forms.Button();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnExtract = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(13, 13);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import links";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lstData
            // 
            this.lstData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNumber,
            this.columnUrl,
            this.columnStatus,
            this.columnHeader1});
            this.lstData.FullRowSelect = true;
            this.lstData.GridLines = true;
            this.lstData.Location = new System.Drawing.Point(13, 42);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(796, 509);
            this.lstData.TabIndex = 1;
            this.lstData.UseCompatibleStateImageBehavior = false;
            this.lstData.View = System.Windows.Forms.View.Details;
            this.lstData.DoubleClick += new System.EventHandler(this.lstData_DoubleClick);
            this.lstData.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstData_MouseDoubleClick);
            // 
            // columnNumber
            // 
            this.columnNumber.Text = "#";
            this.columnNumber.Width = 36;
            // 
            // columnUrl
            // 
            this.columnUrl.Text = "URL";
            this.columnUrl.Width = 382;
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Status";
            this.columnStatus.Width = 143;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Data records";
            this.columnHeader1.Width = 91;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(95, 13);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(733, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(652, 13);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(177, 13);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(75, 23);
            this.btnParse.TabIndex = 5;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(259, 13);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(75, 23);
            this.btnAssign.TabIndex = 6;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnExtract
            // 
            this.btnExtract.Location = new System.Drawing.Point(341, 13);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(75, 23);
            this.btnExtract.TabIndex = 7;
            this.btnExtract.Text = "Extract";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 563);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.lstData);
            this.Controls.Add(this.btnImport);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ListView lstData;
        private System.Windows.Forms.ColumnHeader columnNumber;
        private System.Windows.Forms.ColumnHeader columnUrl;
        private System.Windows.Forms.ColumnHeader columnStatus;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnExtract;
    }
}

