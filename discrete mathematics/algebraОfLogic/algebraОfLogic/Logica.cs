using System;

namespace algebraОfLogic
{
    internal class Logica
    {
        private static int[][] values;
        private static int size = 0;
        private static int numberOfVariable = 0;
        private static string[] variables = { "X", "Y", "Z", "P", "Q" };
        //private static string[] variablesNegative = { "X̄", "Ȳ", "Z̄", "P̄", "Q̄" };
        private static string[] variablesNegative = { "¬X", "¬Y", "¬Z", "¬P", "¬Q" };

        public static void InputData()
        {
            int commandKey = 0;
            Output("1. Задать результаты в ручную\n2. Задать результаты с помощью генератора случайных чисел\n3. Назад");
            Input(ref commandKey);

            switch (commandKey)
            {
                case 1:
                    {
                        Input(ref numberOfVariable, 1, 5, "Введите количество переменных: ");
                        size = (int)Math.Pow(2, numberOfVariable);
                        FillVariableValues(numberOfVariable);
                        for (int i = 0; i < numberOfVariable; i++)
                        {
                            Console.Write(variables[i]);
                        }
                        Console.WriteLine();

                        for (int i = 0; i < size; i++)
                        {
                            for (int j = 0; j < numberOfVariable; j++)///стало (int j = 0; j < numberOfVariable; j++) но гавно -ь заполняшось с конца
                                                                      ///было  int j = numberOfVariable-1; j >=0 ; j--
                            {
                                Console.Write(values[i][j]);
                                //Output($"{values[i][0]}{values[i][1]} {values[i][2]}");
                            }
                            int tempValue = 0;
                            Input(ref tempValue, 0, 1, " ");
                            values[i][numberOfVariable] = tempValue;
                        }
                        break;
                    }
                case 2:
                    {
                        Input(ref numberOfVariable, 1, 5, "Введите количество переменных: ");
                        size = (int)Math.Pow(2, numberOfVariable);
                        FillVariableValues(numberOfVariable);
                        var rand = new Random();
                        for (int i = 0; i < size; i++)
                        {
                            values[i][numberOfVariable] = rand.Next(0, 2);
                        }
                        OutputData();
                        break;
                    }
                case 3:
                    {
                        break;
                    }
            }
        }

        public static bool AllPreviosOne(int i, int j, int numberOfVariable)
        {
            for (int k = numberOfVariable - 1; k > j; k--)//было int k = 0; k < j; k++ //int k = j-1; k >= 0; k--
            {
                if (values[i][k] == 0)
                    return false;
            }

            return true;
        }

        public static bool IWasOne(int i, int j, int numberOfVariable)
        {
            if (values[i][j] == 1)
                return true;
            return false;
        }

        public static bool NextIsOne(int i, int j)
        {
            if (values[i][j - 1] == 1)
                return true;
            return false;
        }

        public static void FillVariableValues(int numberOfVariable)
        {
            size = (int)Math.Pow(2, numberOfVariable);
            values = new int[size][];
            values[0] = new int[1 + numberOfVariable];
            for (int i = 1; i < size; i++)
                values[i] = new int[1 + numberOfVariable];
            for (int i = 1; i < size; i++)
            {
                values[i][numberOfVariable - 1] = (i) % 2;
                for (int j = numberOfVariable - 2; j >= 0; j--)
                {
                    if (AllPreviosOne(i - 1, j, numberOfVariable))
                    {
                        values[i][j] = 1;
                        for (int k = j + 1; k < numberOfVariable; k++)
                        {
                            values[i][k] = 0;
                        }
                    }
                    else
                    {
                        if (IWasOne(i - 1, j, numberOfVariable))
                            values[i][j] = 1;
                    }
                }
            }
        }

        public static void Input(ref int data, int minValue = -100000, int maxValue = 100000, string introductoryMessage = "")
        {
            if (introductoryMessage != "")
            {
                Console.Write(introductoryMessage);
            }
            if (!(int.TryParse((Console.ReadLine()), out data)) || data < minValue || data > maxValue)
            {
                Input(ref data, minValue, maxValue, "Введены не корректные данные, повторите\n");
            }
        }

