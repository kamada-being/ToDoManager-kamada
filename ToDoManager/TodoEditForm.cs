using System;
using System.Windows.Forms;
using ToDoManager.Models;
using ToDoManager.Services;

namespace ToDoManager {
    /// <summary>
    /// ToDoアイテムの編集フォーム
    /// </summary>
    public partial class TodoEditForm : Form {
        #region フィールド・プロパティ
        /// <summary>
        /// 編集対象のToDoアイテムを取得
        /// </summary>
        public TodoItem Item { get; private set; }
        #endregion

        #region 初期化
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vItem">編集対象のToDoアイテム</param>
        public TodoEditForm(TodoItem vItem) {
            InitializeComponent();
            FCmbPriority.DataSource = Enum.GetValues(typeof(PriorityEnum));

            Item = vItem;
            FTxtTitle.Text = vItem.Title;
            FTxtContent.Text = vItem.Content;
            FDtpDueDate.Value = vItem.DueDate;
            FChkDone.Checked = vItem.IsCompleted;
            FCmbPriority.SelectedItem = vItem.Priority;
        }
        #endregion

        #region privateメソッド
        /// <summary>
        /// 入力内容を検証し、問題がなければItemに反映してフォームを閉じる
        /// </summary>
        private void SaveItem() {
            var wItem = new TodoItem {
                Title = FTxtTitle.Text,
                Content = FTxtContent.Text,
                DueDate = FDtpDueDate.Value,
                IsCompleted = FChkDone.Checked,
                Priority = FCmbPriority.SelectedItem is PriorityEnum wPriority ? wPriority : PriorityEnum.中
            };

            try {
                TodoService.Validate(wItem);

                Item.Title = wItem.Title;
                Item.Content = wItem.Content;
                Item.DueDate = wItem.DueDate;
                Item.IsCompleted = wItem.IsCompleted;
                Item.Priority = wItem.Priority;

                DialogResult = DialogResult.OK;
                Close();
            } catch (ArgumentException wEx) {
                MessageBox.Show(this, wEx.Message, "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region イベントハンドラ
        /// <summary>
        /// 保存ボタンがクリックされたときの処理
        /// </summary>
        private void FBtnSave_Click(object sender, EventArgs e) => SaveItem();
        #endregion
    }
}
