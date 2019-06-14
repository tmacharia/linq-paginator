using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Github
{
    public static class Globals
    {
        public const string AppName = "WebApp";
        public const string Description = "This is a generic web application.";

        public static Random random = new Random();
        public static bool RandomBool() => random.Next(0, 2) == 1 ? true : false;
    }
}
