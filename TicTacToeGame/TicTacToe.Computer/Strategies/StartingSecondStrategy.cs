namespace TicTacToe.Computer.Strategies
{
    using System;
    using Models;

    public class StartingSecondStrategy : ComputerStrategy
    {
        private IComputerGameModel game;

        public StartingSecondStrategy(IComputerGameModel game)
        {
            base.ValidateGame(game);
            this.game = game;
        }

        public override int GetComputerMove()
        {
            throw new NotImplementedException();
        }
    }
}