namespace TicTacToe.Computer.Strategies.StartingFirst.TurnStrategies.SecondTurnStrategy
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Models;
    using Constants;
    using TicTacToeCommon.Constants;

    /// <summary>
    /// Contains the logic to be executed when the computer is starting first and it's his second turn.
    /// </summary>
    public class SecondTurnStrategy : TurnStrategy
    {
        public SecondTurnStrategy(IEnumerable<IComputerGameTileModel> gameTiles) : base(gameTiles)
        {
        }

        /// <summary>
        /// If all edges are empty choose one of them, else choose the closest edge to the last oponent's turn
        /// </summary>
        /// <returns>int</returns>
        public override int? GetMove()
        {
            if (this.AllEdgesAreEmpty(gameTiles))
            {
                return this.ChooseRandomlyFromEdges();
            }

            return this.ChooseClosestEdgeToTheOponentsFirstTurn(gameTiles);
        }

        /// <summary>
        /// Checks if all edges are empty
        /// </summary>
        /// <param name="gameTiles">Game.Tiles to check</param>
        /// <returns>bool</returns>
        private bool AllEdgesAreEmpty(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            for (var i = 0; i < ComputerConstants.Edges.Length; i++)
            {
                var currentTile = gameTiles.ElementAt(ComputerConstants.Edges[i]);

                if (currentTile.Value == ComputerConstants.AwaySideSign && currentTile.IsEmpty == false)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Chooses the closest edge to the oponent's first turn
        /// </summary>
        /// <param name="gameTiles"></param>
        /// <returns>int</returns>
        private int ChooseClosestEdgeToTheOponentsFirstTurn(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            int oponentFirstMove = this.GetOponentFirstMove(gameTiles);

            int result = this.GetRandomEdgeTileIndexClosestToTheOponentMove(oponentFirstMove);

            return result;
        }

        /// <summary>
        /// Returns the oponent's first move
        /// </summary>
        /// <param name="gameTiles">Game.Tiles</param>
        /// <returns>int</returns>
        private int GetOponentFirstMove(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            for (var i = 0; i < gameTiles.Count(); i++)
            {
                if (gameTiles.ElementAt(i).IsEmpty == false && gameTiles.ElementAt(i).Value == ComputerConstants.AwaySideSign)
                {
                    return i;
                }
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns one of the the closest edges to the oponent's first turn or throws exception
        /// </summary>
        /// <param name="oponentFirstMove">oponent's first turn tile index</param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <returns>int</returns>
        private int GetRandomEdgeTileIndexClosestToTheOponentMove(int oponentFirstMove)
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
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Returns the closest edge to the top left tile
        /// </summary>
        /// <returns>int</returns>
        private int GetClosestEdgeToTopLeftTile()
        {
            int[] choices = new int[] { TileConstants.TopRightTile, TileConstants.BottomLeftTile };

            int result = this.ChooseRandomValueFromIntArray(choices);

            return result;
        }

        /// <summary>
        /// Returns the closest edge to the top right tile
        /// </summary>
        /// <returns>int</returns>
        private int GetClosestEdgeToTopRightTile()
        {
            int[] choices = new int[] { TileConstants.TopLeftTile, TileConstants.BottomRightTile };

            int result = this.ChooseRandomValueFromIntArray(choices);

            return result;
        }

        /// <summary>
        /// Returns the closest edge to the bottom left tile
        /// </summary>
        /// <returns>int</returns>
        private int GetClosestEdgeToBottomLeftTile()
        {
            int[] choices = new int[] { TileConstants.TopLeftTile, TileConstants.BottomRightTile };

            int result = this.ChooseRandomValueFromIntArray(choices);

            return result;
        }

        /// <summary>
        /// Returns the closest edge to the bottom right tile
        /// </summary>
        /// <returns>int</returns>
        private int GetClosestEdgeToBottomRightTile()
        {
            int[] choices = new int[] { TileConstants.BottomLeftTile, TileConstants.TopRightTile };

            int result = this.ChooseRandomValueFromIntArray(choices);

            return result;
        }

        /// <summary>
        /// Chooses a random value from an int array
        /// </summary>
        /// <param name="choices">int array choose value from</param>
        /// <returns>int</returns>
        private int ChooseRandomValueFromIntArray(int[] choices)
        {
            Random random = new Random();

            int randomChoiceIndex = random.Next(0, choices.Length - 1);

            int result = choices[randomChoiceIndex];

            return result;
        }
    }
}