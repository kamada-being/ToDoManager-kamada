using NUnit.Framework;
using System;
using System.Linq;
using ToDoManager.Models;
using ToDoManager.Services;

namespace ToDoManagerTests {
    /// <summary>
    /// TodoServiceの単体テストクラス
    /// </summary>
    [TestFixture]
    public class TodoServiceTests {
        #region ヘルパーメソッド
        /// <summary>
        /// デフォルトのTodoItemを生成する
        /// </summary>
        private TodoItem CreateDefaultItem() =>
            new TodoItem {
                Title = "Test",
                Content = "TestContent",
                DueDate = DateTime.Today,
                IsCompleted = false
            };
        #endregion

        #region 正常系
        /// <summary>
        /// AddOrUpdateで新規アイテムが追加されること
        /// </summary>
        [Test]
        public void AddOrUpdate_ToDoの追加_ToDoが追加される() {
            var wService = new TodoService();
            var wItem = CreateDefaultItem();
            wService.AddOrUpdate(wItem);
            var wItems = wService.GetItems().ToList();
            Assert.That(wItems.Count, Is.EqualTo(1));
            Assert.That(wItems[0].Title, Is.EqualTo("Test"));
        }

        /// <summary>
        /// AddOrUpdateで既存アイテムが更新されること
        /// </summary>
        [Test]
        public void AddOrUpdate_ToDoの更新_ToDoが更新される() {
            var wService = new TodoService();
            var wItem = CreateDefaultItem();
            wService.AddOrUpdate(wItem);
            wItem.Title = "Updated";
            wService.AddOrUpdate(wItem);
            var wItems = wService.GetItems().ToList();
            Assert.That(wItems.Count, Is.EqualTo(1));
            Assert.That(wItems[0].Title, Is.EqualTo("Updated"));
        }

        /// <summary>
        /// SortByDueDateで期限順にソートされること
        /// </summary>
        [Test]
        public void SortByDueDate_期限順ソート_期限順にソートされる() {
            var wService = new TodoService();
            var wItem1 = CreateDefaultItem();
            wItem1.Title = "Test1";
            wItem1.DueDate = DateTime.Today.AddDays(1);

            var wItem2 = CreateDefaultItem();
            wItem2.Title = "Test2";
            wItem2.DueDate = DateTime.Today;

            wService.AddOrUpdate(wItem1);
            wService.AddOrUpdate(wItem2);

            wService.SortByDueDate();
            var wItems = wService.GetItems().ToList();

            Assert.That(wItems[0].Title, Is.EqualTo("Test2"));
            Assert.That(wItems[1].Title, Is.EqualTo("Test1"));
        }

        /// <summary>
        /// SortByAddedOrderで追加順にソートされること
        /// </summary>
        [Test]
        public void SortByAddedOrder_追加順ソート_追加順にソートされる() {
            var wService = new TodoService();
            var wItem1 = CreateDefaultItem();
            wItem1.Title = "Test1";
            wItem1.DueDate = DateTime.Today.AddDays(1);

            var wItem2 = CreateDefaultItem();
            wItem2.Title = "Test2";
            wItem2.DueDate = DateTime.Today;

            wService.AddOrUpdate(wItem1);
            wService.AddOrUpdate(wItem2);

            wService.SortByAddedOrder();
            var wItems = wService.GetItems().ToList();

            Assert.That(wItems[0].Title, Is.EqualTo("Test1"));
            Assert.That(wItems[1].Title, Is.EqualTo("Test2"));
        }

        /// <summary>
        /// Validateでタイトルが最大文字数の場合に例外が発生しないこと
        /// </summary>
        [Test]
        public void Validate_ToDoの検証_タイトルが最大文字数_例外が発生しない() {
            var wItem = CreateDefaultItem();
            wItem.Title = new string('あ', TodoService.C_MaxTitleLength);
            Assert.That(() => TodoService.Validate(wItem), Throws.Nothing);
        }

        /// <summary>
        /// Validateでタイトルが最低文字数の場合に例外が発生しないこと
        /// </summary>
        [Test]
        public void Validate_ToDoの検証_タイトルが最低文字数_例外が発生しない() {
            var wItem = CreateDefaultItem();
            wItem.Title = new string('あ', TodoService.C_MinTitleLength);
            Assert.That(() => TodoService.Validate(wItem), Throws.Nothing);
        }

        /// <summary>
        /// Validateで前後の空白を含むタイトルはトリムせず許容されていること
        /// </summary>
        [Test]
        public void Validate_ToDoの検証_タイトルの前後が空白_例外が発生しない() {
            var wCorrectTitle = " Test ";
            var wItem = CreateDefaultItem();
            wItem.Title = wCorrectTitle;
            Assert.That(() => TodoService.Validate(wItem), Throws.Nothing);
            Assert.That(wItem.Title, Is.EqualTo(wCorrectTitle));
        }

        /// <summary>
        /// Validateで内容が最大文字数の場合に例外が発生しないこと
        /// </summary>
        [Test]
        public void Validate_ToDoの検証_内容が最大文字数_例外が発生しない() {
            var wItem = CreateDefaultItem();
            wItem.Content = new string('あ', TodoService.C_MaxContentLength);
            Assert.That(() => TodoService.Validate(wItem), Throws.Nothing);
        }

        /// <summary>
        /// Validateで内容が空文字の場合に例外が発生しないこと
        /// </summary>
        [Test]
        public void Validate_ToDoの検証_内容が空文字_例外が発生しない() {
            var wItem = CreateDefaultItem();
            wItem.Content = string.Empty;
            Assert.That(() => TodoService.Validate(wItem), Throws.Nothing);
        }

        /// <summary>
        /// Validateで内容がnullの場合に例外が発生しないこと
        /// </summary>
        [Test]
        public void Validate_ToDoの検証_内容がnull_例外が発生しない() {
            var wItem = CreateDefaultItem();
            wItem.Content = null;
            Assert.That(() => TodoService.Validate(wItem), Throws.Nothing);
        }
        #endregion

        #region 異常系
        /// <summary>
        /// Validateでタイトルが未入力または空白のみの場合にArgumentExceptionが発生すること
        /// </summary>
        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("　")]
        [TestCase("\t\t")]
        public void Validate_ToDoの検証_タイトルが未入力または空白のみ_ArgumentExceptionが発生する(string vInvalidTitle) {
            var wItem = CreateDefaultItem();
            wItem.Title = vInvalidTitle;

            Assert.That(() => TodoService.Validate(wItem), Throws.TypeOf<ArgumentException>());
        }

        /// <summary>
        /// Validateでタイトルが最大文字数を超える場合にArgumentExceptionが発生すること
        /// </summary>
        [Test]
        public void Validate_ToDoの検証_タイトルが最大文字数超過_ArgumentExceptionが発生する() {
            var wItem = CreateDefaultItem();
            wItem.Title = new string('あ', TodoService.C_MaxTitleLength + 1);

            Assert.That(() => TodoService.Validate(wItem), Throws.TypeOf<ArgumentException>());
        }

        /// <summary>
        /// Validateで内容が最大文字数を超える場合にArgumentExceptionが発生すること
        /// </summary>
        [Test]
        public void Validate_ToDoの検証_内容が最大文字数超過_ArgumentExceptionが発生する() {
            var wItem = CreateDefaultItem();
            wItem.Content = new string('あ', TodoService.C_MaxContentLength + 1);

            Assert.That(() => TodoService.Validate(wItem), Throws.TypeOf<ArgumentException>());
        }
        #endregion
    }
}