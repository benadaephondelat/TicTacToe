namespace TicTacToe.ComputerTests.DataMockHelper
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Computer.Models;
    using Computer.Constants;
    using TicTacToeCommon.Constants;

    public class DataMockHelper
    {
        /// <summary>
        /// Creates a new computer vs human game
        /// </summary>
        /// <returns>ComputerGameModel</returns>
        public ComputerGameModel CreateNewComputerVsComputer()
        {
            ComputerGameModel model = new ComputerGameModel();

            model.HomesideUsername = UserConstants.ComputerUsername;
            model.AwaysideUsername = UserConstants.SecondComputerUsername;
            model.TurnsCount = 1;
            model.IsFinished = false;
            model.Tiles = GenerateDefaultTilesList();

            return model;
        }

        /// <summary>
        /// Creates a new computer vs human game
        /// </summary>
        /// <returns>ComputerGameModel</returns>
        public ComputerGameModel CreateNewComputerVsHumanGame()
        {
            ComputerGameModel model = new ComputerGameModel();

            model.HomesideUsername = UserConstants.ComputerUsername;
            model.AwaysideUsername = UserConstants.UserUsername;
            model.TurnsCount = 1;
            model.IsFinished = false;
            model.Tiles = GenerateDefaultTilesList();

            return model;
        }

        /// <summary>
        /// Creates a new human vs computer game
        /// </summary>
        /// <returns>ComputerGameModel</returns>
        public ComputerGameModel CreateNewHumanVsComputerGame()
        {
            ComputerGameModel model = new ComputerGameModel();

            model.HomesideUsername = UserConstants.UserUsername;
            model.AwaysideUsername = UserConstants.ComputerUsername;
            model.TurnsCount = 1;
            model.IsFinished = false;
            model.Tiles = GenerateDefaultTilesList();

            return model;
        }

        /// <summary>
        /// Creates a finished computer vs human game 
        /// </summary>
        /// <returns>ComputerGameModel</returns>
        public ComputerGameModel CreateNewComputerVsHumanFinishedGame()
        {
            ComputerGameModel model = new ComputerGameModel();

            model.HomesideUsername = UserConstants.ComputerUsername;
            model.AwaysideUsername = UserConstants.UserUsername;
            model.TurnsCount = 9;
            model.IsFinished = true;
            model.Tiles = new List<ComputerGameTileModel>();

            return model;
        }

        /// <summary>
        /// Creates a finished human vs computer game 
        /// </summary>
        /// <returns>ComputerGameModel</returns>
        public ComputerGameModel CreateNewHumanVsComputerFinishedGame()
        {
            ComputerGameModel model = new ComputerGameModel();

            model.HomesideUsername = UserConstants.UserUsername;
            model.AwaysideUsername = UserConstants.ComputerUsername;
            model.TurnsCount = 9;
            model.IsFinished = true;
            model.Tiles = new List<ComputerGameTileModel>();

            return model;
        }

        /// <summary>
        /// Creates computer vs human game starting from the 3rd turn
        /// </summary>
        /// <param name="humanPlayerTurnTileIndex">Human player's turn</param>
        /// <returns>ComputerGameModel</returns>
        public ComputerGameModel CreateComputerVsHumanSecondTurnGame(int humanPlayerTurnTileIndex)
        {
            ComputerGameModel model = new ComputerGameModel();

            model.HomesideUsername = UserConstants.ComputerUsername;
            model.AwaysideUsername = UserConstants.UserUsername;
            model.TurnsCount = 3;
            model.IsFinished = false;
            model.Tiles = GenerateDefaultTilesList();

            model.Tiles.ElementAt(ComputerConstants.CenterPosition).IsEmpty = false;
            model.Tiles.ElementAt(ComputerConstants.CenterPosition).Value = ComputerConstants.HomeSideSign;

            model.Tiles.ElementAt(humanPlayerTurnTileIndex).IsEmpty = false;
            model.Tiles.ElementAt(humanPlayerTurnTileIndex).Value = ComputerConstants.AwaySideSign;

            return model;
        }

        /// <summary>
        /// Creates a list of 9 empty fake tiles
        /// </summary>
        /// <returns>List Tile</returns>
        public List<IComputerGameTileModel> GenerateDefaultTilesList()
        {
            List<IComputerGameTileModel> defaultTilesList = new List<IComputerGameTileModel>();

            for (var i = 1; i < 10; i++)
            {
                ComputerGameTileModel tile = new ComputerGameTileModel() { IsEmpty = true, Value = string.Empty };

                defaultTilesList.Add(tile);
            }

            return defaultTilesList;
        }

        /// <summary>
        /// Sets Tile.IsEmpty and Tile.Value properties or throws exception
        /// </summary>
        /// <param name="tiles">IEnumerable<ComputerGameTileModel></ComputerGameTileModel></param>
        /// <param name="tileIndex">Index of the tile</param>
        /// <param name="tileValue">Tile value</param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void SetTileValue(IEnumerable<IComputerGameTileModel> tiles, int tileIndex, string tileValue)
        {
            if (tileIndex < 0 || tileIndex > 8)
            {
                throw new IndexOutOfRangeException();
            }

            tiles.ElementAt(tileIndex).IsEmpty = false;
            tiles.ElementAt(tileIndex).Value = tileValue;
        }
    }
}