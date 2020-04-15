using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03
{
    public class MyColorList
    {
        List<MyColor> colorList;

        public MyColorList()
        {
            colorList = new List<MyColor>();
        }

        /// <summary>
        /// Метод для добавления нового цвета в список
        /// </summary>
        /// <param name="color"></param>
        public void AddMyColor(MyColor color)
        {
            colorList.Add(color);
        }

        /// <summary>
        /// Метод, преобразующий элементы списка цветов в argb
        /// </summary>
        /// <returns>Массив argb цветов</returns>
        public int[] GetARGBList()  
        {
            List<int> argbList = new List<int>();
            colorList.ForEach(color => argbList.Add(color.color.ToArgb()));

            return argbList.ToArray();
        }
    }
}
