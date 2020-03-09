using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notepad
{
    struct Note
    {
        #region Конструкторы

        /// <summary>
        /// Создание заметки
        /// </summary>
        /// <param name="Date">ДатаВремя</param>
        /// <param name="Number">Номер</param>
        /// <param name="Text">Текст</param>
        /// <param name="Owner">Владелец</param>
        /// <param name="Importance">Важность</param>
        public Note(string Date, int Number, string Text, string Owner, string Importance)
        {
            this.date = Date;
            this.number = Number;
            this.text = Text;
            this.owner = Owner;
            this.importance = Importance;
        }

        #endregion

        #region Методы

        public string Print()
        {
            return $"{this.date,15} {this.number,15} {this.text,15} {this.owner,15} {this.importance,10}";
        }

        public string AddNote()
        {
            
            
            
            
            
            return $"{this.date,15} {this.number,15} {this.text,15} {this.owner,15} {this.importance,10}";
        }


        #endregion

        #region Свойства

        /// <summary>
        /// Дата
        /// </summary>
        public string Date { get { return this.date; } set { this.date = value; } }

        /// <summary>
        /// Номер
        /// </summary>
        public uint Number { get { return this.number; } set { this.number = value; } }

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
        /// Поле "Дата"
        /// </summary>
        private string date;

        /// <summary>
        /// Поле "Номер"
        /// </summary>
        private uint number;

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
}
