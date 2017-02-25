namespace TicTacToe.Computer.Strategies
{
    using System;
    using Models;
    using TicTacToeCommon.Exceptions.Game;

    public abstract class ComputerStrategy
    {
        public abstract int GetComputerMove();

        protected Random Random { get; set; }

        public ComputerStrategy()
        {
            this.Random = new Random(DateTime.Now.Second);
        }
        
        /// <summary>
        /// If Game.IsFinished throw exception.
        /// </summary>
        /// <exception cref="GameIsFinishedException"></exception>
        /// <param name="IComputerGameModel">Game to check</param>
        protected void ValidateGame(IComputerGameModel game)
        {
            if (game.IsFinished)
            {
                throw new GameIsFinishedException();
            }
        }
    }
}