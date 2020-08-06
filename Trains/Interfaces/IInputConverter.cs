namespace Trains.Interfaces
{
    public interface IInputConverter
    {
        /// <summary>
        /// Convert input string to matrix.
        /// </summary>
        /// <param name="input">string representation of matrix</param>
        /// <returns>two dimensional integer matrix</returns>
        int[,] ConvertToMatrix(string input);
    }
}
