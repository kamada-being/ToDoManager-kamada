using System;
using System.Xml.Serialization;

namespace ToDoManager.Models
{
    // 抽象クラス (OOP: 抽象化)
    /// <summary>
    /// ToDoエンティティの基底クラス
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
    }


    /// <summary>
    /// ToDoアイテムのエンティティクラス
    /// </summary>
    [Serializable]
    public class TodoItem : EntityBase
    {
        /// <summary>
        /// タイトル
        /// </summary>
        [XmlElement("Title")]
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [XmlElement("Content")]
        public string Content { get; set; }

        /// <summary>
        /// 期限日
        /// </summary>
        [XmlElement("DueDate")]
        public DateTime DueDate { get; set; }

        /// <summary>
        /// 完了フラグ
        /// </summary>
        [XmlElement("IsCompleted")]
        public bool IsCompleted { get; set; }

        private PriorityLevel FPriority = PriorityLevel.Normal;

        /// <summary>
        /// 優先度
        /// </summary>
        [XmlElement("Priority")]
        public PriorityLevel Priority
        {
            get { return FPriority; }
            set { FPriority = value; }
        }

        /// <summary>
        /// タイトルと完了状態を表す文字列を返します。
        /// </summary>
        /// <returns>表示用文字列</returns>
        public override string ToString()
        {
            return $"[{(IsCompleted ? "完了" : "未")}] {Title}";
        }

        /// <summary>
        /// このアイテムが有効な状態か診断します。
        /// 不正な場合は例外を投げます。
        /// </summary>
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.Title))
            {
                throw new ArgumentException("タイトルは必須入力です。");
            }
        }
    }

    /// <summary>
    /// 優先度レベル
    /// </summary>
    public enum PriorityLevel
    {
        High,
        Normal,
        Low
    }
}
