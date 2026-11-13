using System.Collections.Generic;

namespace ToDoManager.Services
{
    /// <summary>
    /// TodoItemリストの永続化処理インターフェース
    /// </summary>
    public interface ITodoItemSerializer
    {
        /// <summary>
        /// TodoItemリストを指定ファイルに保存します。
        /// </summary>
        /// <param name="vFilePath">保存先ファイルパス</param>
        /// <param name="vItems">保存するTodoItemリスト</param>
        void Save(string vFilePath, List<ToDoManager.Models.TodoItem> vItems);

        /// <summary>
        /// 指定ファイルからTodoItemリストを読み込みます。
        /// </summary>
        /// <param name="vFilePzath">読み込むファイルパス</param>
        /// <returns>読み込んだTodoItemリスト</returns>
        List<ToDoManager.Models.TodoItem> Load(string vFilePath);
    }
}
