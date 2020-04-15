using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Task_03
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Список цветов
            MyColorList colorList = new MyColorList();

            // Регулярное выражение для нахождения чисел
            string regexPattern = @"[0-9]+";

            try
            {
                using (StreamReader st = new StreamReader("colors.json"))
                {
                    while (!st.EndOfStream)
                    {
                        string line = st.ReadLine();
                        if (line.Contains(":"))
                        {
                            string[] ls = line.Split(':');

                            string colorName = ls[0].Substring(ls[0].IndexOf('"') + 1, ls[0].LastIndexOf('"') - ls[0].IndexOf('"') - 1);

                            byte[] colorValues = new byte[4];

                            // Применение регулярного выражения для нахождения всех цветов
                            MatchCollection matches = Regex.Matches(ls[1], regexPattern);

                            for (int i = 0; i < 4; i++)
                                byte.TryParse(matches[i].Value.ToString(), out colorValues[i]);


                            MyColor color = new MyColor(colorName, colorValues);
                            Console.WriteLine(color);

                            colorList.AddMyColor(color);
                        }
                    }
                }
            }
            catch (ColorException ex)
            {
                Console.WriteLine($"Ошибка при создании объекта MyColor: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка при открытии файла: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Ошибка доступа: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Непредвиденная: {ex.Message}");
            }

            // Открытие формы
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(colorList.GetARGBList()));
        }
    }
}
