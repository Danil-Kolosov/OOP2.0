﻿using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class main
    {
        //private static int [] oneDimensionArray;
        //private static int[,] twoDimensionArray;

        //static bool programmRuningKey = true;
        //static int currentArrayListIndex = 0;
        static void Main()
        {
            bool programmRuningKey = true;
            do
            {
                OutInformation("1. Работа с одномерными массивами");
                OutInformation("2. Работа с двумерными массивами");
                OutInformation("3. Работа с рваными массивами");
                OutInformation("4. Выход");
                int commandID = 0;
                InputData(ref commandID);
                switch (commandID)
                {
                    case 1:
                        WorkingOneDimensionalArray();
                        break;
                    case 2:
                        WorkingTwoDimensionalArray();
                        break;
                    case 3:
                        WorkingRaggedArray();
                        break;
                    case 4:
                        Exit(ref programmRuningKey);
                        break;
                    default:
                        //ReportIncorrectData(); это наверное не надо тогда
                        OutInformation("Введены не корректные данные");
                        //Main();
                        break;
                }
            } while (programmRuningKey);
            //if (programmRuningKey)
            //    Main();
        }

        static void Exit(ref bool programmRuningKey)
        {
            programmRuningKey = false;
        }

        static void InputData(ref int data, int minValue = -100000, int maxValue = 100000, string introductoryMessage = "")
        {
            if (introductoryMessage != "")
            {
                OutInformation(introductoryMessage);
            }
            if (!(int.TryParse((Console.ReadLine()), out data)) || data < minValue || data > maxValue) //|| (data<0) || (data > 1000)
            {
                //OutInformation();
                InputData(ref data, minValue, maxValue, "Введены не корректные данные, повторите");
            }
        }

        static void OutInformation(string information)
        {
            Console.WriteLine(information);
            //if (information == "Введены не корректные данные" || information == "Ещё не создано ни одного массива")
            //{
            //    Console.WriteLine(information);
            //    OutInformation("Нажмите Enter для продолжения");
            //    Console.ReadLine();
            //    Console.Clear();
            //}
            //else
            //    if (information == "clear")
            //    {
            //        Console.ReadLine();
            //    Console.Clear();
            //}
            //    else
            //        Console.WriteLine(information);
        }

        static void WorkingOneDimensionalArray()
        {
            int[] oneDimensionArray = null;
            ManageWorkingOneDimensionalArray(ref oneDimensionArray);

        }

        static void ManageWorkingOneDimensionalArray(ref int[] oneDimensionArray)
        {
            bool programmRuningKey = true;
            do
            {
                OutInformation("1. Создать массив");
                OutInformation("2. Напечатать массив");
                OutInformation("3. Добавить К элементов в начало массива");
                OutInformation("4. Назад");
                int commandID = 0;
                InputData(ref commandID);
                switch (commandID)
                {
                    case 1:
                        CreateArray(ref oneDimensionArray);
                        //ManageWorkingOneDimensionalArray(ref oneDimensionArray);
                        break;
                    case 2:
                        PrintArray(oneDimensionArray);
                        //ManageWorkingOneDimensionalArray(ref oneDimensionArray);
                        break;
                    case 3:
                        AddElementsFront(ref oneDimensionArray);
                        //ManageWorkingOneDimensionalArray(ref oneDimensionArray);
                        break;
                    case 4:
                        Exit(ref programmRuningKey);//* goBack
                        break;
                    default:
                        //ReportIncorrectData(); это наверное не надо тогда
                        OutInformation("Введены не корректные данные");
                        //Console.Clear();
                        //ManageWorkingOneDimensionalArray(ref oneDimensionArray);
                        break;
                }
            } while (programmRuningKey);

        }

        static void CreateArray(ref int[] array)
        {
            bool programmRuningKey = true;
            do
            {
                OutInformation("1. Создать массив вручную");
                OutInformation("2. Создать массив с помощью датчика случайных чисел");
                OutInformation("3. Назад");
                int commandID = 0;
                InputData(ref commandID);
                switch (commandID)
                {
                    case 1:
                        HandMadeArray(ref array);
                        break;
                    case 2:
                        AutoMadeArray(ref array);
                        break;
                    case 3:
                        Exit(ref programmRuningKey);
                        //ManageWorkingOneDimensionalArray(ref array); //назад вернуться
                        break;
                    default:
                        OutInformation("Введены не корректные данные");
                        //Console.Clear();
                        //CreateArray(ref array);
                        break;
                }
                Exit(ref programmRuningKey);
            } while (programmRuningKey);
        }

        static void HandMadeArray(ref int[] arr)
        {
            //arr = null;
            int arraySize = 0;
            OutInformation("Введите (не отрицательное) количество элементов:");
            InputData(ref arraySize, 0);
            arr = new int[arraySize];
            FullArray(ref arr, arraySize);


            //linkListArrays[currentArrayListIndex++] = arr;
            //for (int i = 0; i < arraySize; i++)
            //{
            //    Console.WriteLine(linkListArrays[0][i]);   работате
            //}
        }

        static void FullArray(ref int[] arr, int arraySize, string command = "hand")
        {
            if (command == "hand")
            {
                int element = 010;
                for (int i = 0; i < arraySize; i++)
                {
                    OutInformation("Введите элемент");
                    InputData(ref element);
                    arr[i] = element;
                }
            }
            else
            {
                var rand = new Random();
                for (int i = 0; i < arraySize; i++)
                {
                    arr[i] = rand.Next(50, 101);
                }
            }
        }
        static void AutoMadeArray(ref int[] arr)
        {
            int arraySize = 0;
            OutInformation("Введите (не отрицательное) количество элементов:");
            InputData(ref arraySize, 0);
            arr = new int[arraySize];
            FullArray(ref arr, arraySize, "auto");
            //linkListArrays[currentArrayListIndex++] = arr;
            //for (int i = 0; i < arraySize; i++)
            //{
            //    Console.WriteLine(linkListArrays[currentArrayListIndex-1][i]);
            //}
            //InputData(ref arraySize, 0);
        }

        static void PrintArray(int[] arr)
        {
            if (arr == null)
                OutInformation("Ещё не создано ни одного массива");
            else
            {
                if(arr.Length == 0)
                    OutInformation("Массив пустой");
                else
                {   
                    string str = arr[0].ToString();
                    for (int i = 1; i < arr.Length; i++)
                    {
                        str += " " + arr[i];
                    }
                    OutInformation(str);
                }
            }
        }
        static void PrintArray(int[][] arr)
        {
            if (arr == null)
                OutInformation("Ещё не создано ни одного массива");
            else
            {
                if (arr.GetLength(0) == 0)
                    OutInformation("Массив пустой");
                else
                    {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        string str = arr[i][0].ToString();
                        for (int j = 1; j < arr[i].Length; j++)
                        {
                            str += " " + arr[i][j];
                        }
                        OutInformation(str);
                    }
                    }
            }
        }
        static void AddElementsFront(ref int[] arr)
        {
            if (arr == null)
                OutInformation("Ещё не создано ни одного массива");
            else
            {
                OutInformation("\n1. Вводить элементы вручную");
                OutInformation("2. Ввести элементы с помощью датчика случайных чисел");
                OutInformation("3. Назад");
                int[] oldArr = null;
                if (arr != null)
                {
                   oldArr = new int[arr.Length];
                   arr.CopyTo(oldArr, 0);
                }
                int commandID = 0;
                InputData(ref commandID);
                switch (commandID)
                {
                    case 1:
                        OutInformation("Введённый первым элемент будет первый в массиве");
                        HandMadeArray(ref arr);
                        //MergeArrays(ref oneDimensionArray, ref arr);
                        break;
                    case 2:
                        AutoMadeArray(ref arr);
                        //MergeArrays(ref oneDimensionArray, ref arr);
                        break;
                    case 3:
                        ManageWorkingOneDimensionalArray(ref arr); //назад вернуться
                        break;
                    default:
                        OutInformation("Введены не корректные данные");
                        //Console.Clear();
                        AddElementsFront(ref arr);
                        break;
                }
                MergeArrays(arr, oldArr, out arr);
            }
        }
        static void MergeArrays(int[] arr1, int[] arr2, out int[] arr3)
        {
            int[] arr = new int[arr1.Length + arr2.Length];
            for (int i = 0; i < arr1.Length; i++)
            {
                arr[i] = arr1[i];
            }
            for (int i = arr1.Length, j = 0; i < arr.Length && j < arr2.Length; i++, j++)
            {
                arr[i] = arr2[j];
            }
            arr3 = arr;
        }
        static void WorkingTwoDimensionalArray()
        {
            int[,] twoDimensionArray = null;
            ManageWorkingTwoDimensionalArray(ref twoDimensionArray);
        }

        static void ManageWorkingTwoDimensionalArray(ref int[,] twoDimensionArray)
        {
            OutInformation("1. Создать массив");
            OutInformation("2. Напечатать массив");
            OutInformation("3. Удалить строки, начиная со строки К1 и до строки К2 включительно");
            OutInformation("4. Назад");
            int commandID = 0;
            InputData(ref commandID);
            switch (commandID)
            {
                case 1:
                    CreateArray(ref twoDimensionArray);
                    ManageWorkingTwoDimensionalArray(ref twoDimensionArray);
                    break;
                case 2:
                    PrintArray(twoDimensionArray);
                    ManageWorkingTwoDimensionalArray(ref twoDimensionArray);
                    break;
                case 3:
                    DeleteRows(ref twoDimensionArray);
                    ManageWorkingTwoDimensionalArray(ref twoDimensionArray);
                    break;
                case 4:
                    Main();//* goBack
                    break;
                default:
                    OutInformation("Введены не корректные данные");
                    //Console.Clear();
                    ManageWorkingTwoDimensionalArray(ref twoDimensionArray);
                    break;
            }
        }

        static void CreateArray(ref int[,] array)
        {
            OutInformation("1. Создать массив вручную");
            OutInformation("2. Создать массив с помощью датчика случайных чисел");
            OutInformation("3. Назад");
            int commandID = 0;
            InputData(ref commandID);
            switch (commandID)
            {
                case 1:
                    HandMadeArray(ref array);
                    break;
                case 2:
                    AutoMadeArray(ref array);
                    break;
                case 3:
                    ManageWorkingTwoDimensionalArray(ref array); //назад вернуться
                    break;
                default:
                    OutInformation("Введены не корректные данные");
                    //Console.Clear();
                    CreateArray(ref array);
                    break;
            }
        }

        static void HandMadeArray(ref int[,] arr)
        {
            int arrayStrSize = 0;
            int arrayColSize = 0;
            OutInformation("Введите (не отрицательное) количество строк:");
            if (arrayStrSize != 0)
            {
                OutInformation("Введите (не отрицательное) количество столбцов:");
                InputData(ref arrayColSize, 0);
            }
            InputData(ref arrayColSize, 0);
            arr = new int[arrayStrSize, arrayColSize];
            FullArray(ref arr, arrayStrSize, arrayColSize);
        }

        static void FullArray(ref int[,] arr, int arrayStrSize, int arrayColSize, string command = "hand")
        {
            if (command == "hand")
            {
                int element = 010;
                for (int i = 0; i < arrayStrSize; i++)
                {
                    for (int j = 0; j < arrayColSize; j++)
                    {
                        OutInformation("Введите элемент массива");
                        InputData(ref element);
                        arr[i, j] = element;
                    }
                }
            }
            else
            {
                var rand = new Random();
                for (int i = 0; i < arrayStrSize; i++)
                {
                    for (int j = 0; j < arrayColSize; j++)
                    {
                        arr[i, j] = rand.Next(-101, 101);
                    }
                }
            }
        }

        static void AutoMadeArray(ref int[,] arr)
        {
            int arrayStrSize = 0;
            int arrayColSize = 0;
            OutInformation("Введите (не отрицательное) количество строк:");
            InputData(ref arrayStrSize, 0);
            if(arrayStrSize != 0)
            {
                OutInformation("Введите (не отрицательное) количество столбцов:");
                InputData(ref arrayColSize, 0);
            }
            arr = new int[arrayStrSize, arrayColSize];
            FullArray(ref arr, arrayStrSize, arrayColSize, "auto");
        }

        static void PrintArray(int[,] arr)
        {
            if (arr == null)
                OutInformation("Ещё не создано ни одного массива");
            else
            {
                if (arr.Length == 0)
                    OutInformation("Массив пустой");
                else
                {
                    for (int i = 0; i < arr.GetLength(0); i++)
                    {
                        string str = arr[i, 0].ToString();
                        for (int j = 1; j < arr.GetLength(1); j++)
                        {
                            str += " " + arr[i, j];
                        }
                        OutInformation(str);
                    }
                }
            }
        }

        static void DeleteRows(ref int[,] twoDimensionArray)
        {
            if (twoDimensionArray == null)
                OutInformation("Ещё не создано ни одного массива");
            else
            {
                if (twoDimensionArray.Length == 0)
                    OutInformation("Из пустого массива удалить ничего нельзя");
                else
                    {
                        int strNumber1 = 0;
                        int strNumber2 = 0;
                        OutInformation("Введите номер строки К1");
                        InputData(ref strNumber1, 1, twoDimensionArray.GetLength(0));
                        OutInformation("Введите номер строки К2");
                        InputData(ref strNumber2, strNumber1, twoDimensionArray.GetLength(0));
                        strNumber1 -= 1;
                        strNumber2 -= 1;
                        DeletingRows(ref twoDimensionArray, strNumber1, strNumber2);
                    }
            }
        }

        static void DeletingRows(ref int[,] twoDimensionArray, int strNumber1, int strNumber2)
        {
            int[,] arr = new int[twoDimensionArray.GetLength(0) - (strNumber2 - strNumber1 + 1), twoDimensionArray.GetLength(1)];
            int newArrayIteratorStr = 0;
            for (int i = 0; i < twoDimensionArray.GetLength(0); i++)
            {
                for (int j = 0; j < twoDimensionArray.GetLength(1); j++)
                {
                    if (i > strNumber2 || i < strNumber1)
                    {
                        arr[newArrayIteratorStr, j] = twoDimensionArray[i, j];
                        if (j + 1 == twoDimensionArray.GetLength(1))
                        {
                            newArrayIteratorStr++;
                        }
                    }
                }
            }
            twoDimensionArray = arr;
        }

        static void WorkingRaggedArray() 
        {
            int[][] raggedArray = null;
            ManageWorkingRaggedArray(ref raggedArray);
        }

        static void ManageWorkingRaggedArray(ref int [][] raggedArray)
        {
            OutInformation("1. Создать массив");
            OutInformation("2. Напечатать массив");
            OutInformation("3. Добавить строку с заданным номером");
            OutInformation("4. Назад");
            int commandID = 0;
            InputData(ref commandID);
            switch (commandID)
            {
                case 1:
                    CreateArray(ref raggedArray);
                    ManageWorkingRaggedArray(ref raggedArray);
                    break;
                case 2:
                    PrintArray(raggedArray);
                    ManageWorkingRaggedArray(ref raggedArray);
                    break;
                case 3:
                    AddString(ref raggedArray);
                    ManageWorkingRaggedArray(ref raggedArray);
                    break;
                case 4:
                    Main();
                    break;
                default:
                    OutInformation("Введены не корректные данные");
                    ManageWorkingRaggedArray(ref raggedArray);
                    break;
            }
        }

        static void CreateArray(ref int[][] array)
        {
            OutInformation("1. Создать массив вручную");
            OutInformation("2. Создать массив с помощью датчика случайных чисел");
            OutInformation("3. Назад");
            int commandID = 0;
            InputData(ref commandID);
            switch (commandID)
            {
                case 1:
                    HandMadeArray(ref array);
                    break;
                case 2:
                    AutoMadeArray(ref array);
                    break;
                case 3:
                    ManageWorkingRaggedArray(ref array);
                    break;
                default:
                    OutInformation("Введены не корректные данные");
                    CreateArray(ref array);
                    break;
            }
        }

        static void HandMadeArray(ref int[][] arr)
        {
            int arrayRowsNumber = 0;
            OutInformation("Введите (не отрицательное) количество строк:");
            InputData(ref arrayRowsNumber, 0);
            arr = new int[arrayRowsNumber][];
            FullArray(ref arr, arrayRowsNumber); // тут спрашивать колличество элементов в строке ещё
        }

        static void FullArray(ref int[][] arr, int arrayRowsNumber, string command = "hand")//не доделано
        {
            if (command == "hand")
            {
                int element = 0;
                int rowElementsNumber = 0;
                for (int i = 0; i < arrayRowsNumber; i++)
                {
                    OutInformation($"Введите количество элементов в {i+1} строке массива");
                    InputData(ref rowElementsNumber);
                    arr[i] = new int[rowElementsNumber];
                    for (int j = 0;j < rowElementsNumber; j++)
                    {
                        OutInformation("Введите элемент");
                        InputData(ref element);
                        arr[i][j] = element; 
                    }
                }
            }
            else
            {
                var rand = new Random();
                int element = 0;
                int rowElementsNumber = 0;
                for (int i = 0; i < arrayRowsNumber; i++)
                {
                    OutInformation($"Введите количество элементов в {i + 1} строке массива");
                    InputData(ref rowElementsNumber, 1, 100);
                    arr[i] = new int[rowElementsNumber];
                    for (int j = 0; j < rowElementsNumber; j++)
                    {
                        element = rand.Next(-101, 101);
                        arr[i][j] = element;
                    }
                }
            }
        }

        static void AutoMadeArray(ref int[][] arr)
        {
            int arrayRowSize = 0;
            OutInformation("Введите (не отрицательное) количество строк:");
            InputData(ref arrayRowSize, 0);           
            arr = new int[arrayRowSize][];
            FullArray(ref arr, arrayRowSize, "auto");
        }

        static void AddString(ref int[][] raggedArray)
        {
            if (raggedArray == null)
                OutInformation("Ещё не создано ни одного массива");
            else
            {
                int rowNumber = 0;
                int rowsIterator = 0;
                OutInformation("Введите (не отрицательный) номер строки:");
                InputData(ref rowNumber, 1, raggedArray.GetLength(0) + 1);
                int[][] newArr = new int[raggedArray.GetLength(0) + 1][];
                for (int i = 0; i < newArr.GetLength(0) && rowsIterator < newArr.GetLength(0); i++, rowsIterator++)
                {
                    int[] littleArr = null;
                    if ( rowsIterator == ((rowNumber - 1))) //rowsIterator + 1 == (rowNumber - 1) ||
                    {
                        HandMadeArray(ref littleArr);
                        newArr[rowsIterator] = littleArr;
                        //if(i+1 ==)
                        i -= ((rowNumber) - rowsIterator);
                    }
                    else
                    {
                        littleArr = new int[raggedArray[i].GetLength(0)];
                        int littleArrSize = raggedArray[i].GetLength(0);
                        for (int j = 0; j < littleArrSize; j++)
                        {
                            if (j == 0)
                                newArr[rowsIterator] = littleArr;
                            newArr[rowsIterator][j] = raggedArray[i][j];
                        }
                    }
                    
                }
                raggedArray = newArr;
            }
        }
    }
}