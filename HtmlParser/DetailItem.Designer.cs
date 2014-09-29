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
            this.button1 = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.Add = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnFindEmail = new System.Windows.Forms.Button();
            this.lstFilterDetail = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.edtValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstFilter
            // 
            this.lstFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(613, 133);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView2.Location = new System.Drawing.Point(12, 162);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(675, 297);
            this.listView2.TabIndex = 3;
            this.listView2.UseCompatibleStateImageBehavior = false;
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
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(258, 89);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 7;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
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
            this.lstFilterDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstFilterDetail.FullRowSelect = true;
            this.lstFilterDetail.GridLines = true;
            this.lstFilterDetail.LabelEdit = true;
            this.lstFilterDetail.LabelWrap = false;
            this.lstFilterDetail.Location = new System.Drawing.Point(343, 29);
            this.lstFilterDetail.Name = "lstFilterDetail";
            this.lstFilterDetail.Size = new System.Drawing.Size(347, 97);
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
            this.edtValue.Location = new System.Drawing.Point(343, 133);
            this.edtValue.Name = "edtValue";
            this.edtValue.Size = new System.Drawing.Size(264, 20);
            this.edtValue.TabIndex = 10;
            // 
            // DetailItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 471);
            this.Controls.Add(this.edtValue);
            this.Controls.Add(this.lstFilterDetail);
            this.Controls.Add(this.btnFindEmail);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnFindEmail;
        private System.Windows.Forms.ListView lstFilterDetail;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox edtValue;
    }
}