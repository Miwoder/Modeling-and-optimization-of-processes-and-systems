using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<StructZad1> listZad11 = new List<StructZad1>();
        public static List<StructZad1> listZad12 = new List<StructZad1>();
        public static List<StructZad1> listZad13 = new List<StructZad1>();
        public static List<StructZad1> listZad21 = new List<StructZad1>();
        public static List<StructZad1> listZad22 = new List<StructZad1>();
        public static List<StructZad1> listZad23 = new List<StructZad1>();
        public static List<StructZad1> listZad31 = new List<StructZad1>();
        public static List<StructZad1> listZad32 = new List<StructZad1>();
        public static List<StructZad1> listZad33 = new List<StructZad1>();

        public MainWindow()
        {
            InitializeComponent();
            Task1();
            Task2();
            Task3();
        }

        public void Task1()
        {
            float[,] data = new float[,] { { 0.25f, 0.35f, 0.4f }, { 0.7f, 0.2f, 0.3f }, { 0.35f, 0.85f, 0.20f }, { 0.8f, 0.1f, 0.35f } };

            for (int i = 0; i < data.GetLength(0); i++)
            {
                listZad11.Add(new StructZad1()
                {
                    Line = "A" + (i + 1),
                    B1=data[i,0].ToString(),
                    B2 = data[i, 1].ToString(),
                    B3 = data[i, 2].ToString()
                });
            }

            Zad11.ItemsSource = listZad11;

            for (int i = 0; i < data.GetLength(1); i++)
            {
                float max = MyMethods.Max(MyMethods.GetColumn(data,i));
                for (int j = 0; j < data.GetLength(0); j++)
                {
                    data[j, i] = (float)Math.Round(max-data[j,i],3);
                }
            }

            for (int i = 0; i < data.GetLength(0); i++)
            {
                listZad12.Add(new StructZad1()
                {
                    Line = "A" + (i + 1),
                    B1 = data[i, 0].ToString(),
                    B2 = data[i, 1].ToString(),
                    B3 = data[i, 2].ToString(),
                    a=MyMethods.GetSum(MyMethods.GetRow(data,i)).ToString()
                });
            }

            Zad12.ItemsSource = listZad12;

            float[] rowSum = new float[listZad12.Count()];

            for (int i = 0; i < rowSum.GetLength(0); i++)
            {
                rowSum[i] = float.Parse(listZad12[i].a);
            }

            TextBoxZad1.Text += $"Min r = {MyMethods.Min(rowSum)}";

        }

        public void Task2()
        {
            float[,] data = new float[,] { { 280, 140, 210, 245 }, { 420, 560, 140, 280 }, { 245, 315, 350, 490 } };

            for (int i = 0; i < data.GetLength(0); i++)
            {
                listZad21.Add(new StructZad1()
                {
                    Line = "A" + (i + 1),
                    B1 = data[i, 0].ToString(),
                    B2 = data[i, 1].ToString(),
                    B3 = data[i, 2].ToString(),
                    B4 = data[i, 3].ToString(),
                    a = MyMethods.Min(MyMethods.GetRow(data, i)).ToString()
                });
            }
            listZad21.Add(new StructZad1()
            {
                Line = "max",
                B1 = MyMethods.Max(MyMethods.GetColumn(data, 0)).ToString(),
                B2 = MyMethods.Max(MyMethods.GetColumn(data, 1)).ToString(),
                B3 = MyMethods.Max(MyMethods.GetColumn(data, 2)).ToString(),
                B4 = MyMethods.Max(MyMethods.GetColumn(data, 3)).ToString()
            });

            float[] min = new float[listZad21.Count() - 1];

            for (int i = 0; i < min.Length; i++)
            {
                min[i] = float.Parse(listZad21[i].a);
            }

            Zad21.ItemsSource = listZad21;

            for (int i = 0; i < data.GetLength(0); i++)
            {
                listZad22.Add(new StructZad1()
                {
                    Line = "A" + (i + 1),
                    B1 = data[i, 0].ToString(),
                    B2 = data[i, 1].ToString(),
                    B3 = data[i, 2].ToString(),
                    B4 = data[i, 3].ToString(),
                    a = MyMethods.Max(MyMethods.GetRow(data, i)).ToString()
                });
            }
            Zad22.ItemsSource = listZad22;

            float[,] newdata = data;

            for (int i = 0; i < data.GetLength(1); i++)
            {
                float max1 = MyMethods.Max(MyMethods.GetColumn(data, i));
                for (int j = 0; j < data.GetLength(0); j++)
                {
                    newdata[j, i] = (float)Math.Round(max1 - newdata[j, i], 3);
                }
            }

            for (int i = 0; i < data.GetLength(0); i++)
            {
                listZad23.Add(new StructZad1()
                {
                    Line = "A" + (i + 1),
                    B1 = newdata[i, 0].ToString(),
                    B2 = newdata[i, 1].ToString(),
                    B3 = newdata[i, 2].ToString(),
                    B4 = newdata[i, 3].ToString(),
                    a = MyMethods.Max(MyMethods.GetRow(data, i)).ToString()
                });
            }
            float[] max = new float[listZad23.Count()];

            for (int i = 0; i < max.Length; i++)
            {
                max[i] = float.Parse(listZad23[i].a);
            }

            Zad23.ItemsSource = listZad23;

            TextBoxZad2.Text += "Критерий Вальда: цена игры = "+ MyMethods.Max(min)+"; оптимальный план = "+(MyMethods.GetIndexMax(min)+1)+"\n";

            TextBoxZad2.Text += "Критерий Сэвиджа: цена игры = " + MyMethods.Min(max) + "; оптимальный план = " + (MyMethods.GetIndexMin(max) + 1)+"\n";

            float[] G = new float[listZad23.Count()];
            float L = 0.4f;

            TextBoxZad2.Text += "G = {";
            for (int i = 0; i < G.Length; i++)
            {
                G[i] = L * MyMethods.Min(MyMethods.GetRow(data, i)) + (1 - L) * MyMethods.Max(MyMethods.GetRow(data, i));
                TextBoxZad2.Text += G[i] + "; ";
            }
            TextBoxZad2.Text += "}\n";

            TextBoxZad2.Text += "Критерий Гурвица: цена игры = " + MyMethods.Max(G) + "; оптимальный план = " + (MyMethods.GetIndexMax(G) + 1) + "\n";

        }

        public void Task3()
        {
            float[,] data = new float[,] { { 4f, 1f, 2f, 5f }, { 3f, 2f, 0f, 4f }, { 0f, 3f, 2f, 5f } };
            float[] q = { 0.25f, 0.15f, 0.2f, 0.4f };
            float[] win = new float[data.GetLength(0)];

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    win[i] += data[i, j] * q[j];
                }
            }

            for (int i = 0; i < data.GetLength(0); i++)
            {
                listZad31.Add(new StructZad1()
                {
                    Line = "A" + (i + 1),
                    B1 = data[i, 0].ToString(),
                    B2 = data[i, 1].ToString(),
                    B3 = data[i, 2].ToString(),
                    B4 = data[i, 3].ToString(),
                    a = win[i].ToString()
                });
            }
            listZad31.Add(new StructZad1()
            {
                Line = "max",
                B1 = MyMethods.Max(MyMethods.GetColumn(data, 0)).ToString(),
                B2 = MyMethods.Max(MyMethods.GetColumn(data, 1)).ToString(),
                B3 = MyMethods.Max(MyMethods.GetColumn(data, 2)).ToString(),
                B4 = MyMethods.Max(MyMethods.GetColumn(data, 3)).ToString(),
                a = MyMethods.Max(win).ToString()
            });
            listZad31.Add(new StructZad1()
            {
                Line = "q",
                B1 = q[0].ToString(),
                B2 = q[1].ToString(),
                B3 = q[2].ToString(),
                B4 = q[3].ToString()
            }); ;

            float maxwin = 0f;

            for (int j = 0; j < data.GetLength(1); j++)
            {
                maxwin += MyMethods.Max(MyMethods.GetColumn(data, j)) * q[j];
            }

            TextBoxZad3.Text += $"{maxwin} - {MyMethods.Max(win)} = {maxwin - MyMethods.Max(win)}\n";
            TextBoxZad3.Text += "Затраты на проведение эксперимента для выяснения условий, в которых будет осуществляться операция, составляют 1,1 д.е.\n";
            float cost = 1.1f;
            char znak = cost > MyMethods.Max(win) - maxwin ? '>' : '<';
            TextBoxZad3.Text += $"{cost} {znak} {maxwin-MyMethods.Max(win)}";

            Zad31.ItemsSource = listZad31;

        }

        public struct StructZad1
        {
            public string Line { get; set; }
            public string B1 { get; set; }
            public string B2 { get; set; }
            public string B3 { get; set; }
            public string B4 { get; set; }
            public string B5 { get; set; }
            public string a { get; set; }
        }

        private void Zad11_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
