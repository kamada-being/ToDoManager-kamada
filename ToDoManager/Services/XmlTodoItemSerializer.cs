using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using ToDoManager.Models;

namespace ToDoManager.Services
{
    /// <summary>
    /// XML形式のTodoItemシリアライザ
    /// </summary>
    public class XmlTodoItemSerializer : ITodoItemSerializer
    {
        public void Save(string vFilePath, List<TodoItem> vItems)
        {
            var wSerializer = new XmlSerializer(typeof(List<TodoItem>));
            using (var wWriter = new StreamWriter(vFilePath))
            {
                wSerializer.Serialize(wWriter, vItems);
            }
        }

        public List<TodoItem> Load(string vFilePath)
        {
            var wSerializer = new XmlSerializer(typeof(List<TodoItem>));
            using (var wReader = new StreamReader(vFilePath))
            {
                return (List<TodoItem>)wSerializer.Deserialize(wReader);
            }
        }
    }
}
