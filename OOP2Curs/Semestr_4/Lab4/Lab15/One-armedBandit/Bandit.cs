using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace One_armedBandit
{
    class Bandit
    {
        static int numberOfShots = 3;
        Thread[] threadArr;
        int[] shots = new int[numberOfShots];

        public static Thread CreateThredGeneration(/*от скольки до  скольки*/) 
        {
            return new Thread();
            //тогда в массив закидываем
        }

        public static string CongratulationGeneration() 
        {
            return "удаче отвернулась от вас";
        }

        private static int IntGeneration() //эту штуку потоки используют
        {

        }

        //public static int ThreadInt() { } надо или нет
    }
}
