using System;
using System.Linq;
using System.Windows.Forms;
using ToDoManager.Models;
using ToDoManager.Services;

namespace ToDoManager
{
    /// <summary>
    /// メインのToDo管理フォーム
    /// </summary>
    public partial class MainForm : Form
    {
        #region フィールド・初期化
        private readonly TodoService FService = new TodoService();
        private const string FFileFilter = "XMLファイル (*.xml)|*.xml|JSONファイル (*.json)|*.json|すべてのファイル (*.*)|*.*";
        private const string DefaultFileName = "TodoItems.xml";
        private string FCurrentFilePath = null;

        public MainForm()
        {
            InitializeComponent();

            // ToolStrip検索イベントに置き換え
            FToolStripBtnSearch.Click += FToolStripBtnSearch_Click;
            FToolStripTxtSearch.KeyDown += FToolStripTxtSearch_KeyDown;
            UpdateList();
            SetFieldsReadOnly(true);
        }
        #endregion

        #region UI操作
        /// <summary>
        /// 入力フィールドの編集可否を設定
        /// </summary>
        private void SetFieldsReadOnly(bool vIsReadOnly)
        {
            FTxtTitle.ReadOnly = vIsReadOnly;
            FTxtContent.ReadOnly = vIsReadOnly;
            FDtpDueDate.Enabled = !vIsReadOnly;
            FChkDone.Enabled = !vIsReadOnly;
            FMainCmbPriority.Enabled = !vIsReadOnly;
        }

        /// <summary>
        /// ToDoリストを更新
        /// </summary>
        private void UpdateList(string vFilter = null)
        {
            FLstItems.Items.Clear();
            foreach (var wItem in FService.GetItems(vFilter))
            {
                FLstItems.Items.Add(wItem);
            }
            UpdateStatusBar();
        }

        /// <summary>
        /// ステータスバーを更新
        /// </summary>
        private void UpdateStatusBar()
        {
            var wAllCount = FService.GetItems().Count();
            var wIncompleteCount = FService.GetItems().Count(x => !x.IsCompleted);
            FStatusLabel.Text = $"全件数: {wAllCount} / 未完了: {wIncompleteCount}";
        }

        /// <summary>
        /// 詳細フィールドを選択アイテムで更新
        /// </summary>
        private void UpdateDetailFields()
        {
            SetFieldsReadOnly(true);
            if (FLstItems.SelectedItem is TodoItem vSelected)
            {
                FTxtTitle.Text = vSelected.Title;
                FTxtContent.Text = vSelected.Content;
                FDtpDueDate.Value = vSelected.DueDate;
                FChkDone.Checked = vSelected.IsCompleted;
                FMainCmbPriority.SelectedIndex = vSelected.Priority == PriorityLevel.High ? 0 : vSelected.Priority == PriorityLevel.Normal ? 1 : 2;
                // REQ-02: 期限切れ警告
                FTxtTitle.BackColor = (!vSelected.IsCompleted && FDtpDueDate.Value < DateTime.Today) ? System.Drawing.Color.Yellow : System.Drawing.SystemColors.Control;
            }
            else
            {
                FTxtTitle.Text = string.Empty;
                FTxtContent.Text = string.Empty;
                FDtpDueDate.Value = DateTime.Now;
                FChkDone.Checked = false;
                FMainCmbPriority.SelectedIndex = 1; 
                FTxtTitle.BackColor = System.Drawing.SystemColors.Control;
            }
        }
        #endregion

        #region ToDo操作
        /// <summary>
        /// 追加アイテムを処理
        /// </summary>
        private void AddItem()
        {
            using (var wForm = new TodoEditForm(new TodoItem()))
            {
                if (wForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        FService.AddOrUpdate(wForm.Item);
                        UpdateList();
                    }
                    catch (ArgumentException wEx)
                    {
                        MessageBox.Show(this, wEx.Message, "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception wEx)
                    {
                        MessageBox.Show(this, $"保存に失敗しました：{wEx.Message}", "システムエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// アイテムを編集
        /// </summary>
        private void EditItem()
        {
            if (FLstItems.SelectedItem is TodoItem wSelected)
            {
                using (var wForm = new TodoEditForm(wSelected))
                {
                    if (wForm.ShowDialog() == DialogResult.OK)
                    {
                        FService.AddOrUpdate(wForm.Item);
                        UpdateList();
                    }
                }
            }
        }

        /// <summary>
        /// アイテムを削除
        /// </summary>
        private void DeleteItem()
        {
            if (FLstItems.SelectedItem is TodoItem wSelected)
            {
                FService.Delete(wSelected.Id);
                UpdateList();
            }
        }

        /// <summary>
        /// アイテムを期限順にソート
        /// </summary>
        private void SortItems()
        {
            var wSorted = FService.GetSortedItems();
            FLstItems.Items.Clear();
            foreach (var wItem in wSorted) FLstItems.Items.Add(wItem);
        }

        /// <summary>
        /// ファイルに保存（拡張子でXML/JSON自動判別）
        /// </summary>
        private void SaveToFile()
        {
            if (!string.IsNullOrEmpty(FCurrentFilePath))
            {
                // 既存ファイルがあれば上書き保存
                try
                {
                    FService.Export(FCurrentFilePath);
                    MessageBox.Show(this, "上書き保存しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception wEx)
                {
                    MessageBox.Show(this, $"上書き保存中にエラーが発生しました：{wEx.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // 無ければ新規保存
                using (var wDialog = new SaveFileDialog())
                {
                    wDialog.Filter = FFileFilter;
                    wDialog.Title = "名前を付けて保存";
                    // デフォルトはＸＭＬファイル
                    wDialog.FileName = DefaultFileName;
                    wDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    if (wDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            FService.Export(wDialog.FileName);
                            FCurrentFilePath = wDialog.FileName;
                            MessageBox.Show(this, "保存しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception wEx)
                        {
                            MessageBox.Show(this, $"保存中にエラーが発生しました：{wEx.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ファイルから読込（拡張子でXML/JSON自動判別）
        /// </summary>
        private void LoadFromFile()
        {
            using (var wDialog = new OpenFileDialog())
            {
                wDialog.Filter = FFileFilter;
                wDialog.Title = "ファイルを選択";
                if (wDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        FService.Import(wDialog.FileName);
                        FCurrentFilePath = wDialog.FileName;
                        UpdateList();
                        MessageBox.Show(this, "ファイルを読み込みました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception wEx)
                    {
                        MessageBox.Show(this, $"読込中にエラーが発生しました：{wEx.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region イベントハンドラ
        private void FBtnAdd_Click(object sender, EventArgs e) => AddItem();
        private void FBtnEdit_Click(object sender, EventArgs e) => EditItem();
        private void FBtnDelete_Click(object sender, EventArgs e) => DeleteItem();
        private void FBtnSort_Click(object sender, EventArgs e) => SortItems();
        private void FBtnXml_Click(object sender, EventArgs e) => SaveToFile();
        private void FBtnXmlLoad_Click(object sender, EventArgs e) => LoadFromFile();
        private void FLstItems_SelectedIndexChanged(object sender, EventArgs e) => UpdateDetailFields();

        private void FToolStripBtnSearch_Click(object sender, EventArgs e)
        {
            UpdateList(FToolStripTxtSearch.Text);
        }

        private void FToolStripTxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateList(FToolStripTxtSearch.Text);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        #endregion
    }
}
