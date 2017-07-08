namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.EdgesCheck
{
    using System.Collections.Generic;
    using TicTacToeCommon.Constants;
    using Models;

    /// <summary>
    /// If the oponent has placed a turn on an edge, choose the closest free edge(except diagonal)
    /// <see cref="Documents/edges-move-example.png"/>
    /// </summary>
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
            if (base.TileIsNotEmpty(this.TopLeftTileValue))
            {
                if (base.TileIsEmpty(this.TopRightTileValue))
                {
                    return TileConstants.TopRightTile;
                }

                if (base.TileIsEmpty(this.BottomLeftTileValue))
                {
                    return TileConstants.BottomLeftTile;
                }
            }

            return null;
        }

        private int? CheckTopRightTile()
        {
            if (base.TileIsNotEmpty(this.TopRightTileValue))
            {
                if (base.TileIsEmpty(this.TopLeftTileValue))
                {
                    return TileConstants.TopLeftTile;
                }

                if (base.TileIsEmpty(this.BottomRightTileValue))
                {
                    return TileConstants.BottomRightTile;
                }
            }

            return null;
        }

        private int? CheckBottomLeftTile()
        {
            if (base.TileIsNotEmpty(this.BottomLeftTileValue))
            {
                if (base.TileIsEmpty(this.TopLeftTileValue))
                {
                    return TileConstants.TopLeftTile;
                }

                if (base.TileIsEmpty(this.BottomRightTileValue))
                {
                    return TileConstants.BottomRightTile;
                }
            }

            return null;
        }

        private int? CheckBottomRightTile()
        {
            if (base.TileIsNotEmpty(this.BottomRightTileValue))
            {
                if (base.TileIsEmpty(this.TopRightTileValue))
                {
                    return TileConstants.TopRightTile;
                }

                if (base.TileIsEmpty(this.BottomLeftTileValue))
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