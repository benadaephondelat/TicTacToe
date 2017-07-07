namespace TicTacToe.Computer.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy.AggressiveMoveStrategy.Checks.KnightMoveCheck
{
    using System.Linq;
    using System.Collections.Generic;
    using Models;
    using Constants;
    using TicTacToeCommon.Constants;

    /// <summary>
    /// Checks if the oponent has made move similar to the Knight's move in chess.
    /// <see cref="Documents/knight-move-example.png"/>
    /// If there is no result and there is no successor set it returns null.
    /// If there is a successor it delegates the responsibility to him.
    /// </summary>
    public class KnightMoveCheck : AgressiveMoveResponsibility
    {
        public override int? GetMove(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            int? computerMove = this.BlockLMove(gameTiles);

            if (computerMove != null)
            {
                return computerMove;
            }
            else if (base.IsSuccessorSet())
            {
                return base.successor.GetMove(gameTiles);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Blocks L move or returns null if the oponent has not made L move
        /// </summary>
        /// <param name="gameTiles">Game tiles to check</param>
        /// <returns>int?</returns>
        private int? BlockLMove(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            int? topMiddle = this.TopMiddleCheck(gameTiles);
            if (topMiddle != null)
            {
                return topMiddle;
            }

            int? bottomMiddle = this.BottomMiddleCheck(gameTiles);
            if (bottomMiddle != null)
            {
                return bottomMiddle;
            }

            int? middleLeft = this.MiddleLeftCheck(gameTiles);
            if (middleLeft != null)
            {
                return middleLeft;
            }

            int? middleRight = this.MiddleRightCheck(gameTiles);
            if (middleRight != null)
            {
                return middleRight;
            }

            return null;
        }

        private int? TopMiddleCheck(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            if (this.TileIsTakenByTheOponent(gameTiles.ElementAt(TileConstants.TopMiddleTile).Value))
            {
                if (this.TileIsTakenByTheOponent(gameTiles.ElementAt(TileConstants.BottomLeftTile).Value))
                {
                    return TileConstants.TopLeftTile;
                }

                if (this.TileIsTakenByTheOponent(gameTiles.ElementAt(TileConstants.BottomRightTile).Value))
                {
                    return TileConstants.TopRightTile;
                }
            }

            return null;
        }

        private int? BottomMiddleCheck(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            if (this.TileIsTakenByTheOponent(gameTiles.ElementAt(TileConstants.BottomMiddleTile).Value))
            {
                if (this.TileIsTakenByTheOponent(gameTiles.ElementAt(TileConstants.TopLeftTile).Value))
                {
                    return TileConstants.BottomLeftTile;
                }

                if (this.TileIsTakenByTheOponent(gameTiles.ElementAt(TileConstants.TopRightTile).Value))
                {
                    return TileConstants.BottomRightTile;
                }
            }

            return null;
        }

        private int? MiddleLeftCheck(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            if (this.TileIsTakenByTheOponent(gameTiles.ElementAt(TileConstants.MiddleLeftTile).Value))
            {
                if (this.TileIsTakenByTheOponent(gameTiles.ElementAt(TileConstants.TopRightTile).Value))
                {
                    return TileConstants.TopLeftTile;
                }

                if (this.TileIsTakenByTheOponent(gameTiles.ElementAt(TileConstants.BottomRightTile).Value))
                {
                    return TileConstants.BottomLeftTile;
                }
            }

            return null;
        }

        private int? MiddleRightCheck(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            if (this.TileIsTakenByTheOponent(gameTiles.ElementAt(TileConstants.MiddleRightTile).Value))
            {
                if (this.TileIsTakenByTheOponent(gameTiles.ElementAt(TileConstants.TopLeftTile).Value))
                {
                    return TileConstants.TopRightTile;
                }

                if (this.TileIsTakenByTheOponent(gameTiles.ElementAt(TileConstants.BottomLeftTile).Value))
                {
                    return TileConstants.BottomRightTile;
                }
            }

            return null;
        }

        /// <summary>
        /// Checks if the tile value is that of the oponent's sign
        /// </summary>
        /// <param name="tileValue">value of the tile to checl</param>
        /// <returns>bool</returns>
        private bool TileIsTakenByTheOponent(string tileValue)
        {
            if (tileValue == ComputerConstants.HomeSideSign)
            {
                return true;
            }

            return false;
        }
    }
}