using System;
using System.Collections.Generic;
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
                    External_Interactions.Input(ref matrix[i, j], 0, 1, $"Введите элемент [{i + 1}][{j + 1}]: ");
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
        /// ////////////////////////////////////////////////////////опа
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns>инт</returns>
        /// 
        private static void DeleteRow(int number, int[,] m)
        {
            int n = m.GetLength(1);
            for (int i = 0; i < n; i++)
                m[number, i] = 0;
        }

        private static List<int> GetAngryComponent(int[,] matrix)// сделать гет ярусть
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

        public static string GetTiers()
        {
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
                for (int i=0;i< tempResult.Count; i++) 
                {
                    result += $" {points[tempResult[i]]}";
                }
                result += "\n";
            }
            return result;
        }

        private static int[,] Sum(int[,] m1, int[,] m2)//не надо
        {
            for (int i = 0; i < m1.GetLength(1); i++)
            {
                for (int j = 0; j < m1.GetLength(1); j++)
                {
                    if (m1[i, j] + m2[i, j] > 0)
                        m1[i, j] = 1;
                }
            }
            return m1;
        }

        private static int[,] Transpose(int[,] m)// не надо
        {
            int[,] transponseM = (int[,])m.Clone();

            for (int i = 0, it = 0; i < transponseM.GetLength(1); i++, it++)
            {
                for (int j = 0, jt = 0; j < transponseM.GetLength(1); j++, jt++)
                {
                    transponseM[jt, it] = m[i, j];
                }
            }
            return transponseM;
        }

        private static void LogicAnd(ref int[,] m1, int[,] m2)// не надо в таком виде но переделать
        {
            for (int i = 0; i < m1.GetLength(1); i++)
            {
                for (int j = 0; j < m1.GetLength(1); j++)
                {
                    m1[i, j] = m1[i, j] & m2[i, j];
                }
            }
        }

        private static int[,] MultiplyMatrices(int[,] m1, int[,] m2)// не надо
        {
            int[,] result = (int[,])m1.Clone();
            int n = m1.GetLength(1);
            for (int i = 0/*, i1 = 0, i2 = 0*/; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (result[i, j] + m1[i, k] * m2[k, j] > 0)
                            result[i, j] = 1;
                    }
                }
            }
            return result;
        }

        private static int[,] PowMatrix(int[,] m, int degree)// не надо
        {
            int[,] result = (int[,])m.Clone();
            for (int i = 0; i < degree; i++)
            {
                result = MultiplyMatrices(result, m);
            }
            return result;
        }

        private static int[,] GetReachabilityMatrix()// не надо
        {
            int n = adjaencyMatrix.GetLength(1);
            int[,] result = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        result[i, j] = 1;
                }
            }

            for (int i = 0; i < adjaencyMatrix.GetLength(1); i++)
            {
                result = Sum(result, PowMatrix(adjaencyMatrix, i));
            }
            return result;
        }

        private static int[,] GetConnectivityMatrix(/*List<List<int>> r*/)//не надо
        {
            int[,] r = GetReachabilityMatrix();
            LogicAnd(ref r, Transpose(r));
            return r;
        }

        

        
        //private static List<List<int>> GetConnectivityComponents()//нет?
        //{
        //    List<List<int>> result = new List<List<int>>();
        //    int[,] connectivityMatrix = GetConnectivityMatrix();

        //    for (int i = 0; i < adjaencyMatrix.GetLength(1); i++)
        //    {
        //        List<int> k = GetComponent(connectivityMatrix, i);
        //        if (k.Count > 0)
        //        {
        //            result.Add(k);
        //        }
        //    }
        //    return result;
        //}

        

        //public static void ShowConnectivityComponents()//пеередел?
        //{
        //    if (adjaencyMatrix == null)
        //    {
        //        Console.WriteLine("Еще не выбрана матрица смежности");
        //        return;
        //    }
        //    List<List<int>> connectivityComponents = GetConnectivityComponents();

        //    for (int i = 0; i < connectivityComponents.Count; i++)
        //    {
        //        string component = $"K{i + 1} : ";
        //        for (int j = 0; j < connectivityComponents[i].Count; j++)
        //        {
        //            component += points[connectivityComponents[i][j]];
        //        }
        //        Console.WriteLine(component);
        //    }
        //}

        

    }
}
