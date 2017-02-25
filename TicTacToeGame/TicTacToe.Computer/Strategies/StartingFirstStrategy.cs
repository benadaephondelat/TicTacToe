namespace TicTacToe.Computer.Strategies
{
    using System;
    using Models;
    using static Constants.ComputerConstants;

    public class StartingFirstStrategy : ComputerStrategy
    {
        private IComputerGameModel game;

        public StartingFirstStrategy(IComputerGameModel game)
        {
            base.ValidateGame(game);
            this.game = game;
        }

        public override int GetComputerMove()
        {
            if (IsFirstTurn(game.TurnsCount))
            {
                return CenterPosition;
            }

            if (IsSecondTurn(game.TurnsCount))
            {
                throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }

        private bool IsFirstTurn(int turnsCount)
        {
            if (turnsCount == 1)
            {
                return true;
            }

            return false;
        }

        private bool IsSecondTurn(int turnsCount)
        {
            if (turnsCount == 3)
            {
                return true;
            }

            return false;
        }
    }
}