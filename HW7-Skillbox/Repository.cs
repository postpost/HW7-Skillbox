using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW7_Skillbox
{
    public class Repository
    {
        private Worker[] workers;
        private string path;
        int index;

        /// <summary>
        /// Конструктор для создания репозитория
        /// </summary>
        /// <param name="Path"></param>
        public Repository (string Path)
        {
            this.path = Path;
            this.workers = new Worker[1];
            index = 0;
        }

        /// <summary>
        /// Добавление новой записи
        /// </summary>
        public void AddNewNote()
        {
            path = "newStaff.txt";
            char key = 'д';
            int ID = 0;

            if (File.Exists(path))
            {
                ID = File.ReadAllLines(path).Length;
            }

            using (StreamWriter sw = new StreamWriter(path, true, Encoding.Unicode))
            {
                do
                {
                    string note = string.Empty;
                    note += $"{++ID}#";

                    string currentDateTime = DateTime.Now.ToString();
                    note += $"{currentDateTime}#";

                    Console.WriteLine("\nФ.И.О.");
                    string fullName = Console.ReadLine();
                    note += $"{fullName}#";

                    Console.WriteLine("Возраст");
                    string age = Convert.ToString(Console.ReadLine());
                    note += $"{age}#";

                    Console.WriteLine("Рост");
                    string height = Console.ReadLine();
                    note += $"{height}#";

                    Console.WriteLine("Дата рождения");
                    DateTime birthday;
                    while (!DateTime.TryParse(Console.ReadLine(), out birthday))
                    {
                        Console.WriteLine("Неверный формат даты. Введите в формате ДД.ММ.ГГГГ:");
                    }
                    note += $"{birthday.ToShortDateString()}#";

                    Console.WriteLine("Место рождения");
                    string placeOfBirthday = Console.ReadLine();
                    note += $"{placeOfBirthday}\t";

                    sw.WriteLine(note);
                    Console.Write("Продолжить н/д?");
                    key = Console.ReadKey(true).KeyChar;
                } while (char.ToLower(key) == 'д');
            }
        }

        /// <summary>
        /// Увеличение размера массива
        /// </summary>
        /// <param name="Flag"></param>
        public void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.workers, workers.Length * 2);
            }
        }

        /// <summary>
        /// Добавление нового работника
        /// </summary>
        /// <param name="NewWorker"></param>
        public void AddWorker(Worker NewWorker)
        {
            this.Resize(index >= workers.Length);
            this.workers[index] = NewWorker;
            index++;
        }

        /// <summary>
        /// Метод выгрузки массива всех работников
        /// </summary>
        /// <returns></returns>
        public Worker[] GetAllWorkers()
        {
            string[] args;
            using(StreamReader sr = new StreamReader(this.path))
            {
                while (!sr.EndOfStream)
                {
                    args = sr.ReadLine().Split('#');
                    AddWorker(new Worker(args[0], args[1], args[2], args[3], args[4], args[5], args[6]));
                }
            }
            //преобразовать из line в структуру Worker
            return workers;
        }

        public Worker[] GetWorkerByID(int id)
        {
            Worker[] workers = GetAllWorkers();
            int cound;
            for (int i = 0; i < workers.Length; i++)
            {
                if(i == id)
                {
                    Worker worker = workers[i];
                }
            }

            return //;
        }
    }
}
