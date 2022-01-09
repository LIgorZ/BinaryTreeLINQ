using System;
using System.IO;
using System.Linq;

namespace BinaryTreeLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("NET.C#.12 Введение в LINQ");

            var tree = new Tree<int>();
            
            string path = @"D:\Student.txt";

            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine("5");
                    sw.WriteLine("Иван Грозный");
                    sw.WriteLine("Государство и право");
                    sw.WriteLine("XVI век");

                    sw.WriteLine("7");
                    sw.WriteLine("Владимир Ленин");
                    sw.WriteLine("Туризм");
                    sw.WriteLine("XX век");

                    sw.WriteLine("1");
                    sw.WriteLine("Цезарь");
                    sw.WriteLine("Математика");
                    sw.WriteLine("I век до нэ");

                    sw.WriteLine("2");
                    sw.WriteLine("Роман");
                    sw.WriteLine("Химия");
                    sw.WriteLine("15/11/2021");

                    sw.WriteLine("6");
                    sw.WriteLine("Максим");
                    sw.WriteLine("Физика");
                    sw.WriteLine("11/10/2020");

                    sw.WriteLine("8");
                    sw.WriteLine("Федор");
                    sw.WriteLine("История");
                    sw.WriteLine("2/04/2018");

                    sw.WriteLine("3");
                    sw.WriteLine("Ли Сы");
                    sw.WriteLine("Вирусология");
                    sw.WriteLine("18/11/2019");

                    sw.Close();
                }
                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                int mark;
                string name, nameTask, dateTask;

                while ((line = sr.ReadLine()) != null)
                {
                    mark = int.Parse(line);
                    name = sr.ReadLine();
                    nameTask = sr.ReadLine();
                    dateTask = sr.ReadLine();

                    tree.Add(mark, name, nameTask, dateTask);
                }

                sr.Close();
            }

            var selectedStudent = tree.InOrderFull().Where(s => s.ToUpper().Contains("В")).OrderByDescending(s => s).Take(5);

            Console.WriteLine("Выборка с сортировкой и с ограничением количества записей");
            foreach (string s in selectedStudent)
                Console.WriteLine(s);

            Console.WriteLine("Вывод преордер");
            foreach (var item in tree.PreOrder())
            {
                Console.Write(item + ", ");
            }

            Console.WriteLine();

            Console.WriteLine("Вывод постордер");
            foreach (var item in tree.PostOrder())
            {
                Console.Write(item + ", ");
            }

            Console.WriteLine();

            Console.WriteLine("Вывод инордер");
            foreach (var item in tree.InOrder())
            {
                Console.Write(item + ", ");
            }

            Console.WriteLine();
            Console.WriteLine("Оценка   ФИО    Название теста   Дата сдачи теста");

            foreach (var item in tree.InOrderFull())
            {
                Console.WriteLine(item);
            }
        }
    }
}
