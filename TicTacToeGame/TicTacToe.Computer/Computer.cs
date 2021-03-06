﻿namespace TicTacToe.Computer
{
    using System.Linq;
    using Strategies;
    using Interfaces;
    using Models;
    using TicTacToeCommon.Exceptions.Game;
    using TicTacToeCommon.Exceptions.Computer;
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
            try
            {
                this.ValidateGame(game);

                int computerMoveIndex = this.GetComputerMove(game);

                return computerMoveIndex;
            }
            catch
            {
                throw new ComputerException();
            }
        }

        private int GetComputerMove(IComputerGameModel game)
        {
            this.computerStrategy = this.strategyChooser.GetComputerStrategy(game);

            int computerMove = this.computerStrategy.GetComputerMove();

            return computerMove;
        }

        /// <summary>
        /// If Game.IsFinished or all Game.Tiles are taken throw exception.
        /// </summary>
        /// <exception cref="GameIsFinishedException"></exception>
        /// <param name="game">IComputerGameModel</param>
        private void ValidateGame(IComputerGameModel game)
        {
            bool allTilesAreTaken = game.Tiles.Any(tile => string.IsNullOrWhiteSpace(tile.Value) && tile.IsEmpty) == false;

            if (game.IsFinished || allTilesAreTaken)
            {
                throw new GameIsFinishedException();
            }
        }
    }
}