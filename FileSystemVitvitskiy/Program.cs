using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileSystemVitvitskiy
{
    class Program
    {
        public static void PrintStr(string str)
        {
            Console.WriteLine(str);
        }

        static void Main(string[] args)
        {
            PrintStr("Задание: Написать консольное приложение, в котором используются все методы классов " +
           "\nDirectory/DirectoryInfo и File/FileInfo ");
            Console.WriteLine();

            PrintStr("Использование методов классов Directory/DirectoryInfo:");
            Console.WriteLine();
            string dirName = @"C:\";

            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Подкаталоги диска С:");
                string[] dirs = Directory.GetDirectories(dirName);
                foreach (string dir in dirs)
                {
                    Console.WriteLine(dir);
                }
                Console.WriteLine();
                PrintStr("Теперь рассмотрим следующие функции\na)Создание каталога\nb)Получение информации о каталоге\n" +
                    "c)Удаление каталога\nd)Перемещение каталога ");
                Console.WriteLine();


                PrintStr("a)Создание каталога");
                string path = @"C:\BrandNewFolder";
                string subpath = @"SubDirectory1\SubDirectory2";
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                    Console.WriteLine($"Каталог{path} был создан.");
                }
                dirInfo.CreateSubdirectory(subpath);
                Console.WriteLine("Подкаталоги {0} каталога {1} были созданы.", subpath, path);
                Console.WriteLine();

                PrintStr("b)Получение информации о каталоге");
                string dirpath = path;
                DirectoryInfo dirInfo1 = new DirectoryInfo(dirpath);
                Console.WriteLine($"Название каталога: {dirInfo1.Name}");
                Console.WriteLine($"Полное название каталога: {dirInfo1.FullName}");
                Console.WriteLine($"Время создания каталога: {dirInfo1.CreationTime}");
                Console.WriteLine($"Корневой каталог: {dirInfo1.Root}");
                Console.WriteLine($"Атрибуты каталога: {dirInfo1.Attributes}");
                if (Directory.Exists(dirpath))
                {
                    Console.WriteLine($"Подкаталоги каталога {dirpath}:");
                    string[] dirs1 = Directory.GetDirectories(dirpath);
                    foreach (string subdir in dirs1)
                    {
                        Console.WriteLine(subdir);
                    }
                    Console.WriteLine();

                    // FileStream
                    PrintStr("Использование методов классов File/FileInfo:");
                    PrintStr("Класс FileStream:");
                    Console.WriteLine();
                   
                    Console.WriteLine("Введите строку для записи в файл:");
                    string text = Console.ReadLine();

                    // запись в файл по пути dirpath\textfiletest.txt
                    using (FileStream fstream = new FileStream($@"{dirpath}\textfiletest.txt", FileMode.OpenOrCreate))
                    {
                        // преобразуем строку в байты
                        byte[] array = System.Text.Encoding.Default.GetBytes(text);
                        // запись массива байтов в файл
                        fstream.Write(array, 0, array.Length);
                        Console.WriteLine("Текст записан в файл");
                    }

                    // чтение из файла
                    using (FileStream fstream = File.OpenRead($@"{dirpath}\textfiletest.txt"))
                    {
                        // преобразуем строку в байты
                        byte[] array = new byte[fstream.Length];
                        // считываем данные
                        fstream.Read(array, 0, array.Length);
                        // декодируем байты в строку
                        string textFromFile = System.Text.Encoding.Default.GetString(array);
                        Console.WriteLine($"Текст из файла: {textFromFile}");
                    }
                    Console.WriteLine();

                    // Вывод файлов папки C:\BrandNewFolder
                    Console.WriteLine($" Файлы каталога {dirpath}:");
                    if (Directory.Exists(dirpath))
                    {
                        string[] files = Directory.GetFiles(dirpath);
                        foreach (string file in files)
                        {
                            Console.WriteLine(file);
                        }

                    if (Directory.Exists(dirpath))
                        {
                            string[] Folderdirectory = Directory.GetDirectories(dirpath);
                            foreach (string directory in Folderdirectory)
                            {
                                Console.WriteLine(directory);
                            }

                            Console.WriteLine();

                            PrintStr("c)Удаление каталога");
                            string folderName2 = @"C:\SomeFolder";

                            try
                            {
                                DirectoryInfo dirInfo2 = new DirectoryInfo(folderName2);
                                if (!dirInfo2.Exists)
                                {
                                    dirInfo2.Create();
                                    Console.WriteLine($"Каталог {folderName2} был создан.");
                                }
                                dirInfo2.Delete(true);
                                Console.WriteLine($"Каталог {folderName2} был удален.");
                            }

                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            Console.WriteLine();

                            PrintStr("d)Перемещение каталога");
                            string oldPath = @"C:\BrandNewFolder";
                            string newPath = @"C:\NewPathFolder";
                            try
                            {
                                DirectoryInfo dirInfo3 = new DirectoryInfo(oldPath);
                                if (dirInfo3.Exists && Directory.Exists(newPath) == false)
                                {
                                    dirInfo3.MoveTo(newPath);
                                    Console.WriteLine($"Каталог {oldPath} был перемещен в каталог {newPath}");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            Console.WriteLine();
                        }

                        Console.WriteLine("Для завершения программы нажмите клавишу Enter...");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
