using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileSystemVitvitskiy2
{
    class Program
    {
        public static void Print (string str1)
        {
            Console.WriteLine(str1);
        }
        static void Main(string[] args)
        {
            Print("Второе задание: Классы StreamWriter и StreamReader");
            Print("а):Дан файл, содержащий текст на русском языке. Определить, входит ли слово\n" +
                "\"экзамен\"в указанный текст, и если входит, то сколько раз.");
            Console.WriteLine();
            // StreamWriter 
            string filepath = @"C:\NewPathFolder\SubDirectory1\SubDirectory2\filetest2.txt";
            Console.WriteLine("Введите строку на русском языке:");
            string[] Filetext = Console.ReadLine().Split(' ', '.', ',', '!', '?').ToArray();
            string slovo = "экзамен";
            string output = String.Join(" ", Filetext);
            int quantity = 0;
            try
            {
                using (StreamWriter sw = new StreamWriter(filepath, false, System.Text.Encoding.Default))
                {
                    for (int i = 0; i < Filetext.Length; i++)
                    {
                        if (Filetext[i].Contains(slovo))
                        {
                            quantity++;
                        }
                    }
                    Console.WriteLine("слово {0} встречается в тексте {1} раз.", slovo, quantity.ToString());
                    //Запись в файл C:\NewPathFolder\SubDirectory1\SubDirectory2\filetest2.txt
                    sw.WriteLine($"Исходный текст:{output}");
                    sw.WriteLine("слово {0} встречается в тексте {1} раз.", slovo, quantity.ToString()); 
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // StreamReader
            try
            {
                using (StreamReader sr = new StreamReader(filepath, System.Text.Encoding.Default))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();


            Print("b):Дан файл, содержащий текст на русском языке. В предложениях некоторые слова повторяются \n" +
                "подряд несколько раз(предложения заканчиваются точкой или знаком восклицания).\n" +
                "Получить в новом файле отредактированный текст, в котором удалены повторные вхождения слов в предложения.");

            string filepath1 = @"C:\NewPathFolder\SubDirectory1\SubDirectory2\Russiantext.txt";
            Console.WriteLine("Введите строку на русском языке:");
            string Russiantext = Console.ReadLine();
            string[] Filetext1 = Russiantext.Split(' ', '.', ',', '!', '-').ToArray();
            string output1 = String.Join(" ", Filetext1);
            int start = 0; // Объявляем переменную для сохранения индекса
            try
            {
                using (StreamWriter sw = new StreamWriter(filepath1, false, System.Text.Encoding.Default))
                {
                    for (int i = 0; i < Filetext1.Length; i++)
                    {
                        for (int j = i + 1; j < Filetext1.Length; j++)
                        {
                            if ((String.Compare(Filetext1[i], Filetext1[j]) == 0) && !String.IsNullOrEmpty(Filetext1[i]))
                            {
                                // если слово встречается
                                Console.WriteLine("'{0}' == '{1}'", Filetext1[i], Filetext1[j]);
                                // Удаляем все его вхождения
                                start = Russiantext.IndexOf(Filetext1[i]);
                                
                                    // Удаляем второе вхождение
                                    Russiantext = Russiantext.Remove(start, Filetext1[i].Length); 

                                    Console.WriteLine("Новая строка: {0}", Russiantext);
                                    start = Russiantext.IndexOf(Filetext1[i]);
                            }
                        }
                    }
                    //Запись в файл C:\NewPathFolder\SubDirectory1\SubDirectory2\Russiantext.txt
                    sw.WriteLine();
                    sw.WriteLine($"Исходная строка:{output1}");
                    sw.WriteLine($"Измененная строка:{Russiantext}");
                 }
               
              }
                
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // StreamReader
            try
            {
                using (StreamReader sr = new StreamReader(filepath1, System.Text.Encoding.Default))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Для завершения программы нажмите клавишу Enter...");
            Console.ReadLine();

        }
    }
}
