using System;
using System.Collections;
using System.Collections.Generic;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {

            ApplicationContactsDirectory applicationContactsDirectory = new ApplicationContactsDirectory();
            applicationContactsDirectory.ApplicationStart();
            Console.Read();
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

