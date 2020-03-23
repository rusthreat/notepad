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

    class Journal
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

            this.Load(Path); // Загрузка данных
            Count = notes.Count;
        }

        /// <summary>
        /// Метод генерации новой записи (служебный)
        /// </summary>
        public Note GenerateNote()
        {
            Random rand = new Random();
            string Owner;
            string Importance;
            int Number;

            Count++;
            Number = Count;

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
            SaveNote(ConcreteNote, Path);

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
                    Save(Path);
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

                Console.Clear();
                PrintDbToConsole();

                Console.WriteLine("\nВведите номер записи для редактирования: ");
                if (!Int32.TryParse(Console.ReadLine(), out int item))
                {
                    Console.WriteLine("\nВведите корректный номер!");
                    continue;
                }

                // поиск записи
                var editItem = Notes.Find(x => x.Number == item);

                // выбор реквизита который требуется изменить
                Console.WriteLine("\nВведите номер реквизита для редактирования (1-5): ");

                if (!Int32.TryParse(Console.ReadLine(), out int item2))
                {
                    Console.WriteLine("\nВведите корректный реквизит (1-5)!");
                    continue;
                }

                if (item2 != 1 && item2 != 2 && item2 != 3 && item2 != 4 && item2 != 5)
                {
                    Console.WriteLine("\nВведите корректный реквизит (1-5)!");
                    continue;
                }

                Console.WriteLine("\nВведите новое значение: ");
                string newvalue = Console.ReadLine();

                switch (item2)
                {
                    case 1:
                        {
                            editItem.Number = Convert.ToInt32(newvalue);
                            break;
                        }
                    case 2:
                        {
                            editItem.Date = Convert.ToDateTime(newvalue);
                            break;
                        }
                    case 3:
                        {
                            editItem.Text = newvalue;
                            break;
                        }
                    case 4:
                        {
                            editItem.Owner = newvalue;
                            break;
                        }
                    case 5:
                        {
                            editItem.Importance = newvalue;
                            break;
                        }
                }

                Console.WriteLine(editItem.Print());

                // сохранение изменений
                Save(Path);

                break;
            }
        }

        /// <summary>
        /// Метод сортировки журнала
        /// </summary>
        public void Sort()
        {
            while (true)
            {
                if (notes.Count == 0)
                {
                    Console.WriteLine("\nВ журнале нет записей!");
                    break;
                }

                Console.Clear();
                PrintDbToConsole();

                // выбор реквизита который требуется изменить
                Console.WriteLine("\nВведите номер реквизита для сортировки (1-5): ");

                if (!Int32.TryParse(Console.ReadLine(), out int item2))
                {
                    Console.WriteLine("\nВведите корректный реквизит (1-5)!");
                    continue;
                }

                if (item2 != 1 && item2 != 2 && item2 != 3 && item2 != 4 && item2 != 5)
                {
                    Console.WriteLine("\nВведите корректный реквизит (1-5)!");
                    continue;
                }

                // сортировка
                switch (item2)
                {
                    case 1:
                        {
                            Notes.Sort();
                            break;
                        }
                    case 2:
                        {
                            Notes.Sort(new SortNotesByDate());
                            break;
                        }
                    case 3:
                        {
                            Notes.Sort(new SortNotesByText());
                            break;
                        }
                    case 4:
                        {
                            Notes.Sort(new SortNotesByOwner());
                            break;
                        }
                    case 5:
                        {
                            Notes.Sort(new SortNotesByImportance());
                            break;
                        }
                }

                Console.Clear();
                Console.WriteLine("Сортировка завершена!\n");
                PrintDbToConsole();

                break;
            }
        }

        /// <summary>
        /// Метод загрузки данных
        /// </summary>
        private void Load(string path)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
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
        /// Метод загрузки данных c отбором по дате
        /// </summary>
        private void Load(string path, DateTime date1, DateTime date2)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] args = sr.ReadLine().Split(',');

                        DateTime date = Convert.ToDateTime(args[1]);

                        if (date >= date1 && date <= date2)
                        {
                            notes.Add(new Note(Convert.ToInt32(args[0]), Convert.ToDateTime(args[1]), args[2], args[3], args[4]));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Метод добавления одной записи в файл
        /// </summary>
        /// <param name="ConcreteNote">Конкретная запись, которую нужно добавить в файл</param>
        public void SaveNote(Note ConcreteNote, string path)
        {
            string temp = ConcreteNote.NoteToString();
            File.AppendAllText(path, $"{temp}\n");
        }

        /// <summary>
        /// Вывод шапки в консоль
        /// </summary>
        public void PrintTitles()
        {
            Console.WriteLine($"{this.titles[0],7} {this.titles[1],19} {this.titles[2],15} {this.titles[3],10} {this.titles[4],10}");
        }

        /// <summary>
        /// перезапись в файл db.csv
        /// </summary>
        public void Save(string Path)
        {
            using (StreamWriter sw = new StreamWriter(this.path))
            {
                foreach (var note in Notes)
                {
                    sw.WriteLine(note.NoteToString());
                }
            }
            Console.WriteLine("\nФайл db.csv перезаписан");
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
        /// Метод импорта данных из другого файла в db.csv
        /// </summary>
        public void Import(String path_import)
        {
            // Считывание строк из файла импорта и добавление их в список
            Load(path_import);

            // сохранение списка с добавленными строками
            Save(Path);

            Console.WriteLine($"\nДанные импортированы из файла {path_import}");
        }
        /// <summary>
        /// Метод импорта данных из другого файла в db.csv c условием
        /// </summary>
        public void Import(String path_import, DateTime date1, DateTime date2)
        {
            // Считывание строк из файла импорта и добавление их в список
            Load(path_import, date1, date2);

            // сохранение списка с добавленными строками
            Save(Path);

            Console.WriteLine($"\nДанные импортированы из файла {path_import} с отбором {date1} - {date2}");
        }

        /// <summary>
        /// Генерация строк файла для импорта
        /// </summary>
        public void NewImportFile(String path_import)
        {
            int i;

            for (i = 0; i <= 7; i++)
            {
                Note ConcreteNote = GenerateNote();
                SaveNote(ConcreteNote, path_import);
            }
            Console.WriteLine($"\nФайл {path_import} сгенерирован. Число строк: {i}");
        }


        /// <summary>
        /// Количество записей в хранилище
        /// </summary>
        public int Count { get { return this.index; } set { this.index = value; } }
        public string Path { get { return this.path; } }
        public List<Note> Notes { get { return this.notes; } }

    }
}
