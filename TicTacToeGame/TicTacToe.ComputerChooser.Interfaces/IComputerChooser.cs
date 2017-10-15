namespace TicTacToe.ComputerChooser.Interfaces
{
    using Computer.Interfaces;

    public interface IComputerChooser
    {
        /// <summary>
        /// Returns an instance of a specific computer implementation based on the provided name
        /// </summary>
        /// <param name="computerName">name of the computer</param>
        /// <returns>IComputer</returns>
        IComputer GetComputerByName(string computerName);
    }
}