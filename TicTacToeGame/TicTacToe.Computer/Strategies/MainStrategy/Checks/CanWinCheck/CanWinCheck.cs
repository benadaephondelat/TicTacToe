namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.CanWinCheck
{
    using System;
    using System.Collections.Generic;
    using Models;
    using TicTacToeCommon.Constants;

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

        private void PopulatePositions()
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

        public override int? GetMove(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.PopulateFields(tiles);
            this.PopulatePositions();

            foreach (var position in this.winningPositions)
            {
                if (TwoTilesHasTheSameValue(position.Key.Item1[0], position.Key.Item1[1], PlayerSign) && TileIsEmpty(position.Key.Item2))
                {
                    return position.Value;
                }
            }

            if (base.successor == null)
            {
                return null;
            }

            return base.successor.GetMove(tiles);
        }

        /// <summary>
        /// Populates the fields with the coresponding values of the tiles
        /// </summary>
        /// <param name="tiles">IEnumerable<IComputerGameTileModel></ComputerGameTileModel></param>
        private void PopulateFields(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.TopLeftTileValue = base.GetTileByIndex(tiles, TileConstants.TopLeftTile).Value;
            this.TopMiddleTileValue = base.GetTileByIndex(tiles, TileConstants.TopMiddleTile).Value;
            this.TopRightTileValue = base.GetTileByIndex(tiles, TileConstants.TopRightTile).Value;

            this.MiddleLeftTileValue = base.GetTileByIndex(tiles, TileConstants.MiddleLeftTile).Value;
            this.MiddleMiddleTileValue = base.GetTileByIndex(tiles, TileConstants.MiddleMiddleTile).Value;
            this.MiddleRightTileValue = base.GetTileByIndex(tiles, TileConstants.MiddleRightTile).Value;

            this.BottomLeftTileValue = base.GetTileByIndex(tiles, TileConstants.BottomLeftTile).Value;
            this.BottomMiddleTileValue = base.GetTileByIndex(tiles, TileConstants.BottomMiddleTile).Value;
            this.BottomRightTileValue = base.GetTileByIndex(tiles, TileConstants.BottomRightTile).Value;
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