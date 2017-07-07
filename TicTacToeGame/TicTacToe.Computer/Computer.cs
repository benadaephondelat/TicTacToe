namespace TicTacToe.Computer
{
    using Models;
    using Strategies;
    using ComputerStrategyChooser = StrategyChooser.StrategyChooser;

    /// <summary>
    /// TicTacToe Computer
    /// </summary>
    public class Computer : IComputer
    {
        private ComputerStrategy computerStrategy;
        private ComputerStrategyChooser strategyChooser;

        public Computer()
        {
            this.strategyChooser = new ComputerStrategyChooser();
        }

        public int GetComputerMoveIndex(IComputerGameModel game)
        {
            this.computerStrategy = this.strategyChooser.GetComputerStrategy(game);

            int computerMove = this.computerStrategy.GetComputerMove();

            return computerMove;
        }
    }
}