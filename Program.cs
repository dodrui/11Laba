using Laba10;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.Metrics;

namespace Laba11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задание 1
            //1.1

            ArrayList al  = new ArrayList();
            for (int i = 0; i < 5; i++)
            {
                Jet j = new Jet();
                al.Add(j);
                j.RandomInit();
            }
            for (int i = 0; i < 5; i++)
            {
                Helecopter j = new Helecopter();
                al.Add(j);
                j.RandomInit();
            }

            Console.WriteLine("Введите номер объекта:");
            Aircraft airSearch = new Aircraft();
            airSearch.Init();

            int position = al.IndexOf(airSearch);

            Console.WriteLine($"Искомая позиция: {position}");
            if (position >= 0)
            {
                Console.WriteLine($"Удаляем {al[position]}");
                al.Remove(position);
            }

            if (al.Contains(position))
            {
                Console.WriteLine("Найден");
            }
            else
            {
                Console.WriteLine("Не найден");
            }

            //Сортировка по типу двигателя
            al.Sort();
            ShowArray(al);
            Console.WriteLine(al.Count);
            Console.WriteLine(al.Capacity);

            Console.WriteLine($"Суммарное колличество экипажа истребителей типа перехватчик: {CrewCount(al)}");
            Console.WriteLine($"Количество самолетов произведенных с 2010 года = {YearCount(al)}");
            Console.WriteLine($"Количество вертолетов: {HelecopterCount(al)}");

            Console.WriteLine("Спиок истребителей:");
            foreach (object j in al)
            {
                if (j is Jet p)
                {
                    Console.WriteLine(p);
                }
            }

            ArrayList alClon = ToClone(al);
            Console.WriteLine("Клон:");
            ShowArray(alClon);

            //2 задание
            Queue<Aircraft> queue = new Queue<Aircraft>();
            for (int i = 0; i < 5; i++)
            {
                Jet j = new Jet();
                j.RandomInit();
                queue.Enqueue(j);
            }
            for (int i = 0; i < 5; i++)
            {
                Helecopter j = new Helecopter();
                j.RandomInit();
                queue.Enqueue(j);
            }
            ShowQueue(queue);

            //Поиск
            Console.WriteLine("Введите элемент для поиска:");
            Aircraft forSearch = new Aircraft();
            forSearch.Init();

            if (queue.Contains(forSearch))
                Console.WriteLine("Элемент найден");
            else
                Console.WriteLine("Элемент не найден");

            //Удаление
            Console.WriteLine("Введите элемент для удаления:");
            Aircraft forDel = new Aircraft();
            forDel.Init();
            queue = RemoveFromQueue(queue, forDel);
            Console.WriteLine("Элемент удален!");
            ShowQueue(queue);

            //Запросы
            Console.WriteLine($"Истребителей в очереди: {JetCount(queue)}");
            Console.WriteLine($"Самолетов в очереди: {PlaneCount(queue)}");
            Console.WriteLine($"Самолетов с вместимостью от 200 человек: {PassengersCount(queue)}");

            //Сортировка
            queue = SortQueue(queue);
            Console.WriteLine("Обновленная очередь:");
            ShowQueue(queue);

            //Клонирование
            Queue<Aircraft> queueClon = ToCloneQueue(queue);
            Console.WriteLine("Клон:");
            ShowQueue(queueClon);

            //3
            TestCollections collections = new TestCollections(10);
            Console.WriteLine("тестовые коллекции созданы");
            Console.WriteLine(collections.FirstElem);
            Console.WriteLine("\n несколько раз запущенный поиск первого элемента");
            Console.WriteLine(collections.FirstEl());
            Console.WriteLine(collections.FirstEl());
            Console.WriteLine(collections.FirstEl());

            Console.WriteLine("\n несколько раз запущенный поиск срединного элемента");
            Console.WriteLine(collections.MiddleEl());
            Console.WriteLine(collections.MiddleEl());

            Console.WriteLine("\n несколько раз запущенный поиск последнего элемента");
            Console.WriteLine(collections.LastEl());
            Console.WriteLine(collections.LastEl());

            Console.WriteLine("\n несколько раз запущенный поиск несуществующего элемента");
            Console.WriteLine(collections.NotExistEl());
            Console.WriteLine(collections.NotExistEl());
        }
        static void ShowArray (ArrayList al)
        {
            foreach (object o in al)
            {
                Console.WriteLine(o.ToString());
            }
        }
        static int CrewCount(ArrayList al)
        {
            int cnt = 0;
            string type = "перехватчик";
            foreach (object item in al)
            {
                if (item is Jet j)
                {
                    if (j.Function == type)
                        cnt += j.CrewNumber;
                }
            }
            return cnt;
        }
        static int YearCount(ArrayList al)
        {
            int cnt = 0;
            foreach (object item in al)
            {
                Aircraft air = item as Aircraft;
                if (air.ProductionYear >= 2010 && (item != null))
                    cnt++;
            }
            return cnt;
        }
        static int HelecopterCount(ArrayList al)
        {
            int cnt = 0;
            foreach(Aircraft item in al)
            {
                if (item is Helecopter j)
                    cnt++;
            }
            return cnt;
        }
        public static ArrayList ToClone(ArrayList al)
        {
            ArrayList alClone = new ArrayList();
            foreach (object item in al)
            {
                alClone.Add(((ICloneable)item).Clone());
            }
            return alClone;
        }
        public static void ShowQueue <T> (Queue <T> queue)
        {
            foreach (T item in queue)
                Console.WriteLine(item);
        }
        public static Queue<T> ToCloneQueue<T>(Queue<T> queue)
        {
            Queue<T> clone = new Queue<T>(queue.ToArray());
            return clone;
        }
        public static Queue<T> RemoveFromQueue<T> (Queue<T> queue, Aircraft forDel) 
        { 
            Queue<T> newArr = new Queue<T>();
            while (queue.Count > 0)
            {
                T temp = queue.Dequeue();
                if (!temp.Equals(forDel))
                {
                    newArr.Enqueue(temp);
                }
                else
                {
                    Console.WriteLine("Объект удален");
                }
            }
            return newArr;
        }
        public static Queue<T> SortQueue<T> (Queue<T> queue)
        {
            T[] arrayed = queue.ToArray();
            Array.Sort(arrayed);

            queue.Clear();
            foreach (T item in arrayed)
                queue.Enqueue(item);
            return queue;
        }
        public static int JetCount<T>(Queue<T> queue)
        {
            int cnt = 0;
            foreach (object item in queue)
            {
                if (item is Jet) 
                    cnt++;
            }
            return cnt;
        }

        public static int PlaneCount<T>(Queue<T> queue)
        {
            int cnt = 0;
            foreach (object item in queue)
            {
                if (item is Plane)
                    cnt++;
            }
            return cnt;
        }
        public static int PassengersCount<T>(Queue<T> queue)
        {
            int cnt = 0;
            foreach (object item in queue)
            {
                if (item is Plane p)
                {
                    if (p.Passengers > 200)
                        cnt++;
                }
            }
            return (cnt);
        }
    }
}
