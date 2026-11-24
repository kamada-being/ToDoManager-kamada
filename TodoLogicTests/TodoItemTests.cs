using NUnit.Framework;
using ToDoManager.Models;

namespace ToDoManagerTests {
    /// <summary>
    /// TodoItemの単体テストクラス
    /// </summary>
    [TestFixture]
    public class TodoItemTests {
        /// <summary>
        /// ToStringが期待通りのフォーマットを返すこと
        /// </summary>
        [Test]
        public void ToString_IsCompletedがtrueのとき_完了付きフォーマットになる() {
            var wItem = new TodoItem { Title = "Test", IsCompleted = true };
            Assert.AreEqual("[完了] Test", wItem.ToString());
        }

        /// <summary>
        /// ToStringが期待通りのフォーマットを返すこと
        /// </summary>
        [Test]
        public void ToString_IsCompletedがfalseのとき_未付きフォーマットになる() {
            var wItem = new TodoItem { Title = "Test", IsCompleted = false };
            Assert.AreEqual("[未] Test", wItem.ToString());
        }
    }
}