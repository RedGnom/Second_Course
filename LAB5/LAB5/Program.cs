using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5
{
    internal class Program
    {
        static Random rnd = new Random();
        static int ReadElem(out int n, int choice)
        {
            switch (choice)
            {
                case 0:
                    Console.WriteLine("Введите количество элементов");
                    break;
                case 1:
                    Console.WriteLine("Введите количество строк");
                    break;
                case 2:
                    Console.WriteLine("Введите элемент");
                    break;
                case 3:
                    Console.WriteLine("Выберите действие");
                    break;
                case 4:
                    Console.WriteLine("Введите номер строки, с которой вставлять");
                    break;
                case 5:
                    Console.WriteLine("Введите количество столбцов");
                    break;
                default:
                    Console.WriteLine("Выберите действие");
                    break;
            }
            
            bool isCorrect;
            do
            {
                isCorrect = int.TryParse(Console.ReadLine(), out n);
                if (!isCorrect || n < 0)
                {
                    Console.WriteLine("Неверные данные, повторите попытку ввода");
                    isCorrect = false;
                }
            }
            while (!isCorrect);
            return n;
        }
        static void FillArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {

                arr[i] = ReadElem(out arr[i], 2);
            }
        }
        static void FillArrRnd(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(0, 50);
            }
        }
        static void FillArr(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = ReadElem(out arr[i, j], 2);
                }
            }
        }
        static void FillArrRnd(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rnd.Next(0, 50);
                }
            }
        }
        static int[][] FillArr(int[][] arr)
        {
            int n;

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Строка номер: " + (i + 1));
                ReadElem(out n, 0);
                arr[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    arr[i][j] = ReadElem(out arr[i][j], 2);
                }
            }
            return arr;
        }
        static int[][] FillArrRnd(int [][] arr)
        {
            int n;

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Строка номер: " + (i + 1));
                ReadElem(out n, 0);
                arr[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    arr[i][j] = rnd.Next(0, 50);
                }
            }
            return arr;
        }
        static void ShowArr(int[] arr)
        {
            Console.WriteLine("Одномерный массив");
            if(arr.Length == 0)
            {
                Console.WriteLine("Массив пустой");
            }
            foreach (int num in arr)
            {
                
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
        static void ShowArr(int[,] arr)
        {
            if (arr.GetLength(0) == 0 || arr.GetLength(1) == 0)
            {
                Console.WriteLine("Массив пустой");
                return;
            }
            Console.WriteLine("Двумерный массив:");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("{0,-5} ", arr[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void ShowArr(int[][] arr)
        {

            Console.WriteLine("Рваный массив:");
            bool isEmptyArray = true;

            foreach (int[] subArray in arr)
            {
                if (subArray.Length == 0)
                {
                    continue;
                }
                isEmptyArray = false;
                foreach (int num in subArray)
                {
                    Console.Write("{0,-5} ", num);
                }
                Console.WriteLine();
            }
            if (isEmptyArray) 
            {
                Console.WriteLine("Массив пустой");
            }
        }
        static void DeleteEven(ref int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                {
                    count++;
                }
            }

            int[] newArr = new int[count];
            int index = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                {
                    newArr[index++] = arr[i];
                }
            }
            arr = newArr;
        }
        static void AddString(ref int[,] arr)
        {
            int k, n;
            ReadElem(out k, 1);
            ReadElem(out n, 4);
            bool IsCheck = false;
            while (!IsCheck)
            {
                if (n > arr.GetLength(0))
                {
                    Console.WriteLine("Номер больше количества строк в массиве");
                    ReadElem(out k, 1);
                    ReadElem(out n, 4);
                }
                else
                {
                    IsCheck = true;
                }
            }
            int[,] tempArr = new int[arr.GetLength(0)+k, arr.GetLength(1)];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (i < (n-1)) { 
                        tempArr[i, j] = arr[i, j];
                    }
                    else
                    {
                        tempArr[i+k, j] = arr[i, j];
                    }

                }
            }
            arr = tempArr;
        }
        static void AddString(ref int[][] arr, ref int m)
        {
            int k = ReadElem(out k, 1);
            int[][] tempArr = new int[m + k][];
            for (int i = 0; i < m; i++)
            {
                tempArr[i] = new int[arr[i].Length];
                for (int j = 0; j < arr[i].Length; j++)
                {
                    tempArr[i][j] = arr[i][j];
                }
            }
            for (int i = 0; i < k; i++)
            {
                int newLength = ReadElem(out newLength, 0);
                tempArr[m + i] = new int[newLength];
                for (int j = 0; j < newLength; j++)
                {
                    tempArr[m + i][j] = 0;
                }
            }
            arr = tempArr;
            m += k;
        }
        static void ProcessArray<T>(T arr, int choiceForFill)
        {
            Console.WriteLine("Выберите тип ввода данных: 1 - вручную, 2 - автоматически");
            choiceForFill = ReadElem(out choiceForFill, 3);
            switch (choiceForFill)
            {
                case 1:
                    FillArr((dynamic)arr);
                    break;
                case 2:
                    FillArrRnd((dynamic)arr);
                    break;
                default:
                    break;
            }
            ShowArr((dynamic)arr);

        }
        static void Switch()
        {
            int m, n, choice;

            bool isFinal = false;
            int choiceForFill = 0;
            while (!isFinal)
            {
                Console.WriteLine("1 - Динамический массив, 2 - Двумерный динамический массив, 3 - Рваный массив, 4 - Выход");
                ReadElem(out choice, 3);
                choiceForFill = 0;
                switch (choice)
                {
                    case 1:
                        ReadElem(out n, 0);
                        int[] arr = new int[n];
                        ProcessArray<int[]>(arr, choiceForFill);
                        DeleteEven(ref arr);
                        Console.WriteLine("Произошло удаление четных");
                        ShowArr(arr);

                        bool continueWork = true;
                        while (continueWork)
                        {
                            Console.WriteLine("Хотите ли вы продолжить работу с данным массивом? 1 - Да, Любая цифра - Нет");
                            choiceForFill = ReadElem(out choice, 3);
                            if (choice == 1)
                            {
                                DeleteEven(ref arr);
                                Console.WriteLine("Произошло удаление четных");
                                ShowArr(arr);
                            }
                            else
                            {
                                continueWork = false;
                            }
                        }
                        break;
                    case 2:
                        ReadElem(out n, 5);
                        ReadElem(out m, 1);
                        int[,] arr2 = new int[m, n];
                        ProcessArray<int[,]>(arr2, choiceForFill);
                        AddString(ref arr2);
                        ShowArr(arr2);
                        continueWork = true;
                        while (continueWork)
                        {
                            Console.WriteLine("Хотите ли вы продолжить работу с данным массивом? 1 - Да, Любая цифра - Нет");
                            choiceForFill = ReadElem(out choice, 3);
                            if (choice == 1)
                            {
                                AddString(ref arr2);
                                Console.WriteLine("Добавление строк");
                                ShowArr(arr2);
                            }
                            else
                            {
                                continueWork = false;
                            }
                        }
                        break;
                    case 3:
                        ReadElem(out m, 1);
                        int[][] arr3 = new int[m][];
                        ProcessArray<int[][]>(arr3, choiceForFill);
                        AddString(ref arr3, ref m);
                        ShowArr(arr3);
                        continueWork = true;
                        while (continueWork)
                        {
                            Console.WriteLine("Хотите ли вы продолжить работу с данным массивом? 1 - Да, Любая цифра - Нет");
                            choiceForFill = ReadElem(out choice, 3);
                            if (choice == 1)
                            {
                                AddString(ref arr3, ref m);
                                Console.WriteLine("Добавление строк");
                                ShowArr(arr3);
                            }
                            else
                            {
                                continueWork = false;
                            }
                        }
                        break;
                    case 4:
                        isFinal = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
            Console.WriteLine("Вы вышли из программы.");
        }
        static void Main(string[] args)
        {
            Switch();
        }
    }
}
