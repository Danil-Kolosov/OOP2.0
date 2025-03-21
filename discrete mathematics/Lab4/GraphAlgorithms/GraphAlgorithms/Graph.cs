using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphConnectivityMatrix
{
    internal class Graph
    {
        static int[,] adjaencyMatrix;
        static string points = "abcdefghij";
        static int currentNumber = 1;

        public static void DisplayAllSavedMatrix()
        {
            string filePath = @"..\..\..\Matrices\matrixNumber.txt";
            int number;
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Считываем строки из файла
                string[] lines = File.ReadAllLines(filePath);
                number = int.Parse(lines[0]);
                reader.Close();
            }
            for (int k = 1; k <= number; k++)
            {
                int[,] matrix = GetSavedMatrix(k);
                Console.WriteLine($"Матрица смежности {k}:");
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        public static void InputMatrix(int size)
        {
            if (size < 0 || size > 10)
            {
                Console.WriteLine();
                return;
            }

            int[,] matrix = new int[size, size];

            Console.WriteLine("Введите элементы матрицы:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    External_Interactions.Input(ref matrix[i, j], 0, 10000, $"Введите элемент [{i + 1}][{j + 1}]: ");
                }
            }

            Console.WriteLine("Введенная матрица:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            adjaencyMatrix = matrix;
            currentNumber = 0;
        }

        public static void SaveMatrix()
        {
            if (adjaencyMatrix == null)
            {
                Console.WriteLine("Еще не выбрана ни одна матрица смежности");
                return;
            }
            if (currentNumber == 0)
            {
                string path = @"..\..\..\Matrices\matrixNumber.txt";
                int number;
                using (StreamReader reader = new StreamReader(path))
                {
                    string[] lines = File.ReadAllLines(path);
                    number = int.Parse(lines[0]);
                    reader.Close();
                }
                number++;
                File.WriteAllText(path, number.ToString());
                currentNumber = number;
            }


            //int[,] matrix = {
            //    {0, 1, 0 },
            //    { 0, 0, 1},
            //    { 1, 0, 0}
            ////{ 0, 0, 0, 1 ,0, 1, 0},
            ////{ 0, 0, 0, 0, 1, 0, 1},
            ////{ 0, 1, 0, 0, 0, 1, 0},
            ////{ 1, 0, 1, 0, 1, 0, 0},
            ////{ 0, 0, 0, 0, 0, 0, 1},
            ////{ 0, 0, 1, 0, 0, 1, 1},
            ////{ 0, 0, 0, 0, 1, 0, 0}
            //};

            int[,] matrix = adjaencyMatrix;
            string filePath = $@"..\..\..\Matrices\matrix{currentNumber}.txt";

            // Записываем матрицу в файл
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                int rows = matrix.GetLength(0); // Количество строк
                int cols = matrix.GetLength(1); // Количество столбцов

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        writer.Write(matrix[i, j]);

                        if (j < cols - 1)
                        {
                            writer.Write(" ");
                        }
                    }
                    writer.WriteLine();
                }
            }

            Console.WriteLine("Матрица успешно записана в файл.");
        }

        private static int[,] GetSavedMatrix(int number)
        {
            string filePath = $@"..\..\..\Matrices\matrix{number}.txt";

            // Считываем данные из файла и определяем размер матрицы
            int[,] matrix;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                int rows = lines.Length;
                int cols = lines[0].Split(' ').Length;

                matrix = new int[rows, cols];

                // Заполняем матрицу данными из файла
                for (int i = 0; i < rows; i++)
                {
                    string[] values = lines[i].Split(' ');
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i, j] = int.Parse(values[j]);
                    }
                }
                reader.Close();
                return matrix;
            }
        }

        public static void ChooseMatrix(int number)
        {
            string[] lines = File.ReadAllLines(@"..\..\..\Matrices\matrixNumber.txt");
            int numberMax = int.Parse(lines[0]);
            if (number > numberMax)
            {
                Console.WriteLine("Введены не корректные данные, повторите");
                return;
            }

            currentNumber = number;
            adjaencyMatrix = GetSavedMatrix(number);
            Console.WriteLine("Загруженная матрица:");
            for (int i = 0; i < adjaencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adjaencyMatrix.GetLength(1); j++)
                {
                    Console.Write(adjaencyMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }


        /// <summary>
        /// Шимбелл
        /// </summary>
        public static string Shimbell()
        {
            if (adjaencyMatrix == null)
            {
                return "Еще не выбрана ни одна матрица смежности";
            }

            int minOrMax = 0;
            External_Interactions.Input(ref minOrMax, 1, 3, "1. Искать минимальные пути\n2. Искать максимальные пути\n3. Назад");
            if (minOrMax == 3)
                return "Возвращаемся в главное меню";

            int size = adjaencyMatrix.GetLength(1);
            int degree = 0;
            External_Interactions.Input(ref degree, 1, size * size, "Пути, состоящие из скольки ребер будут учитываться:");
            string result = "";
            int[,] resultMatrix = new int[0, 0];
            if (minOrMax == 1)
            {
                resultMatrix = ShimbellPowMatrix(adjaencyMatrix, degree);
                result += $"Кратчайшие пути длиной из {degree} ";
            }
            else
            {
                resultMatrix = ShimbellPowMatrix(adjaencyMatrix, degree, false);
                result += $"Максимальные пути длиной из {degree} ";
            }
            if (degree == 1)
                result += "ребра";
            else
                result += "ребер";
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result += $"\n{points[i]} : {points[j]} = {resultMatrix[i, j]}";
                    //if (resultMatrix[i, j]==0)
                    //    result += $"\n{points[i]} : {points[j]} = Недостижима";
                    //else
                    //    result += $"\n{points[i]} : {points[j]} = {resultMatrix[i, j]}";
                }
                result += "\n";
            }
            return result;
            //строку сформировать на  основе полученной матрицы шимбела и вывести - кратчайший/максимальный путь длиной n ребра 
            //    из а в а равен тото
            //    из а в б равен тото

        }

        private static int ShimbellMultiply(int a, int b)
        {
            if (a == 0 || b == 0)
                return 0;
            return a + b;
        }

        private static int ShimbellSum(int a, int b, Func<int, int, int> maxOrMin)
        {
            if (a == 0 & b == 0)
                return 0;
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            return maxOrMin(a, b);
        }

        private static int[,] ShimbellMultiplyMatrices(int[,] m1, int[,] m2, bool maxOrMin)
        {
            int[,] result = (int[,])m1.Clone();
            int n = m1.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int boxResult = 0;
                    for (int k = 0; k < n; k++)
                    {
                        if (maxOrMin)
                            boxResult = ShimbellSum(boxResult, ShimbellMultiply(m1[i, k], m2[k, j]), (a, b) => (a < b) ? a : b);
                        else
                            boxResult = ShimbellSum(boxResult, ShimbellMultiply(m1[i, k], m2[k, j]), (a, b) => (a > b) ? a : b);
                    }
                    result[i, j] = boxResult;
                }
            }
            return result;
        }

        private static int[,] ShimbellPowMatrix(int[,] m, int degree, bool maxOrMin = true)
        {
            int[,] result = (int[,])m.Clone();
            for (int i = 1; i < degree; i++)
            {
                result = ShimbellMultiplyMatrices(result, m, maxOrMin);
            }
            return result;
        }


        /// <summary>
        /// Яростно параллельная форма
        /// </summary>
        public static string GetTiers()
        {
            if (adjaencyMatrix == null)
            {
                return "Еще не выбрана ни одна матрица смежности";
            }
            int[,] tempMatrix = new int[adjaencyMatrix.GetLength(0), adjaencyMatrix.GetLength(1)];
            Array.Copy(adjaencyMatrix, tempMatrix, adjaencyMatrix.Length);

            string result = "";
            int numberOfTops = 0;
            int k = 1;

            while (numberOfTops < adjaencyMatrix.GetLength(1))
            {
                List<int> tempResult = GetAngryComponent(tempMatrix);
                numberOfTops += tempResult.Count;
                result += $"{k}-ый ярус:";
                k++;
                for (int i = 0; i < tempResult.Count; i++)
                {
                    result += $" {points[tempResult[i]]}";
                }
                result += "\n";
            }
            return result;
        }

        private static void DeleteRow(int number, int[,] m)
        {
            int n = m.GetLength(1);
            for (int i = 0; i < n; i++)
                m[number, i] = 0;
        }

        private static List<int> GetAngryComponent(int[,] matrix)
        {
            List<int> result = new List<int>();
            int n = matrix.GetLength(1);

            for (int j = 0; j < n; j++)
            {
                bool isColAngry = true;
                for (int i = 0; i < n && isColAngry; i++)
                {
                    if (matrix[i, j] > 0)
                        isColAngry = false;
                }
                if (isColAngry)
                    result.Add(j);
            }

            for (int i = 0; i < result.Count; i++)
            {
                DeleteRow(result[i], matrix);
                matrix[result[i], result[i]] = 1;
            }

            return result;
        }


        /// <summary>
        /// Клика
        /// </summary>
        private static List<string> GetFirstEquation(int[,] matrix)
        {
            List<string> listResult = new List<string>();
            int n = matrix.GetLength(1);
            for (int i = 0; i < n - 1; i++)
            {
                string result = "";
                result += $"{points[i]}";
                int step = 0;
                for (int j = i + 1; j < n; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        if (step < 1)
                        {
                            result += $" V {points[j]}";
                            step = 1;
                        }
                        else
                            result += $"{points[j]}";
                    }
                }
                listResult.Add(result);
            }
            return listResult;
        }

        private static string DMultiply(string a, string b, ref HashSet<string> seen)
        {
            string[] aList = a.Replace(" ", "").Split('V');
            string[] bList = b.Replace(" ", "").Split('V');



            string result = "";
            for (int i = 0; i < aList.Length; i++)
                for (int j = 0; j < bList.Length; j++)
                {
                    bool isAdd = true;
                    if (bList[j].Contains(aList[i]))
                    {
                        isAdd = seen.Add(bList[j]);
                        if (isAdd)
                            result += bList[j];
                    }
                    else
                    {
                        if (aList[i].Contains(bList[j]))//if (aList[j].Contains(bList[i]))
                        {
                            isAdd = seen.Add(aList[i]);
                            if (isAdd)
                                result += aList[i];
                        }
                        else
                        {
                            string tempRes = aList[i] + bList[j];
                            List<char> temp = tempRes.ToList();
                            temp = temp.Distinct().ToList();
                            temp.Sort();
                            tempRes = String.Join("", temp);
                            //distinc c массивом только - temp.Dictinct() надо
                            //tempRes.Distinct();
                            isAdd = seen.Add(tempRes);
                            if (isAdd/*!bigRes.Contains(tempRes)*/)
                            {
                                result += tempRes;                               
                            }
                        }
                    }
                    if (isAdd)
                    {
                        if (i + 1 != aList.Length)
                            result += " V ";
                        else
                        if (j + 1 != bList.Length)
                            result += " V ";
                    }
                }
            if (result[result.Length - 2] == 'V')
                result = result.Substring(0, result.Length - 3);
            return result;
        }

        private static List<string> DiscrethMultiplyEach(List<string> list)
        {
            List<string> listResult = new List<string>();
            HashSet<string> seen = new HashSet<string>();

            for (int i = 0; i < list.Count; i++)
            {
                if (i + 1 < list.Count)
                {
                    listResult.Add(DMultiply(list[i], list[i + 1], ref seen/*String.Join("", listResult)*/));
                    i++;
                }

                else
                    listResult.Add(list[i]);
            }


            return listResult;
        }      

        private static string Absorption(string str)
        {
            string result = "";
            HashSet<string> seen = new HashSet<string>();
            string[] list = str.Replace(" ", "").Split('V');
            int n = list.Length;
            bool isAdd;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    isAdd = false;
                    if (list[i] == "*")
                    {
                        j = n;
                    }
                    else
                    {
                        if (list[j] == "*")
                            j++;
                        else
                        {
                            int bukCounter = 0;
                            foreach (char buk in list[i])
                            {
                                if (list[j].Contains(buk))
                                    bukCounter++;
                            }
                            if (bukCounter == list[i].Length)
                            {
                                isAdd = seen.Add(list[i]);
                                list[j] = "*";
                                if (isAdd)
                                    result += list[i];
                            }
                            else
                            {
                                bukCounter = 0;
                                foreach (char buk in list[j])
                                {
                                    if (list[i].Contains(buk))
                                        bukCounter++;
                                }
                                if (bukCounter == list[j].Length)
                                {
                                    isAdd = seen.Add(list[j]);
                                    if (isAdd)
                                        result += list[j];
                                    list[i] = "*";
                                    j = n;
                                }
                                else
                                {
                                    if (j + 1 == n)
                                    {
                                        isAdd = seen.Add(list[i]);
                                        if (isAdd)
                                            result += list[i];
                                    }
                                }
                            }
                            if (isAdd)
                            {
                                if (i + 1 != list.Length)
                                    result += " V ";
                                else
                                if (j + 1 != list.Length)
                                    result += " V ";
                            }
                        }
                    }
                }
            }
            if (list[n - 1] != "*")
                result += list[n - 1];
            if (result[result.Length - 2] == 'V')
                result = result.Substring(0, result.Length - 3);
            return result;
        }

        public static string GetClique()
        {
            if (adjaencyMatrix == null)
            {
                return "Еще не выбрана ни одна матрица смежности";
            }

            List<string> resultList = GetFirstEquation(adjaencyMatrix);

            while (resultList.Count != 1)
                resultList = DiscrethMultiplyEach(resultList);
            resultList[0] = Absorption(resultList[0]);

            return GetCliquePoints(resultList[0]);
        }

        private static string GetCliquePoints(string str)
        {
            string result = "";
            string[] list = str.Replace(" ", "").Split('V');
            int n = list.Length;
            for (int i = 0; i < n; i++)
            {
                result += $"Клика {i + 1} : ";
                result += FindMissingPoints(list[i]);
                result += "\n";
            }
            return result;
        }

        private static string FindMissingPoints(string str)
        {
            int n = adjaencyMatrix.GetLength(1);
            string result = "";
            bool isNotFirst = false;
            for (int i = 0; i < n; i++)
            {
                if (!str.Contains(points[i]))
                {
                    if (isNotFirst)
                        result += $", {points[i]}";
                    else
                    {
                        result += $"{points[i]}";
                        isNotFirst = true;
                    }
                }
            }
            return result;
        }      
    }
}
