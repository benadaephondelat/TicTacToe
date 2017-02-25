namespace TicTacToe.Computer.Strategies
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Models;
    using Constants;
    using TicTacToeCommon.Constants;

    public class StartingFirstStrategy : ComputerStrategy
    {
        private IComputerGameModel game;

        public StartingFirstStrategy(IComputerGameModel game)
        {
            base.ValidateGame(game);
            this.game = game;   
        }

        public override int GetComputerMove()
        {
            if (this.IsFirstTurn(this.game.TurnsCount))
            {
                return ComputerConstants.CenterPosition;
            }

            if (this.IsSecondTurn(this.game.TurnsCount))
            {
                return this.ChooseFromBestStartingPositionsClosestToThePlayerTurn(game.Tiles);
            }

            throw new NotImplementedException();
        }

        private int ChooseFromBestStartingPositionsClosestToThePlayerTurn(IEnumerable<ComputerGameTileModel> gameTiles)
        {
            if (this.AllEdgesAreEmpty(gameTiles))
            {
                return this.ChooseRandomlyFromEdges();
            }

            return this.ChooseClosestEdgeToTheLastOponentTurn(gameTiles);
        }

        private int ChooseClosestEdgeToTheLastOponentTurn(IEnumerable<ComputerGameTileModel> gameTiles)
        {
            int oponentFirstMove = this.GetOponentFirstMove(gameTiles);

            int result = this.GetEdgeTileIndexClosestToTheOponentMove(oponentFirstMove);

            return result;
        }

        private int GetEdgeTileIndexClosestToTheOponentMove(int oponentFirstMove)
        {
            if (oponentFirstMove == TileConstants.TopLeftTile)
            {
                return this.GetClosestEdgeToTopLeftTile();
            }
            else if (oponentFirstMove == TileConstants.TopRightTile)
            {
                return this.GetClosestEdgeToTopRightTile();
            }
            else if (oponentFirstMove == TileConstants.BottomLeftTile)
            {
                return this.GetClosestEdgeToBottomLeftTile();
            }
            else if (oponentFirstMove == TileConstants.BottomRightTile)
            {
                return this.GetClosestEdgeToBottomRightTile();
            }
            else
            {
                throw new Exception();
            }
        }

        private int GetClosestEdgeToTopLeftTile()
        {
            int[] choices = new int[] { TileConstants.TopRightTile, TileConstants.BottomLeftTile };

            int result = this.ChooseRandomValueFromIntArray(choices);

            return result;
        }

        private int GetClosestEdgeToTopRightTile()
        {
            int[] choices = new int[] { TileConstants.TopLeftTile, TileConstants.BottomRightTile };

            int result = this.ChooseRandomValueFromIntArray(choices);

            return result;
        }

        private int GetClosestEdgeToBottomLeftTile()
        {
            int[] choices = new int[] { TileConstants.TopLeftTile, TileConstants.BottomRightTile };

            int result = this.ChooseRandomValueFromIntArray(choices);

            return result;
        }

        private int GetClosestEdgeToBottomRightTile()
        {
            int[] choices = new int[] { TileConstants.BottomLeftTile, TileConstants.TopRightTile };

            int result = this.ChooseRandomValueFromIntArray(choices);

            return result;
        }

        private int ChooseRandomValueFromIntArray(int[] choices)
        {
            int randomChoiceIndex = base.Random.Next(0, choices.Length);

            int result = choices[randomChoiceIndex];

            return result;
        }

        private int GetOponentFirstMove(IEnumerable<ComputerGameTileModel> gameTiles)
        {
            for (var i = 0; i < gameTiles.Count(); i++)
            {
                if (gameTiles.ElementAt(i).IsEmpty == false && gameTiles.ElementAt(i).Value == ComputerConstants.AwaySideSign)
                {
                    return i;
                }
            }

            throw new Exception();
        }

        private int ChooseRandomlyFromEdges()
        {
            int randomIndex = base.Random.Next(0, ComputerConstants.Edges.Length - 1);

            int result = ComputerConstants.Edges[randomIndex];

            return result;
        }

        private bool AllEdgesAreEmpty(IEnumerable<ComputerGameTileModel> gameTiles)
        {
            for (var i = 0; i < ComputerConstants.Edges.Length; i++)
            {
                var currentTile = game.Tiles.ElementAt(ComputerConstants.Edges[i]);

                if (currentTile.Value == ComputerConstants.AwaySideSign && currentTile.IsEmpty == false)
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsFirstTurn(int turnsCount)
        {
            if (turnsCount == 1)
            {
                return true;
            }

            return false;
        }

        private bool IsSecondTurn(int turnsCount)
        {
            if (turnsCount == 3)
            {
                return true;
            }

            return false;
        }
    }
}