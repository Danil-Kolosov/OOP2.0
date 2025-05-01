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
        int current = 1;
        List<string> alphabet = new List<string> { "a", "b", "c", "d" };

        public KurumaMashine() { }

        public string Processing() 
        {
            string word = GetInput();
            foreach (char w in word) 
            {
                current = GoToState(w);
                if (current == -1)
                    return "Слово не принадлежит алфавиту";
            }
            if (current == 9 || current == 10)
                return "Слово принадлежит алфавиту";
            return "Слово не принадлежит алфавиту";
            //while(current )
            //current = GoToState(GetInput());
        }

        string GetInput() 
        {
            string result = "";
            External_Interactions.Input(ref result, "Введите слово:");
            return result;
        }

        int GoToState(char input) 
        {
            switch (current) 
            {
                case 1:
                    return FromState1(input);
                case 2:
                    return FromState2(input);
                case 3:
                    return FromState3(input);
                case 4:
                    return FromState4(input);
                case 5:
                    return FromState5(input);
                case 6:
                    return FromState6(input);
                case 7:
                    return FromState7(input);
                case 8:
                    return FromState8(input);
                case 9:
                    return FromState9(input);
                case 10:
                    return FromState10(input);
                case 11:
                    return FromState11(input);
                case 12:
                    return FromState12(input);
                case 13:
                    return FromState13(input);
                case 14:
                    return FromState14(input);
                case 15:
                    return FromState15(input);
                case 16:
                    return FromState16(input);
                case 17:
                    return FromState17(input);
                case 18:
                    return FromState18(input);
                case 19:
                    return FromState19(input);
                case 20:
                    return FromState20(input);
            }
            throw new ArgumentException("До данной строки дойти не должно");
        }

        int FromState1(char input) 
        {
            switch (input) 
            {
                case 'a':
                    return 1;
                case 'b':
                    return 1;
                case 'd':
                    return 2;
                case 'c':
                    return 3;
                default:
                    return -1;
            }
        }

        int FromState2(char input) 
        {
            //throw new ArgumentException("Забыл на схемке сделать");
            switch (input)
            {
                case 'a':
                    return 2;
                case 'b':
                    return 2;
                case 'd':
                    return 13;
                case 'c':
                    return 16;
                default:
                    return -1;
            }
        }

        int FromState13(char input)
        {
            switch (input)
            {
                case 'a':
                    return 13;
                case 'b':
                    return 13;
                case 'd':
                    return 13;
                case 'c':
                    return 14;
                default:
                    return -1;
            }
        }

        int FromState14(char input)
        {
            switch (input)
            {
                case 'a':
                    return 15;
                case 'b':
                    return -1;
                case 'd':
                    return 15;
                case 'c':
                    return 10;
                default:
                    return -1;
            }
        }

        int FromState15(char input)
        {
            switch (input)
            {
                case 'a':
                    return 15;
                case 'b':
                    return 15;
                case 'd':
                    return 15;
                case 'c':
                    return 10;
                default:
                    return -1;
            }
        }

        int FromState16(char input)
        {
            switch (input)
            {
                case 'a':
                    return 17;
                case 'b':
                    return -1;
                case 'd':
                    return 19;
                case 'c':
                    return 18;
                default:
                    return -1;
            }
        }

        int FromState17(char input)
        {
            switch (input)
            {
                case 'a':
                    return 17;
                case 'b':
                    return 17;
                case 'd':
                    return 19;
                case 'c':
                    return 18;
                default:
                    return -1;
            }
        }

        int FromState18(char input)
        {
            switch (input)
            {
                case 'a':
                    return 20;
                case 'b':
                    return -1;
                case 'd':
                    return 9;
                case 'c':
                    return 18;
                default:
                    return -1;
            }
        }

        int FromState19(char input)
        {
            switch (input)
            {
                case 'a':
                    return 19;
                case 'b':
                    return 19;
                case 'd':
                    return 19;
                case 'c':
                    return 10;
                default:
                    return -1;
            }
        }

        int FromState20(char input)
        {
            switch (input)
            {
                case 'a':
                    return 20;
                case 'b':
                    return 20;
                case 'd':
                    return 9;
                case 'c':
                    return 18;
                default:
                    return -1;
            }
        }

        int FromState3(char input)
        {
            switch (input)
            {
                case 'a':
                    return 3;
                case 'b':
                    return -1;
                case 'd':
                    return 5;
                case 'c':
                    return 4;
                default:
                    return -1;
            }
        }

        int FromState4(char input)
        {
            switch (input)
            {
                case 'a':
                    return 11;
                case 'b':
                    return -1;
                case 'd':
                    return 6;
                case 'c':
                    return 4;
                default:
                    return -1;
            }
        }

        int FromState11(char input)
        {
            switch (input)
            {
                case 'a':
                    return 11;
                case 'b':
                    return 11;
                case 'd':
                    return 6;
                case 'c':
                    return 4;
                default:
                    return -1;
            }
        }

        int FromState5(char input)
        {
            switch (input)
            {
                case 'a':
                    return 5;
                case 'b':
                    return 5;
                case 'd':
                    return 7;
                case 'c':
                    return 8;
                default:
                    return -1;
            }
        }

        int FromState6(char input)
        {
            switch (input)
            {
                case 'a':
                    return 6;
                case 'b':
                    return 6;
                case 'd':
                    return 9;
                case 'c':
                    return 10;
                default:
                    return -1;
            }
        }

        int FromState7(char input)
        {
            switch (input)
            {
                case 'a':
                    return 7;
                case 'b':
                    return 7;
                case 'd':
                    return 7;
                case 'c':
                    return 9;
                default:
                    return -1;
            }
        }

        int FromState8(char input)
        {
            switch (input)
            {
                case 'a':
                    return 12;
                case 'b':
                    return -1;
                case 'd':
                    return 9;
                case 'c':
                    return 8;
                default:
                    return -1;
            }
        }

        int FromState12(char input)
        {
            switch (input)
            {
                case 'a':
                    return 12;
                case 'b':
                    return 12;
                case 'd':
                    return 9;
                case 'c':
                    return 8;
                default:
                    return -1;
            }
        }

        int FromState9(char input)
        {
            switch (input)
            {
                case 'a':
                    return 9;
                case 'b':
                    return 9;
                case 'd':
                    return 9;
                case 'c':
                    return 10;
                default:
                    return -1;
            }
        }

        int FromState10(char input)
        {
            switch (input)
            {
                case 'a':
                    return 9;
                case 'b':
                    return -1;
                case 'd':
                    return 9;
                case 'c':
                    return 10;
                default:
                    return -1;
            }
        }
    }
}
