namespace TicTacToe.Computer.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy.AggressiveMoveStrategy.Checks.RhombusMoveCheck
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using TicTacToeCommon.Constants;
    using Models;
    using Constants;

    public class RhombusMoveCheck : AgressiveMoveResponsibility
    {
        public override int? GetMove(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            if (this.TheOponentHasMadeRhombusMove(gameTiles))
            {
                int computerMove = this.BlockRhombusMove(gameTiles);

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

        private bool TheOponentHasMadeRhombusMove(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            if (this.MiddleLeftAndTopMiddleTilesAreTakenByTheOponent(gameTiles))
            {
                return true;
            }

            if (this.TopMiddleAndMiddleRightTilesAreTakenByTheOponent(gameTiles))
            {
                return true;
            }

            if (this.MiddleRightAndBottomMiddleTilesAreTakenByTheOponent(gameTiles))
            {
                return true;
            }

            if (this.BottomMiddleAndMiddleLeftTilesAreTakenByTheOponent(gameTiles))
            {
                return true;
            }

            return false;
        }

        private int BlockRhombusMove(IEnumerable<IComputerGameTileModel> gameTiles)
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

            throw new NotImplementedException();
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