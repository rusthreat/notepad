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
        /// <param name="Number">Номер</param>
        /// <param name="Date">ДатаВремя</param>
        /// <param name="Text">Текст</param>
        /// <param name="Owner">Владелец</param>
        /// <param name="Importance">Важность</param>
        public Note(int Number, string Date, string Text, string Owner, string Importance)
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
            return $"{this.number,5} {this.date,19} {this.text,15} {this.owner,10} {this.importance,10}";
        }

        //static Note AddNote(int i)
        //{
            
            
            
            
        //    return new Note{this.number,5} {this.date,19} {this.text,15} {this.owner,10} {this.importance,10};
        //}


        #endregion

        #region Свойства

        /// <summary>
        /// Номер
        /// </summary>
        public int Number { get { return this.number; } set { this.number = value; } }
        
        /// <summary>
        /// Дата
        /// </summary>
        public string Date { get { return this.date; } set { this.date = value; } }

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
        private string date;

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
