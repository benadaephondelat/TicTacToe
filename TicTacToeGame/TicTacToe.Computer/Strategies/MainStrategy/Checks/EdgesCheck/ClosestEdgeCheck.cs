namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.EdgesCheck
{
    using System.Collections.Generic;
    using TicTacToeCommon.Constants;
    using Models;

    public class ClosestEdgeCheck : Responsibility
    {
        public string TopLeftTileValue { get; set; }

        public string TopRightTileValue { get; set; }

        public string BottomLeftTileValue { get; set; }

        public string BottomRightTileValue { get; set; }

        public override int? GetMove(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.PopulateFields(tiles);

            int? computerMove = this.CheckAllEdges();

            if (computerMove != null)
            {
                return computerMove;
            }

            if (base.successor != null)
            {
                return base.successor.GetMove(tiles);
            }

            return null;
        }

        /// <summary>
        /// Checks all edges of a gameboard. Returns int if success, else return null
        /// </summary>
        /// <returns>int?</returns>
        private int? CheckAllEdges()
        {
            int? topLeftCheck = this.CheckTopLeftTile();

            if (topLeftCheck != null)
            {
                return topLeftCheck;
            }

            int? topRightCheck = this.CheckTopRightTile();

            if (topRightCheck != null)
            {
                return topRightCheck;
            }

            int? bottomLeftCheck = this.CheckBottomLeftTile();

            if (bottomLeftCheck != null)
            {
                return bottomLeftCheck;
            }

            int? bottomRightCheck = this.CheckBottomRightTile();

            if (bottomRightCheck != null)
            {
                return bottomRightCheck;
            }

            return null;
        }

        private int? CheckTopLeftTile()
        {
            if (TileIsNotEmpty(this.TopLeftTileValue))
            {
                if (TileIsEmpty(this.TopRightTileValue))
                {
                    return TileConstants.TopRightTile;
                }

                if (TileIsEmpty(this.BottomLeftTileValue))
                {
                    return TileConstants.BottomLeftTile;
                }
            }

            return null;
        }

        private int? CheckTopRightTile()
        {
            if (TileIsNotEmpty(this.TopRightTileValue))
            {
                if (TileIsEmpty(this.TopLeftTileValue))
                {
                    return TileConstants.TopLeftTile;
                }

                if (TileIsEmpty(this.BottomRightTileValue))
                {
                    return TileConstants.BottomRightTile;
                }
            }

            return null;
        }

        private int? CheckBottomLeftTile()
        {
            if (TileIsNotEmpty(this.BottomLeftTileValue))
            {
                if (TileIsEmpty(this.TopLeftTileValue))
                {
                    return TileConstants.TopLeftTile;
                }

                if (TileIsEmpty(this.BottomRightTileValue))
                {
                    return TileConstants.BottomRightTile;
                }
            }

            return null;
        }

        private int? CheckBottomRightTile()
        {
            if (TileIsNotEmpty(this.BottomRightTileValue))
            {
                if (TileIsEmpty(this.TopRightTileValue))
                {
                    return TileConstants.TopRightTile;
                }

                if (TileIsEmpty(this.BottomLeftTileValue))
                {
                    return TileConstants.BottomLeftTile;
                }
            }

            return null;
        }

        /// <summary>
        /// Populates the fields
        /// </summary>
        /// <param name="tiles">IEnumerable<IComputerGameTileModel></ComputerGameTileModel></param>
        private void PopulateFields(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.TopLeftTileValue = base.GetTileByIndex(tiles, TileConstants.TopLeftTile).Value;
            this.TopRightTileValue = base.GetTileByIndex(tiles, TileConstants.TopRightTile).Value;
            this.BottomLeftTileValue = base.GetTileByIndex(tiles, TileConstants.BottomLeftTile).Value;
            this.BottomRightTileValue = base.GetTileByIndex(tiles, TileConstants.BottomRightTile).Value;
        }
    }
}