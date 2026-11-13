using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ToDoManager.Models;

namespace ToDoManager.Services
{
    /// <summary>
    /// ToDoアイテムの管理や永続化を行うサービスクラス
    /// </summary>
    public class TodoService : IDisposable
    {
        #region フィールド
        private List<TodoItem> FItems = new List<TodoItem>();
        private string FFilePath;
        private ITodoItemSerializer FXmlSerializer = new XmlTodoItemSerializer();
        private ITodoItemSerializer FJsonSerializer = new JsonTodoItemSerializer();
        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TodoService() { }

        #region publicメソッド
        /// <summary>
        /// ToDoアイテムのディクショナリを取得する
        /// </summary>
        /// <returns>Idをキー、TodoItemを値とするディクショナリ</returns>
        public Dictionary<int, TodoItem> GetItemMap()
        {
            return FItems.ToDictionary(x => x.Id);
        }

        /// <summary>
        /// フィルタ条件に一致するToDoアイテムの列挙を返す
        /// </summary>
        /// <param name="vFilter">タイトルまたは内容に含まれる文字列（nullまたは空で全件）</param>
        /// <returns>条件に一致するToDoアイテムの列挙</returns>
        public IEnumerable<TodoItem> GetItems(string vFilter = null)
        {
            // タイトルまたは内容にフィルタ文字列が含まれる場合のみ返す
            var wQuery = FItems.Where(x => string.IsNullOrEmpty(vFilter) || x.Title.Contains(vFilter) || x.Content.Contains(vFilter));
            foreach (var wItem in wQuery) yield return wItem;
        }

        /// <summary>
        /// 期限順にソートされたToDoアイテムのリストを返す
        /// </summary>
        /// <returns>期限順のToDoアイテムリスト</returns>
        public List<TodoItem> GetSortedItems()
        {
            if (!FItems.Any()) return new List<TodoItem>();
            return FItems.OrderBy(x => x.DueDate).ToList();
        }

        /// <summary>
        /// ToDoアイテムを追加または更新
        /// </summary>
        /// <param name="vItem">追加・更新するToDoアイテム</param>
        /// <returns>成功時true/失敗時false</returns>
        public void AddOrUpdate(TodoItem vItem)
        {
            if (vItem == null) throw new ArgumentNullException(nameof(vItem));
            //バリデーションチェック
            vItem.Validate();

            var vExisting = FItems.FirstOrDefault(x => x.Id == vItem.Id);
            if (vExisting != null)
            {
                vExisting.Title = vItem.Title;
                vExisting.Content = vItem.Content;
                vExisting.DueDate = vItem.DueDate;
                vExisting.IsCompleted = vItem.IsCompleted;
            }
            else
            {
                vItem.Id = FItems.Any() ? FItems.Max(x => x.Id) + 1 : 1;
                FItems.Add(vItem);
            }
        }

        /// <summary>
        /// 指定したIDのToDoアイテムを削除
        /// </summary>
        /// <param name="vId">削除するToDoアイテムのID</param>
        public void Delete(int vId)
        {
            var vItem = FItems.FirstOrDefault(x => x.Id == vId);
            if (vItem != null) FItems.Remove(vItem);
        }


        /// <summary>
        /// 拡張子に応じたシリアライザを取得
        /// </summary>
        private ITodoItemSerializer GetSerializerByExtension(string vFilePath)
        {
            var wExtension = Path.GetExtension(vFilePath)?.ToLower();
            if (wExtension == ".json") return FJsonSerializer;
            return FXmlSerializer;
        }

        /// <summary>
        /// ファイルパスに応じてXML/JSONで保存
        /// </summary>
        public void Export(string vFilePath)
        {
            var wSerializer = GetSerializerByExtension(vFilePath);
            wSerializer.Save(vFilePath, FItems);
            FFilePath = vFilePath;
        }

        /// <summary>
        /// ファイルパスに応じてXML/JSONで読込
        /// </summary>
        public void Import(string vFilePath)
        {
            var wSerializer = GetSerializerByExtension(vFilePath);
            FItems = wSerializer.Load(vFilePath);
            FFilePath = vFilePath;
        }

        /// <summary>
        /// リソースの解放処理
        /// </summary>
        public void Dispose()
        {
        }
        #endregion
    }
}
