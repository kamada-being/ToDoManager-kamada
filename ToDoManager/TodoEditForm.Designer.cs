namespace ToDoManager
{
    partial class TodoEditForm
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
        private System.Windows.Forms.Button FBtnSave;
        private System.Windows.Forms.ComboBox FCmbPriority;
        private System.Windows.Forms.Label FPriorityLabel;

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
            this.FBtnSave = new System.Windows.Forms.Button();
            this.FCmbPriority = new System.Windows.Forms.ComboBox();
            this.FPriorityLabel = new System.Windows.Forms.Label();
            this.FEditTitleLabel = new System.Windows.Forms.Label();
            this.FEditContentLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FTxtTitle
            // 
            this.FTxtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FTxtTitle.Location = new System.Drawing.Point(20, 32);
            this.FTxtTitle.Name = "FTxtTitle";
            this.FTxtTitle.Size = new System.Drawing.Size(213, 19);
            this.FTxtTitle.TabIndex = 0;
            // 
            // FTxtContent
            // 
            this.FTxtContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FTxtContent.Location = new System.Drawing.Point(20, 74);
            this.FTxtContent.Multiline = true;
            this.FTxtContent.Name = "FTxtContent";
            this.FTxtContent.Size = new System.Drawing.Size(213, 60);
            this.FTxtContent.TabIndex = 1;
            // 
            // FDtpDueDate
            // 
            this.FDtpDueDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FDtpDueDate.Location = new System.Drawing.Point(20, 144);
            this.FDtpDueDate.Name = "FDtpDueDate";
            this.FDtpDueDate.Size = new System.Drawing.Size(213, 19);
            this.FDtpDueDate.TabIndex = 2;
            // 
            // FChkDone
            // 
            this.FChkDone.Location = new System.Drawing.Point(20, 166);
            this.FChkDone.Name = "FChkDone";
            this.FChkDone.Size = new System.Drawing.Size(80, 19);
            this.FChkDone.TabIndex = 3;
            this.FChkDone.Text = "完了(&F)";
            // 
            // FBtnSave
            // 
            this.FBtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FBtnSave.Location = new System.Drawing.Point(20, 253);
            this.FBtnSave.Name = "FBtnSave";
            this.FBtnSave.Size = new System.Drawing.Size(80, 30);
            this.FBtnSave.TabIndex = 5;
            this.FBtnSave.Text = "保存(&S)";
            this.FBtnSave.UseVisualStyleBackColor = true;
            this.FBtnSave.Click += new System.EventHandler(this.FBtnSave_Click);
            // 
            // FCmbPriority
            // 
            this.FCmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FCmbPriority.FormattingEnabled = true;
            this.FCmbPriority.Items.AddRange(new object[] {
            "高",
            "中",
            "低"});
            this.FCmbPriority.Location = new System.Drawing.Point(20, 209);
            this.FCmbPriority.Name = "FCmbPriority";
            this.FCmbPriority.Size = new System.Drawing.Size(213, 20);
            this.FCmbPriority.TabIndex = 4;
            // 
            // FPriorityLabel
            // 
            this.FPriorityLabel.AutoSize = true;
            this.FPriorityLabel.Location = new System.Drawing.Point(18, 194);
            this.FPriorityLabel.Name = "FPriorityLabel";
            this.FPriorityLabel.Size = new System.Drawing.Size(41, 12);
            this.FPriorityLabel.TabIndex = 7;
            this.FPriorityLabel.Text = "優先度";
            // 
            // FEditTitleLabel
            // 
            this.FEditTitleLabel.AutoSize = true;
            this.FEditTitleLabel.Location = new System.Drawing.Point(20, 14);
            this.FEditTitleLabel.Name = "FEditTitleLabel";
            this.FEditTitleLabel.Size = new System.Drawing.Size(40, 12);
            this.FEditTitleLabel.TabIndex = 5;
            this.FEditTitleLabel.Text = "タイトル";
            // 
            // FEditContentLabel
            // 
            this.FEditContentLabel.AutoSize = true;
            this.FEditContentLabel.Location = new System.Drawing.Point(20, 59);
            this.FEditContentLabel.Name = "FEditContentLabel";
            this.FEditContentLabel.Size = new System.Drawing.Size(29, 12);
            this.FEditContentLabel.TabIndex = 6;
            this.FEditContentLabel.Text = "内容";
            // 
            // TodoEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 301);
            this.Controls.Add(this.FCmbPriority);
            this.Controls.Add(this.FPriorityLabel);
            this.Controls.Add(this.FEditContentLabel);
            this.Controls.Add(this.FEditTitleLabel);
            this.Controls.Add(this.FTxtTitle);
            this.Controls.Add(this.FTxtContent);
            this.Controls.Add(this.FDtpDueDate);
            this.Controls.Add(this.FChkDone);
            this.Controls.Add(this.FBtnSave);
            this.MinimumSize = new System.Drawing.Size(270, 320);
            this.Name = "TodoEditForm";
            this.Text = "ToDo編集";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FEditTitleLabel;
        private System.Windows.Forms.Label FEditContentLabel;
    }
}
