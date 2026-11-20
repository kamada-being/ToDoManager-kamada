using System;
using System.Linq;
using NUnit.Framework;
using ToDoManager.Models;
using ToDoManager.Services;

namespace ToDoManagerTests {
    /// <summary>
    /// TodoServiceの単体テストクラス
    /// </summary>
    [TestFixture]
    public class TodoServiceTests {
        #region フィールド
        private readonly TodoItem FDefaultItem = new TodoItem {
            Title = "Test",
            Content = "TestContent",
            DueDate = DateTime.Today,
            IsCompleted = false
        };
        #endregion

        #region ヘルパーメソッド
        /// <summary>
        /// デフォルトのTodoItemのコピーを生成する
        /// </summary>
        private TodoItem CreateDefaultItem() =>
            new TodoItem {
                Title = FDefaultItem.Title,
                Content = FDefaultItem.Content,
                DueDate = FDefaultItem.DueDate,
                IsCompleted = FDefaultItem.IsCompleted
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
            Assert.AreEqual(1, wItems.Count);
            Assert.AreEqual("Test", wItems[0].Title);
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
            Assert.AreEqual(1, wItems.Count);
            Assert.AreEqual("Updated", wItems[0].Title);
        }

        /// <summary>
        /// SortByDueDateで期限順にソートされること
        /// </summary>
        [Test]
        public void SortByDueDate_期限順ソート_期限順にソートされる() {
            var wService = new TodoService();
            var wItem1 = CreateDefaultItem(); wItem1.Title = "Test1"; wItem1.DueDate = DateTime.Today.AddDays(1);
            var wItem2 = CreateDefaultItem(); wItem2.Title = "Test2"; wItem2.DueDate = DateTime.Today;
            wService.AddOrUpdate(wItem1);
            wService.AddOrUpdate(wItem2);

            wService.SortByDueDate();
            var wItems = wService.GetItems().ToList();

            Assert.AreEqual("Test2", wItems[0].Title);
            Assert.AreEqual("Test1", wItems[1].Title);
        }

        /// <summary>
        /// SortByAddedOrderで追加順にソートされること
        /// </summary>
        [Test]
        public void SortByAddedOrder_追加順ソート_追加順にソートされる() {
            var wService = new TodoService();
            var wItem1 = CreateDefaultItem(); wItem1.Title = "Test1"; wItem1.DueDate = DateTime.Today.AddDays(1);
            var wItem2 = CreateDefaultItem(); wItem2.Title = "Test2"; wItem2.DueDate = DateTime.Today;
            wService.AddOrUpdate(wItem1);
            wService.AddOrUpdate(wItem2);

            wService.SortByAddedOrder();
            var wItems = wService.GetItems().ToList();

            Assert.AreEqual("Test1", wItems[0].Title);
            Assert.AreEqual("Test2", wItems[1].Title);
        }

        /// <summary>
        /// Validateでタイトルが最大文字数の場合に例外が発生しないこと
        /// </summary>
        [Test]
        public void Validate_ToDoの検証_タイトルが最大文字数_例外が発生しない() {
            var wItem = CreateDefaultItem(); wItem.Title = new string('あ', TodoService.C_MaxTitleLength);
            Assert.DoesNotThrow(() => TodoService.Validate(wItem));
        }

        /// <summary>
        /// Validateでタイトルが最低文字数の場合に例外が発生しないこと
        /// </summary>
        [Test]
        public void Validate_ToDoの検証_タイトルが最低文字数_例外が発生しない() {
            var wItem = CreateDefaultItem(); wItem.Title = new string('あ', TodoService.C_MinTitleLength);
            Assert.DoesNotThrow(() => TodoService.Validate(wItem));
        }

        /// <summary>
        /// Validateで前後の空白を含むタイトルはトリムせず許容されていること
        /// </summary>
        [Test]
        public void Validate_ToDoの検証_タイトルの前後が空白_例外が発生しない() {
            var wCorrectTitle = " Test ";
            var wItem = CreateDefaultItem(); wItem.Title = wCorrectTitle;
            Assert.DoesNotThrow(() => TodoService.Validate(wItem));

            Assert.AreEqual(wCorrectTitle, wItem.Title);
        }

        /// <summary>
        /// Validateで内容が最大文字数の場合に例外が発生しないこと
        /// </summary>
        [Test]
        public void Validate_ToDoの検証_内容が最大文字数_例外が発生しない() {
            var wItem = CreateDefaultItem(); wItem.Content = new string('あ', TodoService.C_MaxContentLength);
            Assert.DoesNotThrow(() => TodoService.Validate(wItem));
        }

