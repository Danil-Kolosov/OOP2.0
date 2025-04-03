using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace One_armedBandit
{
    public class Bandit
    {
        public delegate void UpdateUI(int index, int value);
        public static event UpdateUI OnUpdateUI; //Событие для "кручения" однорукого бандита - обновления данных в интерфейсе

        static int numberOfShots = 3;
        static Thread[] threadArr = new Thread[numberOfShots];
        static int[] shots = new int[numberOfShots];
        static volatile bool running = true; //volatile гарантирует, что все потоки будут видеть актуальное значение переменной.
        static Random random = new Random();


        //возможно в каждом цикле надо запоминать i -> int index =i, тк может много время пройти и/или поменяться

        public static bool Running 
        {
            set 
            {
                running = value;
            }
            get 
            {
                return running;
            }
        }

        public static int[] Shots
        {
            get
            {
                return shots;
            }
        }

        private static void StartThreads() 
        {
            for (int i = 0; i < numberOfShots; i++) 
            {
                threadArr[i].Start();
            }
        }

        private static void StopThreads() 
        {
            for (int i = 0; i < numberOfShots; i++) 
            {
                threadArr[i].Join();
                threadArr[i].Interrupt();
            }
            running = true;
        }

        public static void BanditStatrt/*Shots*/(string[] priorityThreads) 
        {
            CreateThreds();
            SetThreadPriority(priorityThreads);
            StartThreads();
            //получли running -> false
            //StopThreads(); эти в BanfitStop
            //return CongratulationGeneration(); эти в BanfitStop
        }

        public static void BanditStop() 
        {
            running = false;
            StopThreads();
            //return CongratulationGeneration();
        }

        public static void CreateThreds(/*от скольки до  скольки*/) 
        {
            for (int i = 1; i < numberOfShots + 1; i++)
            {
                Thread th = new Thread(new ThreadStart(SetResults));
                th.Name = $"Thread {i}";
                threadArr[i - 1] = th;
            }
            

            //return new Thread();
            //тогда в массив закидываем
        }

        public static string CongratulationGeneration() 
        {
            return "удаче отвернулась от вас";
        }

        private static int IntGeneration() //эту штуку потоки используют
        {
            return random.Next(0, 10);
        }

        private static void SetResults() 
        {
            while (running)
            {
                for (int i = 0; i < numberOfShots; i++) 
                {
                    if (Thread.CurrentThread.Name == $"Thread {i + 1}")
                    { 
                        shots[i] = IntGeneration();
                        OnUpdateUI.Invoke(i, shots[i]); //Для "кручения" однорукого бандита, событие для обновления интерфейса - UI
                        i = numberOfShots;
                    }
                }
                //if (Thread.CurrentThread.Name == "Thread 1")
                //    shots[0] = IntGeneration();
                //else
                //    if (Thread.CurrentThread.Name == "Thread 2")
                //        shots[1] = IntGeneration();
                //    else
                //        shots[2] = IntGeneration();
                Thread.Sleep(1000);
            }
            //running = true; каждый поток чтоли тру будет совать
        }

        //public static int ThreadInt() { } надо или нет


        public static void SetThreadPriority(string[] priorityThread/*1, string priorityThread2, string priorityThread3*/) //массив бы передавать для гибкости
        {
            for (int i = 0; i < numberOfShots; i++) 
            {
                switch (priorityThread[i]) 
                {
                    case "Lowest": 
                        {
                            threadArr[i].Priority = ThreadPriority.Lowest;
                            break; 
                        }
                    case "BelowNormal": 
                        {
                            threadArr[i].Priority = ThreadPriority.BelowNormal;
                            break; 
                        }
                    case "Normal": 
                        {
                            threadArr[i].Priority = ThreadPriority.Normal;
                            break; 
                        }
                    case "AboveNormal": 
                        {
                            threadArr[i].Priority = ThreadPriority.AboveNormal;
                            break; 
                        }
                    case "Highest": 
                        {
                            threadArr[i].Priority = ThreadPriority.Highest;
                            break; 
                        }
                    default: 
                        {
                            throw new ArgumentException("Сбой в приоритетах потоков");
                        }
                }                
            }
        }


    }
}
//Объяснение
//Общий ресурс: Массив results является общим ресурсом, который используется несколькими потоками для хранения результатов генерации чисел.
//Блокировка: Использование lock гарантирует, что только один поток может изменять массив results и обновлять элементы управления в любой момент времени. Это предотвращает состояние гонки.
//Обновление интерфейса: Метод UpdateTextBox использует Invoke, чтобы убедиться, что обновление элементов управления происходит в основном потоке, что также является важным аспектом работы с элементами управления в Windows Forms.
//Заключение
//В вашем приложении с "Одноруким бандитом" критическая область возникает, когда несколько потоков обращаются к общим данным или обновляют элементы управления. Использование блокировок и правильная синхронизация доступа к ресурсам помогут избежать проблем, связанных с состоянием гонки и обеспечат корректное поведение вашего приложения.