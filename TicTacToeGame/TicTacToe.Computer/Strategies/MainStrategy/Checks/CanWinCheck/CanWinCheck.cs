namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.CanWinCheck
{
    using System;
    using System.Collections.Generic;
    using Models;
    using TicTacToeCommon.Constants;
    using Helpers;

    /// <summary>
    /// Checks if the player in turn can win.
    /// If there is no winner and there is no successor set it returns null
    /// If there is a successor it delegates the responsibility to him
    /// </summary>
    public class CanWinCheck : Responsibility
    {
        private string PlayerSign { get; }

        private Dictionary<Tuple<string[], string>, int> winningPositions = new Dictionary<Tuple<string[], string>, int>();

        private string TopLeftTileValue { get; set; }

        private string TopMiddleTileValue { get; set; }

        private string TopRightTileValue { get; set; }

        private string MiddleLeftTileValue { get; set; }

        private string MiddleMiddleTileValue { get; set; }

        private string MiddleRightTileValue { get; set; }

        private string BottomLeftTileValue { get; set; }

        private string BottomMiddleTileValue { get; set; }

        private string BottomRightTileValue { get; set; }

        public CanWinCheck(string playerSign)
        {
            this.PlayerSign = playerSign;
        }

        public override int? GetMove(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.PopulateFields(tiles);
            this.PopulateWinningPositions();

            int? computerMove = this.CheckForWinner();

            if (computerMove != null)
            {
                return computerMove;
            }

            if (base.successor == null)
            {
                return null;
            }

            return base.successor.GetMove(tiles);
        }

        private void PopulateFields(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.TopLeftTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.TopLeftTile).Value;
            this.TopMiddleTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.TopMiddleTile).Value;
            this.TopRightTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.TopRightTile).Value;

            this.MiddleLeftTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.MiddleLeftTile).Value;
            this.MiddleMiddleTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.MiddleMiddleTile).Value;
            this.MiddleRightTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.MiddleRightTile).Value;

            this.BottomLeftTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.BottomLeftTile).Value;
            this.BottomMiddleTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.BottomMiddleTile).Value;
            this.BottomRightTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.BottomRightTile).Value;
        }

        private void PopulateWinningPositions()
        {
            this.winningPositions.Add(new Tuple<string[], string>(new string[2] { TopLeftTileValue, TopMiddleTileValue }, TopRightTileValue), TileConstants.TopRightTile);
            this.winningPositions.Add(new Tuple<string[], string>(new string[2] { TopLeftTileValue, TopRightTileValue }, TopMiddleTileValue), TileConstants.TopMiddleTile);
            this.winningPositions.Add(new Tuple<string[], string>(new string[2] { TopMiddleTileValue, TopRightTileValue }, TopLeftTileValue), TileConstants.TopLeftTile);
            this.winningPositions.Add(new Tuple<string[], string>(new string[2] { TopMiddleTileValue, TopRightTileValue }, TopLeftTileValue), TileConstants.TopLeftTile);
            this.winningPositions.Add(new Tuple<string[], string>(new string[2] { TopLeftTileValue, BottomLeftTileValue }, MiddleLeftTileValue), TileConstants.MiddleLeftTile);
            this.winningPositions.Add(new Tuple<string[], string>(new string[2] { TopLeftTileValue, MiddleLeftTileValue }, BottomLeftTileValue), TileConstants.BottomLeftTile);
            this.winningPositions.Add(new Tuple<string[], string>(new string[2] { TopMiddleTileValue, BottomMiddleTileValue }, MiddleMiddleTileValue), TileConstants.MiddleMiddleTile);
            this.winningPositions.Add(new Tuple<string[], string>(new string[2] { TopMiddleTileValue, MiddleMiddleTileValue }, BottomMiddleTileValue), TileConstants.BottomMiddleTile);
            this.winningPositions.Add(new Tuple<string[], string>(new string[2] { MiddleLeftTileValue, MiddleMiddleTileValue }, MiddleRightTileValue), TileConstants.MiddleRightTile);
            this.winningPositions.Add(new Tuple<string[], string>(new string[2] { MiddleRightTileValue, MiddleLeftTileValue }, MiddleMiddleTileValue), TileConstants.MiddleMiddleTile);
            this.winningPositions.Add(new Tuple<string[], string>(new string[2] { MiddleRightTileValue, MiddleMiddleTileValue }, MiddleLeftTileValue), TileConstants.MiddleLeftTile);
            this.winningPositions.Add(new Tuple<string[], string>(new string[2] { MiddleLeftTileValue, BottomLeftTileValue }, TopLeftTileValue), TileConstants.TopLeftTile);
            this.winningPositions.Add(new Tuple<string[], string>(new string[2] { MiddleMiddleTileValue, BottomMiddleTileValue }, TopMiddleTileValue), TileConstants.TopMiddleTile);
            this.winningPositions.Add(new Tuple<string[], string>(new string[2] { MiddleRightTileValue, BottomRightTileValue }, TopRightTileValue), TileConstants.TopRightTile);
            this.winningPositions.Add(new Tuple<string[], string>(new string[2] { MiddleRightTileValue, TopRightTileValue }, BottomRightTileValue), TileConstants.BottomRightTile);
            this.winningPositions.Add(new Tuple<string[], string>(new string[2] { BottomLeftTileValue, BottomMiddleTileValue }, BottomRightTileValue), TileConstants.BottomRightTile);
            this.winningPositions.Add(new Tuple<string[], string>(new string[2] { BottomLeftTileValue, BottomRightTileValue }, BottomMiddleTileValue), TileConstants.BottomMiddleTile);
            this.winningPositions.Add(new Tuple<string[], string>(new string[2] { BottomLeftTileValue, BottomRightTileValue }, BottomMiddleTileValue), TileConstants.BottomMiddleTile);
            this.winningPositions.Add(new Tuple<string[], string>(new string[2] { BottomMiddleTileValue, BottomRightTileValue }, BottomLeftTileValue), TileConstants.BottomLeftTile);
            this.winningPositions.Add(new Tuple<string[], string>(new string[2] { BottomRightTileValue, TopRightTileValue }, MiddleRightTileValue), TileConstants.MiddleRightTile);
            this.winningPositions.Add(new Tuple<string[], string>(new string[2] { BottomRightTileValue, TopLeftTileValue }, MiddleMiddleTileValue), TileConstants.MiddleMiddleTile);
            this.winningPositions.Add(new Tuple<string[], string>(new string[2] { BottomLeftTileValue, TopRightTileValue }, MiddleMiddleTileValue), TileConstants.MiddleMiddleTile);
        }

        private int? CheckForWinner()
        {
            foreach (var position in this.winningPositions)
            {
                if (this.TwoTilesHasTheSameValue(position.Key.Item1[0], position.Key.Item1[1], this.PlayerSign) && TileHelper.TileIsEmpty(position.Key.Item2))
                {
                    return position.Value;
                }
            }

            return null;
        }

        /// <summary>
        /// Returns true if two tiles has the same value and that value equals an expected value, else it returns false
        /// </summary>
        /// <param name="firstTileValue">The value of the first tile</param>
        /// <param name="secondTileValue">The value of the second tile</param>
        /// <param name="expectedValue">The expected value</param>
        /// <returns>bool</returns>
        private bool TwoTilesHasTheSameValue(string firstTileValue, string secondTileValue, string expectedValue)
        {
            bool result = firstTileValue == expectedValue && secondTileValue == expectedValue;

            return result;
        }
    }
}