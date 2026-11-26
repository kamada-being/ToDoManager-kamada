using System;
using System.Windows.Forms;
using ToDoManager.Models;
using ToDoManager.Services;

namespace ToDoManager {
    /// <summary>
    /// メインのToDo管理フォーム
    /// </summary>
    public partial class MainForm : Form {
        #region フィールド・初期化
        private readonly TodoService FService = new TodoService();

        public MainForm() {
            InitializeComponent();

            UpdateList();
        }
        #endregion

        #region UI操作
        /// <summary>
        /// ToDoリストを更新
        /// </summary>
        private void UpdateList() {
            FLstItems.Items.Clear();
            foreach (var wItem in FService.GetItems()) FLstItems.Items.Add(wItem);
        }
        #endregion

        #region ToDo操作
        /// <summary>
        /// 追加アイテムを処理
        /// </summary>
        private void AddItem() => ShowEditDialogAndSaveItem(new TodoItem());

        /// <summary>
        /// アイテムを編集
        /// </summary>
        private void EditItem() {
            if (!(FLstItems.SelectedItem is TodoItem wSelected)) return;

            ShowEditDialogAndSaveItem(wSelected);
        }

        /// <summary>
        /// 編集ダイアログを表示。アイテムを保存し、一覧を更新
        /// </summary>
        /// <param name="vItem">編集するToDoアイテム</param>
        private void ShowEditDialogAndSaveItem(TodoItem vItem) {
            using (var wForm = new TodoEditForm(vItem)) {
                if (wForm.ShowDialog() != DialogResult.OK) return;
                try {
                    FService.AddOrUpdate(wForm.Item);
                    UpdateList();
                } catch (ArgumentException wEx) {
                    MessageBox.Show(this, wEx.Message, "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } catch (Exception wEx) {
                    MessageBox.Show(this, $"保存に失敗しました：{wEx.Message}", "システムエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// アイテムを削除
        /// </summary>
        private void DeleteItem() {
            if (!(FLstItems.SelectedItem is TodoItem wSelected)) return;

            var wResult = MessageBox.Show(this, $"「{wSelected.Title}」を削除しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (wResult != DialogResult.Yes) return;

            FService.Delete(wSelected.Id);
            UpdateList();
        }
        #endregion

        #region イベントハンドラ
        private void FBtnAdd_Click(object sender, EventArgs e) => AddItem();
        private void FBtnEdit_Click(object sender, EventArgs e) => EditItem();
        private void FBtnDelete_Click(object sender, EventArgs e) => DeleteItem();
        private void FBtnXml_Click(object sender, EventArgs e) => FService.Export();
        private void SortByDueDateToolStripMenuItem_Click(object sender, EventArgs e) {
            FService.SortByDueDate();
            UpdateList();
        }
        private void SortByAddedOrderToolStripMenuItem_Click(object sender, EventArgs e) {
            FService.SortByAddedOrder();
            UpdateList();
        }
        private void FBtnXmlLoad_Click(object sender, EventArgs e) {
            if (FService.Import()) {
                UpdateList();
                MessageBox.Show(this, "データを読み込みました。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                MessageBox.Show(this, "指定ファイルが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}