using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algebraОfLogic
{
    internal class Logica
    {
        public static void Main() 
        {
            InputData();
            OutputData();
            //список-массив перменных - по индексу первый-х второй-у и так далее
            //отсюда строить скнф и сднф
            //все работает коменты можно убирать слава Богу
            
            прогнозируются большие проблемы изз-за чтения задом напреред, но еще большие проблемы будут, если пытаться это исправить
            есть сднф, надо скнф и склейку
                еще исправить вывод данных в инпутедата взять из тоутпутдата

        }

        //private static List<List<int>> values;
        private static int[][] values;
        private static int numberOfVariable = 0;
        private static string[] variables = { "X", "Y", "Z", "V", "K" };

        public static void InputData() 
        {
            //int numberOfVariable = 0; //куда-то еще передать надо
            Input(ref numberOfVariable, 0, 5, "Введите количество переменных: ");
            FillVariableValues(numberOfVariable);

            int size = (int)Math.Pow(2, numberOfVariable);
            //values = new int[numberOfVariable][];
            for (int i = 0; i < size; i++)
            {     
                int tempValue = 0;
                Input(ref tempValue, 0, 1, $"{values[i][1]}{values[i][0]} ");
                //ТУТ НЕ ПРАИВЛЬНО ДЕЛАТЬ КАК В OUTPUTdaTA  
                values[i][numberOfVariable] = tempValue;
            }

            //**********************************
            Console.WriteLine(GetSDNF(size, numberOfVariable));

        }

        public static bool AllPreviosOne(int i, int j)
        {
            for (int k = 0; k < j; k++) 
            {
                if (values[i][k] == 0)
                    return false;
            }
            return true;
        }

        public static bool IWasOne(int i, int j, int numberOfVariable)
        {
            if(values[i][j] == 1)
                return true;
            return false;
        }

        public static bool NextIsOne(int i, int j) 
        {
            if (values[i][j+1]==1)
                return true;
            return false;
        }

        public static void FillVariableValues(int numberOfVariable) 
        {
            //if (numberOfVariable < 1 || numberOfVariable > 31)
            //    throw new ArgumentOutOfRangeException("n");
            //int size = 1 << numberOfVariable;
            //for (int i = 0; i < size; i++)
            //{
            //    bool[] values = new bool[numberOfVariable];
            //    for (int j = 0; j < values.Length; j++)
            //    {
            //        values[j] = (int)((i & (1 << (numberOfVariable - j - 1))) > 0);
            //    }
            //    return;
            //}
            //все преидущее единица или я сам был единицей - единица
            
            int size = (int)Math.Pow(2, numberOfVariable);
            values = new int[size][];
            values[0] = new int[1 + numberOfVariable];
            for (int i = 1; i < size; i++)
            {
                values[i] = new int[1 + numberOfVariable];
                values[i][0] = (i) % 2;
                for (int j = 1; j < numberOfVariable; j++)
                {
                    if (AllPreviosOne(i - 1, j) & IWasOne(i - 1, j, numberOfVariable))
                    {
                        if (i == 8 || i == 9)
                            ;
                        if(j!= numberOfVariable - 1)
                        {
                            while (NextIsOne(i - 1, j)) 
                            {
                                values[i][j] = 0;
                                j++;
                            }
                            //values[i][j] = 0;
                            values[i][j + 1] = 1;
                            j ++;
                        }
                        else
                            values[i][j] = 1;
                        //if (j > 0)
                        //  values[i - 1][j - 1] = 0;
                    }
                    else 
                    {
                        if (AllPreviosOne(i - 1, j) || IWasOne(i - 1, j, numberOfVariable))
                        {
                            values[i][j] = 1;
                        }
                    }

                    //if (values[i - 1][j - 1] == 1 || values[i - 1][j] == 1 /*& j!= numberOfVariable-1*/)
                    //    {
                    //        if (values[i - 1][j] == 1 & j == numberOfVariable - 1)
                    //        {
                    //            values[i][j] = 1;
                    //        }
                    //        else
                    //        {
                    //            //if (j - *2 * >= 0)
                    //            bool isZero = true;
                    //            for (int k = 0; k < j & isZero; k++)
                    //            {
                    //                if (values[i - 1][k] != 1)
                    //                    isZero = false;
                    //            }
                    //            if (!isZero)
                    //            {
                    //                values[i][j] = 1;
                    //            }
                    //        }
                    //    }
                }
            }

            //values = new int[(int)Math.Pow(2, numberOfVariable)][];
            //int size = (int)Math.Pow(2, numberOfVariable);
            ////string s = Convert.ToString(4, 2);
            ////for (int i = 1; i < size; i++) 
            ////{
            ////    values[i][0] = 1;
            ////    if()
            ////}


            //for (int i = 0; i < size; i++)
            //{
            //    values[i] = new int[1 + numberOfVariable];
            //    values[i][0] = (i) % 2;
            //    for (int j = 1; j < numberOfVariable; j++)
            //    {

            //        if (i > 0)
            //        {
            //            if (values[i - 1][j - 1] == 1 || values[i - 1][j]==1 /*& j!= numberOfVariable-1*/)
            //            {
            //                if(values[i - 1][j] == 1 & j == numberOfVariable - 1) 
            //                {
            //                    values[i][j] = 1;
            //                }
            //                else
            //                 {
            //                    //if (j - *2 * >= 0)
            //                    bool isZero = true;
            //                    for(int k = 0; k < j & isZero; k++)
            //                    {
            //                            if (values[i - 1][k] != 1)
            //                                isZero = false;
            //                    }
            //                    if(!isZero)
            //                    {
            //                       values[i][j] = 1;
            //                    }
            //                }                        
            //            }
            //        }
            //    }
            //}
        }

        public static void Input(ref int data, int minValue = -100000, int maxValue = 100000, string introductoryMessage = "")
        {
            //Console.OutputEncoding = Encoding.Unicode;
            if (introductoryMessage != "")
            {
                Console.Write(introductoryMessage);
            }
            if (!(int.TryParse((Console.ReadLine()), out data)) || data < minValue || data > maxValue)
            {
                Input(ref data, minValue, maxValue, "Введены не корректные данные, повторите");
            }
        }

        public static void Output(string information)
        {
            Console.WriteLine(information);
        }

        public static void OutputData() 
        {
            for (int i = 0; i < (int)Math.Pow(2, numberOfVariable); i++)
            {
                for (int j = numberOfVariable-1; j >= 0; j--)
                {
                    Console.Write(values[i][j]);
                    //Output($"{values[i][0]}{values[i][1]} {values[i][2]}");
                }
                Console.WriteLine($" {values[i][numberOfVariable]}");
                //int tempValue = 0;
                //Input(ref tempValue, 0, 1, $"{values[i][0]}{values[i][1]}");
                //values[i][3] = tempValue;
            }
        }

        public static string GetSDNF(int size,int numberOfVariable) 
        {
            string sdnf = "";
            for (int i = 0; i < size; i++) 
            {
                if (values[i][numberOfVariable] == 0) 
                {
                    string temp = "";
                    if (sdnf != "")
                        temp = " v ";
                    for (int j = numberOfVariable - 1, var = 0; j >= 0; j--) 
                    {
                        if (values[i][j] == 0)
                        { 
                            temp += variables[var];
                            var++;
                        }
                        else
                        {
                            temp += "!";
                            temp += variables[var];
                            var++;
                        }
                    }
                    sdnf += temp;
                }
                
            }

            return sdnf;
        }
    }
}