        public static void Output(string information)
        {
            //Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine(information);
        }

        public static void OutputData()
        {
            for (int i = 0; i < (int)Math.Pow(2, numberOfVariable); i++)
            {
                for (int j = 0; j < numberOfVariable; j++) //было int j = numberOfVariable - 1; j >= 0; j--
                {
                    Console.Write(values[i][j]);
                    //Output($"{values[i][0]}{values[i][1]} {values[i][2]}");
                }
                Console.WriteLine($" {values[i][numberOfVariable]}");
            }
        }

        public static string GetSKNF(int size, int numberOfVariable)
        {
            string sknf = "";
            for (int i = 0; i < size; i++)
            {
                if (values[i][numberOfVariable] == 0)
                {
                    string temp = "";
                    if (sknf != "")
                        temp += ")•(";
                    else
                        sknf += "(";
                    for (int j = 0, var = 0; j < numberOfVariable; j++)//было int j = numberOfVariable - 1, var = 0; j >= 0; j-- //int j = 0, var = 0; j < numberOfVariable; j++
                    {
                        if (values[i][j] == 0)
                        {
                            if (j > 0)
                                temp += " V ";
                            temp += variables[var];
                            var++;
                        }
                        else
                        {
                            if (j > 0)
                                temp += " V ";
                            temp += variablesNegative[var];
                            var++;
                        }
                    }
                    sknf += temp;
                }
            }
            if (sknf != "")
            {
                sknf += ")";
                return sknf;
            }
            else
                return "СKНФ - пустая";
        }

        public static string GetSDNF(int size, int numberOfVariable)
        {
            string sdnf = "";
            for (int i = 0; i < size; i++)
            {
                if (values[i][numberOfVariable] == 1)
                {
                    string temp = "";
                    if (sdnf != "")
                        temp = " V ";
                    for (int j = 0, var = 0; j < numberOfVariable; j++)//было int j = numberOfVariable - 1, var = 0; j >= 0; j--//int j = 0, var = 0; j < numberOfVariable; j++
                    {
                        if (values[i][j] == 1)
                        {
                            temp += variables[var];
                            var++;
                        }
                        else
                        {
                            temp += variablesNegative[var];
                            var++;
                        }
                    }
                    sdnf += temp;
                }
            }
            if (sdnf != "")
                return sdnf;
            else
                return "СДНФ - пустая";
        }

        public static bool NoPluses(int i, bool[][] imlicantMatrix)
        {
            if (NumberOfPlusesVertical(ref i, imlicantMatrix) == 0)
                return true;
            return false;
        }

        public static int NumberOfPlusesVertical(ref int i, bool[][] imlicantMatrix)//если + один то вернет его индекс в импликантной матрице
        {
            int counter = 0;
            int indexTrue = -1;
            for (int k = 0; k < imlicantMatrix.Length; k++)
            {
                if (imlicantMatrix[k][i] == true) //сравниваем с бул. надеюсь 0 пойдет, но если что то труе
                {
                    counter++;
                    indexTrue = k;
                }
            }

            if (counter == 1)
                i = indexTrue;
            return counter;
        }


