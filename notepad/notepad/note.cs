using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notepad
{
    class Note : IComparable<Note>
    {
        #region Конструкторы

        /// <summary>
        /// Создание заметки
        /// </summary>
        /// <param name="Number">Номер</param>
        /// <param name="Date">ДатаВремя</param>
        /// <param name="Text">Текст</param>
        /// <param name="Owner">Владелец</param>
        /// <param name="Importance">Важность</param>
        public Note(int Number, DateTime Date, string Text, string Owner, string Importance)
        {
            this.number = Number;
            this.date = Date;
            this.text = Text;
            this.owner = Owner;
            this.importance = Importance;
        }

        #endregion

        #region Методы

        public string Print()
        {
            return $"{this.number,7} {this.date,19} {this.text,15} {this.owner,10} {this.importance,10}";
        }

        public string NoteToString()
        {
            string temp = String.Format("{0},{1},{2},{3},{4}",
                                    this.Number,
                                    this.Date,
                                    this.Text,
                                    this.Owner,
                                    this.Importance);
            return temp;
        }

        /// <summary>
        /// интерфейс IComparer, для реелизации сортировок коллекции объектов
        /// </summary>
        public interface IComparer
        {
            int Compare(object a, object b);
        }

        /// <summary>
        /// Сортировка по номеру
        /// </summary>
        public int CompareTo(Note T)
        {
            return this.Number.CompareTo(T.Number);
        }

        #endregion

        #region Свойства

        /// <summary>
        /// Номер
        /// </summary>
        public int Number { get { return this.number; } set { this.number = value; } }
        
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date { get { return this.date; } set { this.date = value; } }

        /// <summary>
        /// Текст
        /// </summary>
        public string Text { get { return this.text; } set { this.text = value; } }

        /// <summary>
        /// Владелец
        /// </summary>
        public string Owner { get { return this.owner; } set { this.owner = value; } }

        /// <summary>
        /// Важность
        /// </summary>
        public string Importance { get { return this.importance; } set { this.importance = value; } }

        #endregion

        #region Поля

        /// <summary>
        /// Поле "Номер"
        /// </summary>
        private int number;
        
        /// <summary>
        /// Поле "Дата"
        /// </summary>
        private DateTime date;

        /// <summary>
        /// Поле "Текст"
        /// </summary>
        private string text;

        /// <summary>
        /// Поле "Владелец"
        /// </summary>
        private string owner;

        /// <summary>
        /// Поле "Важность"
        /// </summary>
        private string importance;

        #endregion
    }

    #region Компараторы

    /// <summary>
    /// сортировка по дате
    /// </summary>
    class SortNotesByDate : IComparer<Note>
    {
        public int Compare(Note x, Note y)
        {
            return DateTime.Compare(x.Date, y.Date);
        }
    }

    /// <summary>
    /// сортировка по дате
    /// </summary>
    class SortNotesByText : IComparer<Note>
    {
        public int Compare(Note x, Note y)
        {
            return String.Compare(x.Text, y.Text);
        }
    }

    /// <summary>
    /// сортировка по дате
    /// </summary>
    class SortNotesByOwner : IComparer<Note>
    {
        public int Compare(Note x, Note y)
        {
            return String.Compare(x.Owner, y.Owner);
        }
    }

    /// <summary>
    /// сортировка по дате
    /// </summary>
    class SortNotesByImportance : IComparer<Note>
    {
        public int Compare(Note x, Note y)
        {
            return String.Compare(x.Importance, y.Importance);
        }
    }
    #endregion
}
