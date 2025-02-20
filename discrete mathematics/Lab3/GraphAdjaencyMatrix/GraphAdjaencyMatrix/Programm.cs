using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphConnectivityMatrix
{
    internal class Programm
    {
        public static void Main() 
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
                            Graph.ShowConnectivityComponents();
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

        public static void OldMain()
        {
            Graph.DisplayAllSavedMatrix();
            Graph.ChooseMatrix(1);
            Graph.ShowConnectivityComponents();
            //Graph.ShowConnectivityComponents();
        }
    }
}
