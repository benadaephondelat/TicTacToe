namespace TicTacToe.ComputerChooser
{
    using System;
    using Interfaces;
    using Computer.Interfaces;

    public class ComputerChooser : IComputerChooser
    {
        private IComputer myComputer;
        //TODO DECLARE SECOND COMPUTER HERE

        //TODO PASS SECOND COMPUTER HERE
        public ComputerChooser(IComputer myComputer)
        {
            this.myComputer = myComputer;
        }

        public IComputer GetComputerByName(string computerName)
        {
            //TODO INSTANTIATE BY A GIVEN NAME

            return this.myComputer;

            throw new NotImplementedException();
        }
    }
}
