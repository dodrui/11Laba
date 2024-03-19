using Laba10;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba11
{
    public class TestCollections
    {
        SortedDictionary<Aircraft, Jet> col1 = new SortedDictionary<Aircraft, Jet>();
        SortedDictionary<String, Jet> col2 = new SortedDictionary<String, Jet>();

        HashSet<Jet> col3 = new HashSet<Jet>();
        HashSet<String> col4 = new HashSet<String>();


        //Конструктор для заполнения коллекция 1000 штук элементов.
        Jet firstElem = new Jet();
        Jet middleElem = new Jet();
        Jet lastElem = new Jet();

        public TestCollections(int len)
        {
            Jet jj = new Jet();
            jj.RandomInit();
            for (int i = 0; i < len; i++)
            {
                try
                {
                    Jet jet = new Jet();
                    jet.RandomInit();
                    //Добавим цифру для уникальности имени
                    jet.Model += i.ToString();

                    //Добавление элементов
                    col1.Add(jet.GetBase, jet);
                    col2.Add(jet.GetBase.ToString(), jet);
                    col3.Add(jet);
                    col4.Add(jet.ToString());

                    //Поиск
                    if (i == 0)
                    {
                        firstElem = (Jet)jet.Clone();
                    }
                    else if (i == len / 2)
                    {
                        middleElem = (Jet)jet.Clone();
                    }
                    else if (i == len - 1)
                    {
                        lastElem = (Jet)jet.Clone();
                    }

                    Console.WriteLine(jet);
                }
                catch
                {
                    Console.WriteLine("2");
                    i--;
                }
            }
        }
        public Jet FirstElem
        {
            get => firstElem;
        }
        public string FirstEl()
        {
            Stopwatch sw = new Stopwatch();
            string output = "";

            sw.Start();
            bool res = col1.ContainsValue(firstElem);
            sw.Stop();
            output += $"Средний элемент в SortedDictionary<Aircraft, Jet> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";
            sw.Restart();
            res = col2.ContainsValue(firstElem);
            sw.Stop();
            output += $"Средний элемент в SortedDictionary<String, Jet> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";
            sw.Restart();
            res = col3.Contains(firstElem);
            sw.Stop();
            output += $"Средний элемент в HashSet<Jet> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";
            sw.Restart();
            res = col4.Contains(firstElem.ToString());
            sw.Stop();
            output += $"Средний элемент в HashSet<String> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";

            return output;
        }
        public string MiddleEl()
        {
            Stopwatch sw = new Stopwatch();
            string output = "";

            sw.Start();
            bool res = col1.ContainsValue(middleElem);
            sw.Stop();
            output += $"Последний элемент в SortedDictionary<Aircraft, Jet> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";
            sw.Restart();
            res = col2.ContainsValue(middleElem);
            sw.Stop();
            output += $"Последний элемент в SortedDictionary<String, Jet> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";
            sw.Restart();
            res = col3.Contains(middleElem);
            sw.Stop();
            output += $"Последний элемент в HashSet<Jet> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";
            sw.Restart();
            res = col4.Contains(middleElem.ToString());
            sw.Stop();
            output += $"Последний элемент в HashSet<String> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";

            return output;
        }
        public string LastEl()
        {
            Stopwatch sw = new Stopwatch();
            string output = "";

            sw.Start();
            bool res = col1.ContainsValue(lastElem);
            sw.Stop();
            output += $"Первый элемент в SortedDictionary<Aircraft, Jet> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";
            sw.Restart();
            res = col2.ContainsValue(lastElem);
            sw.Stop();
            output += $"Первый элемент в SortedDictionary<String, Jet> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";
            sw.Restart();
            res = col3.Contains(lastElem);
            sw.Stop();
            output += $"Первый элемент в HashSet<Jet> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";
            sw.Restart();
            res = col4.Contains(lastElem.ToString());
            sw.Stop();
            output += $"Первый элемент в HashSet<String> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";

            return output;
        }
        public string NotExistEl()
        {
            Jet jet = new Jet("None", -1, "None", 5, 0,"None");
            Stopwatch sw = new Stopwatch();
            string output = "";

            sw.Start();
            bool res = col1.ContainsValue(jet);
            sw.Stop();
            output += $"Первый элемент в SortedDictionary<Aircraft, Jet> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";
            sw.Restart();
            res = col2.ContainsValue(jet);
            sw.Stop();
            output += $"Первый элемент в SortedDictionary<String, Jet> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";
            sw.Restart();
            res = col3.Contains(jet);
            sw.Stop();
            output += $"Первый элемент в HashSet<Jet> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";
            sw.Restart();
            res = col4.Contains(jet.ToString());
            sw.Stop();
            output += $"Первый элемент в HashSet<String> " + (res ? "найден" : "не найден") + $" за {sw.ElapsedTicks}\n";

            return output;
        }
    }
}
