using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using ToDoManager.Models;

namespace ToDoManager.Services {
    /// <summary>
    /// ToDoアイテムの管理や永続化を行うサービスクラス
    /// </summary>
    public class TodoService {
        #region フィールド・定数
        private List<TodoItem> FItems = new List<TodoItem>();
        private int FNextId = 1;
        private const string C_FilePath = "todos.xml";
        public const int C_MinTitleLength = 1;
        public const int C_MaxTitleLength = 20;
        public const int C_MaxContentLength = 150;
        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TodoService() {
        }

        #region publicメソッド
        /// <summary>
        /// ToDoアイテムの一覧を取得する
        /// </summary>
        /// <returns>登録されているToDoアイテムの読み取り専用リスト</returns>
        public IReadOnlyList<TodoItem> GetItems() => FItems;

        /// <summary>
        /// ToDoアイテムを追加または更新
        /// </summary>
        /// <param name="vItem">追加または更新するToDoアイテム</param>
        public void AddOrUpdate(TodoItem vItem) {
            if (vItem == null) throw new ArgumentNullException(nameof(vItem));

            if (vItem.Id == 0) {
                Add(vItem);
            } else {
                Update(vItem);
            }
        }

        /// <summary>
        /// ToDoアイテムを削除
        /// </summary>
        /// <param name="vId">削除するToDoアイテムのID</param>
        public void Delete(int vId) => FItems.RemoveAll(x => x.Id == vId);

        /// <summary>
        /// ToDoアイテムの入力内容を検証する
        /// </summary>
        /// <param name="vItem">検証対象のToDoアイテム</param>
        public static void Validate(TodoItem vItem) {
            if (string.IsNullOrWhiteSpace(vItem?.Title) || vItem.Title.Length > C_MaxTitleLength)
                throw new ArgumentException($"タイトルは{C_MinTitleLength}文字以上、{C_MaxTitleLength}文字以内で入力してください。");

            if (vItem.Content?.Length > C_MaxContentLength)
                throw new ArgumentException($"内容は{C_MaxContentLength}文字以下で入力してください。");
        }

        /// <summary>
        /// XMLで保存
        /// </summary>
        public void Export() {
            var wSerializer = new XmlSerializer(typeof(List<TodoItem>));
            using (var wWriter = new StreamWriter(C_FilePath)) wSerializer.Serialize(wWriter, FItems);
        }

        /// <summary>
        /// XMLで読込
        /// </summary>
        public bool Import() {
            if (!File.Exists(C_FilePath)) return false;

            var wSerializer = new XmlSerializer(typeof(List<TodoItem>));
            var wStreamReader = new StreamReader(C_FilePath);
            FItems = (List<TodoItem>)wSerializer.Deserialize(wStreamReader);

            FNextId = FItems.Any() ? FItems.Max(x => x.Id) + 1 : 1;

            return true;
        }

        /// <summary>
        /// 期限順にソート
        /// </summary>
        public void SortByDueDate() {
            var wTodoItems = FItems.OrderBy(x => x.DueDate).ToList();
        }

        /// <summary>
        /// 追加順にソート
        /// </summary>
        public void SortByAddedOrder() {
            for (int i = 0; i < FItems.Count - 1; i++) {
                int wMinIndex = i;
                for (int j = i + 1; j < FItems.Count; j++) {
                    if (FItems[j].Id < FItems[wMinIndex].Id) {
                        wMinIndex = j;
                    }
                }
                if (wMinIndex != i) {
                    var wTemp = FItems[i];
                    FItems[i] = FItems[wMinIndex];
                    FItems[wMinIndex] = wTemp;
                }
            }
        }
        #endregion

        #region privateメソッド
        /// <summary>
        /// 新しいToDoアイテムをコレクションに追加
        /// </summary>
        /// <param name="vItem">ToDoアイテム</param>
        private void Add(TodoItem vItem) {
            vItem.Id = FNextId++;
            FItems.Add(vItem);
        }

        /// <summary>
        /// 既存のToDoアイテムの内容を更新
        /// </summary>
        /// <param name="vItem">ToDoアイテム</param>
        private void Update(TodoItem vItem) {
            var wExisting = FItems.FirstOrDefault(x => x.Id == vItem.Id);
            if (wExisting == null) throw new InvalidOperationException("更新対象のToDoが存在しません。");

            wExisting.Title = vItem.Title;
            wExisting.Content = vItem.Content;
            wExisting.DueDate = vItem.DueDate;
            wExisting.IsCompleted = vItem.IsCompleted;
            wExisting.Priority = vItem.Priority;
        }
        #endregion
    }
}