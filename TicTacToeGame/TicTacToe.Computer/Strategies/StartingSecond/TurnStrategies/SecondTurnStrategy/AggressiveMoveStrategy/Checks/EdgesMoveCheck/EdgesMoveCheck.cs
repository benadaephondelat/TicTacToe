namespace TicTacToe.Computer.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy.AggressiveMoveStrategy.Checks.TwoEdgesMoveCheck
{
    using System.Linq;
    using System.Collections.Generic;
    using Constants;
    using TicTacToeCommon.Constants;
    using Models;

    /// <summary>
    /// Checks if the oponent has placed his first two turns on edges
    /// <see cref="Documents/edges-move-example.png"/>
    /// If there is no result and there is no successor set it returns null.
    /// If there is a successor it delegates the responsibility to him.
    /// </summary>
    public class EdgesMoveCheck : AgressiveMoveResponsibility
    {
        public override int? GetMove(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            int? computerMove = this.BlockEdgesMove(gameTiles);

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
        /// Blocks edges move or returns null if the oponent has not made L move
        /// </summary>
        /// <param name="gameTiles">Game tiles to check</param>
        /// <returns>int?</returns>
        private int? BlockEdgesMove(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            if (this.TopLeftAndTopRightTilesAreTakenByTheOponent(gameTiles))
            {
                return TileConstants.TopMiddleTile;
            }

            if (this.BottomLeftAndBottomRightTilesAreTakenByTheOponent(gameTiles))
            {
                return TileConstants.BottomMiddleTile;
            }

            if (this.TopLeftAndBottomLeftTilesAreTakenByTheOponent(gameTiles))
            {
                return TileConstants.MiddleLeftTile;
            }

            if (this.TopRightAndBottomRightTilesAreTakenByTheOponent(gameTiles))
            {
                return TileConstants.MiddleRightTile;
            }

            if (this.TopLeftAndBottomRightTilesAreTakenByTheOponent(gameTiles))
            {
                return TileConstants.TopMiddleTile;
            }

            if (this.TopRightAndBottomLeftTilesAreTakenByTheOponent(gameTiles))
            {
                return TileConstants.BottomMiddleTile;
            }

            return null;
        }

        private bool TopLeftAndTopRightTilesAreTakenByTheOponent(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            string topLeftTile = gameTiles.ElementAt(TileConstants.TopLeftTile).Value;

            string topRightTile = gameTiles.ElementAt(TileConstants.TopRightTile).Value;

            bool result = topLeftTile == ComputerConstants.HomeSideSign && topRightTile == ComputerConstants.HomeSideSign;

            return result;
        }

        private bool BottomLeftAndBottomRightTilesAreTakenByTheOponent(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            string bottomLeftTile = gameTiles.ElementAt(TileConstants.BottomLeftTile).Value;

            string bottomRightTile = gameTiles.ElementAt(TileConstants.BottomRightTile).Value;

            bool result = bottomLeftTile == ComputerConstants.HomeSideSign && bottomRightTile == ComputerConstants.HomeSideSign;

            return result;
        }

        private bool TopLeftAndBottomLeftTilesAreTakenByTheOponent(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            string topLeftTile = gameTiles.ElementAt(TileConstants.TopLeftTile).Value;

            string topRightTile = gameTiles.ElementAt(TileConstants.BottomLeftTile).Value;

            bool result = topLeftTile == ComputerConstants.HomeSideSign && topRightTile == ComputerConstants.HomeSideSign;

            return result;
        }

        private bool TopRightAndBottomRightTilesAreTakenByTheOponent(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            string topRightTile = gameTiles.ElementAt(TileConstants.TopRightTile).Value;

            string bottomRightTile = gameTiles.ElementAt(TileConstants.BottomRightTile).Value;

            bool result = topRightTile == ComputerConstants.HomeSideSign && bottomRightTile == ComputerConstants.HomeSideSign;

            return result;
        }

        private bool TopLeftAndBottomRightTilesAreTakenByTheOponent(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            string topLeftTile = gameTiles.ElementAt(TileConstants.TopLeftTile).Value;

            string bottomRightTile = gameTiles.ElementAt(TileConstants.BottomRightTile).Value;

            bool result = topLeftTile == ComputerConstants.HomeSideSign && bottomRightTile == ComputerConstants.HomeSideSign;

            return result;
        }

        private bool TopRightAndBottomLeftTilesAreTakenByTheOponent(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            string topRightTile = gameTiles.ElementAt(TileConstants.TopRightTile).Value;

            string bottomLeftTile = gameTiles.ElementAt(TileConstants.BottomLeftTile).Value;

            bool result = topRightTile == ComputerConstants.HomeSideSign && bottomLeftTile == ComputerConstants.HomeSideSign;

            return result;
        }
    }
}