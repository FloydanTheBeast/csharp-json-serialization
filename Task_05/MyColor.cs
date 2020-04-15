using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task_03
{
    public class MyColor
    {
        public Color color;

        public string ColorName { get; set; }

        public byte A { get; set; }
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public MyColor(string colorName, string hex)
        {
            ColorName = colorName;
            GetRGB(hex);
        }

        public MyColor(string colorName, byte[] rgba)
        {
            if (rgba.Length != 4)
                throw new ColorException("Должно быть передано ровно 4 параметра, соответветствующих каждому каналу");

            
            ColorName = colorName;
            R = rgba[0];
            G = rgba[1];
            B = rgba[2];
            A = rgba[3];
            color = Color.FromArgb(A * 255, R, G, B);
        }
      
        /// <summary>
        /// Метод, преобразующий цвет из HEX-строки в отдельные байты
        /// </summary>
        /// <param name="hex">HEX код цвета</param>
        void GetRGB(string hex)
        {
            color = ColorTranslator.FromHtml(hex);
            R = color.R;
            G = color.G;
            B = color.B;
        }

        public override string ToString()
        {
            return $"{ColorName}: {R}, {G}, {B}, {A}";
        }
    }
}
