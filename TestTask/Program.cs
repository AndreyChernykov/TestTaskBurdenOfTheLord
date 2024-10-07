using System;
using System.Collections;
using System.Collections.Generic;
using TestTask.HashData;
using TestTask.GeometricFigure;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] testArray = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            Console.WriteLine("Сумма чисел главной диагонали = " + new TaskOne().MainSequenceSum(testArray));
            Console.WriteLine("Сумма чисел кратных 3 = " + new TaskOne().MultipeOfThree(testArray));
            Console.WriteLine("Фибоначи = " + new TaskTwo().Fibonachi(14));
            Console.WriteLine("Степень = " + new TaskTwo().Power(12, 5));
            Console.Read();

            ///<summary>
            ///applicationContactsDirectory - 3е задание телефонный справочник с хешированием
            ///applicationFigure - 4е задание проверка геометрических фигур
            ///раскомментить нужное для запуска

            //ApplicationContactsDirectory applicationContactsDirectory = new ApplicationContactsDirectory();
            //applicationContactsDirectory.ApplicationStart();

            //ApplicationFigure applicationFigure = new ApplicationFigure();
            //applicationFigure.ApplicationStart();
        }
    }

    class TaskOne
    {
        private int _multiple = 3;

        public int MainSequenceSum(int[,] array)//Сумма чисел главной диагонали
        {
            int result = 0;
            for(int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i == j) result += array[i, j];
                }
            }

            return result;
        }

        public int MultipeOfThree(int[,] array)//Сумма чисел кратных 3
        {
            int result = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] % _multiple == 0) result += array[i, j];
                }
            }

            return result;
        }
    }

    class TaskTwo
    {
        public int Fibonachi(int num)//рекурсивный Фибоначи
        {
            if (num == 0 || num == 1) return num;
            return Fibonachi(num - 1) + Fibonachi(num - 2);
        }

        public int Power(int num, int degree)//рекурсивное возведение в степень
        {
            if (degree == 0)
            {
                return 1;
            }

            if (degree % 2 == 0)
            {
                var p = Power(num, degree / 2);
                return p * p;
            }
            else
            {
                return num * Power(num, degree - 1);
            }
        }
    }

}

