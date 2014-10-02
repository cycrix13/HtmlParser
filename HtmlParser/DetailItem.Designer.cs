namespace HtmlParser
{
    partial class DetailItem
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
            this.lstFilter = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.lstResult = new System.Windows.Forms.ListView();
            this.Add = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnFindEmail = new System.Windows.Forms.Button();
            this.lstFilterDetail = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.edtValue = new System.Windows.Forms.TextBox();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lstFilter
            // 
            this.lstFilter.Location = new System.Drawing.Point(12, 29);
            this.lstFilter.Name = "lstFilter";
            this.lstFilter.Size = new System.Drawing.Size(239, 113);
            this.lstFilter.TabIndex = 0;
            this.lstFilter.UseCompatibleStateImageBehavior = false;
            this.lstFilter.View = System.Windows.Forms.View.List;
            this.lstFilter.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstFilter_ItemSelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter";
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(1018, 133);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lstResult
            // 
            this.lstResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lstResult.GridLines = true;
            this.lstResult.Location = new System.Drawing.Point(12, 208);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(1080, 586);
            this.lstResult.TabIndex = 3;
            this.lstResult.UseCompatibleStateImageBehavior = false;
            this.lstResult.View = System.Windows.Forms.View.Details;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(258, 29);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 4;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(258, 59);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(258, 89);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 7;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnFindEmail
            // 
            this.btnFindEmail.Location = new System.Drawing.Point(258, 119);
            this.btnFindEmail.Name = "btnFindEmail";
            this.btnFindEmail.Size = new System.Drawing.Size(75, 23);
            this.btnFindEmail.TabIndex = 8;
            this.btnFindEmail.Text = "Find email";
            this.btnFindEmail.UseVisualStyleBackColor = true;
            this.btnFindEmail.Click += new System.EventHandler(this.btnFindEmail_Click);
            // 
            // lstFilterDetail
            // 
            this.lstFilterDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFilterDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstFilterDetail.FullRowSelect = true;
            this.lstFilterDetail.GridLines = true;
            this.lstFilterDetail.LabelEdit = true;
            this.lstFilterDetail.LabelWrap = false;
            this.lstFilterDetail.Location = new System.Drawing.Point(343, 29);
            this.lstFilterDetail.Name = "lstFilterDetail";
            this.lstFilterDetail.Size = new System.Drawing.Size(752, 97);
            this.lstFilterDetail.TabIndex = 9;
            this.lstFilterDetail.UseCompatibleStateImageBehavior = false;
            this.lstFilterDetail.View = System.Windows.Forms.View.Details;
            this.lstFilterDetail.SelectedIndexChanged += new System.EventHandler(this.lstFilterDetail_SelectedIndexChanged);
            this.lstFilterDetail.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstFilterDetail_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Title";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 356;
            // 
            // edtValue
            // 
            this.edtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtValue.Location = new System.Drawing.Point(12, 148);
            this.edtValue.Name = "edtValue";
            this.edtValue.Size = new System.Drawing.Size(669, 20);
            this.edtValue.TabIndex = 10;
            this.edtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtValue_KeyPress);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "XPath";
            this.columnHeader3.Width = 648;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "email";
            this.columnHeader4.Width = 146;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "xpathRelative1";
            this.columnHeader5.Width = 66;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "relative1";
            this.columnHeader6.Width = 70;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "xpathRelative2";
            this.columnHeader7.Width = 72;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "relative2";
            // 
            // DetailItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 806);
            this.Controls.Add(this.edtValue);
            this.Controls.Add(this.lstFilterDetail);
            this.Controls.Add(this.btnFindEmail);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.lstResult);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstFilter);
            this.Name = "DetailItem";
            this.Text = "DetailItem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ListView lstResult;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnFindEmail;
        private System.Windows.Forms.ListView lstFilterDetail;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox edtValue;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
    }
}