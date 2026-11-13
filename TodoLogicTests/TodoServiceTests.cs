using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoManager.Models;
using ToDoManager.Services;

namespace ToDoManagerTests
{
    /// <summary>
    /// TodoServiceの単体テストクラス
    /// </summary>
    [TestClass]
    public class TodoServiceTests
    {
        /// <summary>
        /// AddOrUpdateで新規アイテムが追加されること
        /// </summary>
        [TestMethod]
        public void AddOrUpdate_AddsNewItem()
        {
            var wService = new TodoService();
            var wItem = new TodoItem { Title = "Test", Content = "TestContent", DueDate = DateTime.Today, IsCompleted = false };
            wService.AddOrUpdate(wItem);
            var wItems = wService.GetItems().ToList();
            Assert.That(wItems.Count, Is.EqualTo(1));
            Assert.That(wItems[0].Title, Is.EqualTo("Test"));
        }

        /// <summary>
        /// AddOrUpdateで既存アイテムが更新されること
        /// </summary>
        [TestMethod]
        public void AddOrUpdate_UpdatesExistingItem()
        {
            var wService = new TodoService();
            var wItem = new TodoItem { Title = "Test", Content = "TestContent", DueDate = DateTime.Today, IsCompleted = false };
            wService.AddOrUpdate(wItem);
            wItem.Title = "Updated";
            wService.AddOrUpdate(wItem);
            var wItems = wService.GetItems().ToList();
            Assert.That(wItems.Count, Is.EqualTo(1));
            Assert.That(wItems[0].Title, Is.EqualTo("Updated"));
        }

        /// <summary>
        /// Deleteでアイテムが削除されること
        /// </summary>
        [TestMethod]
        public void Delete_RemovesItem()
        {
            var wService = new TodoService();
            var wItem = new TodoItem { Title = "Test", Content = "TestContent", DueDate = DateTime.Today, IsCompleted = false };
            wService.AddOrUpdate(wItem);
            wService.Delete(wItem.Id);
            var wItems = wService.GetItems().ToList();
            Assert.That(wItems.Count, Is.EqualTo(0));
        }

        /// <summary>
        /// GetSortedItemsで期限順にソートされること
        /// </summary>
        [TestMethod]
        public void GetSortedItems_ReturnsItemsSortedByDueDate()
        {
            var wService = new TodoService();
            var wItem1 = new TodoItem { Title = "A", DueDate = DateTime.Today.AddDays(2) };
            var wItem2 = new TodoItem { Title = "B", DueDate = DateTime.Today.AddDays(1) };
            wService.AddOrUpdate(wItem1);
            wService.AddOrUpdate(wItem2);
            var vSorted = wService.GetSortedItems();
            Assert.That(vSorted[0].Title, Is.EqualTo("B"));
            Assert.That(vSorted[1].Title, Is.EqualTo("A"));
        }

        /// <summary>
        /// GetItemMapでディクショナリが正しく返ること
        /// </summary>
        [TestMethod]
        public void GetItemMap_ReturnsDictionary()
        {
            var wService = new TodoService();
            var wItem = new TodoItem { Title = "Test" };
            wService.AddOrUpdate(wItem);
            var wMap = wService.GetItemMap();
            Assert.That(wMap.ContainsKey(wItem.Id), Is.True);
            Assert.That(wMap[wItem.Id].Title, Is.EqualTo(wItem.Title));
        }

        /// <summary>
        /// AddOrUpdateでバリデーションエラー（タイトル未入力時）が発生すること
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddOrUpdate_ThrowsException_WhenTitleIsEmpty()
        {
            var wService = new TodoService();
            var wItem = new TodoItem { Title = "", Content = "TestContent", DueDate = DateTime.Today, IsCompleted = false };
            wService.AddOrUpdate(wItem);
        }

        /// <summary>
        /// AddOrUpdateでバリデーションエラー（タイトルが空白のみ）が発生すること
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddOrUpdate_ThrowsException_WhenTitleIsWhitespace()
        {
            var wService = new TodoService();
            var wItem = new TodoItem { Title = "   ", Content = "TestContent", DueDate = DateTime.Today, IsCompleted = false };
            wService.AddOrUpdate(wItem);
        }

        /// <summary>
        /// AddOrUpdateでタイトルが1文字の境界値でも正常に追加できること
        /// </summary>
        [TestMethod]
        public void AddOrUpdate_AddsItem_WhenTitleIsSingleChar()
        {
            var wService = new TodoService();
            var wItem = new TodoItem { Title = "A", Content = "TestContent", DueDate = DateTime.Today, IsCompleted = false };
            wService.AddOrUpdate(wItem);
            var wItems = wService.GetItems().ToList();
            Assert.That(wItems.Count, Is.EqualTo(1));
            Assert.That(wItems[0].Title, Is.EqualTo("A"));
        }
    }
}
