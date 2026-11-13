namespace ToDoManager
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // コントロール宣言（F接頭辞＋パスカル型）
        private System.Windows.Forms.TextBox FTxtTitle;
        private System.Windows.Forms.TextBox FTxtContent;
        private System.Windows.Forms.DateTimePicker FDtpDueDate;
        private System.Windows.Forms.CheckBox FChkDone;
        private System.Windows.Forms.ListBox FLstItems;
        private System.Windows.Forms.Button FBtnAdd;
        private System.Windows.Forms.Button FBtnEdit;
        private System.Windows.Forms.Button FBtnDelete;
        private System.Windows.Forms.Button FBtnXml;
        private System.Windows.Forms.Button FBtnXmlLoad;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByDueDateToolStripMenuItem;
        private System.Windows.Forms.StatusStrip FStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel FStatusLabel;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.FTxtTitle = new System.Windows.Forms.TextBox();
            this.FTxtContent = new System.Windows.Forms.TextBox();
            this.FDtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.FChkDone = new System.Windows.Forms.CheckBox();
            this.FLstItems = new System.Windows.Forms.ListBox();
            this.FBtnAdd = new System.Windows.Forms.Button();
            this.FBtnEdit = new System.Windows.Forms.Button();
            this.FBtnDelete = new System.Windows.Forms.Button();
            this.FBtnXml = new System.Windows.Forms.Button();
            this.FBtnXmlLoad = new System.Windows.Forms.Button();
            this.FTitleLabel = new System.Windows.Forms.Label();
            this.FContentLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByDueDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FStatusStrip = new System.Windows.Forms.StatusStrip();
            this.FStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.FMainCmbPriority = new System.Windows.Forms.ComboBox();
            this.FMainPriorityLabel = new System.Windows.Forms.Label();
            this.FToolStripSearch = new System.Windows.Forms.ToolStrip();
            this.FToolStripTxtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.FToolStripBtnSearch = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.FStatusStrip.SuspendLayout();
            this.FToolStripSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // FTxtTitle
            // 
            this.FTxtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FTxtTitle.Location = new System.Drawing.Point(290, 111);
            this.FTxtTitle.Name = "FTxtTitle";
            this.FTxtTitle.Size = new System.Drawing.Size(200, 19);
            this.FTxtTitle.TabIndex = 5;
            // 
            // FTxtContent
            // 
            this.FTxtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FTxtContent.Location = new System.Drawing.Point(290, 155);
            this.FTxtContent.Multiline = true;
            this.FTxtContent.Name = "FTxtContent";
            this.FTxtContent.Size = new System.Drawing.Size(200, 60);
            this.FTxtContent.TabIndex = 6;
            // 
            // FDtpDueDate
            // 
            this.FDtpDueDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FDtpDueDate.Location = new System.Drawing.Point(290, 225);
            this.FDtpDueDate.Name = "FDtpDueDate";
            this.FDtpDueDate.Size = new System.Drawing.Size(200, 19);
            this.FDtpDueDate.TabIndex = 7;
            // 
            // FChkDone
            // 
            this.FChkDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FChkDone.Location = new System.Drawing.Point(290, 255);
            this.FChkDone.Name = "FChkDone";
            this.FChkDone.Size = new System.Drawing.Size(80, 19);
            this.FChkDone.TabIndex = 9;
            this.FChkDone.Text = "完了";
            // 
            // FLstItems
            // 
            this.FLstItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FLstItems.ItemHeight = 12;
            this.FLstItems.Location = new System.Drawing.Point(8, 55);
            this.FLstItems.MinimumSize = new System.Drawing.Size(100, 200);
            this.FLstItems.Name = "FLstItems";
            this.FLstItems.Size = new System.Drawing.Size(246, 256);
            this.FLstItems.TabIndex = 1;
            this.FLstItems.SelectedIndexChanged += new System.EventHandler(this.FLstItems_SelectedIndexChanged);
            // 
            // FBtnAdd
            // 
            this.FBtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FBtnAdd.Location = new System.Drawing.Point(290, 55);
            this.FBtnAdd.Name = "FBtnAdd";
            this.FBtnAdd.Size = new System.Drawing.Size(56, 30);
            this.FBtnAdd.TabIndex = 2;
            this.FBtnAdd.Text = "追加(&A)";
            this.FBtnAdd.UseVisualStyleBackColor = true;
            this.FBtnAdd.Click += new System.EventHandler(this.FBtnAdd_Click);
            // 
            // FBtnEdit
            // 
            this.FBtnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FBtnEdit.Location = new System.Drawing.Point(419, 55);
            this.FBtnEdit.Name = "FBtnEdit";
            this.FBtnEdit.Size = new System.Drawing.Size(56, 30);
            this.FBtnEdit.TabIndex = 4;
            this.FBtnEdit.Text = "編集(&E)";
            this.FBtnEdit.UseVisualStyleBackColor = true;
            this.FBtnEdit.Click += new System.EventHandler(this.FBtnEdit_Click);
            // 
            // FBtnDelete
            // 
            this.FBtnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FBtnDelete.Location = new System.Drawing.Point(357, 55);
            this.FBtnDelete.Name = "FBtnDelete";
            this.FBtnDelete.Size = new System.Drawing.Size(56, 30);
            this.FBtnDelete.TabIndex = 3;
            this.FBtnDelete.Text = "削除(&D)";
            this.FBtnDelete.UseVisualStyleBackColor = true;
            this.FBtnDelete.Click += new System.EventHandler(this.FBtnDelete_Click);
            // 
            // FBtnXml
            // 
            this.FBtnXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FBtnXml.Location = new System.Drawing.Point(418, 341);
            this.FBtnXml.Name = "FBtnXml";
            this.FBtnXml.Size = new System.Drawing.Size(72, 30);
            this.FBtnXml.TabIndex = 11;
            this.FBtnXml.Text = "保存(&S)";
            this.FBtnXml.UseVisualStyleBackColor = true;
            this.FBtnXml.Click += new System.EventHandler(this.FBtnXml_Click);
            // 
            // FBtnXmlLoad
            // 
            this.FBtnXmlLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FBtnXmlLoad.Location = new System.Drawing.Point(341, 341);
            this.FBtnXmlLoad.Name = "FBtnXmlLoad";
            this.FBtnXmlLoad.Size = new System.Drawing.Size(72, 30);
            this.FBtnXmlLoad.TabIndex = 10;
            this.FBtnXmlLoad.Text = "読込(&L)";
            this.FBtnXmlLoad.UseVisualStyleBackColor = true;
            this.FBtnXmlLoad.Click += new System.EventHandler(this.FBtnXmlLoad_Click);
            // 
            // FTitleLabel
            // 
            this.FTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FTitleLabel.AutoSize = true;
            this.FTitleLabel.Location = new System.Drawing.Point(288, 96);
            this.FTitleLabel.Name = "FTitleLabel";
            this.FTitleLabel.Size = new System.Drawing.Size(40, 12);
            this.FTitleLabel.TabIndex = 11;
            this.FTitleLabel.Text = "タイトル";
            // 
            // FContentLabel
            // 
            this.FContentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FContentLabel.AutoSize = true;
            this.FContentLabel.Location = new System.Drawing.Point(288, 140);
            this.FContentLabel.Name = "FContentLabel";
            this.FContentLabel.Size = new System.Drawing.Size(29, 12);
            this.FContentLabel.TabIndex = 12;
            this.FContentLabel.Text = "内容";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Lavender;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(536, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.fileToolStripMenuItem.Text = "ファイル";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.loadToolStripMenuItem.Text = "読込(&L)";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.FBtnXmlLoad_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveToolStripMenuItem.Text = "保存(&S)";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.FBtnXml_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.editItemToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.editToolStripMenuItem.Text = "編集";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.addToolStripMenuItem.Text = "追加(&A)";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.FBtnAdd_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.deleteToolStripMenuItem.Text = "削除(&D)";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.FBtnDelete_Click);
            // 
            // editItemToolStripMenuItem
            // 
            this.editItemToolStripMenuItem.Name = "editItemToolStripMenuItem";
            this.editItemToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.editItemToolStripMenuItem.Text = "編集(&E)";
            this.editItemToolStripMenuItem.Click += new System.EventHandler(this.FBtnEdit_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortByDueDateToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.viewToolStripMenuItem.Text = "表示";
            // 
            // sortByDueDateToolStripMenuItem
            // 
            this.sortByDueDateToolStripMenuItem.Name = "sortByDueDateToolStripMenuItem";
            this.sortByDueDateToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.sortByDueDateToolStripMenuItem.Text = "期限順(&O)";
            this.sortByDueDateToolStripMenuItem.Click += new System.EventHandler(this.FBtnSort_Click);
            // 
            // FStatusStrip
            // 
            this.FStatusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.FStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FStatusLabel});
            this.FStatusStrip.Location = new System.Drawing.Point(0, 379);
            this.FStatusStrip.Name = "FStatusStrip";
            this.FStatusStrip.Size = new System.Drawing.Size(536, 22);
            this.FStatusStrip.TabIndex = 14;
            this.FStatusStrip.Text = "statusStrip1";
            // 
            // FStatusLabel
            // 
            this.FStatusLabel.Name = "FStatusLabel";
            this.FStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // FMainCmbPriority
            // 
            this.FMainCmbPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FMainCmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FMainCmbPriority.FormattingEnabled = true;
            this.FMainCmbPriority.Items.AddRange(new object[] {
            "高",
            "中",
            "低"});
            this.FMainCmbPriority.Location = new System.Drawing.Point(290, 299);
            this.FMainCmbPriority.Name = "FMainCmbPriority";
            this.FMainCmbPriority.Size = new System.Drawing.Size(201, 20);
            this.FMainCmbPriority.TabIndex = 8;
            // 
            // FMainPriorityLabel
            // 
            this.FMainPriorityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FMainPriorityLabel.AutoSize = true;
            this.FMainPriorityLabel.Location = new System.Drawing.Point(288, 284);
            this.FMainPriorityLabel.Name = "FMainPriorityLabel";
            this.FMainPriorityLabel.Size = new System.Drawing.Size(41, 12);
            this.FMainPriorityLabel.TabIndex = 12;
            this.FMainPriorityLabel.Text = "優先度";
            // 
            // FToolStripSearch
            // 
            this.FToolStripSearch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FToolStripTxtSearch,
            this.FToolStripBtnSearch});
            this.FToolStripSearch.Location = new System.Drawing.Point(0, 24);
            this.FToolStripSearch.Name = "FToolStripSearch";
            this.FToolStripSearch.Size = new System.Drawing.Size(536, 25);
            this.FToolStripSearch.TabIndex = 0;
            this.FToolStripSearch.Text = "toolStripSearch";
            // 
            // FToolStripTxtSearch
            // 
            this.FToolStripTxtSearch.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.FToolStripTxtSearch.Name = "FToolStripTxtSearch";
            this.FToolStripTxtSearch.Size = new System.Drawing.Size(140, 25);
            // 
            // FToolStripBtnSearch
            // 
            this.FToolStripBtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FToolStripBtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FToolStripBtnSearch.Name = "FToolStripBtnSearch";
            this.FToolStripBtnSearch.Size = new System.Drawing.Size(35, 22);
            this.FToolStripBtnSearch.Text = "検索";
            this.FToolStripBtnSearch.Click += new System.EventHandler(this.FToolStripBtnSearch_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 401);
            this.Controls.Add(this.FToolStripSearch);
            this.Controls.Add(this.FMainCmbPriority);
            this.Controls.Add(this.FMainPriorityLabel);
            this.Controls.Add(this.FStatusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.FContentLabel);
            this.Controls.Add(this.FTitleLabel);
            this.Controls.Add(this.FTxtTitle);
            this.Controls.Add(this.FTxtContent);
            this.Controls.Add(this.FDtpDueDate);
            this.Controls.Add(this.FChkDone);
            this.Controls.Add(this.FLstItems);
            this.Controls.Add(this.FBtnAdd);
            this.Controls.Add(this.FBtnEdit);
            this.Controls.Add(this.FBtnDelete);
            this.Controls.Add(this.FBtnXml);
            this.Controls.Add(this.FBtnXmlLoad);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(450, 420);
            this.Name = "MainForm";
            this.Text = "ToDo管理";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.FStatusStrip.ResumeLayout(false);
            this.FStatusStrip.PerformLayout();
            this.FToolStripSearch.ResumeLayout(false);
            this.FToolStripSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FTitleLabel;
        private System.Windows.Forms.Label FContentLabel;
        private System.Windows.Forms.ComboBox FMainCmbPriority;
        private System.Windows.Forms.Label FMainPriorityLabel;
        private System.Windows.Forms.ToolStrip FToolStripSearch;
        private System.Windows.Forms.ToolStripTextBox FToolStripTxtSearch;
        private System.Windows.Forms.ToolStripButton FToolStripBtnSearch;
    }
}
