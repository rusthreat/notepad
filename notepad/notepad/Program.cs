using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notepad
{
    class Program
    {
        static string str;

        static void Main(string[] args)
        {
            /// Разработать ежедневник.
            /// В ежедневнике реализовать возможность 
            /// - создания
            /// - удаления
            /// - редактирования 
            /// записей
            /// 
            /// В отдельной записи должно быть не менее пяти полей
            /// 
            /// Реализовать возможность 
            /// - Загрузки данных из файла
            /// - Выгрузки данных в файл
            /// - Добавления данных в текущий ежедневник из выбранного файла
            /// - Импорт записей по выбранному диапазону дат
            /// - Упорядочивания записей ежедневника по выбранному полю

            // 1. Структура одной записи
            //      1) ДатаВремя
            //      2) Номер
            //      3) Текст
            //      4) Владелец
            //      5) Важность - Низкая, Обычная, Высокая
            // 2. Структура обработки файлов
            // 3. Структура обработки записей
            // 4.
             
            // по умолчанию открывается файл - база данных
            string path = @"db.csv";
            Journal jour = new Journal(path);

            // Обработка начального меню
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nМеню ежедневника (выберите 1-8):");
                Console.WriteLine("1 - Создать новую запись");
                Console.WriteLine("2 - Удалить запись");
                Console.WriteLine("3 - Редактировать запись");
                Console.WriteLine("\n4 - Открыть журнал записей");
                Console.WriteLine("5 - Сортировать журнал");
                Console.WriteLine("6 - Импорт записей из файла");
                Console.WriteLine("7 - Импорт записей из файла по диапозону дат");
                Console.WriteLine("\n8 - выход");

                //string item = Console.ReadLine();

                if (!Int32.TryParse(Console.ReadLine(), out int item))
                {
                    continue;
                }

                bool exit = false;

                Console.Clear();

                switch (item)
                {
                    case 1:
                        {
                            jour.Add();
                            break;
                        }
                    //case 2: OpenJournal(); break;
                    //case 3: exit = true; break;
                    case 4:
                        {
                            jour.PrintDbToConsole(); 
                            break;
                        }
                    //case 5: OpenJournal();
                    //    {
                    //        jour.PrintDbToConsole()    
                    //        break;
                    //    }
                    //case 6: break;
                    //case 7: AddNote(); break;
                    case 8:
                        {
                            exit = true;
                            break;
                        }
                    default:
                        {
                            continue;
                        }
                }

                if (exit == true)
                {
                    break;
                }

                Console.WriteLine("\n\nВернуться в главное меню? y/n");
                str = Console.ReadLine();

                if (str == "y")
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
        }
    }    
}
