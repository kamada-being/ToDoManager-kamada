using System;
using System.Xml.Serialization;

namespace ToDoManager.Models {
    /// <summary>
    /// 優先度の列挙型
    /// </summary>
    public enum PriorityEnum {
        低, 中, 高
    }

    /// <summary>
    /// ToDoアイテムのエンティティクラス
    /// </summary>
    [Serializable]
    public class TodoItem {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

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
        public DateTime DueDate { get; set; } = DateTime.Today;

        /// <summary>
        /// 完了フラグ
        /// </summary>
        [XmlElement("IsCompleted")]
        public bool IsCompleted { get; set; }

        /// <summary>
        /// 優先度
        /// </summary>
        [XmlElement("Priority")]
        public PriorityEnum Priority { get; set; } = PriorityEnum.中;

        /// <summary>
        /// タイトルと完了状態を表す文字列を返します。
        /// </summary>
        /// <returns>表示用文字列</returns>
        public override string ToString() => $"[{(IsCompleted ? "完了" : "未")}] {Title}";
    }
}