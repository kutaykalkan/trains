using System.Collections.Generic;

namespace Trains.Interfaces
{
    public interface IInputReader
    {
        /// <summary>
        /// Get input by line.
        /// </summary>
        /// <returns>List of string representing each line</returns>
        List<string> GetInputByLine();
    }
}