        public static string Gluing(int i, int j, int numberOfVariable, int[][] tempValues, int tempIter, int[][] value, int numberToEuqls, bool[][] implicantMatrix, int realVarNumber)
        {
            int numberOfEuqls = 0;
            int numberOfDifferents = 0;
            string gluingResult = "";
            //int[] savedVariables = new int[numberOfVariable - 1];
            //int savedVariablesCounter = 0;

            for (int k = 0; k < numberOfVariable; k++)//было int k = numberOfVariable - 1; k >= 0; k-- и дичайше не согласовалось с последующми добавлениями: совпало z а добавили и записали  x хотя его в одном из дизъюнктов даже не было!
            {
                if (value[i][k] == value[j][k] & value[j][k] != -1)
                {
                    numberOfEuqls++;
                    if (value[i][k] == 0)
                    {
                        gluingResult += variablesNegative[k]; //было numberOfVariable - 1 - k] и не согласовалось наждо просто к
                        tempValues[tempIter][k] = 0; //тк value[i][k] == 0
                        tempValues[tempIter][numberOfVariable] = 1; //так как резуьтат по любому один
                        //savedVariables[savedVariablesCounter] = numberOfVariable - 1 - k;
                        //savedVariablesCounter++;

                        implicantMatrix[tempIter][i] = true;
                        implicantMatrix[tempIter][j] = true;
                    }
                    else
                    {
                        gluingResult += variables[k];
                        tempValues[tempIter][k] = 1; //тк value[i][k] == 1
                        tempValues[tempIter][numberOfVariable] = 1; //так как резуьтат по любому один
                        //savedVariables[savedVariablesCounter] = numberOfVariable - 1 - k;
                        //savedVariablesCounter++;

                        implicantMatrix[tempIter][i] = true;
                        implicantMatrix[tempIter][j] = true;
                    }
                }
                else
                {
                    if (value[i][k] != -1 & value[j][k] != -1)
                        numberOfDifferents++;
                }
            }
            if (numberOfEuqls == numberToEuqls & numberOfDifferents == 1)
            {
                //for (int k = 0; k < savedVariablesCounter; k++)
                //{
                //    tempValues[tempIter][k] = values[][];
                //}                
                return gluingResult;
            }
            else
            {
                //if(j==size-1 & NoPluses(i, implicantMatrix))  //i подается как столбец                  
                //{
                //    for (int k = 0; k < numberOfVariable; k++)//было int k = numberOfVariable - 1; k >= 0; k-- и дичайше не согласовалось с последующми добавлениями: совпало z а добавили и записали  x хотя его в одном из дизъюнктов даже не было!
                //    {
                //        if (value[i][k] == 0)
                //        {
                //            gluingResult += variablesNegative[k]; //было numberOfVariable - 1 - k] и не согласовалось наждо просто к
                //            tempValues[tempIter][k] = 0; //тк value[i][k] == 0
                //            tempValues[tempIter][numberOfVariable] = 1; //так как резуьтат по любому один
                //                                                        //savedVariables[savedVariablesCounter] = numberOfVariable - 1 - k;
                //                                                        //savedVariablesCounter++;
                //        }
                //        else
                //        {
                //            gluingResult += variables[k];
                //            tempValues[tempIter][k] = 1; //тк value[i][k] == 1
                //            tempValues[tempIter][numberOfVariable] = 1; //так как резуьтат по любому один
                //                                                        //savedVariables[savedVariablesCounter] = numberOfVariable - 1 - k;
                //                                                        //savedVariablesCounter++;
                //        }
                //    }
                //    return gluingResult;
                //}
                //else
                {
                    if (j == realVarNumber - 1 & NoPluses(i, implicantMatrix))
                    {

                        for (int k = 0; k < numberOfVariable; k++)//было int k = numberOfVariable - 1; k >= 0; k-- и дичайше не согласовалось с последующми добавлениями: совпало z а добавили и записали  x хотя его в одном из дизъюнктов даже не было!
                        {
                            if (value[i][k] != -1)
                            {
                                if (value[i][k] == 0)
                                {
                                    gluingResult += variablesNegative[k]; //было numberOfVariable - 1 - k] и не согласовалось наждо просто к
                                    tempValues[tempIter][k] = 0;
                                    tempValues[tempIter][numberOfVariable] = 1;

                                }
                                else
                                {
                                    gluingResult += variables[k];
                                    tempValues[tempIter][k] = 1;
                                    tempValues[tempIter][numberOfVariable] = 1;
                                }
                            }
                        }
                        return gluingResult;
                    }

                    for (int k = 0; k < numberOfVariable + 1; k++)
                    {
                        tempValues[tempIter][k] = -1;
                    }

                    implicantMatrix[tempIter][i] = false;
                    implicantMatrix[tempIter][j] = false;

                    return "";
                }
            }
        }

