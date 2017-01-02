using System;
using System.Collections.Generic;
using System.Linq;

namespace SpiralMatrixForAlgorithmsCources
{
    class Program
    {
        static void Main(string[] args)
        {
            //считываем с консоли количество строк и двумерный массив(т.к там есть свои "приколы",
            //например пробелы в конце то приходиться делать Trim(т.е убирать пробелы))
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] arr = new int[n, n];
            string[] s = new string[n];
            for (int i = 0; i < n; i++)
            {
                s[i] = Console.ReadLine();
                int j = 0;
                foreach (int v in s[i].TrimEnd(' ').Split(' ').Select(v => Convert.ToInt32(v)))
                {
                    arr[i, j++] = v;
                }
            }

            List<int> li = solveProblem(arr, n);
            foreach (var l in li)
            {
                Console.Write(l + " ");
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Метод позволящий "перевести" наш массив в лист с необходимой нам последовательностью данных
        /// В данном методе мы делим нашу матрицу на квадраты и изменяем счетчики при нахождении той или иной вершины
        /// при этом записывая числа в List пока не найдем опорный элемент
        /// </summary>
        /// <param name="arr"> входной массив данных</param>
        /// <param name="n"> кол-во элементов в строках и столбцах</param>
        /// <returns></returns>
        private static List<int> solveProblem(int[,] arr, int n)
        {
            List<int> li = new List<int>();
            int i = 0, j = 0; // счетчики
            int temp = 0; // временная переменная для изменения счетчиков
            int count = 0; // подсчет общего количества элементов
            int d = n%2 == 0 ? n*n : n*n - 1; // Опорный элемент(цикл заканчивается, когда мы его находим)
            if (n == 0)
            {
                return li;
            }
            if (n == 1)
            {
                li.Add(arr[0, 0]);
            }
            else
            {
                do
                {
                    do
                    {
                        li.Add(arr[i, j]);
                        j++;
                        count++;
                    } while (j != n - 1 - temp);

                    do
                    {
                        li.Add(arr[i, j]);
                        i++;
                        count++;
                    } while (i != n - temp);
                    
                    do
                    {
                        j--;
                        li.Add(arr[i - 1, j]);
                        count++;
                    } while (j != temp);

                    if (count != n*n)
                    {
                        do
                        {
                            li.Add(arr[i - 2, j]);
                            i--;
                            count++;
                        } while (i != 2 + temp);
                        i--;
                        j++;
                        temp++;
                    }
                } while (count != d);
                // Для нечетного n нам необходимо записать сам опорный элемент
                if (n%2 != 0)
                {
                    li.Add(arr[(n - 1)/2, (n - 1)/2]);
                }
            }
            return li;
        }
    }
}
