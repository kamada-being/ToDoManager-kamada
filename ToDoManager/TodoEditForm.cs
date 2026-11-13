using System;
using System.Windows.Forms;
using ToDoManager.Models;

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
            Item = vItem;
            FTxtTitle.Text = vItem.Title;
            FTxtContent.Text = vItem.Content;
            FDtpDueDate.Value = vItem.DueDate == default(DateTime) ? DateTime.Now : vItem.DueDate;
            FChkDone.Checked = vItem.IsCompleted;
        }
        #endregion

        #region privateメソッド
        /// <summary>
        /// 入力内容をItemに反映しバリデーションする
        /// </summary>
        private void SaveItem() {
            Item.Title = FTxtTitle.Text;
            Item.Content = FTxtContent.Text;
            Item.DueDate = FDtpDueDate.Value;
            Item.IsCompleted = FChkDone.Checked;

            DialogResult = DialogResult.OK;
            Close();
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