        public static void AddGluingRes(ref string mdnf, string gluingRes, ref int tempIter)
        {
            if (gluingRes != "")
            {
                tempIter++;
                if (mdnf != gluingRes & (!mdnf.Contains($"{gluingRes} ") & !mdnf.Contains($" {gluingRes}")))//было || вместо & ориентировочно мешало - добавлялось когда уже и так было в мднф ОДНАКО добавился только лишний z икса лишнего не было ХОТЯ его и так не получалось по склейке ТЕПЕРЬ выдает что и должно на 0 1 0 1 1 1 1 и тд
                {
                    if (gluingRes.Length == 2 & gluingRes.Contains("¬") || gluingRes.Length == 1)
                    {
                        if (mdnf.Contains($"¬{gluingRes} ") || mdnf.Contains($" ¬{gluingRes}"))
                        {
                            //значит этого длина 1
                            //mdnf = mdnf.Replace($" V ¬{gluingRes}", ""); //прекрасно работает но надо ведь просто сделать == 1
                            mdnf = "1";
                        }
                        else
                        {
                            if (mdnf.Contains($"{gluingRes} ") || mdnf.Contains($" {gluingRes}"))
                            {
                                //mdnf = mdnf.Replace($"V {gluingRes[1]} ", "");//прекрасно работает но надо ведь просто сделать == 1
                                //mdnf = mdnf.Replace($"V ¬{gluingRes} ", ""); //
                                mdnf = "1";
                            }
                            else
                            {
                                if (mdnf != "")
                                {
                                    mdnf += " V ";
                                }
                                mdnf += gluingRes;
                            }
                        }
                    }
                    else
                    {
                        //////if ((gluingRes.Length == 3 || gluingRes.Length == 4) & gluingRes.Contains("¬") || gluingRes.Length == 2)
                        //////{
                        //////    if (gluingRes.Contains("¬"))
                        //////    {
                        //////        if (gluingRes.Length == 3)
                        //////        {
                        //////            if (gluingRes[0] == '¬')
                        //////            {
                        //////                if (mdnf.Contains($" {gluingRes[0]}{gluingRes[1]}") || mdnf.Contains($"{gluingRes[0]}{gluingRes[1]} "))

                        //////            }
                        //////        }
                        //////    }
                        //////    else { }
                        //////}

                        if (mdnf != "")
                        {
                            mdnf += " V ";
                        }
                        mdnf += gluingRes;
                    }
                }
            }
        }

