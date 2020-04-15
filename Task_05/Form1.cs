using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_03
{
    public partial class Form1 : Form
    {
        TableLayoutPanel colorTable = new TableLayoutPanel();

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(int[] argbList)
        {
            InitializeComponent();
            Controls.Add(colorTable);

            DisplayColors(argbList, 15);

            colorTable.BackColor = Color.FromArgb(100, 100, 100);
            colorTable.Show();

            Width = 0;
            Height = 0;

            AutoSize = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void DisplayColors(int[] argbList, int columns = 10)
        {
            Panel[] colorViewList = new Panel[argbList.Length];

            colorTable.AutoSize = true;
            colorTable.ColumnCount = columns;
            colorTable.Padding = new Padding(0);
            colorTable.Margin = new Padding(0);

            int x = 0;
            int y = 0;

            for (int i = 0; i < argbList.Length; i++)
            {
                colorViewList[i] = new Panel();
                colorViewList[i].Location = new Point(x, y);
                colorViewList[i].Size = new Size(50, 50);
                colorViewList[i].BackColor = Color.FromArgb(argbList[i]);
                colorViewList[i].Margin = new Padding(0);
                colorViewList[i].MouseClick += (object sender, MouseEventArgs e) => {
                    Text = $"Selected color: { ((Panel)sender).BackColor }";
                };

                x += 50;
                x %= columns * 50;
                y += 50 * (i % columns);

                colorTable.Controls.Add(colorViewList[i]);
            }
        }
    }
}
