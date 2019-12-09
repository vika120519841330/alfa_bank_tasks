/*
 От Вас требуется написать функцию rrotate, которая принимает на вход массив произвольных элементов и целое значение k.
 Функция должна выполнить циклический сдвиг массива на k элементов вправо. 
 Запрещается использовать дополнительный массив. Сложность алгоритма сдвига не должна превышать O(n).
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var MyArr = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (var t in rrotate(ref MyArr, 9))
            {
                Console.Write(t);
            }
            Console.ReadKey();
        }
        private static int[] rrotate(ref int[] arr, int ofs)
        {
            int offset;
            int len = arr.Length;
            if (ofs == len)
            {
                return arr;
            }
            else if (ofs < len)
            {
                offset = ofs;
            }
            else
            {
                offset = len % ofs;
            }
            for(int j = 0; j < offset; j++)
            {
                foreach (var t in arr)
                {
                    Console.Write(t);
                }
                Console.WriteLine();
                int temp = arr[0];
                for (int i = 0; i < len; i++)
                {
                    if (i == len - 1)
                    {
                        arr[i] = temp;
                    }
                    else arr[i] = arr[i + 1];
                }
            }
            return arr;
        }
    }
}
