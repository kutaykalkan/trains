using System;
using System.IO;
using Trains.Implementations;
using Trains.Interfaces;

namespace Trains
{
    class Program
    {
        static void Main(string[] args)
        {
            IInputConverter inputConverter = new InputConverter();
            string fileName = "Input.txt";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            IInputReader reader = new FileReader(path);
            ITrainsApp trainsApp = new TrainsApp(reader, inputConverter);
            trainsApp.Run();

            Console.Read();
        }
    }
}
