using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameHogerLager.Models
{
    public static class Globals
    {
        public const string SessionKeyGame = "_Game";
    }

    public class GameState
    {
        public const int START = 0;
        public const int SUCCES = 1;
        public const int HIGHER = 2;
        public const int LOWER = 3;
        public const int WRONGINPUT = 4;


        public int Target { get; set; }
        public int Steps { get; set; }
        public int State { get; set; }

        public GameState()
        {
            Steps = 1;
            Random random = new Random();
            Target = random.Next(1, 101);
            State = START;
        }

        public string GetStateText()
        {
            switch (State)
            {
                case SUCCES: return "SUCCES";
                case HIGHER: return "Hoger!";
                case LOWER: return "Lager!";
                case WRONGINPUT: return "Verkeerde invoer!";
                default: return "";
            }
        }

        public string StateText
        {
            get
            {
                switch (State)
                {
                    case SUCCES: return "SUCCES";
                    case HIGHER: return "Hoger!";
                    case LOWER: return "Lager!";
                    case WRONGINPUT: return "Verkeerde invoer!";
                    default: return "";
                }
            }
            private set { }
        }
    }
}
