using GraphConnectivityMatrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgorithms
{
    public class Programm
    {
        public static void Main() 
        {
            клики ггггггггггг, поледний ваирнт предложения от гробика не опробован, а так все ггггггггг
            int command = 0;
            int exitCommand = 6;
            while (command != exitCommand)
            {
                Console.WriteLine("1. Задать матрицу смежности\n2. Получить ярусы графа\n3. Получить минимальный путь " +
                    "алгоритмом Шимбелла\n4. Получить клики графа\n5. Сохранить введенную матрицу смежности\n6. Выход");
                External_Interactions.Input(ref command, 1, 6);
                switch (command)
                {
                    case 1:
                        {
                            while (command != 3)
                            {
                                Console.WriteLine("1. Выбрав из имеющихся вариантов\n2. Введя с клавиатуры\n3. Назад");
                                External_Interactions.Input(ref command, 1, 3);
                                switch (command)
                                {
                                    case 1:
                                        {
                                            Graph.DisplayAllSavedMatrix();
                                            External_Interactions.Input(ref command, 1, 15, "Введите номер матрицы, которую хотите загрузить");
                                            Graph.ChooseMatrix(command);
                                            command = 3;
                                            break;
                                        }
                                    case 2:
                                        {
                                            External_Interactions.Input(ref command, 2, 10, "Введите размер матрицы, которую хотите задать");
                                            Graph.InputMatrix(command);
                                            command = 3;
                                            break;
                                        }
                                    case 3:
                                        {
                                            //назад
                                            break;
                                        }
                                    default:
                                        break;
                                }
                            }
                            //command = 0;
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine(Graph.GetTiers());
                            break;
                        }
                    case 3:
                        {                            
                            Console.WriteLine(Graph.Shimbell());
                            //добавить выбор вершины
                            //    хотя нет, просто для всех ввести и все,
                            //    а вот путь в ребрах - для скольких ребер брать спросить нужно, сколько раз в степенть возводить
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine(Graph.GetClique());
                            break;
                        }
                    case 5: 
                        {
                            Graph.SaveMatrix();
                            break;
                        }
                    case 6: 
                        {
                            //выход
                            break;
                        }
                }


            }
        }

        public static void OldM() 
        {
            int command = 0;
            while (command != 4)
            {
                Console.WriteLine("1. Задать матрицу смежности\n2. Вывести компоненты связности\n3. Сохранить введенную матрицу смежности\n4. Выход");
                External_Interactions.Input(ref command, 1, 4);
                switch (command)
                {
                    case 1:
                        {
                            while (command != 3)
                            {
                                Console.WriteLine("1. Выбрав из имеющихся вариантов\n2. Введя с клавиатуры\n3. Назад");
                                External_Interactions.Input(ref command, 1, 3);
                                switch (command)
                                {
                                    case 1:
                                        {
                                            Graph.DisplayAllSavedMatrix();
                                            External_Interactions.Input(ref command, 1, 15, "Введите номер матрицы, которую хотите загрузить");
                                            Graph.ChooseMatrix(command);
                                            command = 3;
                                            break;
                                        }
                                    case 2:
                                        {
                                            External_Interactions.Input(ref command, 2, 10, "Введите размер матрицы, которую хотите задать");
                                            Graph.InputMatrix(command);
                                            command = 3;
                                            break;
                                        }
                                    case 3:
                                        {
                                            break;
                                        }
                                    default:
                                        break;
                                }
                            }
                            //command = 0;
                            break;
                        }
                    case 2:
                        {
                            //Graph.ShowConnectivityComponents();
                            break;
                        }
                    case 3:
                        {
                            Graph.SaveMatrix();
                            break;
                        }
                    case 4:
                        {
                            break;
                        }
                }


            }
        }
    }
}
