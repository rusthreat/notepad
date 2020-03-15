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
        //private Note[] notes; // Основной массив для хранения данных

        private List<Note> notes;

        private string path; // путь к файлу с данными

        int index; // текущий элемент для добавления записи в notes

        string[] titles; // массив, хранящий заголовки полей. используется в PrintDbToConsole

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Path">Путь в файлу с данными</param>
        public Journal(string Path)
        {
            this.path = Path; // Сохранение пути к файлу с данными
            this.index = 0; // текущая позиция для добавления записи в notes
            this.titles = new string[5] { "1-Номер", "2-Дата", "3-Текст", "4-Владелец", "5-Важность" }; // инициализация массива заголовков   
            this.notes = new List<Note>(); // инициализация списка записей.    | изначально предпологаем, что данных нет

            this.Load(); // Загрузка данных
        }

        /// <summary>
        /// Метод генерации новой записи
        /// </summary>
        public Note GenerateNote()
        {
            Random rand = new Random();
            string Owner;
            string Importance;
            int Number;

            // номер присваивается автоматически
            if (notes.Count > 0)
            {
                Number = notes.Count + 1;
            }
            else
            {
                Number = 1;
            }
            
            // генерация даты
            DateTime today = DateTime.Now;
            DateTime Date = today.AddDays((double)rand.Next(-20, 21));

            // генерация текста
            string Text = "test " + rand.Next(0, 101).ToString();

            // генерация владельца
            int own = rand.Next(0, 3);
            if (own == 0)
            {
                Owner = "Александр";
            }
            else if (own == 1)
            {
                Owner = "Петр";
            }
            else
            {
                Owner = "Николай";
            }

            // генерация важности
            int imp = rand.Next(0, 3);
            if (imp == 0)
            {
                Importance = "Высокая";
            }
            else if (imp == 1)
            {
                Importance = "Средняя";
            }
            else
            {
                Importance = "Низкая";
            }
            
            Note ConcreteNote = new Note(Number, Date, Text, Owner, Importance);

            return ConcreteNote;        
        }

        /// <summary>
        /// Метод добавления записи в хранилище
        /// </summary>
        /// <param name="ConcreteNote">Запись</param>
        public void AddNote()
        {
            // Генерация новой записи для удобства отладки
            Note ConcreteNote = GenerateNote();
            
            //// номер присваивается автоматически
            //Console.WriteLine($"Введите номер: ");
            //int Number = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("\nВведите дату/время:");
            //string Date = Console.ReadLine();

            //Console.WriteLine("\nВведите текст:");
            //string Text = Console.ReadLine();

            //Console.WriteLine("\nВведите владельца:");
            //string Owner = Console.ReadLine();

            //Console.WriteLine("\nВведите важность:");
            //string Importance = Console.ReadLine();

            // добавление записи в список
            //Note ConcreteNote = new Note(Number, Date, Text, Owner, Importance);
            notes.Add(ConcreteNote);

            // добавление записи в файл
            this.SaveNote(ConcreteNote);
            
            PrintTitles();
            Console.WriteLine(ConcreteNote.Print());
            Console.WriteLine("\nЗапись добавлена! Файл db.csv перезаписан");
        }

        /// <summary>
        /// Метод удаления выбранной записи
        /// </summary>
        public void DeleteNote()
        {
            while (true)
            {
                if (notes.Count == 0)
                {
                    Console.WriteLine("\nВ журнале нет записей!");
                    break;
                }

                bool exit = false;

                Console.Clear();
                PrintDbToConsole();

                Console.WriteLine("\nВведите номер записи для удаления: ");
                if (!Int32.TryParse(Console.ReadLine(), out int item))
                {
                    Console.WriteLine("\nЗапись с таким номером не найдена!");
                    continue;
                }

                // поиск записей с указанным номером
                
                // индекс для удаления по индексу
                int i = 0;
                // признак, что удаление было
                bool del = false;

                foreach (var note in notes)
                {
                    if (note.Number == item)
                    {
                        notes.RemoveAt(i);
                        del = true;
                        break;
                    }
                    i++;
                }

                if (!del)
                {
                    Console.WriteLine("\nЗапись для удаления не найдена!");
                    break;
                }

                // перезапись в файл db.csv
                if (notes.Count > 0)
                {
                    using (StreamWriter sw = new StreamWriter(this.path))
                    {
                        foreach (var note in notes)
                        {
                            sw.WriteLine(note.NoteToString());
                        }
                    }
                    Console.WriteLine("\nУдаление выполнено! Файл db.csv перезаписан");
                    exit = true;
                }
                else
                {
                    // записей нет, удаление файла
                    File.Delete(this.path);
                    Console.WriteLine("\nУдаление выполнено! Файл db.csv перезаписан");
                    exit = true;
                }

                if (exit == true)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Метод редактирования выбранной записи
        /// </summary>
        public void EditNote()
        {
            while (true)
            {
                if (notes.Count == 0)
                {
                    Console.WriteLine("\nВ журнале нет записей!");
                    break;
                }

                bool exit = false;

                Console.Clear();
                PrintDbToConsole();

                Console.WriteLine("\nВведите номер записи для редактирования: ");
                if (!Int32.TryParse(Console.ReadLine(), out int item))
                {
                    Console.WriteLine("\nЗапись с таким номером не найдена!");
                    continue;
                }

                // поиск записей с указанным номером

                // признак, что редактирование было
                bool edit = false;

                for (int i = 0; i <= notes.Count; i++)
                {
                    if (notes[i].Number == item)
                    {
                        while (true)
                        {
                            Console.Clear();
                            PrintTitles();
                            Console.WriteLine(notes[i].Print());

                            // выбор реквизита который требуется изменить
                            Console.WriteLine("\nВведите номер реквизита для редактирования (1-5): ");

                            if (!Int32.TryParse(Console.ReadLine(), out int item2))
                            {
                                Console.WriteLine("\nНеверный реквизит!");
                                continue;
                            }

                            string newvalue = Console.ReadLine();

                            switch (item2)
                            {
                                case 1:
                                    {
                                        notes[i].Number = newvalue;
                                        break;
                                    }
                                case 2:
                                    {
                                        notes[i].Date = newvalue;
                                        break;
                                    }
                                case 3:
                                    {
                                        notes[i].Text = newvalue;
                                        break;
                                    }
                                case 4:
                                    {
                                        notes[i].Owner = newvalue;
                                        break;
                                    }
                                case 5:
                                    {
                                        notes[i].Importance = newvalue;
                                        break;
                                    }
                            }



                        }

                        edit = true;
                        break;
                    }
                    i++;
                }

                if (!edit)
                {
                    Console.WriteLine("\nЗапись для редактирования не найдена!");
                    break;
                }

                // перезапись в файл db.csv
                if (notes.Count > 0)
                {
                    using (StreamWriter sw = new StreamWriter(this.path))
                    {
                        foreach (var note in notes)
                        {
                            sw.WriteLine(note.NoteToString());
                        }
                    }
                    Console.WriteLine("\nРедактирование выполнено! Файл db.csv перезаписан");
                    exit = true;
                }
                else
                {
                    // записей нет, удаление файла
                    File.Delete(this.path);
                    Console.WriteLine("\nУдаление выполнено! Файл db.csv перезаписан");
                    exit = true;
                }

                if (exit == true)
                {
                    break;
                }
            }
        }


        /// <summary>
        /// Метод загрузки данных
        /// </summary>
        private void Load()
        {
            // При открытии происходит попытка чтения файла db.csv
            if (File.Exists(this.path))
            {
                using (StreamReader sr = new StreamReader(this.path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] args = sr.ReadLine().Split(',');

                        notes.Add(new Note(Convert.ToInt32(args[0]), Convert.ToDateTime(args[1]), args[2], args[3], args[4]));
                    }
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
                                        this.notes[i].Number,
                                        this.notes[i].Date,
                                        this.notes[i].Text,
                                        this.notes[i].Owner,
                                        this.notes[i].Importance);
                File.AppendAllText(Path, $"{temp}\n");
            }
        }

        /// <summary>
        /// Метод преобразования записи в строку
        /// </summary>
        /// <param name="ConcreteNote">Конкретная запись, которую нужно добавить в файл</param>

        /// <summary>
        /// Метод добавления одной записи в файл
        /// </summary>
        /// <param name="ConcreteNote">Конкретная запись, которую нужно добавить в файл</param>
        public void SaveNote(Note ConcreteNote)
        {
            string temp = ConcreteNote.NoteToString();
            File.AppendAllText(this.path, $"{temp}\n");
        }

        /// <summary>
        /// Вывод шапки в консоль
        /// </summary>
        public void PrintTitles()
        {
            Console.WriteLine($"{this.titles[0],5} {this.titles[1],19} {this.titles[2],15} {this.titles[3],10} {this.titles[4],10}");
        }

        /// <summary>
        /// Вывод данных в консоль
        /// </summary>
        public void PrintDbToConsole()
        {
            PrintTitles();
            foreach (var note in notes)
            {
                Console.WriteLine(note.Print());
            }
        }

        /// <summary>
        /// Количество записей в хранилище
        /// </summary>
        public int Count { get { return this.index; } }
    }
}
