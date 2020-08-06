using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Trains.Implementations
{
    class FileReader : IInputReader
    {
        private readonly string _path;

        public FileReader(string path)
        {
            _path = path;
        }

        public List<string> GetInputByLine()
        {
            return File.ReadAllLines(_path).ToList();
        }
    }
}
