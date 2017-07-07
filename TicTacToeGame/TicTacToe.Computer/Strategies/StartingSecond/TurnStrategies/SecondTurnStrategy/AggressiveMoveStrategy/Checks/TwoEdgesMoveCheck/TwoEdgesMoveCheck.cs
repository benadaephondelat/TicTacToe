namespace TicTacToe.Computer.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy.AggressiveMoveStrategy.Checks.TwoEdgesMoveCheck
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Constants;
    using TicTacToeCommon.Constants;
    using Models;

    public class TwoEdgesMoveCheck : AgressiveMoveResponsibility
    {
        public override int? GetMove(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            if (this.TheOponentHasPlacedOnTwoEdges(gameTiles))
            {
                int computerMove = this.PlaceTurnBetweenTwoOponentTiles(gameTiles);

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

        private bool TheOponentHasPlacedOnTwoEdges(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            if (this.TopLeftAndTopRightTilesAreTakenByTheOponent(gameTiles))
            {
                return true;
            }

            if (this.BottomLeftAndBottomRightTilesAreTakenByTheOponent(gameTiles))
            {
                return true;
            }

            if (this.TopLeftAndBottomLeftTilesAreTakenByTheOponent(gameTiles))
            {
                return true;
            }

            if (this.TopRightAndBottomRightTilesAreTakenByTheOponent(gameTiles))
            {
                return true;
            }

            if (this.TopLeftAndBottomRightTilesAreTakenByTheOponent(gameTiles))
            {
                return true;
            }

            if (this.TopRightAndBottomLeftTilesAreTakenByTheOponent(gameTiles))
            {
                return true;
            }

            return false;
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

        private int PlaceTurnBetweenTwoOponentTiles(IEnumerable<IComputerGameTileModel> gameTiles)
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

            throw new NotImplementedException();
        }
    }
}