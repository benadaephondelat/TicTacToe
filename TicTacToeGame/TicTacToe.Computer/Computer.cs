namespace TicTacToe.Computer
{
    using Models;
    using Strategies;
    using static StrategyChooser.StrategyChooser;

    public class Computer
    {
        private ComputerStrategy strategy;

        public Computer(IComputerGameModel game)
        {
            this.strategy = GetComputerStrategy(game);
        }

        public int GetComputerMove()
        {
            int tileIndex = this.strategy.GetComputerMove();

            return tileIndex;
        }
    }
}