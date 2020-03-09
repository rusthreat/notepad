using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notepad
{
    /// <summary>
    /// Структура по работе с данными
    /// </summary>
    struct Journal
    {
        private Note[] notes; // Основной массив для хранения данных

        private string path; // путь к файлу с данными

        int index; // текущий элемент для добавления записи в notes

        string[] titles; // массив, хранящий заголовки полей. используется в PrintDbToConsole

        /// <summary>
        /// Констрктор
        /// </summary>
        /// <param name="Path">Путь в файлу с данными</param>
        public Journal(string Path)
        {
            this.path = Path; // Сохранение пути к файлу с данными
            this.index = 0; // текущая позиция для добавления записи в notes
            this.titles = new string[0]; // инициализация массива заголовков   
            this.notes = new Note[1]; // инициализация массива записей.    | изначально предпологаем, что данных нет

            this.Load(); // Загрузка данных
        }

        /// <summary>
        /// Метод увеличения текущего хранилища
        /// </summary>
        /// <param name="Flag">Условие увеличения</param>
        private void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.notes, this.notes.Length * 2);
            }
        }

        /// <summary>
        /// Метод добавления записи в хранилище
        /// </summary>
        /// <param name="ConcreteNote">Запись</param>
        public void Add()
        {
            // Увеличиваем размер хранилища, если он недостаточен
            this.Resize(index >= this.notes.Length);
            // номер присваивается автоматически
            
            Console.WriteLine($"Номер записи: {index + 1}");

            Console.WriteLine("Введите дату/время:");
            this.notes[index].Date.set = Console.ReadLine();

            Console.WriteLine("Введите текст:");
            this.notes[index].text = Console.ReadLine();

            Console.WriteLine("Введите владельца:");
            this.notes[index].owner = Console.ReadLine();

            Console.WriteLine("Введите важность:");
            this.importance = Console.ReadLine();
            this.notes[index] = Note.AddNote((uint)index);
            this.index++;
        }

        /// <summary>
        /// Метод загрузки данных
        /// </summary>
        private void Load()
        {
            using (StreamReader sr = new StreamReader(this.path))
            {
                titles = sr.ReadLine().Split(',');


                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split(',');

                    //Add(new Note(Convert.ToUInt32(args[0]), args[1], args[2], args[3], args[4]));
                }
            }
        }

        /// <summary>
        /// Метод сохранения данных
        /// </summary>
        /// <param name="Path">Путь к файлу сохранения</param>
        public void Save(string Path)
        {
            string temp = String.Format("{0},{1},{2},{3},{4}",
                                            this.titles[0],
                                            this.titles[1],
                                            this.titles[2],
                                            this.titles[3],
                                            this.titles[4]);

            File.AppendAllText(Path, $"{temp}\n");

            for (int i = 0; i < this.index; i++)
            {
                temp = String.Format("{0},{1},{2},{3},{4}",
                                        this.notes[i].Date,
                                        this.notes[i].Number,
                                        this.notes[i].Text,
                                        this.notes[i].Owner,
                                        this.notes[i].Importance);
                File.AppendAllText(Path, $"{temp}\n");
            }
        }

        /// <summary>
        /// Вывод данных в консоль
        /// </summary>
        public void PrintDbToConsole()
        {
            Console.WriteLine($"{this.titles[0],15} {this.titles[1],15} {this.titles[4],15} {this.titles[2],15} {this.titles[3],10}");

            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(this.notes[i].Print());
            }
        }

        /// <summary>
        /// Количество записей в хранилище
        /// </summary>
        public int Count { get { return this.index; } }
    }
}
