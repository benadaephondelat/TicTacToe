namespace TicTacToe.Computer.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy.AggressiveMoveStrategy.Checks.RhombusMoveCheck
{
    using System.Linq;
    using System.Collections.Generic;
    using TicTacToeCommon.Constants;
    using Models;
    using Constants;

    /// <summary>
    /// Checks if the oponent has made a Rhombus move
    /// <see cref="Documents/rhombus-move-example.png"/>
    /// If there is no result and there is no successor set it returns null.
    /// If there is a successor it delegates the responsibility to him.
    /// </summary>
    public class RhombusMoveCheck : AgressiveMoveResponsibility
    {
        public override int? GetMove(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            int? computerMove = this.BlockRhombusMove(gameTiles);

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
        /// Blocks Rhombus move or returns null if the oponent has not made L move
        /// </summary>
        /// <param name="gameTiles">Game tiles to check</param>
        /// <returns>int?</returns>
        private int? BlockRhombusMove(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            if (this.MiddleLeftAndTopMiddleTilesAreTakenByTheOponent(gameTiles))
            {
                return TileConstants.TopLeftTile;
            }

            if (this.TopMiddleAndMiddleRightTilesAreTakenByTheOponent(gameTiles))
            {
                return TileConstants.TopRightTile;
            }

            if (this.MiddleRightAndBottomMiddleTilesAreTakenByTheOponent(gameTiles))
            {
                return TileConstants.BottomRightTile;
            }

            if (this.BottomMiddleAndMiddleLeftTilesAreTakenByTheOponent(gameTiles))
            {
                return TileConstants.BottomLeftTile;
            }

            return null;
        }

        private bool MiddleLeftAndTopMiddleTilesAreTakenByTheOponent(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            string middleLeftTile = gameTiles.ElementAt(TileConstants.MiddleLeftTile).Value;

            string topMiddleTile = gameTiles.ElementAt(TileConstants.TopMiddleTile).Value;

            bool result = middleLeftTile == ComputerConstants.HomeSideSign && topMiddleTile == ComputerConstants.HomeSideSign;

            return result;
        }

        private bool TopMiddleAndMiddleRightTilesAreTakenByTheOponent(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            string topMiddleTile = gameTiles.ElementAt(TileConstants.TopMiddleTile).Value;

            string middleRightTile = gameTiles.ElementAt(TileConstants.MiddleRightTile).Value;

            bool result = topMiddleTile == ComputerConstants.HomeSideSign && middleRightTile == ComputerConstants.HomeSideSign;

            return result;
        }

        private bool MiddleRightAndBottomMiddleTilesAreTakenByTheOponent(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            string middleRightTile = gameTiles.ElementAt(TileConstants.MiddleRightTile).Value;

            string bottomoMiddle = gameTiles.ElementAt(TileConstants.BottomMiddleTile).Value;

            bool result = middleRightTile == ComputerConstants.HomeSideSign && bottomoMiddle == ComputerConstants.HomeSideSign;

            return result;
        }

        private bool BottomMiddleAndMiddleLeftTilesAreTakenByTheOponent(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            string bottomoMiddle = gameTiles.ElementAt(TileConstants.BottomMiddleTile).Value;

            string middleLeftTile = gameTiles.ElementAt(TileConstants.MiddleLeftTile).Value;

            bool result = bottomoMiddle == ComputerConstants.HomeSideSign && middleLeftTile == ComputerConstants.HomeSideSign;

            return result;
        }
    }
}