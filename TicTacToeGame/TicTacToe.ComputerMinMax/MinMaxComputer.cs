namespace TicTacToe.ComputerMinMax
{
    using System.Linq;
    using Computer.Interfaces;
    using Computer.Models;
    using ComputerImplementation.Enums;
    using TicTacToeCommon.Exceptions.Computer;
    using TicTacToeCommon.Exceptions.Game;

    /// <summary>
    /// Tic Tac Toe Min Max Computer
    /// </summary>
    public class MinMaxComputer : IComputer
    {
        public int GetComputerMoveIndex(IComputerGameModel game)
        {
            try
            {
                this.ValidateGame(game);

                int computerMove = this.GetComputerMove(game);

                return computerMove;
            }
            catch
            {
                throw new ComputerException();
            }
        }

        private int GetComputerMove(IComputerGameModel game)
        {
            CellValue[,] gameBoardState = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(game.Tiles);

            MinMaxComputerImplementation computer = new MinMaxComputerImplementation(gameBoardState);

            CellValue currentPlayerSign = ModelConvertor.ModelConvertor.GetCurrentPlayerCellValueSign(game.TurnsCount);

            int[] result = computer.MiniMax(8, currentPlayerSign, int.MinValue, int.MaxValue);

            int computerMove = ModelConvertor.ModelConvertor.ConvertArrayToIndex(result);

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