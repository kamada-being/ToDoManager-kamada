using System;
using NUnit.Framework;
using ToDoManager.Models;

namespace ToDoManagerTests
{
    /// <summary>
    /// TodoItemの単体テストクラス
    /// </summary>
    [TestFixture]
    public class TodoItemTests
    {
        /// <summary>
        /// ToStringが期待通りのフォーマットを返すこと
        /// </summary>
        [Test]
        public void ToString_ReturnsExpectedFormat()
        {
            var wItem = new TodoItem { Title = "Test", IsCompleted = true };
            Assert.That(wItem.ToString(), Is.EqualTo("[完了] Test"));
        }

        /// <summary>
        /// Validateでタイトル未入力時に例外が発生すること
        /// </summary>
        [Test]
        public void Validate_ThrowsException_WhenTitleIsEmpty()
        {
            var wItem = new TodoItem { Title = "" };
            Assert.Throws<ArgumentException>(() => wItem.Validate());
        }

        /// <summary>
        /// Validateでタイトルが空白のみの場合に例外が発生すること
        /// </summary>
        [Test]
        public void Validate_ThrowsException_WhenTitleIsWhitespace()
        {
            var wItem = new TodoItem { Title = "   " };
            Assert.Throws<ArgumentException>(() => wItem.Validate());
        }

        /// <summary>
        /// Validateでタイトルが1文字のとき例外が発生しないこと（境界値）
        /// </summary>
        [Test]
        public void Validate_DoesNotThrow_WhenTitleIsSingleChar()
        {
            var wItem = new TodoItem { Title = "A" };
            Assert.DoesNotThrow(() => wItem.Validate());
        }
    }
}
