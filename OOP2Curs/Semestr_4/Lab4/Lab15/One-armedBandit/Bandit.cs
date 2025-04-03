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

        private static int numberOfShots = 3;
        private static int timeSleep = 1000;
        private static Thread[] threadArr = new Thread[numberOfShots];
        private static int[] shots = new int[numberOfShots];
        private static volatile bool running = true; //volatile гарантирует, что все потоки будут видеть актуальное значение переменной. //возможно в каждом цикле надо запоминать i -> int index =i, тк может много время пройти и/или поменяться
        private static bool isThreadsAllive = false;
        private static Random random = new Random();
        private static Mutex mutex = new Mutex();

        

        public static bool IsThreadsAllive
        {
            get
            {
                return isThreadsAllive;
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
            isThreadsAllive = true;
            for (int i = 0; i < numberOfShots; i++) 
            {
                threadArr[i].Start();
            }
        }

        private static void StopThreads() //public - для подстраховки можно сделать, и при закрытии окна формы вызывать, хотя и так нормально
        {
            for (int i = 0; i < numberOfShots; i++) 
            {
                threadArr[i].Join();
                threadArr[i].Interrupt();
            }
            running = true;
            isThreadsAllive = false;
            for(int i = 0; i < numberOfShots; i++) 
            {
                if (threadArr[i].IsAlive) 
                {
                    isThreadsAllive = true;
                }
            }
        }

        public static void BanditStart(string[] priorityThreads) 
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

        public static void CreateThreds() 
        {
            for (int i = 1; i < numberOfShots + 1; i++)
            {
                Thread th = new Thread(new ThreadStart(SetResults));
                th.Name = $"Thread {i}";
                threadArr[i - 1] = th;
            }
        }

        public static string CongratulationGeneration() 
        {
            //if(isThreadsAllive) // подстраховка
            //    while (isThreadsAllive) 
            //    { }
            string congratulation = "";
            if (IsThreeEquals()) 
            {
                congratulation += "Три попадания!";
                if (IsThreeOnes()) 
                {
                    congratulation += "\nВсе единицы - суперприз!";
                }

                if (IsThreeSevens()) 
                {
                    congratulation += "\nВсе семерки - вот это удача!";
                }

                if (IsThereFour()) 
                {
                    congratulation += "\nЕсть четверка - золотой самородок!";
                }
                
                return congratulation;
            }  

            if (IsTwoEquals()) 
            {
                congratulation += "Два попадания!";
                if (IsTwoOnes()) 
                {
                    congratulation += "\nДве единицы - неплохо!";
                }

                if (IsThereFour()) 
                {
                    congratulation += "\nЕсть четверка - золотой самородок!";
                }

                if (congratulation.Count(c => c == 'n') == 2)
                    congratulation += "\nВсе выигрыши для 2 чисел - джекпот!";
                return congratulation;
            }

            if (IsThereFour())
            {
                congratulation += "\nЕсть четверка - золотой самородок!";
                return congratulation;
            }
            return "Удача отвернулась от вас";
        }

        private static bool IsThreeEquals() 
        {
            if (shots[0] == shots[1])
                if (shots[0] == shots[2])
                    return true;
            return false;
        }

        private static bool IsThreeOnes() 
        {
            if (shots[0] == 1)
                return true;
            return false;
        }

        private static bool IsThreeSevens()
        {
            if (shots[0] == 7)
                return true;
            return false;
        }

        private static bool IsTwoEquals()
        {
            if (shots[0] == shots[1] || shots[0] == shots[2] ||
                shots[1] == shots[2])                
                    return true;
            return false;
        }

        private static bool IsTwoOnes()
        {
            if ((shots[0] == shots[1] & shots[0] == 1) || (shots[0] == shots[2] & shots[0] == 1) ||
                (shots[1] == shots[2] & shots[1] == 1))
                return true;
            return false;
        }

        private static bool IsThereFour()
        {
            if (shots[0] == 4 || shots[1] == 4 || shots[2] == 4)
                return true;
            return false;
        }

        private static int IntGeneration(/*от скольки до  скольки*/) //это потоки используют тоже
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
                        // Используем Mutex для синхронизации доступа к общему ресурсу
                        mutex.WaitOne(); // Ожидаем, пока Mutex будет доступен
                        try
                        { 
                            shots[i] = IntGeneration();
                            OnUpdateUI.Invoke(i, shots[i]); //Для "кручения" однорукого бандита, событие для обновления интерфейса - UI
                        }
                        finally
                        {
                            mutex.ReleaseMutex(); // Освобождаем Mutex
                        }
                        i = numberOfShots;
                    }
                }
                Thread.Sleep(timeSleep);
            }
            //running = true; каждый поток дает в массив отгда лучше, и по нему ясно, кто живой
        }

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

        public static bool TestingHelp() 
        {
            if (IsTwoOnes())
                return true;
            return false;
        }
    }
}