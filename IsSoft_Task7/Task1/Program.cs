using System;
using Task1Library;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger("result.json");
            logger.Track(new Task1Testing());
        }
    }
}