        public static string GetMDNF(int size, int numberOfVariable, int[][] value, int counter = 1)
        {
            string mdnf = "";
            int[][] tempValues = new int[size * size][];
            bool[][] implicantMatrix = new bool[size * size][];
            int tempIter = 0;
            int numberOfOneResult = 0;
            for (int k = 0; k < size; k++)
            {
                if (values[k][numberOfVariable] == 1)
                    numberOfOneResult++;
            }
            if (numberOfOneResult == 1)
                return GetSDNF(size, numberOfVariable);
            else
            {
                if (numberOfOneResult == 0)
                    return "МДНФ - пустая";
            }
            int realVarNumber = 0;
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i][numberOfVariable] != -1)
                {
                    realVarNumber++;
                }
            }
            //int[,] tempValues = new int[size, numberOfVariable + 1]; можно вот так и тогда нимжний цикл не нужен но потом везде исправить на [,] 
            for (int i = 0; i < size * size; i++)
            {
                tempValues[i] = new int[numberOfVariable + 1];

                implicantMatrix[i] = new bool[size * size];//просто сизе можно ожалуй

                for (int j = 0; j < numberOfVariable + 1; j++)
                    tempValues[i][j] = -1;
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < realVarNumber/*size*/; j++)
                {
                    if (value[i][numberOfVariable] == value[j][numberOfVariable] & value[j][numberOfVariable] == 1)
                    {
                        string gluingRes = Gluing(i, j, numberOfVariable, tempValues, tempIter, value, counter, implicantMatrix, realVarNumber);//ОСТОРОЖНО МЕНЯТЬ COUNTER, ОН ВАЖНАЯ ФИГУРА
                        if (gluingRes != "")
                        {
                            tempIter++;
                            if (mdnf != gluingRes & (!mdnf.Contains($"{gluingRes} ") & !mdnf.Contains($" {gluingRes}")))//было || вместо & ориентировочно мешало - добавлялось когда уже и так было в мднф ОДНАКО добавился только лишний z икса лишнего не было ХОТЯ его и так не получалось по склейке ТЕПЕРЬ выдает что и должно на 0 1 0 1 1 1 1 и тд
                            {
                                if (gluingRes.Length == 2 & gluingRes.Contains("¬") || gluingRes.Length == 1)
                                {
                                    if ((mdnf.Contains($"¬{gluingRes} ") & (mdnf.IndexOf($" ¬{gluingRes}") == 0)) || (mdnf.Contains($" ¬{gluingRes}") & (mdnf.IndexOf($" ¬{gluingRes}") == mdnf.Length - 2)))
                                    {
                                        return "1";
                                    }
                                    else
                                    {
                                        if (mdnf.Contains($"{gluingRes} ") || mdnf.Contains($" {gluingRes}"))
                                        {
                                            return "1";
                                        }
                                        else
                                        {
                                            if (mdnf != "")
                                            {
                                                mdnf += " V ";
                                            }
                                            mdnf += gluingRes;
                                        }
                                    }
                                }
                                else
                                {
                                    if (mdnf != "")
                                    {
                                        mdnf += " V ";
                                    }
                                    mdnf += gluingRes;
                                }
                            }
                        }
                    }
                }
            }
            if (tempIter == 0)
                if (counter == numberOfVariable - 1)
                    return GetSDNF(size, numberOfVariable);
                else
                    return "";
            //if (counter == 1)
            //{
            mdnf = "";
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i][numberOfVariable] == 1)
                {
                    if (NoPluses(i, implicantMatrix))
                    {
                        string gluingResult = "";
                        for (int k = 0; k < numberOfVariable; k++)//было int k = numberOfVariable - 1; k >= 0; k-- и дичайше не согласовалось с последующми добавлениями: совпало z а добавили и записали  x хотя его в одном из дизъюнктов даже не было!
                        {
                            if (value[i][k] != -1)
                            {
                                if (value[i][k] == 0)
                                {
                                    gluingResult += variablesNegative[k]; //было numberOfVariable - 1 - k] и не согласовалось наждо просто к
                                    tempValues[tempIter][k] = 0; //тк value[i][k] == 0
                                    tempValues[tempIter][numberOfVariable] = 1; //так как резуьтат по любому один
                                                                                //savedVariables[savedVariablesCounter] = numberOfVariable - 1 - k;
                                                                                //savedVariablesCounter++;
                                }
                                else
                                {
                                    gluingResult += variables[k];
                                    tempValues[tempIter][k] = 1; //тк value[i][k] == 1
                                    tempValues[tempIter][numberOfVariable] = 1; //так как резуьтат по любому один
                                                                                //savedVariables[savedVariablesCounter] = numberOfVariable - 1 - k;
                                                                                //savedVariablesCounter++;
                                }
                            }
                        }
                        AddGluingRes(ref mdnf, gluingResult, ref tempIter);
                    }
                }
            }

            int counterToCreate = 0;
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i][numberOfVariable] == 1)
                    counterToCreate++;
            }

            bool[] tempValAddedHigh = new bool[counterToCreate]; //можно заполнмит их по value и все где f()=0 сделать true
            bool[] tempValAddedLeft = new bool[tempIter];
            tempIter = 0;         
            for (int k = 0, highIter = 0; k < size; k++)//было  k < implicantMatrix.Length/implicantMatrix[0].Length/стало size/tempIter
            {
                int indexStr = k;
                if (value[k][numberOfVariable] == 1)
                {

                    int numberPluses = NumberOfPlusesVertical(ref indexStr, implicantMatrix);//передавать в параметры дожны учитвая счет где зн функции =0
                    if (numberPluses == 1)//было numberPluses == 1/numberPluses > 0 & tempValAddedHigh[k] == false
                    {
                        tempValAddedHigh[highIter] = true; //было к
                                                           //highIter++;
                        tempValAddedLeft[indexStr] = true;
                        string textResult = GetTextRes(indexStr, tempValues);
                        AddGluingRes(ref mdnf, textResult, ref tempIter);
                    }
                    highIter++;
                }
            }
            //int k = 0; k < counterToCreate; k++//добавить хигхерИтер как в предыдущем
            for (int k = 0, highIter = 0; k < size; k++)//было  k < implicantMatrix.Length/implicantMatrix[0].Length/стало size/tempIter/int k = 0; k < counterToCreate; k++/size
            {
                if (value[k][numberOfVariable] == 1)
                {
                    int indexStr = k;
                    int numberPluses = NumberOfPlusesVertical(ref indexStr, implicantMatrix);
                    if (numberPluses > 1 & tempValAddedHigh[highIter] == false)//тут вместо к нужен свой индекс - так столбец считает и где f()=0 а в верхних переменных такого нет
                    {
                        string textResult;
                        int valLeftIndex;
                        for (valLeftIndex = 0; valLeftIndex < tempValAddedLeft.Length/*tempIter*/; valLeftIndex++)
                        {
                            if (IsPlus(valLeftIndex, k, implicantMatrix) & tempValAddedLeft[valLeftIndex] == true)
                            {
                                tempValAddedHigh[highIter] = true;
                                //textResult = GetTextRes(valLeftIndex, tempValues); Это лишнее потмоу что данный случай - добавленная уже покрывает и добавлено уже
                                //AddGluingRes(ref mdnf, textResult, ref tempIter);
                                valLeftIndex = tempValAddedLeft.Length;
                            }
                        }
                        if (tempValAddedHigh[highIter] == false)
                        {
                            for (valLeftIndex = 0; valLeftIndex < tempValAddedLeft.Length; valLeftIndex++)
                            {
                                if (IsPlus(valLeftIndex, k, implicantMatrix))
                                {
                                    tempValAddedHigh[highIter] = true;
                                    tempValAddedLeft[valLeftIndex] = true;
                                    textResult = GetTextRes(valLeftIndex, tempValues);
                                    AddGluingRes(ref mdnf, textResult, ref tempIter);
                                    valLeftIndex = tempValAddedLeft.Length;
                                }
                            }
                        }
                        //смотреть что плюс на пересечении
                    }
                    highIter++;
                }
            }

            if (counter > 1)
            {
                string tempResult = GetMDNF(size, numberOfVariable, tempValues, counter - 1);
                if (tempResult == "")
                    return mdnf;
                else
                    return tempResult;
            }
            else
                return mdnf;
        }

        public static bool IsPlus(int i, int j, bool[][] implecMatrix)
        {
            return implecMatrix[i][j];
        }

        public static string GetTextRes(int index, int[][] value)
        {
            string textRes = "";
            for (int k = 0; k < numberOfVariable; k++)//было int k = numberOfVariable - 1; k >= 0; k-- и дичайше не согласовалось с последующми добавлениями: совпало z а добавили и записали  x хотя его в одном из дизъюнктов даже не было!
            {
                if (value[index][k] != -1)
                {
                    if (value[index][k] == 0)
                    {
                        textRes += variablesNegative[k];
                    }
                    else
                    {
                        textRes += variables[k];
                    }
                }
            }
            return textRes;
        }

        public static void OutSDNF()
        {
            Console.WriteLine(GetSDNF(size, numberOfVariable));
        }

        public static void OutSKNF()
        {
            Console.WriteLine(GetSKNF(size, numberOfVariable));
        }

        public static void OutMDNF()
        {
            //int cnt = 0;
            //for(int i = 0; i < size; i++) 
            //{
            //    if (values[i][numberOfVariable] == 1)
            //        cnt++;
            //}
            //values=
            Console.WriteLine(GetMDNF(size, numberOfVariable, values, numberOfVariable - 1));
        }
    }
}
