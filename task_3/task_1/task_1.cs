/*
От Вас требуется написать функцию dsearch, которая принимает на вход имя файла и блок данных.
В качестве результата функция должна возвращать смещение идентичного блока данных в файле.Размер файла не превышает 512 Mb.
Блоки данных в файле выровнены по границе 256 B.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    class task_1
    {
        static void Main(string[] args)
        {
            //для примера считаем блок кода из файла, а затем с пом. функции dsearch найдем смещение, по которому искомый блок находится в файле
            string path = @"D:\CLR_via_C#._Programmirovanie_na_platforme_Microsoft_.NET_Framework_2.0_na_yazyke_C#.pdf";
            byte[] searchBlock = new byte [256];
            //кол-во успешно считанных байт
            int numByte = 0;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                //считать третий блок данных
                fs.Seek(256 * 2, SeekOrigin.Begin);
                numByte = fs.Read(searchBlock, 0, 256);
            }
            if (numByte != 0)
            {
                int result = dsearch(path, searchBlock);
                switch(result)
                {
                    case (-2):
                        Console.WriteLine($"Размер считываемого файла превышает предельно допустимый размер 512 Mb !!!");
                        break;
                    case (-1):
                        Console.WriteLine($"Файл считан полностью и искомый блок данных в файле {Path.GetFileName(path)} не обнаружен!!");
                        break;
                    default:
                        Console.WriteLine($"Искомый в файле <<{Path.GetFileName(path)}>> блок кода находится по смещению : {result} Байт");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Блок кода для осуществления поиска не удалось считать!");
            }
            Console.ReadKey();
        }
        public static int dsearch(string path, byte[] block)
        {
            //размер блока инф-ции
            const int blockSize = 256;

            //предельный размер записываемого файла, Байт
            const int fileSize = 512 * 1024 * 1024;

            //временный массив для считанного блока данных
            byte[] bufferTemp = new byte[blockSize];

            //смещение относительно начала файла с данными
            int offset = 0;

            //флаг равенства искомого и считываемого блока кода
            bool equalFlag = false;

            using (FileStream f = new FileStream(path, FileMode.Open))
            {
                if(f.Length > fileSize)
                {
                    offset = -2;
                    return offset;
                }
                //кол-во проходов равно кол-ву блоков данных в считываемом файле
                for (int i = 0; i < (f.Length / 256); i++)
                {
                    //считать блок данных во временный массив - возвращает кол-во успешно считанных байт
                    int num = f.Read(bufferTemp, 0, blockSize);
                    if (num != 0)
                    {
                        equalFlag = block.SequenceEqual(bufferTemp);
                        if(equalFlag != true)
                        {
                            offset = offset + 256;
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        offset = -1;
                        break;
                    }
                }
                return offset;
            }
        }
    }
}