        /// <summary>
        /// Validateで内容が空文字の場合に例外が発生しないこと
        /// </summary>
        [Test]
        public void Validate_ToDoの検証_内容が空文字_例外が発生しない() {
            var wItem = CreateDefaultItem(); wItem.Content = string.Empty;
            Assert.DoesNotThrow(() => TodoService.Validate(wItem));
        }

        /// <summary>
        /// Validateで内容がnullの場合に例外が発生しないこと
        /// </summary>
        [Test]
        public void Validate_ToDoの検証_内容がnull_例外が発生しない() {
            var wItem = CreateDefaultItem(); wItem.Content = null;
            Assert.DoesNotThrow(() => TodoService.Validate(wItem));
        }
        #endregion

        #region 異常系
        /// <summary>
        /// Validateでタイトルが空文字（最低文字数未満）の場合にArgumentExceptionが発生すること
        /// </summary>
        [Test]
        public void Validate_ToDoの検証_タイトルが空文字_ArgumentExceptionが発生する() {
            var wItem = CreateDefaultItem(); wItem.Title = string.Empty;

            var wEx = Assert.Throws<ArgumentException>(() => TodoService.Validate(wItem));
            Assert.AreEqual(nameof(wItem.Title), wEx.ParamName);
        }

        /// <summary>
        /// Validateでタイトルがnullの場合にArgumentExceptionが発生すること
        /// </summary>
        [Test]
        public void Validate_ToDoの検証_タイトルがnull_ArgumentExceptionが発生する() {
            var wItem = CreateDefaultItem(); wItem.Title = null;

            var wEx = Assert.Throws<ArgumentException>(() => TodoService.Validate(wItem));
            Assert.AreEqual(nameof(wItem.Title), wEx.ParamName);
        }

        /// <summary>
        /// Validateでタイトルが半角スペースのみの場合にArgumentExceptionが発生すること
        /// </summary>
        [Test]
        public void Validate_ToDoの検証_タイトルが半角スペースのみ_ArgumentExceptionが発生する() {
            var wItem = CreateDefaultItem(); wItem.Title = " ";

            var wEx = Assert.Throws<ArgumentException>(() => TodoService.Validate(wItem));
            Assert.AreEqual(nameof(wItem.Title), wEx.ParamName);
        }

        /// <summary>
        /// Validateでタイトルが全角スペースのみの場合にArgumentExceptionが発生すること
        /// </summary>
        [Test]
        public void Validate_ToDoの検証_タイトルが全角スペースのみ_ArgumentExceptionが発生する() {
            var wItem = CreateDefaultItem(); wItem.Title = "　";

            var wEx = Assert.Throws<ArgumentException>(() => TodoService.Validate(wItem));
            Assert.AreEqual(nameof(wItem.Title), wEx.ParamName);
        }

        /// <summary>
        /// Validateでタイトルがタブ文字のみの場合にArgumentExceptionが発生すること
        /// </summary>
        [Test]
        public void Validate_ToDoの検証_タイトルがタブ文字のみ_ArgumentExceptionが発生する() {
            var wItem = CreateDefaultItem(); wItem.Title = "\t\t";

            var wEx = Assert.Throws<ArgumentException>(() => TodoService.Validate(wItem));
            Assert.AreEqual(nameof(wItem.Title), wEx.ParamName);
        }

        /// <summary>
        /// Validateでタイトルが最大文字数を超える場合にArgumentExceptionが発生すること
        /// </summary>
        [Test]
        public void Validate_ToDoの検証_タイトルが最大文字数超過_ArgumentExceptionが発生する() {
            var wItem = CreateDefaultItem(); wItem.Title = new string('あ', TodoService.C_MaxTitleLength + 1);

            var wEx = Assert.Throws<ArgumentException>(() => TodoService.Validate(wItem));
            Assert.AreEqual(nameof(wItem.Title), wEx.ParamName);
        }

        /// <summary>
        /// Validateで内容が最大文字数を超える場合にArgumentExceptionが発生すること
        /// </summary>
        [Test]
        public void Validate_ToDoの検証_内容が最大文字数超過_ArgumentExceptionが発生する() {
            var wItem = CreateDefaultItem(); wItem.Content = new string('あ', TodoService.C_MaxContentLength + 1);

            var wEx = Assert.Throws<ArgumentException>(() => TodoService.Validate(wItem));
            Assert.AreEqual(nameof(wItem.Content), wEx.ParamName);
        }
        #endregion
    }
}