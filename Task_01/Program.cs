using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;


namespace Task_01
{
    class Program
    {
        /// <summary>
        /// Запись в файл(сериализация)
        /// </summary>
        /// <param name="groups">передаем группу студентов </param>
        static void WriteToFile(Group[] groups)
        {
            DataContractJsonSerializer format = new DataContractJsonSerializer(typeof(Group[]));
            try
            {
                using (FileStream bas = new FileStream("group.ser", FileMode.Create))
                {
                    try
                    {
                        format.WriteObject(bas, groups);
                        Console.WriteLine("Выполнена запись в файл group.ser");
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Чтение файла(десериализация)
        /// </summary>
        static void ReadFromFile()
        {
            DataContractJsonSerializer format = new DataContractJsonSerializer(typeof(Group[]));
            try
            {
                using (FileStream bas = new FileStream("group.ser", FileMode.Open))
                {
                    while (true)
                    {
                        try
                        {
                            Group[] grps = (Group[])format.ReadObject(bas);
                            Array.ForEach<Group>(grps, (gr) => Console.WriteLine(gr));
                        }
                        catch (Exception)
                        {
                            bas.Close();
                            break;
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Main(string[] args)
        {
            //Список группы 171
            Student[] list171 = {new Student("Иванов", 1),
                new Student("Петров", 1),new Student("Сидоров",1)};
            Group gr171 = new Group("ПИ-171", list171);

            //Список группы 271
            Student[] list271 = {new Student("Яковлев", 2),
                new Student("Юрьевa", 2),new Student("Белов",2)};
            Group gr271 = new Group("ПИ-271", list271);

            //Список групп
            Group[] groups = { gr171, gr271 };

            //Сериализуем
            WriteToFile(groups);

            //Десериализуем
            ReadFromFile();

            Console.ReadLine();
        }
    }
}
