using System;
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
            External_Interactions.Input(ref degree, 1, size*size, "Пути, состоящие из скольки ребер будут учитываться:");
            string result = "";
            int[,] resultMatrix = new int[0,0];
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

        private static int[,] ShimbellMultiplyMatrices(int[,] m1, int[,] m2, bool maxOrMin)// не надо, надо но изменить под шимбела
        {
            int[,] result = (int[,])m1.Clone();
            int n = m1.GetLength(1);
            for (int i = 0/*, i1 = 0, i2 = 0*/; i < n; i++)
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

        private static int[,] ShimbellPowMatrix(int[,] m, int degree, bool maxOrMin = true)// не надо, надо под шимбела
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
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns>стринг ответ</returns>
        /// 

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


        /// <summary>
        /// Клик
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns>стринг ответ</returns>
        /// 

        private static List<string> GetFirstEquation(int[,] matrix) 
        {
            List<string> listResult = new List<string>();
            int n = matrix.GetLength(1);
            for(int i=0;i<n-1;i++)
            {
                string result = "";
                result += $"{points[i]}";
                int step = 0;
                for (int j = i+1; j < n; j++) 
                {
                    //if(j<n)
                    //{
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
                    //}        
                }
                listResult.Add(result);
            }
            return listResult;
        }

        private static string DMultiply(string a, string b) 
        {
            string[] aList = a.Replace(" ", "").Split('V');
            string[] bList = b.Replace(" ", "").Split('V');
            
            string result = "";
            for(int i=0;i<aList.Length;i++)
                for(int j = 0; j < bList.Length; j++)
                {
                    HashSet<char> seen = new HashSet<char>();
                    if (bList[j].Contains(aList[i]))
                        result += bList[j];
                    else
                    {
                        if (aList[j].Contains(bList[i]))
                            result += aList[j];
                        else 
                        {
                            string tempRes = aList[i] + bList[j];
                            foreach(char c in tempRes)
                            {
                                if (seen.Add(c)) // Добавляет символ в HashSet и возвращает true, если он новый
                                {
                                    result += c;
                                }
                            }
                        }
                    }
                    if (i +1 != aList.Length /*& j + 1 != bList.Length*/)
                        result += " V ";
                    else
                        if(j+1 != bList.Length)
                            result += " V ";
                }
            return result;
        }

        private static List<string> DiscrethMultiplyEach(List<string> list) 
        {
            List<string> listResult = new List<string>();

            for(int i =0;i<list.Count; i++)
            {
                if (i + 1 < list.Count)
                { 
                    listResult.Add(DMultiply(list[i], list[i + 1]));
                    i++;
                }

                else
                    listResult.Add(list[i]);
            }


            return listResult;
        }

        private static string Absorption(string a, string b) 
        {
            /*// Убираем пробелы и разбиваем строки на переменные
            var aVars = new HashSet<char>(a.Replace(" ", "").Split('V').Select(s => s[0]));
            var bVars = new HashSet<char>(b.Replace(" ", "").Split('V').Select(s => s[0]));

            // Проверяем, является ли a подмножеством b
            if (aVars.IsSubsetOf(bVars))
            {
                return a; // a поглощает b
            }

            // Проверяем, является ли b подмножеством a
            if (bVars.IsSubsetOf(aVars))
            {
                return b; // b поглощает a
            }

            // Если поглощения нет, возвращаем пустую строку
            return "";*/
            string[] aList = a.Replace(" ", "").Split('V');
            string[] bList = b.Replace(" ", "").Split('V');

            string result = "";
            for (int i = 0; i < aList.Length; i++)
                for (int j = 0; j < bList.Length; j++)
                {
                    HashSet<char> seen = new HashSet<char>();
                    if (aList[i].OrderBy(cha => cha).ToArray().SequenceEqual(bList[j].OrderBy(cha => cha).ToArray()))
                    {
                        return new string(aList[i].OrderBy(cha => cha).ToArray());
                    }
                }
            return result;
        }

        private static List<string> DoAbsorption(List<string> list) 
        {
            List<string> result = new List<string>();

            for(int i = 0; i < list.Count; i++) 
            {
                for(int j = i; j < list.Count; j++)
                {
                    string res = Absorption(list[i], list[j]);
                    if (res != "")
                    {
                        result.Add(res);
                        list.Remove(list[j]);
                        j = list.Count;
                    }
                    else
                        if (j + 1 == list.Count)
                        result.Add(list[i]);
                }
            }

            return result;

            //List<string> result = new List<string>();

            //// Копируем список, чтобы не изменять оригинальный
            //var tempList = new List<string>(list);

            //// Применяем поглощение ко всем парам дизъюнктов
            //for (int i = 0; i < tempList.Count; i++)
            //{
            //    bool isAbsorbed = false;

            //    for (int j = 0; j < tempList.Count; j++)
            //    {
            //        if (i == j) continue; // Не сравниваем дизъюнкт с самим собой

            //        // Проверяем, поглощается ли tempList[i] tempList[j]
            //        string absorbed = Absorption(tempList[i], tempList[j]);
            //        if (absorbed == tempList[i])
            //        {
            //            // tempList[i] поглощается tempList[j], пропускаем его
            //            isAbsorbed = true;
            //            break;
            //        }
            //    }

            //    // Если дизъюнкт не поглощен, добавляем его в результат
            //    if (!isAbsorbed)
            //    {
            //        result.Add(tempList[i]);
            //    }

            }
        public static string GetClique() 
        {
            //    var expressions = new List<string>
            //{
            //    "(A ∨ CE)",
            //    "(B ∨ CD)"

            //};
                //string result = MultiplyExpressions(expressions);

            //нормально перемножать скобки сделать!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            List<string> resultList = GetFirstEquation(adjaencyMatrix);
            //resultList = DoAbsorption(resultList);


            //List<string> result = DiscrethMultiplyEach(resultList);



            //сделать сортирову по алфовиту в dmultimply + поглащение попробовать на конечном результате + 
            //    + убирание повторяющихся полностью частей + получение из имеющихся недостающих


            while (resultList.Count != 1)
                resultList = DiscrethMultiplyEach(resultList);
            //string result = MultiplyExpressions(resultList.ToArray());
            //string result = FindCliques(adjaencyMatrix);
            return resultList[0];//resultList.ToArray().ToString();
        }

        static string FindCliques(int[,] adjacencyMatrix)
        {
            int n = adjacencyMatrix.GetLength(0);
            List<List<int>> cliques = new List<List<int>>();

            // Используем битовые маски для генерации всех подмножеств
            for (int mask = 1; mask < (1 << n); mask++)
            {
                List<int> currentClique = new List<int>();
                bool isClique = true;

                // Проверяем, является ли подмножество кликой
                for (int i = 0; i < n; i++)
                {
                    if ((mask & (1 << i)) != 0) // Если i-я вершина включена в подмножество
                    {
                        currentClique.Add(i);
                        // Проверяем, соединена ли вершина с остальными
                        for (int j = 0; j < n; j++)
                        {
                            if (i != j && (mask & (1 << j)) != 0 && adjacencyMatrix[i, j] == 0)
                            {
                                isClique = false;
                                break;
                            }
                        }
                    }
                    if (!isClique) break;
                }

                if (isClique)
                {
                    cliques.Add(currentClique);
                }
            }

            // Формируем строку для вывода
            return FormatCliques(cliques);
        }

        static string FormatCliques(List<List<int>> cliques)
        {
            if (cliques.Count == 0)
                return "Клики: нет";

            List<string> formattedCliques = new List<string>();
            for (int i = 0; i < cliques.Count; i++)
            {
                // Преобразуем индексы в символы
                string cliqueString = string.Join(", ", cliques[i].ConvertAll(index => ((char)('A' + index)).ToString()));
                formattedCliques.Add($"{i + 1}: {cliqueString}");
            }

            return "Клики:\n" + string.Join("\n", formattedCliques);
        }

        static string MultiplyExpressions(string[] expressions)
        {
            // Список для хранения всех конъюнкций
            List<List<string>> conjunctions = new List<List<string>>();

            // Разделяем каждое выражение на его компоненты
            foreach (var expression in expressions)
            {
                var terms = expression.Split(new[] { " V " }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(t => t.Trim())
                                      .ToList();
                conjunctions.Add(terms);
            }

            // Упрощаем конъюнкции
            conjunctions = conjunctions.Select(Simplify).ToList();

            // Получаем все комбинации
            var combinations = GetCombinations(conjunctions);

            // Объединяем результаты в строку
            return string.Join(" ∨ ", combinations.Select(c => string.Join(" ∧ ", c)));
        }

        static List<string> Simplify(List<string> terms)
        {
            // Убираем дубликаты
            var uniqueTerms = new HashSet<string>(terms);
            return uniqueTerms.ToList();
        }

        static List<List<string>> GetCombinations(List<List<string>> conjunctions)
        {
            // Начинаем с пустого списка
            List<List<string>> result = new List<List<string>>();

            // Рекурсивная функция для получения всех комбинаций
            void Combine(List<string> current, int index)
            {
                if (index == conjunctions.Count)
                {
                    result.Add(new List<string>(current));
                    return;
                }

                foreach (var term in conjunctions[index])
                {
                    current.Add(term);
                    Combine(current, index + 1);
                    current.RemoveAt(current.Count - 1);
                }
            }

            Combine(new List<string>(), 0);
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

        

        //private static int[,] GetReachabilityMatrix()// не надо
        //{
        //    int n = adjaencyMatrix.GetLength(1);
        //    int[,] result = new int[n, n];
        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int j = 0; j < n; j++)
        //        {
        //            if (i == j)
        //                result[i, j] = 1;
        //        }
        //    }

        //    for (int i = 0; i < adjaencyMatrix.GetLength(1); i++)
        //    {
        //        result = Sum(result, PowMatrix(adjaencyMatrix, i));
        //    }
        //    return result;
        //}

        //private static int[,] GetConnectivityMatrix(/*List<List<int>> r*/)//не надо
        //{
        //    int[,] r = GetReachabilityMatrix();
        //    LogicAnd(ref r, Transpose(r));
        //    return r;
        //}

        

        
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
