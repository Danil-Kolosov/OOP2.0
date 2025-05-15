using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI;

namespace АutomataTheory
{
    public class KurumaMashine
    {
        private enum State
        {
            // States without 'c' prefix
            Q0_0, Q1_0, Q2P_0,
            Q0_1, Q1_1, Q2P_1,
            Q0_2P, Q1_2P, Q2P_2P,

            // States with 'c' prefix
            Q1_0_c, Q2P_0_c, /*Q0_1_c,*/
            Q1_1_c, Q2P_1_c, /*Q0_2P_c,*/
            Q1_2P_c, Q2P_2P_c, Q0_0_c,

            Error
        }

        private State currentState = State.Q0_0;

        public string ProcessWord(string word)
        {
            currentState = State.Q0_0;
            foreach (char ch in word)
            {
                if (currentState == State.Error)
                    break;

                ProcessChar(ch);
            }

            if (currentState == State.Q2P_2P || currentState == State.Q2P_2P_c)
                return "Слово принадлежит языку";
            else
                return "Слово не принадлежит языку";
            
        }

        private void ProcessChar(char ch)
        {
            switch (ch)
            {
                case 'a':
                    ProcessA();
                    break;
                case 'b':
                    ProcessB();
                    break;
                case 'c':
                    ProcessC();
                    break;
                case 'd':
                    ProcessD();
                    break;
                default:
                    currentState = State.Error;
                    break;
            }
        }

        private void ProcessA()
        {
            switch (currentState)
            {
                case State.Q1_0_c:
                    currentState = State.Q1_0;
                    break;
                case State.Q2P_0_c:
                    currentState = State.Q2P_0;
                    break;
                case State.Q1_1_c:
                    currentState = State.Q1_1;
                    break;
                case State.Q2P_1_c:
                    currentState = State.Q2P_1;
                    break;
                case State.Q1_2P_c:
                    currentState = State.Q1_2P;
                    break;
                case State.Q2P_2P_c:
                    currentState = State.Q2P_2P;
                    break;
                    // Other states remain unchanged
            }
        }

        private void ProcessB()
        {
            switch (currentState)
            {
                case State.Q1_0_c:
                case State.Q2P_0_c:
                case State.Q1_1_c:
                case State.Q2P_1_c:
                case State.Q1_2P_c:
                case State.Q2P_2P_c:
                    currentState = State.Error;
                    break;
                    // Other states remain unchanged
            }
        }

        private void ProcessC()
        {
            switch (currentState)
            {
                case State.Q0_0:
                    currentState = State.Q1_0_c;
                    break;
                case State.Q1_0:
                case State.Q1_0_c:
                    currentState = State.Q2P_0_c;
                    break;
                case State.Q2P_0:
                case State.Q2P_0_c:
                    currentState = State.Q2P_0_c;
                    break;
                case State.Q0_1:
                //case State.Q0_1_c:
                    currentState = State.Q1_1_c;
                    break;
                case State.Q1_1:
                case State.Q1_1_c:
                    currentState = State.Q2P_1_c;
                    break;
                case State.Q2P_1:
                case State.Q2P_1_c:
                    currentState = State.Q2P_1_c;
                    break;
                case State.Q0_2P:
                //case State.Q0_2P_c:
                    currentState = State.Q1_2P_c;
                    break;
                case State.Q1_2P:
                case State.Q1_2P_c:
                    currentState = State.Q2P_2P_c;
                    break;
                case State.Q2P_2P:
                case State.Q2P_2P_c:
                    currentState = State.Q2P_2P_c;
                    break;
                default:
                    currentState = State.Error;
                    break;
            }
        }

        private void ProcessD()
        {
            switch (currentState)
            {
                case State.Q0_0:
                case State.Q0_0_c:
                    currentState = State.Q0_1;
                    break;
                case State.Q1_0:
                case State.Q1_0_c:
                    currentState = State.Q1_1;
                    break;
                case State.Q2P_0:
                case State.Q2P_0_c:
                    currentState = State.Q2P_1;
                    break;
                case State.Q0_1:
                //case State.Q0_1_c:
                    currentState = State.Q0_2P;
                    break;
                case State.Q1_1:
                case State.Q1_1_c:
                    currentState = State.Q1_2P;
                    break;
                case State.Q2P_1:
                case State.Q2P_1_c:
                    currentState = State.Q2P_2P;
                    break;
                    // For states with d_count already ≥2, remain unchanged
            }
        }
    }
}
