using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ToDoManager.Models;

namespace ToDoManager.Services
{
    /// <summary>
    /// JSON形式のTodoItemシリアライザ
    /// </summary>
    public class JsonTodoItemSerializer : ITodoItemSerializer
    {
        public void Save(string vFilePath, List<TodoItem> vItems)
        {
            var wJson = JsonConvert.SerializeObject(vItems, Formatting.Indented);
            File.WriteAllText(vFilePath, wJson);
        }

        public List<TodoItem> Load(string vFilePath)
        {
            var wJson = File.ReadAllText(vFilePath);
            return JsonConvert.DeserializeObject<List<TodoItem>>(wJson);
        }
    }
}
