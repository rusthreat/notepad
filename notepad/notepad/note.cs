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
        public Note(DateTime Date, int Number, string Text, string Owner, string Importance)
        {
            this.date = Date;
            this.number = Number;
            this.text = Text;
            this.owner = Owner;
            this.importance = Importance;
        }

        #endregion

        #region Методы

        //public string Print()
        //{
        //    return $"{this.firstName,15} {this.lastName,15} {this.department,15} {this.position,15} {this.salary,10}";
        //}

        #endregion

        #region Свойства

        /// <summary>
        /// Дата
        /// </summary>
        public string Date { get { return this.date; } set { this.date = value; } }

        /// <summary>
        /// Номер
        /// </summary>
        public string Number { get { return this.number; } set { this.number = value; } }

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
        public uint Importance { get { return this.importance; } set { this.Importance = value; } }

        /// <summary>
        /// Почасовая оплата
        /// </summary>
        //public double HourRate
        //{
        //    get
        //    {
        //        byte workingDays = 25; // Рабочих дней в месяце
        //        byte workingHours = 8; // Рабочих часов в день
        //        return ((double)Salary) / workingDays / workingHours;
        //    }
        //}

        #endregion

        #region Поля

        /// <summary>
        /// Поле "Дата"
        /// </summary>
        private DateTime date = new DateTime();

        /// <summary>
        /// Поле "Номер"
        /// </summary>
        private int number;

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
