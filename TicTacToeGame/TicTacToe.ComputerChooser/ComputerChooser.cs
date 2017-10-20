namespace TicTacToe.ComputerChooser
{
    using Interfaces;
    using Computer.Interfaces;

    public class ComputerChooser : IComputerChooser
    {
        private const string MyComputerName = "computer@yahoo.com";

        private IComputer myComputer;
        private IComputer minMaxComputer;

        public ComputerChooser(IComputer myComputer, IComputer minMaxComputer)
        {
            this.myComputer = myComputer;
            this.minMaxComputer = minMaxComputer;
        }

        public IComputer GetComputerByName(string computerName)
        {
            if (computerName.Equals(MyComputerName))
            {
                return this.myComputer;
            }

            return this.minMaxComputer;
        }
    }
}